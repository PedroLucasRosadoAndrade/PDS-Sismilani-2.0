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
using PDS_Sismilani.Models;
using PDS_Sismilani.Helpers;
using System.Windows.Media.TextFormatting;

namespace PDS_Sismilani.Views
{
    /// <summary>
    /// Lógica interna para addFuncionario.xaml
    /// </summary>
    public partial class addFuncionario : Window
    {
        private int _id;

        private Funcionario _funcionario;

        public addFuncionario()
        {
            InitializeComponent();
            Loaded += addFuncionario_Loaded;
        }

        public addFuncionario(int id)
        {
            _id = id;
            InitializeComponent();
            Loaded += addFuncionario_Loaded;
        }

        private void addFuncionario_Loaded(object sender, RoutedEventArgs e)
        {
            _funcionario = new Funcionario();

            //LoadComboBox();

            if (_id > 0)
                FillForm();
        }
        private void BtSalvar(object sender, RoutedEventArgs e)
        {
            _funcionario.Id = _id;
            _funcionario.Nome = txtNome.Text;
            _funcionario.CPF = txtCpf.Text;
            _funcionario.Funcao = txtFuncao.Text;
            _funcionario.Email = txtEmail.Text;
            _funcionario.RG = txtRg.Text;
            _funcionario.Celular = txtCeluar.Text;
            _funcionario.Sexo= txtSexo.Text;
            //_funcionario.Salario = txtSalario.;
            _funcionario.DataNascimento = dtpDataNasc.SelectedDate;

            if (double.TryParse(txtSalario.Text, out double salario))
                _funcionario.Salario = salario;

            //if (dtpDataNasc.SelectedDate != null)
            //    _funcionario.DataNascimento = (DateTime)dtpDataNasc.SelectedDate;

            SaveData();

            //if (comboBoxSexo.SelectedItem != null)
            //    _funcionario.Sexo = comboBoxSexo.SelectedItem as Sexo;

            //_funcionario.Endereco = new Endereco();
            //_funcionario.Endereco.Rua = txtRua.Text;
            //_funcionario.Endereco.Bairro = txtBairro.Text;
            //_funcionario.Endereco.Cidade = txtCidade.Text;

            //if (int.TryParse(txtNumero.Text, out int numero))
            //    _funcionario.Endereco.Numero = numero;

            //if (comboBoxEstado.SelectedItem != null)
            //    _funcionario.Endereco.Estado = comboBoxEstado.SelectedItem as string;


               //txtNome.Clear();
               // dtpDataNasc.IsEnabled = false;
               // txtCpf.Clear();
               // txtEmail.Clear();
               // txtSalario.Clear();
               // txtFuncao.Clear();
               // txtCeluar.Clear();
               // txtRg.Clear();
               // txtSexo.Clear();
               // txtNome.Focus();
   
        }
        private bool Validate()
        {
            var validator = new FuncionarioValitador();
            var result = validator.Validate(_funcionario);

            if (!result.IsValid)
            {
                string errors = null;
                var count = 1;

                foreach (var failure in result.Errors)
                {
                    errors += $"{count++} - {failure.ErrorMessage}\n";
                }

                MessageBox.Show(errors, "Validação de Dados", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            return result.IsValid;
        }
        private void SaveData()
        {
            try
            {
                if (Validate())
                {
                    var dao = new FuncionarioDAO();
                    var text = "atualizado";

                    if (_funcionario.Id == 0)
                    {
                        dao.Insert(_funcionario);
                        text = "adicionado";
                    }
                    else
                        dao.Update(_funcionario);

                    MessageBox.Show($"O Funcionário foi {text} com sucesso!", "Sucesso", MessageBoxButton.OK, MessageBoxImage.Information);
                    CloseFormVerify();
                }
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
                var dao = new FuncionarioDAO();
                _funcionario = dao.GetById(_id);
                txtId.Text = _funcionario.Id.ToString();
                txtNome.Text = _funcionario.Nome;
                txtCpf.Text = _funcionario.CPF;
                txtRg.Text = _funcionario.RG;
                dtpDataNasc.SelectedDate = _funcionario.DataNascimento;
                txtEmail.Text = _funcionario.Email;
                txtCeluar.Text = _funcionario.Celular;
                txtFuncao.Text = _funcionario.Funcao;
                txtSalario.Text = _funcionario.Salario.ToString();
                txtSexo.Text = _funcionario.Sexo;

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
            if (_funcionario.Id == 0)
            {
                var result = MessageBox.Show("Deseja continuar adicionando funcionários?", "Continuar?", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.No)
                    this.Close();
                else
                    ClearInputs();
            }
            else
                this.Close();
        }


        //exemplo de combo box
        //private void LoadComboBox()
        //{
        //    try
        //    {
        //        comboBoxEstado.ItemsSource = Estado.List();
        //        comboBoxSexo.ItemsSource = new SexoDAO().List();
        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //}

        private void ClearInputs()
        {
           
            txtNome.Text = "";
            txtCpf.Text = "";
            txtRg.Text = "";
            dtpDataNasc.SelectedDate = null;
            txtEmail.Text = "";
            txtCeluar.Text = "";
            txtFuncao.Text = "";
            txtSalario.Text = "";
            txtSexo.Text = "";
        }
        private void btVoltar(object sender, RoutedEventArgs e)
        {
            this.Close();   
        }

    }
}
