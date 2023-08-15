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
using PDS_Sismilani.Models;
using PDS_Sismilani.DataBase;

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
            Loaded += MainWindow_Loadeb;
        }

        private void MainWindow_Loadeb(object sender, RoutedEventArgs e)
        {
            try
            {
                var conexao = new Conexao();

            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }



            //txtDataAtual.text = "-";
            //DateTime.Now.ToString("dd/MM/yyyy");

            List<Venda> listavendas = new List<Venda>();

            for (int i = 0; i < 30; i++)
            {
                listavendas.Add(new Venda()
                {
                    /*id = i + 1,
                    Cliente = "Pedro - " + i,
                    QuantidadeProdutos = 5 * i,
                    ValorTotal = 120.55 * i,
                    Situacao = "Aberto"*/
                });
            }
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
            new CadastrarEstoque().ShowDialog();
        }

        private void btCadastrarFuncionario_Click(object sender, RoutedEventArgs e)
        {
            new CadastrarFuncionario().ShowDialog();
        }

        private void btCadastrarProdutora_Click(object sender, RoutedEventArgs e)
        {
            new CadastrarProdutora().ShowDialog();
        }

        private void btListarCadastro_Click(object sender, RoutedEventArgs e)
        {
             new TelaInicial().ShowDialog();
        }
    }
}
