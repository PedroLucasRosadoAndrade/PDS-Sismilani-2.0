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

namespace PDS_Sismilani.Views
{
    public partial class CadastrarCliente : Window

    {
        MySqlConnection conexao;
        MySqlCommand comando;
        ObservableCollection<Cliente> cliente = new ObservableCollection<Cliente>(); // Coleção de clientes


        public CadastrarCliente()
        {
            InitializeComponent();
            Conexao();
            clientesDataGrid.ItemsSource = cliente;
            LoadCliente();
        }
        private void Conexao()
        {
            string conexaoString = "server=localhost;database=cinemilani_bd;user=root;password=root;port=3306";
            conexao = new MySqlConnection(conexaoString);
            comando = conexao.CreateCommand();

            conexao.Open();
        }
        private void LoadCliente()
        {
            try
            {
                string query = "SELECT * FROM cliente;";
                var comando = new MySqlCommand(query, conexao);
                MySqlDataReader reader = comando.ExecuteReader();

                cliente.Clear();
                while (reader.Read())
                {
                    cliente.Add(new Cliente
                    {
                        id = reader.GetInt32("id_cli"),
                        nome = reader.GetString("nome_cli"),
                        rg = reader.GetString("rg_cli"),
                        cpf = reader.GetString("cpf_cli"),
                        email = reader.GetString("email_cli"),
                        telefone = reader.GetString("telefone_cli"),
                        dataNasc = reader.GetDateTime("data_nasc_cli"),
                        sexo = reader.GetString("sexo_cli"),
                        endereco = reader.GetString("endereco_cli")
                    });
                }

                reader.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        //---------------------------------- Botão Editar e Excluir ---------------------

        private void btEditar_Click_1(object sender, RoutedEventArgs e)
        {
            var editCliente = new EditCliente().ShowDialog();
        }
        private void ExcluirCliente(int id)
        {
            var deleteCli = new ClienteDAO();
            
        }
        private void btDeletar_Click_1(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            var dataGridRow = (DataGridRow)clientesDataGrid.ItemContainerGenerator.ContainerFromItem(button.DataContext);
            var clientes = (Cliente)dataGridRow.Item;

            if (ExcluirCliente(clientes.id))
            {
                cliente.Remove(clientes);
                clientesDataGrid.Items.Refresh();
            }
            else
            {
                MessageBox.Show("Falha ao excluir o cliente.");
            }
        }

        //add novo
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