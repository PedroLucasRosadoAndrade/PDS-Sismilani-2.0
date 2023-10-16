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
using System.Web.UI.WebControls;
using MySqlX.XDevAPI;

namespace PDS_Sismilani.Views
{
    /// <summary>
    /// Lógica interna para EditFuncionario.xaml
    /// </summary>
    public partial class EditFuncionario : Window
    {
        
        MySqlConnection conexao;
        MySqlCommand comando;
        ObservableCollection<Funcionario> funcionario = new ObservableCollection<Funcionario>();
        Funcionario FuncionarioEmEdicao;

        public EditFuncionario()
        {
            InitializeComponent();
        }

        public void PreencherCampos(Funcionario funcionario)
        {
            FuncionarioEmEdicao = funcionario;

            if (FuncionarioEmEdicao != null)
            {
                txtNome.Text = FuncionarioEmEdicao.Nome;
                dtpDataNasc.SelectedDate = FuncionarioEmEdicao.DataNascimento;
                txtCpf.Text = FuncionarioEmEdicao.CPF;
                txtFuncao.Text = FuncionarioEmEdicao.Funcao;
                txtSalario.Text = FuncionarioEmEdicao.Salario.ToString();
                txtEmail.Text = FuncionarioEmEdicao.Email;
                txtCeluar.Text = FuncionarioEmEdicao.Celular;
                txtRg.Text = FuncionarioEmEdicao.RG;
                txtSexo.Text = FuncionarioEmEdicao.Sexo;
            }
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
                string query = "UPDATE Funcionario SET Nome_fun = @_nome, nascimento_fun = @_dataNascimento, cpf_fun = @_cpf, funcao_fun = @_funcao, salario_fun = @_salario, email_fun = @_email, telefone_fun = @_telefone,  rg_fun = @_rg, sexo_fun = @_sexo WHERE id_fun = @id";

                using (MySqlCommand cmd = new MySqlCommand(query, conexao))
                {
                    cmd.Parameters.AddWithValue("@id", FuncionarioEmEdicao.Id);
                    cmd.Parameters.AddWithValue("@_nome", txtNome.Text);
                    cmd.Parameters.AddWithValue("@_dataNascimento", dtpDataNasc.SelectedDate);
                    cmd.Parameters.AddWithValue("@_cpf", txtCpf.Text);
                    cmd.Parameters.AddWithValue("@_funcao", txtFuncao.Text);
                    cmd.Parameters.AddWithValue("@_salario", txtSalario.Text);
                    cmd.Parameters.AddWithValue("@_email", txtEmail.Text);
                    cmd.Parameters.AddWithValue("@_telefone", txtCeluar.Text);
                    cmd.Parameters.AddWithValue("@_rg", txtRg.Text);
                    cmd.Parameters.AddWithValue("@_sexo", txtSexo.Text);

                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Funcionário atualizado com sucesso!");
                Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao atualizar o funcionário: " + ex.Message);
            }
        }

        private void btVoltar(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
