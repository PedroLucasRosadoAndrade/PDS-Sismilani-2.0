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
using PDS_Sismilani.Models;
using PDS_Sismilani.Helpers;
using System.Windows.Media.TextFormatting;

namespace PDS_Sismilani.Views
{
    /// <summary>
    /// Lógica interna para EditProdut.xaml
    /// </summary>
    public partial class EditProdut : Window
    {
        private int _id;

        private Produt _produt;

        public EditProdut()
        {
            InitializeComponent();
            Loaded += EditProdut_Loaded;
        }
        public EditProdut(int id)
        {
            _id = id;
            InitializeComponent();
            Loaded += EditProdut_Loaded;
        }

        private void EditProdut_Loaded(object sender, RoutedEventArgs e)
        {
            _produt = new Produt();

            //LoadComboBox();

            if (_id > 0)
                FillForm();
        }

        private void BtSalvar(object sender, RoutedEventArgs e)
        {
            //_produt.id = _id;
            //_produt.nome = txtNome.Text;
            //_produt.marca = txtCpf.Text;
            //_produt.quantidade = txtFuncao.Text;
            //_produt.tipo = txtEmail.Text;
            //_produt.validade = dtpValidade.SelectedDate;
            //_produt.valor = txtCeluar.Text;
            //_produt.DataNascimento = dtpDataNasc.SelectedDate;

            //if (double.TryParse(txtSalario.Text, out double salario))
            //    _funcionario.Salario = salario;

            ////if (dtpDataNasc.SelectedDate != null)
            ////    _funcionario.DataNascimento = (DateTime)dtpDataNasc.SelectedDate;

            //SaveData();

        }

        private void FillForm()
        {
            try
            {
                var dao = new ProdutDAO();
                _produt = dao.GetById(_id);


                txtId.Text = _produt.id.ToString();
                txtNome.Text = _produt.nome;
                txtMarca.Text = _produt.marca;
                txtQtd.Text = _produt.quantidade.ToString();
                txtTipo.Text = _produt.tipo;
                dtpValidade.SelectedDate = _produt.validade;
                txtValor.Text = _produt.valor.ToString()    ;
                txtForne.Text = _produt.idFor.ToString();
                txtEsto.Text = _produt.idEst.ToString();

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
    }
}
