using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
//using MySqlX.XDevAPI;
using PDS_Sismilani.Models;
using static System.Net.Mime.MediaTypeNames;
using Button = System.Windows.Controls.Button;
namespace PDS_Sismilani.Views
{
    /// <summary>
    /// Lógica interna para CadastroCliente.xaml
    /// </summary>
    public partial class CadastroCliente : Window
    {
        //private string _id;
        private Cliente _cliente;
        //MySqlConnection conexao;
        //MySqlCommand comando;
        ObservableCollection<Cliente> cliente = new ObservableCollection<Cliente>();

        public CadastroCliente()
        {
            InitializeComponent();
            //Conexao();
            //FuncionariosDataGrid.ItemsSource = funcionario;
            //LoadFuncionario();
            Loaded += CadastrarCliente_Loaded;
        }
        private void CadastrarCliente_Loaded(object sender, RoutedEventArgs e)
        {
            LoadedClienteDataGrid();
        }

        private void LoadedClienteDataGrid()
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
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var addCli = new addCliente().ShowDialog();
        }
        private void btDeletar_Click(object sender, RoutedEventArgs e)
        {
            var clienteSelected = clientesDataGrid.SelectedItem as Cliente;

            var result = MessageBox.Show($"Deseja realmente remover o Cliente `{clienteSelected.nome}`?", "Confirmação de Exclusão",
                MessageBoxButton.YesNo, MessageBoxImage.Warning);

            try
            {
                if (result == MessageBoxResult.Yes)
                {
                    var dao = new ClienteDAO();
                    dao.Delete(clienteSelected);
                    LoadedClienteDataGrid();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exceção", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        
        private void btEditar_Click(Object sender, RoutedEventArgs e)
        {
            var clienteSelected = clientesDataGrid.SelectedItem as Cliente;

            var window = new addCliente(clienteSelected.id);
            window.ShowDialog();
            LoadedClienteDataGrid();
        }
        private void Btestoque(object sender, RoutedEventArgs e)
        {
            var estoque = new Estoque().ShowDialog();
        }

        private void Btfornecedores(object sender, RoutedEventArgs e)
        {
            var fornecedor = new CadastrarFornecedor().ShowDialog();
        }

        private void Btprodutora(object sender, RoutedEventArgs e)
        {
            var produtora = new Produtora().ShowDialog();
        }

        private void Btfilmes(object sender, RoutedEventArgs e)
        {
            var Filmes = new CadastrarFilme().ShowDialog();
        }

        private void btHome(object sender, RoutedEventArgs e)
        {
            var home = new Home().ShowDialog();
            var cadastrarFun = new CadastrarFuncionario();
            cadastrarFun.Close();
        }

        private void Btclientes(object sender, RoutedEventArgs e)
        {
            var cliente = new CadastrarCliente().ShowDialog();
        }

        private void BtFechar(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Btprodutos_Click(object sender, RoutedEventArgs e)
        {
            var produto = new CadastrarProduto().ShowDialog();
        }

        private void clientesDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

    }
}
