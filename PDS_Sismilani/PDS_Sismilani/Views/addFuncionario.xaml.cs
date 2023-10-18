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
using MySql.Data.MySqlClient;
using PDS_Sismilani.DataBase;
using PDS_Sismilani.Models;

namespace PDS_Sismilani.Views
{
    /// <summary>
    /// Lógica interna para addFuncionario.xaml
    /// </summary>
    public partial class addFuncionario : Window
    {
        MySqlConnection conexao;
        MySqlCommand comando;
        ObservableCollection<Funcionario> funcionario = new ObservableCollection<Funcionario>();

        public addFuncionario()
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

        private void btVoltar(object sender, RoutedEventArgs e)
        {
            this.Close();   
        }

        private void btSalvar(object sender, RoutedEventArgs e)
        {
            try
            {

                var nome = txtNome.Text;
                var data = dtpDataNasc.SelectedDate;
                var cpf = txtCpf.Text;
                var salario = txtSalario.Text;
                var funcao = txtFuncao.Text;
                var email = txtEmail.Text;
                var telefone = txtCeluar.Text;
                var rg = txtRg.Text;
                var sexo = txtSexo.Text;


                using (MySqlConnection conexao = new MySqlConnection("server=localhost;database=cinemilani_bd;user=root;password=root;port=3306"))
                {
                    conexao.Open();

                    string query = "INSERT INTO funcionario " +
                        "(Nome_fun, nascimento_fun, cpf_fun, salario_fun, funcao_fun, email_fun, telefone_fun, rg_fun, sexo_fun) " +
                        "VALUES (@_nome, @_datanasc, @_cpf, @_salario, @_funcao, @_email, @_celular, @_rg, @_sexo)";


                    using (MySqlCommand comando = new MySqlCommand(query, conexao))
                    {
                        comando.Parameters.AddWithValue("@_nome", nome);
                        comando.Parameters.AddWithValue("@_datanasc", data);
                        comando.Parameters.AddWithValue("@_cpf", cpf);
                        comando.Parameters.AddWithValue("@_salario", salario);
                        comando.Parameters.AddWithValue("@_funcao", funcao);
                        comando.Parameters.AddWithValue("@_email", email);
                        comando.Parameters.AddWithValue("@_celular", telefone);
                        comando.Parameters.AddWithValue("@_rg", rg);
                        comando.Parameters.AddWithValue("@_sexo", sexo);

                        comando.ExecuteNonQuery();
                    }
                }
                //System.NullReferenceException: 'Referência de objeto não definida para uma instância de um objeto.'
                //comando.ExecuteNonQuery();
                txtNome.Clear();
                dtpDataNasc.IsEnabled = false;
                txtCpf.Clear();
                txtEmail.Clear();
                txtSalario.Clear();
                txtFuncao.Clear();
                txtCeluar.Clear();
                txtRg.Clear();
                txtSexo.Clear();
                txtNome.Focus();

                var opcao = MessageBox.Show("Funcionário salvo com sucesso!\n" +
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
                dtpDataNasc.IsEnabled = false;
                txtCpf.Clear();
                txtEmail.Clear();
                txtSalario.Clear();
                txtFuncao.Clear();
                txtCeluar.Clear();
                txtRg.Clear();
                txtSexo.Clear();
                txtNome.Focus();
            }
        }
    }
}
