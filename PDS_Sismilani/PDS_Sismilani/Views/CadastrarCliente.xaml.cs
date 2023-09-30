using Org.BouncyCastle.Utilities.Collections;
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
using PDS_Sismilani.DataBase;
using System.Windows.Media.TextFormatting;

namespace PDS_Sismilani.Views
{
    /// <summary>
    /// Lógica interna para CadastrarCliente.xaml
    /// </summary>
    public partial class CadastrarCliente : Window
    {
       MySqlConnection conexao;

        MySqlCommand comando;

        public CadastrarCliente()
        {
            InitializeComponent();
            Conexao();
            //txtNome.Focus();        
        }

        private void Conexao()
        {
            string conexaoString = "server=localhost;database=cinemilani_bd;user=root;password=root;port=3306";
            conexao = new MySqlConnection(conexaoString);
            comando = conexao.CreateCommand();

            conexao.Open();
        }

        private void LimparImputs()
        {

        }

        private void btnSalvar_Click(object sender, RoutedEventArgs e)
        {
            try 
            {
                var dataNasc = dtPickerDataNascimento.SelectedDate;

                bool _rdSexo1 = (bool)rdSexo1.IsChecked;
                var _rdSexo2 = (bool)rdSexo2.IsChecked;



                if (!(bool)rdSexo1.IsChecked && !(bool)rdSexo2.IsChecked)
                {
                    MessageBox.Show("Marque uma opção");
                }
                else
                {

                    var nome = txtNome.Text;
                    var rg = TxtRG.Text;
                    var cidade = txtCidade.Text;
                    var uf = txtUF.Text;
                    var telefone = txtTelefone.Text;
                    var email = txtEmail.Text;
                    var cep = txtCep.Text;
                    var cpf = txtCpf.Text;
                    var rua = TxtRua.Text;
                    var senha = TxtSenha.Text;
                    var sexo = "Feminino";
                    //var bairro = txtBairro.Text;
                   

                    if ((bool)rdSexo1.IsChecked)
                    {
                        sexo = "Masculino";
                    }


                    string query = "INSERT INTO Funcionario (nome_cli, rg_cli, cidade_cli, uf_cli, telefone_cli, email_cli, cep_cli, data_nasc_cli, cpf_cli, rua_cli, senha_cli, sexo_cli) VALUES (@_nome, @_rg, @_cidade, @_uf, @_telefone, @_email, @_cep, @_dataNasc,  @_cpf, @_sexo, @_rua, @_senha, @_sexo_cli)";
                    var comando = new MySqlCommand(query, conexao);

                    comando.Parameters.AddWithValue("@_nome", nome);
                    comando.Parameters.AddWithValue("@_rg", rg);
                    comando.Parameters.AddWithValue("@_cidade", cidade);
                    comando.Parameters.AddWithValue("@_uf", uf);
                    comando.Parameters.AddWithValue("@_telefone", telefone);
                    comando.Parameters.AddWithValue("@_email", email);
                    comando.Parameters.AddWithValue("", cep);
                    comando.Parameters.AddWithValue("@_dataNasc", dataNasc);
                    comando.Parameters.AddWithValue("@_cpf", cpf);
                    comando.Parameters.AddWithValue("@_rua", rua);
                    comando.Parameters.AddWithValue("@_senha", senha);
                    comando.Parameters.AddWithValue("@_sexo", sexo);
                    //comando.Parameters.AddWithValue("@_bairro", bairro);
                    

                    comando.ExecuteNonQuery();
                    txtNome.Clear();
                    TxtRG.Clear();
                    txtCidade.IsEnabled = false;
                    txtUF.IsEnabled = false;
                    txtTelefone.Clear();
                    txtEmail.Clear();
                    txtCep.IsEnabled = false;
                    txtCpf.Clear();
                    TxtRua.Clear();
                    TxtSenha.Clear();
                    //txtBairro.Clear();
                    dtPickerDataNascimento.IsEnabled = false;
                    rdSexo1.IsChecked = false;
                    rdSexo2.IsChecked = false;
                    txtNome.Focus();

                    var opcao = MessageBox.Show("Salvo com sucesso!\n" +
                        "Deseja realizar um novo cadastro?", "Informação",
                        MessageBoxButton.YesNo, MessageBoxImage.Question);


                    if (opcao == MessageBoxResult.Yes)
                    {
                        LimparImputs();
                        MainWindow form = new MainWindow();
                        form.ShowDialog();
                    }
                    else
                    {
                        this.Close();
                    }
                }

            } catch { }
        }

        private void btLimpar_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
