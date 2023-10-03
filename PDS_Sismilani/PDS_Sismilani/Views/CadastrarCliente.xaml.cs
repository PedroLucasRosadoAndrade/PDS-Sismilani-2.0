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

namespace PDS_Sismilani.Views
{
    public partial class CadastrarClientes : Window

    {
        MySqlConnection conexao;

        MySqlCommand comando;

        public CadastrarClientes()
        {
            //InitializeComponent();
            Conexao();
            //txtNome.Focus();        
        }
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

        private void Conexao()
        {
            string conexaoString = "server=localhost;database=cinemilani_bd;user=root;password=root;port=3306";
            conexao = new MySqlConnection(conexaoString);
            comando = conexao.CreateCommand();

            conexao.Open();
        }

        private void clientesDataGrid_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var Home = new Home().ShowDialog();
        }

        private void Btfilmes_Click(object sender, RoutedEventArgs e)
        {
            var Cadastrarfilme = new CadastrarFilme().ShowDialog();

        }

        private void Btfornecedores_Click(object sender, RoutedEventArgs e)
        {
            var CadastrarFornecedor = new CadastrarFornecedor().ShowDialog();
        }

        private void Btprodutora_Click(object sender, RoutedEventArgs e)
        {
            var CadastrarProdutora = new Produtora().ShowDialog();
        }

        private void Btfuncionarios_Click(object sender, RoutedEventArgs e)
        {
            var CadastrarFuncionario = new Funcionario().ShowDialog();
        }

        private void Btestoque_Click(object sender, RoutedEventArgs e)
        {
            var CadastrarEstoque = new Estoque().ShowDialog();
        }

        private void Btprodutos_Click(object sender, RoutedEventArgs e)
        {
            //var CadastrarProdutos = new Produto().
        }

    }
}