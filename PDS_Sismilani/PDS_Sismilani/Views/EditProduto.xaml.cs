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
using System.Web.UI.WebControls;
using MySqlX.XDevAPI;

namespace PDS_Sismilani.Views
{
    /// <summary>
    /// Lógica interna para EditProduto.xaml
    /// </summary>
    public partial class EditProduto : Window
    {
        private int _id;

        MySqlConnection conexao;
        MySqlCommand comando;
      
        ObservableCollection<Produto> produto = new ObservableCollection<Produto>();
        Produto EdicaoProduto;
        public EditProduto(int id)
        {
            InitializeComponent();

            Loaded += EditProduto_Loaded;
        }

        public EditProduto(string id)
        {
            InitializeComponent();
            _id = int.Parse(id);
            Loaded += EditProduto_Loaded;
        }

        private void EditProduto_Loaded(object sender, RoutedEventArgs e)
        {
            if (_id > 0)
            {
                PreencherCampos();
            }
        }

        public void PreencherCampos()
        {
            if (EdicaoProduto != null)
            {
                txtNome.Text = EdicaoProduto.Nome;
                txtmarca.Text = EdicaoProduto.Marca;
                txtTipo.Text = EdicaoProduto.Tipo;
                txtValor.Text = EdicaoProduto.Valor.ToString();
                txtQuantidade.Text =  EdicaoProduto.Quantidade.ToString();
                datePickerData.SelectedDate = EdicaoProduto.Validade;

            }
        }


        //private void Conexao()
        //{
        //    string conexaoString = "server=localhost;database=cinemilani_bd;user=root;password=root;port=3306";
        //    conexao = new MySqlConnection(conexaoString);
        //    comando = conexao.CreateCommand();
        //    conexao.Open();
        //}

        private void BtSalvar(object sender, RoutedEventArgs e)
        {

            try
            {
             string query = "UPDATE produto Set nome_prod = @_nome, Marca_prod = @_marca ,tipo_prod = @_tipo ," +
                    "quantidade_prod = @_quantidade,validade_prod = @_validade,valor_prod = @_valor WHERE id_prod = @id";

                using (MySqlCommand cmd = new MySqlCommand(query, conexao))
                {

                    cmd.Parameters.AddWithValue("@_nome", EdicaoProduto.Nome);
                    cmd.Parameters.AddWithValue("@_marca", EdicaoProduto.Marca);
                    cmd.Parameters.AddWithValue("@_tipo", EdicaoProduto.Tipo);
                    cmd.Parameters.AddWithValue("@_quantidade", EdicaoProduto.Quantidade);
                    cmd.Parameters.AddWithValue("@_validade", EdicaoProduto.Validade);
                    cmd.Parameters.AddWithValue("@_valor", EdicaoProduto.Valor);
                    cmd.Parameters.AddWithValue("@id", EdicaoProduto.Id);

                    cmd.ExecuteNonQuery();

                }

                MessageBox.Show("Produto atualizado com sucesso!");
                Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao atualizar o produto: " + ex.Message);
            }


        }

        private void BtVoltar(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }

   
}
