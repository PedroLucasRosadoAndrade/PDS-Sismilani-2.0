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

namespace PDS_Sismilani.Views
{
    /// <summary>
    /// Lógica interna para CadastrarFilme.xaml
    /// </summary>
    public partial class CadastrarFilme : Window
    {
        public CadastrarFilme()
        {
            InitializeComponent();
        }

        private void BtHome_Click(object sender, RoutedEventArgs e)
        {
            var home = new Home().ShowDialog();

        }

        //private void Btfilmes_Click(object sender, RoutedEventArgs e)
        //{

       // }

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

        }

        private void Btclientes(object sender, RoutedEventArgs e)
        {
            var cliente = new CadastrarCliente().ShowDialog();

        }
    }
}
