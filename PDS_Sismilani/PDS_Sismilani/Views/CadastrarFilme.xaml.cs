using MySql.Data.MySqlClient;
using PDS_Sismilani.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MySqlX.XDevAPI;
using static System.Net.Mime.MediaTypeNames;
using Button = System.Windows.Controls.Button;

namespace PDS_Sismilani.Views
{
    /// <summary>
    /// Lógica interna para CadastrarFilme.xaml
    /// </summary>
    public partial class CadastrarFilme : Window
    {

        //MySqlConnection conexao;
        //MySqlCommand comando;
  
        public CadastrarFilme()
        {
            InitializeComponent();

            Loaded += CadastrarFilme_Loaded;
        }


        private void BtHome_Click(object sender, RoutedEventArgs e)
        {
            var home = new Home().ShowDialog();

        }

        //private void Btfilmes_Click(object sender, RoutedEventArgs e)
        //{

        // }

        private void CadastrarFilme_Loaded(object sender, RoutedEventArgs e)
        {
            LoadDataGrid();
        }

       
        private void Btprodutora_Click(object sender, RoutedEventArgs e)
        {
            var produtora = new Produtora().ShowDialog();

        }

        private void Btfornecedores_Click(object sender, RoutedEventArgs e)
        {
            var fornecedor = new CadastrarFornecedor().ShowDialog();

        }

        private void Btfuncionarios_Click(object sender, RoutedEventArgs e)
        {
            var funcionario = new CadastrarFuncionario().ShowDialog();

        }

        private void Btestoque_Click(object sender, RoutedEventArgs e)
        {
            var estoque = new Estoque().ShowDialog();

        }

        private void Btprodutos_Click(object sender, RoutedEventArgs e)
        {
           var produto = new CadastrarProduto().ShowDialog();
        }

        private void Btclientes(object sender, RoutedEventArgs e)
        {
            var cliente = new CadastrarCliente().ShowDialog();

        }
        private void BtAdd_Click(object sender, RoutedEventArgs e)
        {
            var filme = new CadastrarFilme().ShowDialog();
        }

        private void BtSair(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        private void btDeletar_Click_1(object sender, RoutedEventArgs e)
        {

            var filmeSelected = filmsDataGrid.SelectedItem as Filme;

            var result = MessageBox.Show($"Deseja excluir o filme `{filmeSelected.Titulo}`?", "Excluido com sucesso",
               MessageBoxButton.YesNo, MessageBoxImage.Warning);

            try
            {
                if (result == MessageBoxResult.Yes)
                {
                    var dao = new FilmeDAO();
                    dao.Delete(filmeSelected);
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

                //FilmesDataGrid.ItemsSource = dao.List();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exceção", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

    }

       
}

