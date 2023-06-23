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
using MySql.Data.MySqlClient;

namespace PDS_Sismilani.Views
{
    /// <summary>
    /// Lógica interna para Estoque.xaml
    /// </summary>
    public partial class Estoque : Window
    {

        private MySqlConnection conexao;

        private MySqlCommand comando;
        public Estoque()
        {
            InitializeComponent();
            Conexao();
            txtUnidade.Focus();
        }
        private void Conexao()
        {
            string conexaoString = "server=localhost;database=bd_Sismilani;user=root;password=root;port=3306";
            conexao = new MySqlConnection(conexaoString);
            comando = conexao.CreateCommand();

            conexao.Open();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var dataNasc = datePickerData.SelectedDate;

                var unidade = txtUnidade.Text;
                var categoria = txtCategoria.Text;
                var valor = txtValor;

                string query = "insert into estoque (unidade_est, categoria_est, data_est, valor_est) VALUES (@_unidade, @_categoria, @_data, @_valor)";
                var comando = new MySqlCommand(query, conexao);

                comando.Parameters.AddWithValue("@_unidade", unidade);
                comando.Parameters.AddWithValue("@_categoria", categoria);
                comando.Parameters.AddWithValue("@_data", dataNasc);
                comando.Parameters.AddWithValue("@_valor", valor);


                comando.ExecuteNonQuery();
                txtCategoria.Clear();
                datePickerData.IsEnabled = false;
                txtUnidade.Clear();
                txtValor.Clear();

                var opcao = MessageBox.Show("Salvo com sucesso!\n" +
                    "Deseja realizar um novo cadastro?", "Informação",
                    MessageBoxButton.YesNo, MessageBoxImage.Question);


                if (opcao == MessageBoxResult.Yes)
                {
                    LimparInputs();
                    MainWindow form = new MainWindow();
                    form.ShowDialog();
                }
                else
                {
                    this.Close();
                }



            }
            catch (Exception ex)
            {
               /* MessageBox.Show($"Ocorreram erros ao tentar salvar os dados! " +
                 $"Contate o suporte do sistema. (CAD 25)");*/

                MessageBox.Show(ex.Message);
            }

        }
        private void LimparInputs()
        {


        }

        /*private void btLimpar_Click(object sender, RoutedEventArgs e)
        {
            txtValor.Clear();
            txtCategoria.Clear();
            txtUnidade.Clear();
        }*/
    
    }
}
