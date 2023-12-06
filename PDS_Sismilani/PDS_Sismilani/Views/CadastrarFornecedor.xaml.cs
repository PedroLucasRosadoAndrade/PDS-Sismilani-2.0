using System;
using System.Collections.Generic;
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
using MySql.Data.MySqlClient;
using PDS_Sismilani.Models;
using System.Collections.ObjectModel;
using System.Data.SqlClient;


namespace PDS_Sismilani.Views
{
    /// <summary>
    /// Lógica interna para CadastrarFornecedor.xaml
    /// </summary>
    public partial class CadastrarFornecedor : Window
    {
        private int _id;

        private Fornecedor _fornecedor;
        public CadastrarFornecedor()
        {
            InitializeComponent();
            Loaded += CadastrarFornecedor_Loaded;
        }
        public CadastrarFornecedor(int id)
        {
            _id = id;
            InitializeComponent();
            Loaded += CadastrarFornecedor_Loaded;
        }
        private void CadastrarFornecedor_Loaded(object sender, RoutedEventArgs e)
        {
            _fornecedor = new Fornecedor();

            //LoadComboBox();

            if (_id > 0)
                FillForm();
        }
        private void btSalvar(object sender, RoutedEventArgs e)
        {
            _fornecedor.Id = _id;
            _fornecedor.Nome = txtNome.Text;
            _fornecedor.CNPJ = txtCnpj.Text;
            _fornecedor.tipo = txtTipo.Text;
            _fornecedor.telefone = txtTelefone.Text;
            _fornecedor.historico = txtHistorico.Text;
            

            SaveData();
        }

        private void SaveData()
        {
            try
            {
               
                    var dao = new FornecedorDAO();
                    var text = "atualizado";

                    if (_fornecedor.Id == 0)
                    {
                        dao.Insert(_fornecedor);
                        text = "adicionado";
                    }
                    else
                        dao.Update(_fornecedor);

                    MessageBox.Show($"O Fornecedor foi {text} com sucesso!", "Sucesso", MessageBoxButton.OK, MessageBoxImage.Information);
                    CloseFormVerify();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Não Executado", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void FillForm()
        {
            try
            {
                var dao = new FornecedorDAO();
                _fornecedor = dao.GetById(_id);
                txtId.Text = _fornecedor.Id.ToString();
                txtNome.Text = _fornecedor.Nome;
                txtCnpj.Text = _fornecedor.CNPJ;
                txtTipo.Text = _fornecedor.tipo;
                txtTelefone.Text = _fornecedor.telefone;
                txtHistorico.Text = _fornecedor.historico;
                
                //if (_funcionario.Sexo != null)
                //    comboBoxSexo.SelectedValue = _funcionario.Sexo.Id;

                //if (_funcionario.Endereco != null)
                //{
                //    txtRua.Text = _funcionario.Endereco.Rua;
                //    txtNumero.Text = _funcionario.Endereco.Numero.ToString();
                //    txtBairro.Text = _funcionario.Endereco.Bairro;
                //    txtCidade.Text = _funcionario.Endereco.Cidade;

                //    comboBoxEstado.SelectedValue = _funcionario.Endereco.Estado;
                //}

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exceção", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void CloseFormVerify()
        {
            if (_fornecedor.Id == 0)
            {
                var result = MessageBox.Show("Deseja continuar adicionando Fornecedores?", "Continuar?", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.No)
                    this.Close();
                else
                    ClearInputs();
            }
            else
                this.Close();
        }
        private void ClearInputs()
        {

            txtNome.Text = "";
            txtCnpj.Text = "";
            txtTipo.Text = "";
            txtTelefone.Text = "";
            txtHistorico.Text = "";
           
        }
        private void btVoltar(object sender, RoutedEventArgs e)
        {
          this.Close();

        }

        private void txtEstado_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
