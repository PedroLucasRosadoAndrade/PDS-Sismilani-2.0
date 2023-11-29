using Org.BouncyCastle.Utilities.Collections;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MySql.Data.MySqlClient;
using PDS_Sismilani.DataBase;
using System.Windows.Media.TextFormatting;
using PDS_Sismilani.Models;
using System;
using MySqlX.XDevAPI;
using System.Windows.Controls;
using System.Web.UI.WebControls;
using System.Security.Cryptography;

namespace PDS_Sismilani.Views
{
    public partial class CadastrarCliente : Window
    {
    //    private int id;
        private Cliente cli;

        //MySqlConnection conexao;
        //MySqlCommand comando;
        ObservableCollection<Cliente> cliente = new ObservableCollection<Cliente>(); // Coleção de clientes


        public CadastrarCliente()
        {
            InitializeComponent();
            //clientesDataGrid.ItemsSource = cliente;
            //LoadCliente();
            Loaded += CadastrarCliente_Loaded;
        }
        private void CadastrarCliente_Loaded(object sender, RoutedEventArgs e)
        {
            LoadDataGrid();
        }

        private void LoadDataGrid()
        {
            try
            {
                var dao = new ClienteDAO();

                clientesDataGrid.ItemsSource = dao.List();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exceção", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btDeletar_Click_1(object sender, RoutedEventArgs e)
        {
            var ClienteSelected = clientesDataGrid.SelectedItem as Cliente;

            var result = MessageBox.Show($"Deseja realmente remover o Cliente `{ClienteSelected.nome}`?", "Confirmação de Exclusão",
                MessageBoxButton.YesNo, MessageBoxImage.Warning);

            try
            {
                if (result == MessageBoxResult.Yes)
                {
                    var dao = new ClienteDAO();
                    dao.Delete(ClienteSelected);
                    LoadDataGrid();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exceção", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        //private void LoadCliente()
        //{
        //    try
        //    {
        //        string query = "SELECT * FROM cliente;";
        //        var comando = new MySqlCommand(query, conexao);
        //        MySqlDataReader reader = comando.ExecuteReader();

        //        cliente.Clear();
        //        while (reader.Read())
        //        {
        //            cliente.Add(new Cliente
        //            {
        //                id = reader.GetInt32("id_cli"),
        //                nome = reader.GetString("nome_cli"),
        //                rg = reader.GetString("rg_cli"),
        //                cpf = reader.GetString("cpf_cli"),
        //                email = reader.GetString("email_cli"),
        //                telefone = reader.GetString("telefone_cli"),
        //                dataNasc = reader.GetDateTime("data_nasc_cli"),
        //                sexo = reader.GetString("sexo_cli"),
        //                endereco = reader.GetString("endereco_cli")
        //            });
        //        }

        //        reader.Close();

        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }

        //}



        //---------------------------------- Botão Editar e Excluir ---------------------

        private void btEditar_Click_1(object sender, RoutedEventArgs e)
        {
            var editCliente = new EditCliente().ShowDialog();
        }
        private void ExcluirCliente(int id)
        {
            var deleteCli = new ClienteDAO();
            
        }

        //add novo cliente
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var addCli = new addCliente();
            addCli.ShowDialog();
        }
        private void btHome_Click(object sender, RoutedEventArgs e)
        {
            var home = new Home();
            home.ShowDialog();
        }

        private void Btfilmes_Click(object sender, RoutedEventArgs e)
        {
            var CadFilme = new CadastrarFilme();
            CadFilme.ShowDialog();
        }
        private void Btprodutora_Click(object sender, RoutedEventArgs e)
        {
            var CadProdutora = new Produtora();
            CadProdutora.ShowDialog();
        }
        private void Btfornecedores_Click(object sender, RoutedEventArgs e)
        {
            var CadFornecedores = new CadastrarFornecedor();
            CadFornecedores.ShowDialog();
        }
        private void Btfuncionarios_Click(object sender, RoutedEventArgs e)
        {
            var CadFuncionario = new CadastrarFuncionario().ShowDialog();
        }
        private void Btestoque_Click(object sender, RoutedEventArgs e)
        {
            var CadEstoque = new Estoque();
            CadEstoque.ShowDialog();
        }

        // ----------------------------------------------- Otimização de tela -----------------------------------------------

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }


        private bool IsMaximized = false;
        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e) // e esse trecho estão fazendo a responsividade da tela 
        {
            if (e.ClickCount == 2)
            {
                if (IsMaximized)
                {
                    this.WindowState = WindowState.Normal;
                    this.Width = 1080;
                    this.Height = 720;

                    IsMaximized = false;
                }
                else
                {

                    this.WindowState = WindowState.Maximized;

                    IsMaximized = false;
                }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


    }

}