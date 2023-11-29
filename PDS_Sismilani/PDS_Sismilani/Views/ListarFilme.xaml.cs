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
    /// Lógica interna para ListarFilme.xaml
    /// </summary>
    public partial class ListarFilme : Window
    {
        private MySqlConnection conexao;

        private MySqlCommand comando;
        public ListarFilme()
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
            MySqlCommand cmd = new MySqlCommand("Select * from Filme", conexao);
            var reader = cmd.ExecuteReader();

            List<Object> lista = new List<Object>();



            while (reader.Read())
            {
                var contato = new
                {
                    Titulo = reader.GetString(1),
                    Sinopse = reader.GetString(2),
                    Fornecedor = reader.GetString(3),
                    Categoria = reader.GetString(4),
                    Elenco = reader.GetString(5),
                    Diretor = reader.GetString(6),
                    DataLancamento = reader.GetString(7)

                };
                lista.Add(contato);
            }
              dgvContato.ItemsSource = lista;
        }

        private void btNovo_Click(object sender, RoutedEventArgs e)
        {
            carregarDados();

        }
    }
}
