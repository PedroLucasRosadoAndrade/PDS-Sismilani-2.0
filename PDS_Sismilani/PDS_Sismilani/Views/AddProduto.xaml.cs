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
    /// Lógica interna para AddProduto.xaml
    /// </summary>
    public partial class AddProduto : Window
    {
        MySqlConnection conexao;
        MySqlCommand comando;
        ObservableCollection<Produto> produtos = new ObservableCollection<Produto>();
        public AddProduto()
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

        private void BtVoltar(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        private void BtSalvar(object sender, RoutedEventArgs e)
        {
            try
            {
                var nome = txtNome.Text;
                var marca = txtMarca.Text;
                var Tipo = txtTipo.Text;
                var quantidade = txtQuantidade.Text;
                var valor = txtValor.Text;
                var validade = datePickerData.SelectedDate;


                using (MySqlConnection conexao = new MySqlConnection("server=localhost;database=cinemilani_bd;user=root;password=root;port=3306"))
                {
                    conexao.Open();

                    string query = "INSERT INTO produto (nome_prod,marca_prod ,tipo_prod,quantidade_prod,validade_prod, valor_prod)" +
                                  "VALUES (@_nome_prod,@_ marca_prod,@_tipo_prod,@_quantidade_prod, @_validade_prod,@_valor_prod)";

                    using (MySqlCommand comando = new MySqlCommand(query, conexao))
                    {
                        comando.Parameters.AddWithValue("@_nome", nome);
                        comando.Parameters.AddWithValue("@_marca", marca);
                        comando.Parameters.AddWithValue("@_tipo", Tipo);
                        comando.Parameters.AddWithValue("@_quantidade", quantidade);
                        comando.Parameters.AddWithValue("@_valor", valor);
                        comando.Parameters.AddWithValue("@_validade", validade);

                        comando.ExecuteNonQuery();
                    }
                }

                comando.ExecuteNonQuery();
                txtNome.Clear();
                datePickerData.IsEnabled = false;
                txtMarca.Clear();
                txtTipo.Clear();
                txtQuantidade.Clear();
                txtValor.Clear();


                var opcao = MessageBox.Show("Produto salvo com sucesso!\n" +
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

            }

            txtNome.Clear();
            datePickerData.IsEnabled = false;
            txtMarca.Clear();
            txtTipo.Clear();
            txtQuantidade.Clear();
            txtValor.Clear();
            txtNome.Focus();
   }    }
}
