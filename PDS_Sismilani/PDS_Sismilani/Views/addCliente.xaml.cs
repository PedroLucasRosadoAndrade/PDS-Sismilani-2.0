using MySql.Data.MySqlClient;
using PDS_Sismilani.DataBase;
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
    /// Lógica interna para addCliente.xaml
    /// </summary>
    public partial class addCliente : Window
    {
        MySqlConnection conexao;
        MySqlCommand comando;
        ObservableCollection<Cliente> cliente = new ObservableCollection<Cliente>(); // Coleção de clientes

        public addCliente()
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

        private void btVoltar_Click(object sender, RoutedEventArgs e) // gerando Botão voltar
        {
            this.Close();
        }

        private void btSalvar_Click(object sender, RoutedEventArgs e)
        {

            try
            {

                var nome = txtNome.Text;
                var cpf = txtCpf.Text;
                var rg = txtRg.Text;
                var email = txtEmail.Text;
                var telefone = txtTelefone.Text;
                var data = datePickerData.SelectedDate;
                var endereco = txtEndereco.Text;
                var sexo = txtSexo.Text;


                using (MySqlConnection conexao = new MySqlConnection("server=localhost;database=cinemilani_bd;user=root;password=root;port=3306"))
                {
                    conexao.Open();

                    string query = "INSERT INTO Funcionario (nome_cli, rg_cli, telefone_cli, email_cli, data_nasc_cli, cpf_cli, sexo_cli, endereco_cli) " +
                                   "VALUES (@_nome, @_rg, @_telefone, @_email, @_data_nascimento, @_cpf, @_sexo, @_endereco)";
                    using (MySqlCommand comando = new MySqlCommand(query, conexao))
                    {
                        comando.Parameters.AddWithValue("@_nome", nome);
                        comando.Parameters.AddWithValue("@_rg", rg);
                        comando.Parameters.AddWithValue("@_telefone", telefone);
                        comando.Parameters.AddWithValue("@_email", email);
                        comando.Parameters.AddWithValue("@_data_nascimento", data);
                        comando.Parameters.AddWithValue("@_cpf", cpf);
                        comando.Parameters.AddWithValue("@_sexo", sexo);
                        comando.Parameters.AddWithValue("@_endereco", endereco);

                        comando.ExecuteNonQuery();
                    }
                }
                comando.ExecuteNonQuery();
                txtNome.Clear();
                datePickerData.IsEnabled = false;
                txtSexo.Clear();
                txtCpf.Clear();
                txtRg.Clear();
                txtTelefone.Clear();
                txtEmail.Clear();
                txtEndereco.Clear();
                txtNome.Focus();

                var opcao = MessageBox.Show("Cliente salvo com sucesso!\n" +
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

                txtNome.Clear();
                datePickerData.IsEnabled = false;
                txtSexo.Clear();
                txtCpf.Clear();
                txtRg.Clear();
                txtTelefone.Clear();
                txtEmail.Clear();
                txtEndereco.Clear();
                txtNome.Focus();
            }
        }

    }
}
