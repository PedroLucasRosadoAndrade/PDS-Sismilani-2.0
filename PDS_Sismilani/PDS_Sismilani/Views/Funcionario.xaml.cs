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
    /// Lógica interna para Funcionario.xaml
    /// </summary>
    public partial class Funcionario : Window
    {
        private MySqlConnection conexao;

        private MySqlCommand comando;

        public Funcionario()
        {
            InitializeComponent();
            Conexao();
            txtNome.Focus();
        }
        private void Conexao()
        {
            string conexaoString = "server=localhost;database=bd_Sismilani;user=root;password=root;port=3306";
            conexao = new MySqlConnection(conexaoString);
            comando = conexao.CreateCommand();

            conexao.Open();
        }

        private void btSalvar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var dataNasc = dtpDataNasc.SelectedDate;

                bool _rdSexo1 = (bool) rdSexo1.IsChecked;
                var _rdSexo2 = (bool) rdSexo2.IsChecked;


                if (!(bool)rdSexo1.IsChecked && !(bool)rdSexo2.IsChecked)
                {
                    MessageBox.Show("Marque uma opção");
                }
                else
                {
                    var nome = txtNome.Text;
                    var sexo = "Feminino";
                    var cpf = txtCpf.Text;
                    var salario = txtSalario.Text;
                    var funcao = txtFuncao.Text;
                    var email = txtEmail.Text;
                    var telefone = txtCeluar.Text;
                    var rg = txtRg.Text;

                    if ((bool)rdSexo1.IsChecked)
                    {
                        sexo = "Masculino";
                    }


                    string query = "INSERT INTO contato_con (Nome_fun, nascimento_fun, sexo_fun, cpf_fun, salario_fun, funcao_fun, email_fun, telefone_fun, rg_fun) VALUES (@_nome, @_dataNasc, @_sexo, @_cpf , @_salario, @_funcao, @_email, @_telefone, @_rg)";
                    var comando = new MySqlCommand(query, conexao);

                    comando.Parameters.AddWithValue("@_nome", nome);
                    comando.Parameters.AddWithValue("@_dataNasc", dataNasc);
                    comando.Parameters.AddWithValue("@_sexo", sexo);
                    comando.Parameters.AddWithValue("@_cpf", cpf);
                    comando.Parameters.AddWithValue("@_salario", salario);
                    comando.Parameters.AddWithValue("@_funcao", funcao);
                    comando.Parameters.AddWithValue("@_email", email);
                    comando.Parameters.AddWithValue("@_salario", salario);
                    comando.Parameters.AddWithValue("@_telefone", telefone);
                    comando.Parameters.AddWithValue("@_rg", rg);

                    comando.ExecuteNonQuery();

                    var opcao = MessageBox.Show("Salvo com sucesso!\n" +
                        "Deseja realizar um novo cadastro?", "Informação",
                        MessageBoxButton.YesNo, MessageBoxImage.Question);


                    if (opcao == MessageBoxResult.Yes)
                    {
                        LimparInputs();
                    }
                    else
                    {
                        this.Close();
                    }
                }


            }
            catch (Exception ex)
            {
                //MessageBox.Show($"Ocorreram erros ao tentar salvar os dados! " +
                // $"Contate o suporte do sistema. (CAD 25)");

                MessageBox.Show(ex.Message);
            }

        }
        private void LimparInputs()
        {
            txtNome.Clear();
            dtpDataNasc.IsEnabled = false;
            rdSexo1.IsChecked = false;
            rdSexo2.IsChecked = false;
            txtCpf.Clear();
            txtSalario.Clear();
            txtCeluar.Clear();
            txtEmail.Clear();
            txtCeluar.Clear();
            txtNome.Focus();
        }
    }
}
