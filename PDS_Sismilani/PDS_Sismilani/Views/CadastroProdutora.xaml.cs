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
    public partial class CadastroProdutora : Window
    {

        //private Produtoracla _produtora;
        //ObservableCollection<Produtoracla> produtora = new ObservableCollection<Produtoracla>();

        //public CadastroProdutora()
        //{
        //    InitializeComponent();
        //    Loaded += CadastroProdutora_Loaded;
        //}

        //private void CadastroProdutora_Loaded(object sender, RoutedEventArgs e)
        //{
        //    LoadDataGrid();
        //}

        //private void btAdd(object sender, RoutedEventArgs e)
        //{
        //    var produ = new CadastProdutora().ShowDialog();
        //}

        //private void btDeletar(object sender, RoutedEventArgs e)
        //{
        // var produtoraSelected = DataGridProdutora.SelectedItem as Produtoracla;

        //    var result = MessageBox.Show($"Deseja realmente remover a Produtora `{produtoraSelected.nome}`?", "Confirmação de Exclusão",
        //        MessageBoxButton.YesNo, MessageBoxImage.Warning);

        //    try
        //    {
        //        if (result == MessageBoxResult.Yes)
        //        {
        //            var dao = new ProdutoraDAO();
        //            dao.Delete(produtoraSelected);
        //            LoadDataGrid();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "Exceção", MessageBoxButton.OK, MessageBoxImage.Error);
        //    }
        //}
        //private void LoadDataGrid()
        //{
        //    try
        //    {
        //        var dao = new ProdutoraDAO();

        //        DataGridProdutora.ItemsSource = dao.List();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "Exceção", MessageBoxButton.OK, MessageBoxImage.Error);
        //    }
        //}
        //private void btEditar(object sender, RoutedEventArgs e)
        //{
        //    var produtoraSelected = DataGridProdutora.SelectedItem as Produtoracla;

        //    var window = new CadastProdutora(produtoraSelected.id);
        //    window.ShowDialog();
        //    LoadDataGrid();

        //}

        //private void BtHome(object sender, RoutedEventArgs e)
        //{
        //    var home = new Home().ShowDialog();
        //    var cadastraProd = new CadastProdutora();
        //    cadastraProd.Close();
        //}

        //private void Btfilmes(object sender, RoutedEventArgs e)
        //{
        //    var filme = new CadastrarFilme().ShowDialog();
        //}

        //private void BtFechar(object sender, RoutedEventArgs e)
        //{
        //    this.Close();
        //}
    }
}
