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

              }

        private void Home_Loaded(object sender, RoutedEventArgs e)
        {
            txtDataAtual.Text = DateTime.UtcNow.ToString("dd/mm/yyyy");

            List<Venda> listaVedas = new List<Venda>();

            for (int i = 0; i < 30; i++)
            {
                listaVedas.Add(new Venda()
                {
                    Id = i + 1,
                    Cliente = "Pedro -" + i,
                    QuantidadesDeprodutos = 5 * i,
                    valorTotal = 120.55 + i,
                    situaca = "aberta"
                });
            }

            dataGridVendas.ItemsSource = listaVedas;
        }

        private void btCliente_Click(object sender, RoutedEventArgs e)
        {
           // Cliente form = new Cliente();
            //form.
        }
    }
}
