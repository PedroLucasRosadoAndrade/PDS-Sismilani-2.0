using PDS_Sismilani.Models;
using System;
using System.Collections.Generic;
using System.Deployment.Internal;
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
    /// Lógica interna para AddProduto.xaml
    /// </summary>
    public partial class AddProduto : Window
    {
        private int _id;

        private Produto _Produto;
        public AddProduto()
        {
            InitializeComponent();
            Loaded += AddProduto_Loaded;

        }

       
        public AddProduto(int id)
        {
            InitializeComponent();
           
            Loaded += AddProduto_Loaded;

            _id = id;
        }

        private void AddProduto_Loaded(object sender, RoutedEventArgs e)
        {
            if (_id > 0)
            {
                _Produto = new Produto(); // Mova a inicialização para dentro do if
                FillForm();
            }
            else
            {
                _Produto = new Produto();
            }
        }
      

        private void BtVoltar(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        private void BtSalvar(object sender, RoutedEventArgs e)
        {
          
                _Produto.Id = _id;
                _Produto.Nome = txtNome.Text;
                _Produto.Marca = txtMarca.Text;
                _Produto.Tipo = txtTipo.Text;
                if (int.TryParse(txtQuantidade.Text, out int quantidade))
                 _Produto.Quantidade = quantidade;

                if (int.TryParse(txtValor.Text, out int valor))
                 _Produto.Valor = valor;

                _Produto.Validade = dtpDataValidade.SelectedDate;


                SaveData();               
        }

        private bool Validate() 
        {
            var validator = new ProdutoValitador();
            var result = validator.Validate(_Produto);

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
                    var dao = new ProdutoDAO();
                    var text = "atualizado";

                    if (_Produto.Id == 0)
                    {
                        dao.Insert(_Produto);
                        text = "adicionado";
                    }
                    else
                        dao.Update(_Produto);

                    MessageBox.Show($"O Produto foi {text} com sucesso!", "Sucesso", MessageBoxButton.OK, MessageBoxImage.Information);
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
                var dao = new ProdutoDAO();
                _Produto = dao.GetById(_id);

                txtId.Text = _Produto.Id.ToString();
                txtNome.Text = _Produto.Nome;
                txtMarca.Text = _Produto.Marca;
                txtTipo.Text = _Produto.Tipo;
                txtQuantidade.Text = _Produto.Quantidade.ToString();
                txtValor.Text = _Produto.Valor.ToString();
                dtpDataValidade.SelectedDate = _Produto.Validade;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exceção", MessageBoxButton.OK, MessageBoxImage.Error);
            }
  
        }


        private void CloseFormVerify()
        {
            if (_Produto.Id == 0)
            {
                var result = MessageBox.Show("Deseja continuar adicionando novos produtos?", "Continuar?", MessageBoxButton.YesNo, MessageBoxImage.Question);

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
            txtMarca.Text = "";
            txtTipo.Text = "";
            txtQuantidade.Text = "";
            txtValor.Text = "";
           dtpDataValidade.SelectedDate = null;
           
        }

    }
}
