using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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
using PDS_Sismilani.Views;
using PDS_Sismilani.DataBase;
using PDS_Sismilani.Models;
using MaterialDesignThemes.Wpf;

namespace PDS_Sismilani.Views
{
    /// <summary>
    /// Lógica interna para Home.xaml
    /// </summary>
    public partial class Home : Window
    {
        public Home()
        {
            InitializeComponent();
            Loaded += Home_Loaded;
            LoadBorder();

        }

        private void Home_Loaded(object sender, RoutedEventArgs e)
        {

            txtDataAtual.Text = "-";
            txtDataAtual.Text = DateTime.UtcNow.ToString("MM/dd/yyyy");

            //List<Venda> listaVedas = new List<Venda>();

            //for (int i = 0; i < 30; i++)
            //{
            //    listaVedas.Add(new Venda()
            //    {
            //        Id = i + 1,
            //        Cliente = "Pedro -" + i,
            //        QuantidadesDeprodutos = 5 * i,
            //        valorTotal = 120.55 + i,
            //        situaca = "aberta"
            //    });
            //}

            //dataGridVendas.ItemsSource = listaVedas;
            LoadDataGrid();
            LoadBorder();
        }

        private void LoadDataGrid()
        {
            try
            {
                var dao = new VendaDAO();

                dataGridVendas.ItemsSource = dao.List();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exceção", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnCliente_Click(object sender, RoutedEventArgs e)
        {

            var CadastrarClientes = new CadastrarCliente();
               CadastrarClientes.ShowDialog();
        }

        private void BtFuncionario_Click(object sender, RoutedEventArgs e)
        {
            _ = new CadastrarFuncionario().ShowDialog();
        }
        private void Btnfilmes_Click(object sender, RoutedEventArgs e)
        {
            var cadFilme = new CadastrarFilme();
            cadFilme.ShowDialog();
        }
        private void BtFechar(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Btprodutora(object sender, RoutedEventArgs e)
        {
            var produtora = new CadastroProdutora().ShowDialog();
        }

        private void LoadBorder()
        {
            try
            {
                var dao = new FuncionarioDAO();

                int totalFuncionarios = dao.TotalFuncionarios();
                txtTotalFuncionarios.Text = totalFuncionarios.ToString();

            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message, "Exceção", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            var vendaSelected = dataGridVendas.SelectedItem as Venda;

            var window = new addFuncionario(vendaSelected.Id);
            window.ShowDialog();
            LoadDataGrid();
        }

        private void btnDeletar_Click(object sender, RoutedEventArgs e)
        {
            var vendaSelected = dataGridVendas.SelectedItem as Venda;

            var result = MessageBox.Show($"Deseja realmente remover o funcionário `{vendaSelected.Id}`?", "Confirmação de Exclusão",
                MessageBoxButton.YesNo, MessageBoxImage.Warning);

            try
            {
                if (result == MessageBoxResult.Yes)
                {
                    var dao = new VendaDAO();
                    dao.Delete(vendaSelected);
                    LoadDataGrid();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exceção", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Btnprodutos(object sender, RoutedEventArgs e)
        {
            var produtos = new CadastrarProduto().ShowDialog();
        }
    }
}
