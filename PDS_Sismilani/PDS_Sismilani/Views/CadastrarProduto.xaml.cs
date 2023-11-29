﻿using MySql.Data.MySqlClient;
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
    /// Lógica interna para CadastrarProduto.xaml
    /// </summary>
    public partial class CadastrarProduto : Window
    {
        MySqlConnection conexao;
        MySqlCommand comando;
        ObservableCollection<Produto> produto = new ObservableCollection<Produto>();
        public CadastrarProduto()
        {
            InitializeComponent();
            Loaded += CadastrarProduto_Loaded;

        }

        // private void clientesDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{

        // }

        private void btAdd_Click(object sender, RoutedEventArgs e)
        {
            var produto = new CadastrarProduto().ShowDialog();
        }

        private void BtSair(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btDeletar(object sender, RoutedEventArgs e)
        {

            var produtoSelected = produtosDataGrid.SelectedItem as Filme;

            var result = MessageBox.Show($"Deseja excluir o produto `{produtoSelected.Titulo}`?", "Excluido com sucesso",
               MessageBoxButton.YesNo, MessageBoxImage.Warning);

            try
            {
                if (result == MessageBoxResult.Yes)
                {
                    var dao = new FilmeDAO();
                    dao.Delete(produtoSelected);
                    LoadDataGrid();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exceção", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btEditar(object sender, RoutedEventArgs e)
        {
            var editProduto = new EditProduto().ShowDialog();

        }

        private void LoadDataGrid()
        {
            try
            {
                var dao = new ProdutoDAO();

                produtosDataGrid.ItemsSource = dao.List();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exceção", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtHome_Click(object sender, RoutedEventArgs e)
        {
            var home = new Home().ShowDialog();

        }

        //private void Btfilmes_Click(object sender, RoutedEventArgs e)
        //{

        // }

        private void CadastrarProduto_Loaded(object sender, RoutedEventArgs e)
        {
            LoadDataGrid();
        }


        private void Btprodutora_Click(object sender, RoutedEventArgs e)
        {
            var produtora = new Produtora().ShowDialog();

        }

        private void Btfornecedores_Click(object sender, RoutedEventArgs e)
        {
            var fornecedor = new CadastrarFornecedor().ShowDialog();

        }

        private void Btfuncionarios_Click(object sender, RoutedEventArgs e)
        {
            var funcionario = new CadastrarFuncionario().ShowDialog();

        }

        private void Btestoque_Click(object sender, RoutedEventArgs e)
        {
            var estoque = new Estoque().ShowDialog();

        }



        private void Btclientes(object sender, RoutedEventArgs e)
        {
            var cliente = new CadastrarCliente().ShowDialog();

        }
    }
}