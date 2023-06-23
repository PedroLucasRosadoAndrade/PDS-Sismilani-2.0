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
using MySql.Data.MySqlClient;

namespace PDS_Sismilani.Views
{
    /// <summary>
    /// Lógica interna para ListarEstoque.xaml
    /// </summary>
    public partial class ListarEstoque : Window
    {
        private MySqlConnection conexao;
        private MySqlCommand comando;

        public ListarEstoque()
        {
            InitializeComponent();
            Conexao();
            carregarDados();
        }

        private void Conexao()
        {
            string conexaoString = "server=localhost;database=bd_Sismilani;user=root;password=root;port=3306";
            conexao = new MySqlConnection(conexaoString);
            comando = conexao.CreateCommand();
            conexao.Open();
        }

        private void carregarDados()
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("Select * from Estoque", conexao);
                MySqlDataReader reader = cmd.ExecuteReader();

                List<Object> lista = new List<Object>();

                while (reader.Read())
                {
                    var estoque = new
                    {
                        Unidade = reader.GetString(1),
                        Categoria = reader.GetString(2),
                        Data = reader.GetString(3),
                        Valor = reader.GetString(4),
                    };

                    lista.Add(estoque);
                }

                dgvEstoque.ItemsSource = lista;

                // Fecha o reader e a conexão.
                reader.Close();
                conexao.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btNovo_Click(object sender, RoutedEventArgs e)
        {
            Conexao();
            carregarDados();
        }
    }
}