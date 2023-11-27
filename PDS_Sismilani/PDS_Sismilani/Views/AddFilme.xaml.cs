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
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PDS_Sismilani.Views
{
    /// <summary>
    /// Lógica interna para AddFilme.xaml
    /// </summary>
    public partial class AddFilme : Window
    {
        MySqlConnection conexao;
        MySqlCommand comando;
        ObservableCollection<Filme> filmes = new ObservableCollection<Filme>();

        public AddFilme()
        {
            InitializeComponent();
        }


        private void Conexao()
        {
            string conexaoString = "server=localhost;database=cinemilani_bd;user=root;password=root;port=3306";
            conexao = new MySqlConnection(conexaoString);
            comando = conexao.CreateCommand();

            conexao.Open();
        }

        private void BtVoltar(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtSalvar(object sender, RoutedEventArgs e)
        {
            try
            {
                var titulo = txtTitulo.Text;
                var sinopse = txtSinopse.Text;
                var fornecedor = txtFornecedor.Text;
                var categoria = txtCategoria.Text;
                var elenco = txtElenco.Text;
                var diretor = txtDiretor.Text;
                var dataLancamento = datePickerData.SelectedDate;


                using (MySqlConnection conexao = new MySqlConnection("server=localhost;database=cinemilani_bd;user=root;password=root;port=3306"))
                {
                    conexao.Open();

                    string query = "INSERT INTO Filme (titulo_film,fornecedor_film ,categoria_film,dataLancamento_film, sinopse_film,elenco_film,diretor_film ) " +
                                   "VALUES (@_titulo_film,@_fornecedor_film ,@_categoria_film,@_dataLancamento_film, @_sinopse_film,@_elenco_film, @_diretor_film)";
                    using (MySqlCommand comando = new MySqlCommand(query, conexao))
                    {
                        comando.Parameters.AddWithValue("@_titulo", titulo);
                        comando.Parameters.AddWithValue("@_fornecedor", fornecedor);
                        comando.Parameters.AddWithValue("@_categoria", categoria);
                        comando.Parameters.AddWithValue("@_dataLancamento", dataLancamento);
                        comando.Parameters.AddWithValue("@_sinopse", sinopse);
                        comando.Parameters.AddWithValue("@_elenco", elenco);
                        comando.Parameters.AddWithValue("@_diretor", diretor);

                        comando.ExecuteNonQuery();
                    }
                }

                comando.ExecuteNonQuery();
                txtTitulo.Clear();
                datePickerData.IsEnabled = false;
                txtFornecedor.Clear();
                txtCategoria.Clear();
                txtSinopse.Clear();
                txtElenco.Clear();
                txtDiretor.Clear();



                var opcao = MessageBox.Show("Filme salvo com sucesso!\n" +
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

            }

            txtTitulo.Clear();
            datePickerData.IsEnabled = false;
            txtFornecedor.Clear();
            txtCategoria.Clear();
            txtSinopse.Clear();
            txtElenco.Clear();
            txtDiretor.Clear();
            txtTitulo.Focus();


        }
    }
}
