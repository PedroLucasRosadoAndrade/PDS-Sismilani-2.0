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
    /// Lógica interna para ListarProduto.xaml
    /// </summary>
    public partial class ListarProduto : Window
    {
        private MySqlConnection conexao;

        private MySqlCommand comando;
        public ListarProduto()
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
            MySqlCommand cmd = new MySqlCommand("Select * from Produto", conexao);
            var reader = cmd.ExecuteReader();

            List<Object> lista = new List<Object>();

            while (reader.Read())
            {
                var produto = new
                {
                    Nome = reader.GetString(1),
                    Marca = reader.GetString(2),
                    Tipo = reader.GetString(3),
                    Quantidade = reader.GetString(4),
                    Validade = reader.GetString(5),
                    Valor = reader.GetString(6),
                   
                };

                lista.Add(produto);
            }

            dgvContato.ItemsSource = lista;
        }


        private void btNovo_Click(object sender, RoutedEventArgs e)
        {
            carregarDados();
        }
    }
}
