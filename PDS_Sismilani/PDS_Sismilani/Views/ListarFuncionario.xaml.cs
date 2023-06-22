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
    /// Lógica interna para ListarFuncionario.xaml
    /// </summary>
    public partial class ListarFuncionario : Window
    {
        private MySqlConnection conexao;

        private MySqlCommand comando;
        public ListarFuncionario()
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
            MySqlCommand cmd = new MySqlCommand("Select * from Funcionario", conexao);
            var reader = cmd.ExecuteReader();

            List<Object> lista = new List<Object>();

            while (reader.Read())
            {
                var contato = new
                {
                    Nome = reader.GetString(1),
                    DataNascimento = reader.GetString(2),
                    Sexo = reader.GetString(3),
                    CPF = reader.GetString(4),
                    Salario = reader.GetString(5),
                    Funcao = reader.GetString(6),
                    Email = reader.GetString(7),
                    Celular = reader.GetString(8),
                    RG = reader.GetString(9),

                   
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
