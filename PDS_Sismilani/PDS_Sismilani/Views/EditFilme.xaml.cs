﻿using MySql.Data.MySqlClient;
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
    /// Lógica interna para EditFilme.xaml
    /// </summary>
    public partial class EditFilme : Window
    {
        private int _id;
        MySqlConnection conexao;
        MySqlCommand comando;

        ObservableCollection<Filme> filmes = new ObservableCollection<Filme>();
        Filme EdicaoFilme;
        public EditFilme(int id)
        {
            InitializeComponent();
            Loaded += EditFilme_Loaded;

        }

        public EditFilme(string id)
        {
            InitializeComponent();
            _id = int.Parse(id);
            Loaded += EditFilme_Loaded;
        }


        private void EditFilme_Loaded(object sender, RoutedEventArgs e)
        {
            if (_id > 0)
            {
                PreencherCampos();
            }
        }

        public void PreencherCampos()
        {
            if (EdicaoFilme != null)
            {
                txtTitulo.Text = EdicaoFilme.Titulo;
                txtSinopse.Text = EdicaoFilme.Sinopse;
                txtFornecedor.Text = EdicaoFilme.Fornecedor;
                txtCategoria.Text = EdicaoFilme.Categoria;
                txtElenco.Text = EdicaoFilme.Elenco;
                txtDiretor.Text = EdicaoFilme.Diretor;
                datePickerData.SelectedDate = EdicaoFilme.DataLancamento;

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
                string query = "UPDATE filme set titulo_film = @_titulo, fornecedor_film = @_fornecedor ,categoria_film = @_categoria,dataLancamento_film = @_dataLancamento," + 
                    "sinopse_film = @_sinopse, elenco_film = @_elenco,diretor_film = @_diretor where id_film = @id ";

                using (MySqlCommand cmd = new MySqlCommand(query, conexao))
                {
                    cmd.Parameters.AddWithValue("@_titulo",EdicaoFilme.Titulo);
                    cmd.Parameters.AddWithValue("@_sinopse", EdicaoFilme.Sinopse);
                    cmd.Parameters.AddWithValue("@_fornecedor",EdicaoFilme.Fornecedor);
                    cmd.Parameters.AddWithValue("@_categoria", EdicaoFilme.Categoria);
                    cmd.Parameters.AddWithValue(" @_elenco", EdicaoFilme.Elenco);
                    cmd.Parameters.AddWithValue("@_diretor", EdicaoFilme.Diretor);
                    cmd.Parameters.AddWithValue("@_dataLancamento", EdicaoFilme.DataLancamento);
                    cmd.Parameters.AddWithValue("@id", EdicaoFilme.Id);

                    cmd.ExecuteNonQuery();

                }

                MessageBox.Show("Filme atualizado com sucesso!");
                Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao atualizar o filme: " + ex.Message);
            }
        }

        private void BtVoltar(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }


}
