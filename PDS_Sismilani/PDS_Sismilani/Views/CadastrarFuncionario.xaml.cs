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
using MySqlX.XDevAPI;
using PDS_Sismilani.Models;

namespace PDS_Sismilani.Views
{
    public partial class CadastrarFuncionario : Window
    {
        MySqlConnection conexao;
        MySqlCommand comando;
        ObservableCollection<Funcionario> funcionario = new ObservableCollection<Funcionario>();


        public CadastrarFuncionario()
        {
            InitializeComponent();
            Conexao();
            FuncionariosDataGrid.ItemsSource = funcionario;
            LoadFuncionario();
        }
        private void Conexao()
        {
            string conexaoString = "server=localhost;database=cinemilani_bd;user=root;password=root;port=3306";
            conexao = new MySqlConnection(conexaoString);
            comando = conexao.CreateCommand();

            conexao.Open();
        }

        private void LoadFuncionario()
        {
            string query = "select * from funcionario;";
            var comando = new MySqlCommand(query, conexao);
            MySqlDataReader reader = comando.ExecuteReader();

            funcionario.Clear();
            while (reader.Read())
            {
                funcionario.Add(new Funcionario
                {
                    Id = reader.GetString("id_fun"),
                    Nome = reader.GetString("Nome_fun"),
                    DataNascimento = reader.GetDateTime("nascimento_fun"),
                    CPF = reader.GetString("cpf_fun"),
                    Salario = reader.GetDouble("salario_fun"),
                    Funcao = reader.GetString("funcao_fun"),
                    Email = reader.GetString("email_fun"),
                    Celular = reader.GetString("telefone_fun"),
                    RG = reader.GetString("rg_fun"),
                    Sexo = reader.GetString("sexo_fun"),
                });
            }

            reader.Close();
        }

        //private void LimparInputs()
        //{

           
        //}

        //private void btLimpar_Click(object sender, RoutedEventArgs e)
        //{
           
        //}

        //private void rdSexo1_Checked(object sender, RoutedEventArgs e)
        //{

        //}

        private void btAdd(object sender, RoutedEventArgs e)
        {
            var funcionario = new addFuncionario().ShowDialog();
        }

        private void btDeletar(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            var dataGridRow = (DataGridRow)FuncionariosDataGrid.ItemContainerGenerator.ContainerFromItem(button.DataContext);
            var funcionarios = (Funcionario)dataGridRow.Item;

            if (ExcluirFuncionario(funcionarios.Id))
            {
                funcionario.Remove(funcionarios);
                FuncionariosDataGrid.Items.Refresh();
            }
            else
            {
                MessageBox.Show("Falha ao excluir o Funcionário.");
            }
        }

        private void btEditar(object sender, RoutedEventArgs e)
        {
            var editFuncionario = new EditFuncionario().ShowDialog();
        }

        private bool ExcluirFuncionario(string id)
        {
            try
            {
                string query = "DELETE FROM Funcionario WHERE id_fun = @id";

                using (MySqlCommand cmd = new MySqlCommand(query, conexao))
                {
                    cmd.Parameters.AddWithValue("@id", id);

                    cmd.ExecuteNonQuery();
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao excluir o Funcionário: " + ex.Message);
                return false;
            }
        }

        private void Btestoque(object sender, RoutedEventArgs e)
        {
            var estoque = new Estoque().ShowDialog();
        }

        private void Btfornecedores(object sender, RoutedEventArgs e)
        {
            var fornecedor = new CadastrarFornecedor().ShowDialog();    
        }

        private void Btprodutora(object sender, RoutedEventArgs e)
        {
            var produtora = new Produtora().ShowDialog();
        }

        private void Btfilmes(object sender, RoutedEventArgs e)
        {
            var Filmes = new CadastrarFilme().ShowDialog();
        }

        private void btHome(object sender, RoutedEventArgs e)
        {
            var home = new Home().ShowDialog();
        }

        private void Btclientes(object sender, RoutedEventArgs e)
        {
            var cliente = new CadastrarCliente().ShowDialog();  
        }

        private void BtFechar(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        //private bool IsMaximized = false;

    }
}
