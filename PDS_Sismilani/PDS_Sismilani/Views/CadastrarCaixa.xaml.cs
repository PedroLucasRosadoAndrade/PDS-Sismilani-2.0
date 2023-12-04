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
using PDS_Sismilani.Models;
using System.Collections.ObjectModel;
using System.Data.SqlClient;


namespace PDS_Sismilani.Views
{
    /// <summary>
    /// Lógica interna para CadastrarCaixa.xaml
    /// </summary>
    public partial class CadastrarCaixa : Window
    {
        MySqlConnection conexao;
        MySqlCommand comando;
        ObservableCollection<CadastrarCaixa> caixas = new ObservableCollection<CadastrarCaixa>(); // Coleção de clientes
        public CadastrarCaixa()
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

        private void BotaoSalvarCaixa_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                var dataInicial = dtDataInicial.SelectedDate;
                var horaAbertura = txtHoraAbertura.Text;
                var HoraFechamento = txtHoraFechamento.Text;
                var SaldoFinal = txtSaldoFinal.Text;
                var SaldoInicial = txtSaldoInicial.Text;

                using (MySqlConnection conexao = new MySqlConnection("server=localhost;database=cinemilani_bd;user=root;password=root;port=3360"))
                {
                    conexao.Open();

                    string query = "INSERT INTO caixa (dataInicial_cai, horaAbertura_cai, horaFechamento_cai, saldoFinal_cai, saldoInicial_cai) " +
                                   "VALUES (@_dataInicial, @_horaAbertura, @_horaFechamento, @_saldoFinal, @_saldoInicial)";
                    using (MySqlCommand comando = new MySqlCommand(query, conexao))
                    {
                        comando.Parameters.AddWithValue("@_dataInicial", dataInicial);
                        comando.Parameters.AddWithValue("@_horaAbertura", horaAbertura);
                        comando.Parameters.AddWithValue("@_horaFechamento", HoraFechamento);
                        comando.Parameters.AddWithValue("@_saldoFinal", SaldoFinal);
                        comando.Parameters.AddWithValue("@_saldoInicial", SaldoInicial);


                        comando.ExecuteNonQuery();
                    }
                }

                dtDataInicial.SelectedDate = null;
                txtHoraAbertura.Clear();
                txtHoraFechamento.Clear();
                txtSaldoFinal.Clear();
                txtSaldoInicial.Clear();

                dtDataInicial.Focus();

                var opcao = MessageBox.Show("Caixa cadastrado com sucesso!\n" +
                    "Deseja realizar um novo cadastro?", "Informação",
                    MessageBoxButton.YesNo, MessageBoxImage.Question);


                if (opcao == MessageBoxResult.Yes)
                {

                    dtDataInicial.SelectedDate = null;
                    txtHoraAbertura.Clear();
                    txtHoraFechamento.Clear();
                    txtSaldoFinal.Clear();
                    txtSaldoInicial.Clear();

                    dtDataInicial.Focus();
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

                dtDataInicial.SelectedDate = null;
                txtHoraAbertura.Clear();
                txtHoraFechamento.Clear();
                txtSaldoFinal.Clear();
                txtSaldoInicial.Clear();

            }
        }

        private void BotaoCaixaVoltar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();

        }
    }
}
