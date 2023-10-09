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

        private void btSalvar_Click(object sender, RoutedEventArgs e) // criando estrutura do Botão salvar
        {
            try
            {
                bool _rdSexo1 = (bool)rdSexo1.IsChecked;
                var _rdSexo2 = (bool)rdSexo2.IsChecked;

                if (!(bool)rdSexo1.IsChecked && !(bool)rdSexo2.IsChecked)
                {
                    MessageBox.Show("Marque uma opção");
                }
                else
                {
                    var nome = txtNome.Text;
                    var cpf = txtCpf.Text;
                    var rg = txtRg.Text;  // Obtenha o texto do TextBox
                    var email = txtEmail.Text;
                    var telefone = txtTelefone.Text;
                    var data = datePickerData.SelectedDate;
                    var endereco = txtEndereco.Text;
                    var sexo = "Feminino";

                    if ((bool)rdSexo1.IsChecked)
                    {
                        sexo = "Masculino";
                    }
                    string query = "INSERT INTO Funcionario (nome_cli, nascimento_fun, sexo_fun, cpf_fun, salario_fun, funcao_fun, email_fun, telefone_fun, rg_fun) " +
                                   "VALUES (@_nome, @_dataNasc, @_sexo, @_cpf , @_salario, @_funcao, @_email, @_telefone, @_rg)";
                    var comando = new MySqlCommand(query, conexao);

                    comando.Parameters.AddWithValue("@_unidade", unidade);
                    comando.Parameters.AddWithValue("@_categoria", categoria);
                    comando.Parameters.AddWithValue("@_data", data);

                    decimal value;

                if (Decimal.TryParse(valor, out value))  // Converta o valor para decimal
                {
                    comando.Parameters.AddWithValue("@_valor", value);
                }
                else
                {
                    MessageBox.Show("Valor não é um número válido.");
                    return;
                }

                comando.ExecuteNonQuery();
                txtCategoria.Clear();
                datePickerData.IsEnabled = false;
                txtUnidade.Clear();
                txtValor.Clear();

                var opcao = MessageBox.Show("Salvo com sucesso! \n Deseja realizar um novo cadastro?", "Informação", MessageBoxButton.YesNo, MessageBoxImage.Question);

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
                MessageBox.Show(ex.Message);
            }



        }

    }
}
