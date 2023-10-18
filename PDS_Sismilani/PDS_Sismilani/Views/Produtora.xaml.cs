using MySql.Data.MySqlClient;
using PDS_Sismilani.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Lógica interna para Produtora.xaml
    /// </summary>
    public partial class Produtora : Window
    {
        MySqlConnection conexao;
        MySqlCommand comando;
        ObservableCollection<Cliente> cliente = new ObservableCollection<Cliente>(); // Coleção de clientes
        public Produtora()
        {
            InitializeComponent();
        }
        private void Conexao() // criando conexão
        {
            string conexaoString = "server=localhost;database=cinemilani_bd;user=root;password=root;port=3360";
            conexao = new MySqlConnection(conexaoString);
            comando = conexao.CreateCommand();

            conexao.Open();
        }

        private void btVoltar(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btSalvar(object sender, RoutedEventArgs e)
        {
            try
            {

                var atores = txtAtores.Text;
                var sinopse = txtSinopse.Text;
                var elenco = txtElenco.Text;
                var fornecedor = txtFornecedor.Text;
                var titulo = txtTitulo.Text;
                var data_filme = dtpDatafilm.SelectedDate;
                var data_lancamento = dtpDatalancamento.SelectedDate;
                var categoria = txtCategoria.Text;
                var diretor = txtDiretor.Text;


                using (MySqlConnection conexao = new MySqlConnection("server=localhost;database=cinemilani_bd;user=root;password=root;port=3360"))
                {
                    conexao.Open();

                    string query = "INSERT INTO Funcionario (atores_film, sinopse_film, elenco_film, fornecedor_film, data_film, dataLancamento_film, titulo_film, categoria_film, diretor_film) " +
                                   "VALUES (@_atores, @_sinopse, @_elenco, @_fornecedor, @_data, @_dataLancamento, @_titulo, @_categoria, @_diretor)";
                    using (MySqlCommand comando = new MySqlCommand(query, conexao))
                    {
                        comando.Parameters.AddWithValue("@_atores", atores);
                        comando.Parameters.AddWithValue("@_sinopse", sinopse);
                        comando.Parameters.AddWithValue("@_elenco", elenco);
                        comando.Parameters.AddWithValue("@_fornecedor", fornecedor);
                        comando.Parameters.AddWithValue("@_data", data_filme);
                        comando.Parameters.AddWithValue("@_dataLancamento", data_lancamento);
                        comando.Parameters.AddWithValue("@_titulo", titulo);
                        comando.Parameters.AddWithValue("@_categoria", categoria);
                        comando.Parameters.AddWithValue("@_diretor", diretor);

                        comando.ExecuteNonQuery();
                    }
                }
                comando.ExecuteNonQuery();
                txtAtores.Clear();
                dtpDatafilm.IsEnabled = false;
                dtpDatalancamento.IsEnabled = false;
                txtSinopse.Clear();
                txtElenco.Clear();
                txtFornecedor.Clear();
                txtTitulo.Clear();
                txtCategoria.Clear();
                txtDiretor.Clear();
                txtAtores.Focus();

                var opcao = MessageBox.Show("Produtora salva com sucesso!\n" +
                    "Deseja realizar um novo cadastro?", "Informação",
                    MessageBoxButton.YesNo, MessageBoxImage.Question);


                if (opcao == MessageBoxResult.Yes)
                {

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
                MessageBox.Show($"Ocorreram erros ao tentar salvar os dados!\n" +
                    $"Contate o suporte do sistema. (CAD 25)\n\n{ex.Message}");

                txtAtores.Clear();
                dtpDatafilm.IsEnabled = false;
                dtpDatalancamento.IsEnabled = false;
                txtSinopse.Clear();
                txtElenco.Clear();
                txtFornecedor.Clear();
                txtTitulo.Clear();
                txtCategoria.Clear();
                txtDiretor.Clear();
                txtAtores.Focus();
            }
        }
    
    }
}
