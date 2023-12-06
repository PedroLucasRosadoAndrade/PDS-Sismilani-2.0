using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using PDS_Sismilani.Models;
using static System.Net.Mime.MediaTypeNames;
using Button = System.Windows.Controls.Button;


namespace PDS_Sismilani.Views
{
    /// <summary>
    /// Lógica interna para CadastrarForncedorList.xaml
    /// </summary>
    public partial class CadastrarForncedorList : Window
    {
        private Fornecedor _fornecedor;
        ObservableCollection<Fornecedor> fornecedor = new ObservableCollection<Fornecedor>();

        public CadastrarForncedorList()
        {
            InitializeComponent();
            Loaded += CadastrarForncedorList_Loaded;
        }
        private void CadastrarForncedorList_Loaded(object sender, RoutedEventArgs e)
        {
            LoadDataGrid();
        }

        private void btAdd(object sender, RoutedEventArgs e)
        {
            var fornecedor = new CadastrarFornecedor().ShowDialog();
        }

        private void btDeletar(object sender, RoutedEventArgs e)
        {
            var fornecedorSelected = ForneDataGrid.SelectedItem as Fornecedor;

            var result = MessageBox.Show($"Deseja realmente remover o fornecedor `{fornecedorSelected.Nome}`?", "Confirmação de Exclusão",
                MessageBoxButton.YesNo, MessageBoxImage.Warning);

            try
            {
                if (result == MessageBoxResult.Yes)
                {
                    var dao = new FornecedorDAO();
                    dao.Delete(fornecedorSelected);
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
                var dao = new FornecedorDAO();

                ForneDataGrid.ItemsSource = dao.List();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exceção", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btEditar(object sender, RoutedEventArgs e)
        {
            var fornecedorSelected = ForneDataGrid.SelectedItem as Fornecedor;

            var window = new CadastrarFornecedor(fornecedorSelected.Id);
            window.ShowDialog();
            LoadDataGrid();
        }

        private void btHome(object sender, RoutedEventArgs e)
        {
            var home = new Home().ShowDialog();
            var cadastrarForn = new CadastrarForncedorList();
            cadastrarForn.Close();
        }

        private void Btfilmes(object sender, RoutedEventArgs e)
        {
            var Filmes = new CadastrarFilme().ShowDialog();
        }

        private void Btprodutora(object sender, RoutedEventArgs e)
        {
            var produtora = new CadastProdutora().ShowDialog();
        }

        private void BtFuncionario_Click(object sender, RoutedEventArgs e)
        {
            var fun = new CadastrarFuncionario().ShowDialog();
        }

        private void Btclientes(object sender, RoutedEventArgs e)
        {
            var cliente = new CadastrarCliente().ShowDialog();
        }

        private void Btestoque(object sender, RoutedEventArgs e)
        {
            var estoque = new Estoque().ShowDialog();
        }

        private void Btprodutos_Click(object sender, RoutedEventArgs e)
        {
            var produto = new CadastrarProduto().ShowDialog();
        }

        private void BtFechar(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
