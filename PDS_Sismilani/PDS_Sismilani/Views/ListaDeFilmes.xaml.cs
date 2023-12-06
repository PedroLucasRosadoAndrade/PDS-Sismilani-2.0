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
    /// Interação lógica para ListaDeFilmes.xam
    /// </summary>
    public partial class ListaDeFilmes : Window
    {
        private Filme _filme;
        //MySqlConnection conexao;
        //MySqlCommand comando;
        ObservableCollection<Filme> Filme = new ObservableCollection<Filme>();
        public ListaDeFilmes()
        {
            InitializeComponent();
            Loaded += ListarFilmes_Loaded;
        }

        private void ListarFilmes_Loaded(object sender, RoutedEventArgs e)
        {
            LoadDataGrid();
        }

        private void btDeletar(object sender, RoutedEventArgs e)
        {


            var FilmeSelected = FilmesDataGrid.SelectedItem as Filme;

            var result = MessageBox.Show($"Deseja realmente remover o Filme `{FilmeSelected.Titulo}`?", "Confirmação de Exclusão",
                MessageBoxButton.YesNo, MessageBoxImage.Warning);

            try
            {
                if (result == MessageBoxResult.Yes)
                {
                    var dao = new FilmeDAO();
                    dao.Delete(FilmeSelected);
                    LoadDataGrid();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exceção", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void LoadDataGrid()
        {
            try
            {
                var dao = new FilmeDAO();

                FilmesDataGrid.ItemsSource = dao.List();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exceção", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void btEditar(object sender, RoutedEventArgs e)
        {
            //var Funcionarios = new EditFuncionario().ShowDialog();
            var FilmeSelected = FilmesDataGrid.SelectedItem as Filme;

            var window = new AddFilme(FilmeSelected.Id);
            window.ShowDialog();
            LoadDataGrid();

        }

       

        private void BotaoHome_Click(object sender, RoutedEventArgs e)
        {
            var home = new Home().ShowDialog();
            var cadastrarFun = new CadastrarFuncionario();
            cadastrarFun.Close();
        }

        private void BotaoFilmes_Click(object sender, RoutedEventArgs e)
        {
            

        }

        private void BotaonProdutora_Click(object sender, RoutedEventArgs e)
        {
            var produtora = new CadastProdutora().ShowDialog();

        }

        private void Btnfornecedores_Click(object sender, RoutedEventArgs e)
        {
            var fornecedor = new CadastrarFornecedor().ShowDialog();

        }

        private void Btonclientes_Click(object sender, RoutedEventArgs e)
        {
            var cliente = new CadastrarCliente().ShowDialog();

        }

        private void Btnestoque_Click(object sender, RoutedEventArgs e)
        {
            var estoque = new Estoque().ShowDialog();

        }

        private void Btnprodutos_Click(object sender, RoutedEventArgs e)
        {
            var produto = new CadastrarProduto().ShowDialog();

        }

        private void BotaoFechar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BotaoAdd_Click(object sender, RoutedEventArgs e)
        {
            var filme = new AddFilme().ShowDialog();
        }
    }
}
