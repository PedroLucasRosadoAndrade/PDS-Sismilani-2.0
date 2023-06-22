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
using System.Windows.Navigation;
using System.Windows.Shapes;
using PDS_Sismilani.Views;

namespace PDS_Sismilani
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btCadastrarCliente_Click(object sender, RoutedEventArgs e)
        {
            CadastrarCliente form = new CadastrarCliente();
            form.ShowDialog();
        }

        private void btCadastrarFilme_Click(object sender, RoutedEventArgs e)
        {
            CadastrarFilme form = new CadastrarFilme();
            form.ShowDialog();
        }

        private void btCadastrarFornecedor_Click(object sender, RoutedEventArgs e)
        {
            CadastrarFornecedor form = new CadastrarFornecedor();
            form.ShowDialog();
        }

        private void btCadastrarEstoque_Click(object sender, RoutedEventArgs e)
        {
            Estoque form = new Estoque();
            form.ShowDialog();
        }

        private void btCadastrarFuncionario_Click(object sender, RoutedEventArgs e)
        {
            Funcionario form = new Funcionario();
            form.ShowDialog();
        }

        private void btCadastrarProdutora_Click(object sender, RoutedEventArgs e)
        {
            Produtora form = new Produtora();
            form.ShowDialog();
        }
    }
}
