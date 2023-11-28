using MySql.Data.MySqlClient;
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
    /// Lógica interna para CadastrarRecebimento.xaml
    /// </summary>
    public partial class CadastrarRecebimento : Window
    {
        // Substitua com suas credenciais e informações de conexão
        string conexaoString = "server=localhost;database=cinemilani_bd;user=root;password=root;port=3306";
        public CadastrarRecebimento()
        {
            InitializeComponent();
        }

        private void btSalvar(object sender, RoutedEventArgs e)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(conexaoString))
                {
                    connection.Open();

                    // Execute suas operações de banco de dados aqui

                    MessageBox.Show("Recebimento salvo com sucesso!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro: {ex.Message}");
            }
        }
    }
}
