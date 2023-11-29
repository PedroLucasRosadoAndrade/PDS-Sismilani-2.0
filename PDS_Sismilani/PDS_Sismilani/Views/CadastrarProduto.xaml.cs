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
    /// Lógica interna para CadastrarProduto.xaml
    /// </summary>
    public partial class CadastrarProduto : Window
    {
        public CadastrarProduto()
        {
            InitializeComponent();
        }

        private void btAdd_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btfilmes_Click(object sender, RoutedEventArgs e)
        {
            var cadast = new CadastrarFilme();
            cadast.ShowDialog();
        }

        private void btHome_Click(object sender, RoutedEventArgs e)
        {
            var home = new Home();
            home.ShowDialog();
        }
    }
}
