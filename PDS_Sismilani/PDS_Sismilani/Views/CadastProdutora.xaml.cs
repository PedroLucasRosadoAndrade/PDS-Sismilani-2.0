using FluentValidation;
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

namespace PDS_Sismilani.Views
{
    /// <summary>
    /// Lógica interna para Produtora.xaml
    /// </summary>
    public partial class CadastProdutora : Window
    {
        private int _id;

        private Produtoracla _produtora;
        public CadastProdutora()
        {
            InitializeComponent();
            Loaded += CadastProdutora_Loaded;
        }
        public CadastProdutora(int id)
        {
            _id = id;
            InitializeComponent();
            Loaded += CadastProdutora_Loaded;
        }
        private void CadastProdutora_Loaded(object sender, RoutedEventArgs e)
        {
            _produtora = new Produtoracla();

            //LoadComboBox();

            if (_id > 0)
                FillForm();
        }
        private void btVoltar(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btSalvar(object sender, RoutedEventArgs e)
        {
            _produtora.id = _id;
            _produtora.nome = txtNome.Text;
            _produtora.cnpj = txtCnpj.Text;
            _produtora.telefone = txtTelefone.Text;
            _produtora.rasao_social = txtRazao_social.Text;
            _produtora.tipo = txtTipo.Text;
            _produtora.historico = txtHistorico.Text;

            SaveData();
        }
        private void SaveData()
        {
            try
            {
                var dao = new ProdutoraDAO();
                var text = "atualizado";

                 if (_produtora.id == 0)
                 {
                    dao.Insert(_produtora);
                    text = "adicionado";
                 }
                 else
                    dao.Update(_produtora);
                MessageBox.Show($"O Funcionário foi {text} com sucesso!", "Sucesso", MessageBoxButton.OK, MessageBoxImage.Information);
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
                var dao = new ProdutoraDAO  ();
                _produtora = dao.GetById(_id);


                //txtId.Text = _funcionario.Id.ToString();
                txtNome.Text = _produtora.nome;
                txtCnpj.Text = _produtora.cnpj;
                txtTelefone.Text = _produtora.telefone;
                txtRazao_social.Text = _produtora.rasao_social;
                txtTipo.Text = _produtora.tipo;
                txtHistorico.Text = _produtora.historico;
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exceção", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void CloseFormVerify()
        {
            if (_produtora.id == 0)
            {
                var result = MessageBox.Show("Deseja continuar adicionando Produtoras?", "Continuar?", MessageBoxButton.YesNo, MessageBoxImage.Question);

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
            txtTelefone.Text = "";
            txtRazao_social.Text = "";
            txtTipo.Text = ""; 
            txtHistorico.Text = "";
        }

    }
}
