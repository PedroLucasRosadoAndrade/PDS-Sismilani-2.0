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
    /// Lógica interna para CadastrarFornecedor.xaml
    /// </summary>
    public partial class CadastrarFornecedor : Window
    {
        MySqlConnection conexao;
        MySqlCommand comando;
        ObservableCollection<Fornecedor> fornecedors = new ObservableCollection<Fornecedor>(); // Coleção de clientes
        public CadastrarFornecedor()
        {
            InitializeComponent();
        }
        private void Conexao() // criando conexão
        {
            string conexaoString = "server=localhost;database=cinemilani_bd;user=root;password=root;port=3306";
            conexao = new MySqlConnection(conexaoString);
            comando = conexao.CreateCommand();

            conexao.Open();
        }

        private void btSalvar(object sender, RoutedEventArgs e)
        {
            try
            {

                var nome = txtNome.Text;
                var cnpj = txtCnpj.Text;
                var telefone = txtTelefone.Text;
                var tipo = txtTipo.Text;
                var historico = txtHistorico.Text;

                using (MySqlConnection conexao = new MySqlConnection("server=localhost;database=cinemilani_bd;user=root;password=root;port=3306"))
                {
                    conexao.Open();

                    string query = "INSERT INTO fornecedor (Nome_for, CNPJ_for, tipo_for, telefone_for, historico_for) " +
                                   "VALUES (@_nome, @_CNPJ, @_tipo, @_telefone, @_historico)";
                    using (MySqlCommand comando = new MySqlCommand(query, conexao))
                    {
                        comando.Parameters.AddWithValue("@_Nome", nome);
                        comando.Parameters.AddWithValue("@_cnpj", cnpj);
                        comando.Parameters.AddWithValue("@_telefone", telefone);
                        comando.Parameters.AddWithValue("@_tipo", tipo);
                        comando.Parameters.AddWithValue("@_historico", historico);


                        comando.ExecuteNonQuery();
                    }
                }

                txtNome.Clear();
                txtCnpj.Clear();
                txtTelefone.Clear();
                txtTipo.Clear();
                txtHistorico.Clear();

                txtNome.Focus();

                var opcao = MessageBox.Show("Fornecedor cadastrado com sucesso!\n" +
                    "Deseja realizar um novo cadastro?", "Informação",
                    MessageBoxButton.YesNo, MessageBoxImage.Question);


                if (opcao == MessageBoxResult.Yes)
                {

                    txtNome.Clear();
                    txtCnpj.Clear();
                    txtTelefone.Clear();
                    txtTipo.Clear();
                    txtHistorico.Clear();

                    txtNome.Focus();
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

                txtNome.Clear();
                txtCnpj.Clear();
                txtTelefone.Clear();
                txtTipo.Clear();
                txtHistorico.Clear();
            }
        } 

            private void btVoltar(object sender, RoutedEventArgs e)
            {
            this.Close();

            }

        private void txtEstado_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
