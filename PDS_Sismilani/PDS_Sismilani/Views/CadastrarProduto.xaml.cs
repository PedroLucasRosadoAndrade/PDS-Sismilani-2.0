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
using Button = System.Windows.Controls.Button;
using static System.Net.Mime.MediaTypeNames;

namespace PDS_Sismilani.Views
{
    /// <summary>
    /// Lógica interna para CadastrarProduto.xaml
    /// </summary>
    public partial class CadastrarProduto : Window
    {
        private Produto _produto;
        //MySqlConnection conexao;
        //MySqlCommand comando;
        ObservableCollection<Produto> Produtos = new ObservableCollection<Produto>();

        public CadastrarProduto()
        {
            InitializeComponent();
            produtosDataGrid.ItemsSource = Produtos;
            Loaded += CadastrarProduto_Loaded;
        }

        //public CadastrarProduto(int id)
        //{
        //    InitializeComponent();

        //}
        private void CadastrarProduto_Loaded(object sender, RoutedEventArgs e)
        {
            LoadDataGrid();
        }

       

        private void btAdd_Click(object sender, RoutedEventArgs e)
        {
            var produto = new AddProduto().ShowDialog();
            LoadDataGrid();
        }

        private void BtSair(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        

        

        private void LoadDataGrid()
        {
            try
            {
                var dao = new ProdutoDAO();
                var produtosList = dao.List();
                Produtos.Clear();
                foreach (var produto in produtosList)
                {
                    Produtos.Add(produto);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro ao carregar produtos", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtHome(object sender, RoutedEventArgs e)
        {
            var home = new Home().ShowDialog();
            var cadastrarPro = new CadastrarProduto();
            cadastrarPro.Close();
        }

        private void Btfilmes(object sender, RoutedEventArgs e)
        {
            var Filme = new ListaDeFilmes().ShowDialog();
        }


        private void Btprodutora_Click(object sender, RoutedEventArgs e)
        {
            var produtora = new CadastrarProdutora().ShowDialog();

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

        private void btEditar_Click(object sender, RoutedEventArgs e)
        {
            if (produtosDataGrid.SelectedItem is Produto selectedProduto)
            {
                var editWindow = new AddProduto(selectedProduto.Id);
                editWindow.ShowDialog();
                LoadDataGrid();
            }
            else
            {
                MessageBox.Show("Por favor, selecione um produto para editar.", "Seleção Necessária", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void btaDeletar_Click(object sender, RoutedEventArgs e)
        {
            var produtoSelected = produtosDataGrid.SelectedItem as Produto;

            var result = MessageBox.Show($"Deseja excluir o produto `{produtoSelected.Nome}`?", "Excluido com sucesso",
               MessageBoxButton.YesNo, MessageBoxImage.Warning);

            try
            {
                if (result == MessageBoxResult.Yes)
                {
                    var dao = new ProdutoDAO();
                    dao.Delete(produtoSelected);
                    LoadDataGrid();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exceção", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtFechar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
