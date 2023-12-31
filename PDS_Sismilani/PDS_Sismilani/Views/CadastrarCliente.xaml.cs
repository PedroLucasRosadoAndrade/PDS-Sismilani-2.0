﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
//using MySqlX.XDevAPI;
using PDS_Sismilani.Models;
using static System.Net.Mime.MediaTypeNames;
using Button = System.Windows.Controls.Button;

namespace PDS_Sismilani.Views
{
    public partial class CadastrarCliente : Window
    {
        //private string _id;
        private Cliente _cliente;
        //MySqlConnection conexao;
        //MySqlCommand comando;
        ObservableCollection<Cliente> cliente = new ObservableCollection<Cliente>();

        public CadastrarCliente()
        {
            InitializeComponent();
            //Conexao();
            //FuncionariosDataGrid.ItemsSource = funcionario;
            //LoadFuncionario();
            Loaded += CadastrarCliente_Loaded;
        }
        private void CadastrarCliente_Loaded(object sender, RoutedEventArgs e)
        {
            LoadDataGrid();
        }

        //private void LoadFuncionario()
        //{
        //    string query = "select * from funcionario;";
        //    var comando = new MySqlCommand(query, conexao);
        //    MySqlDataReader reader = comando.ExecuteReader();

        //    funcionario.Clear();
        //    while (reader.Read())
        //    {
        //        funcionario.Add(new Funcionario
        //        {
        //            Id = reader.GetInt32("id_fun"),
        //            Nome = reader.GetString("Nome_fun"),
        //            DataNascimento = reader.GetDateTime("nascimento_fun"),
        //            CPF = reader.GetString("cpf_fun"),
        //            Salario = reader.GetDouble("salario_fun"),
        //            Funcao = reader.GetString("funcao_fun"),
        //            Email = reader.GetString("email_fun"),
        //            Celular = reader.GetString("telefone_fun"),
        //            RG = reader.GetString("rg_fun"),
        //            Sexo = reader.GetString("sexo_fun"),
        //        });
        //    }

        //    reader.Close();
        //}


        //private void LimparInputs()
        //{


        //}

        //private void btLimpar_Click(object sender, RoutedEventArgs e)
        //{

        //}

        //private void rdSexo1_Checked(object sender, RoutedEventArgs e)
        //{

        //}
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var addcli = new addCliente().ShowDialog();
        }
        
        private void btDeletar_Click_1(object sender, RoutedEventArgs e)
        {
            //var button = (Button)sender;
            //var dataGridRow = (DataGridRow)FuncionariosDataGrid.ItemContainerGenerator.ContainerFromItem(button.DataContext);
            //var funcionarios = (Funcionario)dataGridRow.Item;

            //if (ExcluirFuncionario(funcionarios.Id))
            //{
            //    funcionario.Remove(funcionarios);
            //    FuncionariosDataGrid.Items.Refresh();
            //}
            //else
            //{
            //    MessageBox.Show("Falha ao excluir o Funcionário.");
            //}

            var clienteSelected = clientesDataGrid.SelectedItem as Cliente;

            var result = MessageBox.Show($"Deseja realmente remover o cliente `{clienteSelected.nome}`?", "Confirmação de Exclusão",
                MessageBoxButton.YesNo, MessageBoxImage.Warning);

            try
            {
                if (result == MessageBoxResult.Yes)
                {
                    var dao = new ClienteDAO();
                    dao.Delete(clienteSelected);
                    LoadDataGrid();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exceção", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void LoadDataGrid()
        {
            try
            {
                var dao = new ClienteDAO();

                clientesDataGrid.ItemsSource = dao.List();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exceção", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btEditar_Click_1(object sender, RoutedEventArgs e)
        {
            //var Funcionarios = new EditFuncionario().ShowDialog();
            var clienteSelected = clientesDataGrid.SelectedItem as Cliente;

            var window = new addCliente(clienteSelected.id);
            window.ShowDialog();
            LoadDataGrid();

        }

        //private bool ExcluirFuncionario(int id)
        //{
        //    try
        //    {
        //        string query = "DELETE FROM Funcionario WHERE id_fun = @id";

        //        using (MySqlCommand cmd = new MySqlCommand(query, conexao))
        //        {
        //            cmd.Parameters.AddWithValue("@id", id);

        //            cmd.ExecuteNonQuery();
        //        }

        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Erro ao excluir o Funcionário: " + ex.Message);
        //        return false;
        //    }


        //}

        //private bool Validate()
        //{
        //    var validator = new FuncionarioValitador();
        //    var result = validator.Validate(_funcionario);

        //    if (!result.IsValid)
        //    {
        //        string errors = null;
        //        var count = 1;

        //        foreach (var failure in result.Errors)
        //        {
        //            errors += $"{count++} - {failure.ErrorMessage}\n";
        //        }

        //        MessageBox.Show(errors, "Validação de Dados", MessageBoxButton.OK, MessageBoxImage.Information);
        //    }

        //    return result.IsValid;
        //}

        //private void SaveData()
        //{
        //    try
        //    {
        //        if (Validate())
        //        {
        //            var dao = new FuncionarioDAO();
        //            var text = "atualizado";

        //            if (_funcionario.Id == "0")
        //            {
        //                dao.Insert(_funcionario);
        //                text = "adicionado";
        //            }
        //            else
        //            {
        //                dao.Update(_funcionario);

        //                MessageBox.Show($"O Funcionário foi {text} com sucesso!", "Sucesso", MessageBoxButton.OK, MessageBoxImage.Information);
        //                CloseFormVerify();
        //            }

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "Não Executado", MessageBoxButton.OK, MessageBoxImage.Error);
        //    }
        //}

        private void Btestoque_Click(object sender, RoutedEventArgs e)
        {
            var estoque = new Estoque().ShowDialog();
            var Filmes = new CadastrarFilme().ShowDialog();

        }

        private void Btfornecedores_Click(object sender, RoutedEventArgs e)
        {
            var fornecedor = new CadastrarFornecedor().ShowDialog();
        }

        private void Btprodutora_Click(object sender, RoutedEventArgs e)
        {
            var produtora = new ListaDeProdutoras().ShowDialog();
        }

        private void Btfilmes_Click(object sender, RoutedEventArgs e)
        {
            var Filme = new ListaDeFilmes().ShowDialog();
        }
        //private void Btprodutora_Click(object sender, RoutedEventArgs e)
        //{
        //    var CadProdutora = new CadastProdutora();
        //    CadProdutora.ShowDialog();
        //}
        //private void Btfornecedores_Click(object sender, RoutedEventArgs e)
        //{
        //    var CadFornecedores = new CadastrarFornecedor();
        //    CadFornecedores.ShowDialog();
        //}
        private void Btfuncionarios_Click(object sender, RoutedEventArgs e)
        {
            var CadFuncionario = new CadastrarFuncionario().ShowDialog();
        }
        //private void Btestoque_Click(object sender, RoutedEventArgs e)
        //{
        //    var CadEstoque = new Estoque();
        //    CadEstoque.ShowDialog();
        //    var Filmes = new CadastrarFilme().ShowDialog();
        //}

        private void btHome_Click(object sender, RoutedEventArgs e)
        {
            var home = new Home().ShowDialog();
            //  var cadastrarFun = new CadastrarFuncionario();
            // cadastrarFun.Close();
        }

        private void Btclientes(object sender, RoutedEventArgs e)
        {
            var cliente = new CadastrarCliente().ShowDialog();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Btprodutos_Click_1(object sender, RoutedEventArgs e)
        {
            var produto = new CadastrarProduto().ShowDialog();
        }

  
        private void clientesDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Loaded += CadastrarCliente_Loaded;
        }

        //private void Btfuncionarios_Click(object sender, RoutedEventArgs e)
        //{
        //    var funci = new CadastrarFuncionario().ShowDialog();
        //}





        //private bool IsMaximized = false;

        //private void ClearInputs()
        //{
        //    txt.Clear();
        //    dtpDataNasc.IsEnabled = false;
        //    txtCpf.Clear();
        //    txtEmail.Clear();
        //    txtSalario.Clear();
        //    txtFuncao.Clear();
        //    txtCeluar.Clear();
        //    txtRg.Clear();
        //    txtSexo.Clear();

        //}


        //private void CloseFormVerify()
        //{
        //    if (_funcionario.Id == 0)
        //    {
        //        var result = MessageBox.Show("Deseja continuar adicionando funcionários?", "Continuar?", MessageBoxButton.YesNo, MessageBoxImage.Question);

        //        if (result == MessageBoxResult.No)
        //            this.Close();
        //        else
        //            ClearInputs();
        //    }
        //    else
        //        this.Close();
        //}

    }
}
