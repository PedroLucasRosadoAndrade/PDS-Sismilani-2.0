using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using PDS_Sismilani.DataBase;
using PDS_Sismilani.Models;
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
using System.Security.Cryptography;

namespace PDS_Sismilani.Views
{
    /// <summary>
    /// Lógica interna para EditCliente.xaml
    /// </summary>
    public partial class EditCliente : Window
    {
        private int _id;

        MySqlConnection conexao;
        MySqlCommand comando;
        ObservableCollection<Cliente> cliente = new ObservableCollection<Cliente>(); // Coleção de clientes
        Cliente clienteEmEdicao;

        public EditCliente()
        {
            InitializeComponent();
            Loaded += EditCliente_Loaded;
        }
        public EditCliente(string id)
        {
            InitializeComponent();
            _id = int.Parse(id);
            Loaded += EditCliente_Loaded;
        }
        private void EditCliente_Loaded(object sender, RoutedEventArgs e)
        {
            if (_id > 0)
            {
                PreencherCampos();
            }
        }
        public void PreencherCampos()
        {
            //clienteEmEdicao = cliente;

            if (clienteEmEdicao != null)
            {
                txtNome.Text = clienteEmEdicao.nome;
                txtRg.Text = clienteEmEdicao.rg;
                txtTelefone.Text = clienteEmEdicao.telefone;
                txtEmail.Text = clienteEmEdicao.email;
                datePickerData.SelectedDate = clienteEmEdicao.dataNasc;
                txtCpf.Text = clienteEmEdicao.cpf;
                txtSexo.Text = clienteEmEdicao.sexo;
                txtEndereco.Text = clienteEmEdicao.endereco;
            }
        }

        //private void Conexao() // criando conexão
        //{
        //    string conexaoString = "server=localhost;database=cinemilani_bd;user=root;password=root;port=3306";
        //    conexao = new MySqlConnection(conexaoString);
        //    comando = conexao.CreateCommand();
        //    conexao.Open();
        //}

        private void SalvarButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string query = "UPDATE Cliente SET nome_cli = @_nome, rg_cli = @_rg, telefone_cli = @_telefone, " +
                    "email_cli = @_email, data_nasc_cli = @_dataNascimento, cpf_cli = @_cpf, sexo_cli = @_sexo, " +
                    "endereco_cli = @_endereco WHERE id_cli = @id";

                using (MySqlCommand cmd = new MySqlCommand(query, conexao))
                {
                    cmd.Parameters.AddWithValue("@id", clienteEmEdicao.id);
                    cmd.Parameters.AddWithValue("@_nome", txtNome.Text);
                    cmd.Parameters.AddWithValue("@_rg", txtRg.Text);
                    cmd.Parameters.AddWithValue("@_telefone", txtTelefone.Text);
                    cmd.Parameters.AddWithValue("@_email", txtEmail.Text);
                    cmd.Parameters.AddWithValue("@_dataNasc", datePickerData.SelectedDate);
                    cmd.Parameters.AddWithValue("@_cpf", txtCpf.Text);
                    cmd.Parameters.AddWithValue("@_sexo", txtSexo.Text);
                    cmd.Parameters.AddWithValue("@_endereco", txtEndereco.Text);

                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Cliente atualizado com sucesso!");
                Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao atualizar o cliente: " + ex.Message);
            }
        }

        private void btVoltar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }

}


