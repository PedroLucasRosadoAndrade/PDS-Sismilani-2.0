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
            string query = "SELECT *FROM Cliente;";
            var comando = new MySqlCommand(query, conexao);
            MySqlDataReader reader = comando.ExecuteReader();


            cliente.Clear();
            while (reader.Read())
            {
                cliente.Add(new Cliente
                {
                    id = reader.GetString("id_cli"),
                    nome = reader.GetString("nome_cli"),
                    rg = reader.GetString("rg_cli"),
                    telefone = reader.GetString("telefone_cli"),
                    email = reader.GetString("email_cli"),
                    dataNasc = reader.GetDateTime("data_nasc_cli"),
                    cpf = reader.GetString("cpf_cli"),
                    sexo = reader.GetString("sexo_cli"),
                    endereco = reader.GetString("endereco_cli"),
                    id_log_fk = reader.GetString("id_log_fk"),
                    id_ing_fk = reader.GetString("id_ing_fk")
                });
            }

            reader.Close();

            clientesDataGrid.ItemsSource = cliente;
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
            var CadFuncionario = new Funcionario();
            CadFuncionario.ShowDialog();
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


    }

}