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
        private void btLogin_Click(object sender, RoutedEventArgs e)
        {
            var Home = new Home().ShowDialog();
            string usuario = "roberval";//txtUsuario.Text;
            string senha = "123456";//passBoxSenha.ToString();

            if (Usuario.Login(usuario, senha))
            {
                var main = new MainWindow();
                main.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Usuario e/ou senha incorretos! Tente novamente", "Autorização negada", MessageBoxButton.OK, MessageBoxImage.Warning);
                _ = txtUsuario.Focus();
            }
        }

        private void BtFechar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
