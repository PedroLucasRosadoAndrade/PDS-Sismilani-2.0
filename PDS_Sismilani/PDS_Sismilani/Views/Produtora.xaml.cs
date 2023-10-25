using MySql.Data.MySqlClient;
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
    /// Lógica interna para Produtora.xaml
    /// </summary>
    public partial class Produtora : Window
    {
        MySqlConnection conexao;
        MySqlCommand comando;
        ObservableCollection<Cliente> cliente = new ObservableCollection<Cliente>(); // Coleção de clientes
        public Produtora()
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

        private void btVoltar(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btSalvar(object sender, RoutedEventArgs e)
        {
            try
            {

                var nome = txtNome.Text;
                var cnpj = txtCnpj.Text;
                var telefone = txtTelefone.Text;
                var rasao_social= txtRazao_social.Text;
                var tipo = txtTipo.Text;
                var historico = txtHistorico.Text;


                using (MySqlConnection conexao = new MySqlConnection("server=localhost;database=cinemilani_bd;user=root;password=root;port=3360"))
                {
                    conexao.Open();

                    string query = "INSERT INTO produtora (nome_produ, CNPJ_produ, telefone_produ, razaoSocial_produ, Tipo_produ, historico_produ) " +
                                   "VALUES (@_nome, @_cnpj, @_telefone, @_razaoSocial, @_tipo, @_historico)"; 
                    using (MySqlCommand comando = new MySqlCommand(query, conexao))
                    {
                        comando.Parameters.AddWithValue("@_nome", nome);
                        comando.Parameters.AddWithValue("@_cnpj", cnpj);
                        comando.Parameters.AddWithValue("@_telefone", telefone);
                        comando.Parameters.AddWithValue("@_razaoSocial", rasao_social);
                        comando.Parameters.AddWithValue("@_tipo",tipo);
                        comando.Parameters.AddWithValue("@_historico", historico);

                        comando.ExecuteNonQuery();
                    }
                }
                
                txtNome.Clear();
                txtCnpj.Clear();
                txtTelefone.Clear();
                txtRazao_social.Clear();
                txtTipo.Clear();
                txtHistorico.Clear();
                
                txtNome.Focus();

                var opcao = MessageBox.Show("Produtora salva com sucesso!\n" +
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
                txtCnpj.Clear();
                txtTelefone.Clear();
                txtRazao_social.Clear();
                txtTipo.Clear();
                txtHistorico.Clear();
                
            }
        }
    
    }
}
