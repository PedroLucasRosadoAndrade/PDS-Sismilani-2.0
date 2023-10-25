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
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PDS_Sismilani.Views
{
    /// <summary>
    /// Lógica interna para AddFilme.xaml
    /// </summary>
    public partial class AddFilme : Window
    {
        MySqlConnection conexao;
        MySqlCommand comando;
        ObservableCollection<Filme> filmes = new ObservableCollection<Filme>();

        public AddFilme()
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


        private void BtSalvar(object sender, RoutedEventArgs e)
        {
            try
            {
                var titulo = txtTitulo.Text;
                var sinopse = txtSinopse.Text;
                var fornecedor = txtFornecedor.Text;
                var categoria = txtCategoria.Text;
                var elenco = txtElenco.Text;
                var date = datePickerData.SelectedDate;


                using (MySqlConnection conexao = new MySqlConnection("server=localhost;database=cinemilani_bd;user=root;password=root;port=3306"))
                {
                    conexao.Open();

                    string query = "INSERT INTO Filme (titulo_film,fornecedor_film ,  categoria_film,dataLancamento_film, sinopse_film,elenco_film, ) " +
                                   "VALUES (@_titulo_film,@_fornecedor_film ,@_categoria_film,@_dataLancamento_film, @_sinopse_film,@_elenco_film, diretor_film)";
                    using (MySqlCommand comando = new MySqlCommand(query, conexao))
                    {
                        comando.Parameters.AddWithValue("@_titulo",titulo);
                        comando.Parameters.AddWithValue("@_fornecedor", fornecedor);
                        comando.Parameters.AddWithValue("@_categoria",categoria);
                        comando.Parameters.AddWithValue("@_dataLancamento", date);
                        comando.Parameters.AddWithValue("@_sinopse", sinopse);
                        comando.Parameters.AddWithValue("@_elenco", elenco);
                        comando.Parameters.AddWithValue("@_diretor", diretor);

                        comando.ExecuteNonQuery();
                    }
                }








            }







        }

        private void BtVoltar(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


    }
}
