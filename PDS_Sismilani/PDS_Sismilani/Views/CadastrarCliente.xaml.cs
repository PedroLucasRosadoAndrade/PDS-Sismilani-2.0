using Org.BouncyCastle.Utilities.Collections;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MySql.Data.MySqlClient;
using PDS_Sismilani.DataBase;
using System.Windows.Media.TextFormatting;
using PDS_Sismilani.Models;
using System;

namespace PDS_Sismilani.Views
{
    public partial class CadastrarCliente : Window

    {
        MySqlConnection conexao;
        MySqlCommand comando;
        ObservableCollection<Cliente> cliente = new ObservableCollection<Cliente>(); // Coleção de clientes


        public CadastrarCliente()
        {
            InitializeComponent();
            Conexao();
            LoadCliente();
        }
        private void Conexao()
        {
            string conexaoString = "server=localhost;database=cinemilani_bd;user=root;password=root;port=3306";
            conexao = new MySqlConnection(conexaoString);
            comando = conexao.CreateCommand();

            conexao.Open();
        }

        private void LoadCliente() {
            string query = "SELECT *FROM Cliente;";
            var comando = new MySqlCommand(query, conexao);
            MySqlDataReader reader = comando.ExecuteReader();


            cliente.Clear();
            while(reader.Read())
            {
                cliente.Add(new Cliente
                {
                    id = reader.GetString("id_cli"),
                    nome = reader.GetString("nome_cli"),
                    rg = reader.GetString("rg_cli"),
                    telefone = reader.GetString("telefone_cli"),
                    email = reader.GetString("email_cli"),
                    dataNasc = reader.GetDateTime("data_nasc_cli"),
                    cpf = reader.GetString("cpf_cli"),
                    sexo = reader.GetString("sexo_cli"),
                    endereco = reader.GetString("endereco_cli"),
                    id_log_fk = reader.GetString("id_log_fk"),
                    id_ing_fk = reader.GetString("id_ing_fk")
                 });
            }

            reader.Close();

            clientesDataGrid.ItemsSource = cliente;
        }

        //add novo
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Crie um novo cliente com os dados fornecidos pelo usuário
            Cliente novoCliente = new Cliente
            {
                Nome = txtNome.Text,
                Telefone = txtTelefone.Text,
                Email = txtEmail.Text
                // Configure outras propriedades conforme necessário
            };

        }
            //add novo

            private void Button_Click(object sender, RoutedEventArgs e)
            {
            string query = "INSERT INTO Cliente (nome_cli, rg_cli, telefone_cli, email_cli,  data_nasc_cli, cpf_cli, sexo_cli, endereco_cli,id_log_fk, id_ing_fk) " +
                "VALUES (@_nome, @_rg, @_telefone, @_email,@_DTNacimento, @_cpf, @_sexo, @_endereco, @_fk_log, @_fk_ing)";
            using (MySqlCommand comando = new MySqlCommand(query, conexao))
            {
                comando.Parameters.AddWithValue("@_nome", cliente.nome);
                comando.Parameters.AddWithValue("@_cidade", cliente.Telefone);
                comando.Parameters.AddWithValue("@_telefone", cliente.Email);
                comando.Parameters.AddWithValue("@_email", cliente.Email);
                comando.Parameters.AddWithValue("@_cep", cliente.Email);
                comando.Parameters.AddWithValue("@_DTNascimento", cliente.Email);
                comando.Parameters.AddWithValue("@_cpf", cliente.Email);
                comando.Parameters.AddWithValue("@_rua", cliente.Email);
                comando.Parameters.AddWithValue("@_cpf", cliente.Email);
                comando.Parameters.AddWithValue("@_cpf", cliente.Email);

                conexao.Open();
                comando.ExecuteNonQuery();
            }
            try
            {
                var data = datePickerData.SelectedDate;
                var unidade = txtUnidade.Text;
                var categoria = txtCategoria.Text;
                var valor = txtValor.Text;  // Obtenha o texto do TextBox

                string query = "insert into Estoque (unidade_est, categoria_est, data_est, valor_est) VALUES (@_unidade, @_categoria, @_data, @_valor)";
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
        private void btHome_Click(object sender, RoutedEventArgs e)
        {
            var home = new Home();
            home.ShowDialog();
        }

        private void Btfilmes_Click(object sender, RoutedEventArgs e)
        {
            var CadFilme = new CadastrarFilme(); 
            CadFilme.ShowDialog();
        }
        private void Btprodutora_Click(object sender, RoutedEventArgs e)
        {
            var CadProdutora = new Produtora();
            CadProdutora.ShowDialog();
        }
        private void Btfornecedores_Click(object sender, RoutedEventArgs e)
        {
            var CadFornecedores = new CadastrarFornecedor();
            CadFornecedores.ShowDialog();
        }
        private void Btfuncionarios_Click(object sender, RoutedEventArgs e)
        {
            var CadFuncionario = new Funcionario();
            CadFuncionario.ShowDialog();
        }
        private void Btestoque_Click(object sender, RoutedEventArgs e)
        {
            var CadEstoque = new Estoque();
            CadEstoque.ShowDialog();
        }

        // ----------------------------------------------- Otimização de tela -----------------------------------------------

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }
        

        private bool IsMaximized = false;
        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e) // e esse trecho estão fazendo a responsividade da tela 
        {
            if (e.ClickCount == 2)
            {
                if (IsMaximized)
                {
                    this.WindowState = WindowState.Normal;
                    this.Width = 1080;
                    this.Height = 720;

                    IsMaximized = false;
                }
                else
                {

                    this.WindowState = WindowState.Maximized;

                    IsMaximized = false;
                }
            }
        }

        
    }

}