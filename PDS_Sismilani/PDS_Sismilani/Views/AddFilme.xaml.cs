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
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PDS_Sismilani.Views
{
    /// <summary>
    /// Lógica interna para AddFilme.xaml
    /// </summary>
    public partial class AddFilme : Window
    {
        private int _id;

        private Filme _filme;
        // MySqlConnection conexao;
        // MySqlCommand comando;
        // ObservableCollection<Filme> filmes = new ObservableCollection<Filme>();

        public AddFilme()
        {
            InitializeComponent();
            Loaded += AddFilme_Loaded;
        }


        public AddFilme(int id)
        {
            InitializeComponent();

            Loaded += AddFilme_Loaded;

            _id = id;
        }

        private void AddFilme_Loaded(object sender, RoutedEventArgs e)
        {
            _filme = new Filme();

            if (_id > 0)
                FillForm();
        }


        private void BtVoltar(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtSalvar(object sender, RoutedEventArgs e)
        {

            _filme.Id = _id;
            _filme.Titulo = txtTitulo.Text;
            _filme.Fornecedor = txtFornecedor.Text;
            _filme.Categoria = txtCategoria.Text;
            _filme.Elenco = txtElenco.Text;
            _filme.Diretor = txtDiretor.Text;
            _filme.DataLancamento = datePickerData.SelectedDate;

            SaveData();

        }

        //private bool Validate()
        //{
        //    var validator = new FilmeValitador();
        //    var result = validator.Validate(_filme);

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

        private void SaveData()
        {
            try
            {
                var dao = new FilmeDAO();
                var text = "atualizado";

                if (_filme.Id == 0)
                {
                    dao.Insert(_filme);
                    text = "adicionado";
                }
                else
                    dao.Update(_filme);

                MessageBox.Show($"O Filme foi {text} com sucesso!", "Sucesso", MessageBoxButton.OK, MessageBoxImage.Information);
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
                var dao = new FilmeDAO();
                _filme = dao.GetById(_id);

                txtId.Text = _filme.Id.ToString();
                txtTitulo.Text = _filme.Titulo;
                txtSinopse.Text = _filme.Sinopse;
                txtFornecedor.Text = _filme.Fornecedor;
                txtDiretor.Text = _filme.Diretor;
                txtElenco.Text = _filme.Elenco;
                txtCategoria.Text = _filme.Categoria;
                datePickerData.SelectedDate = _filme.DataLancamento;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exceção", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CloseFormVerify()
        {
            if (_filme.Id == 0)
            {
                var result = MessageBox.Show("Deseja continuar adicionando novos filmes?", "Continuar?", MessageBoxButton.YesNo, MessageBoxImage.Question);

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
            txtId.Text = "";
            txtTitulo.Text = "";
            txtSinopse.Text = "";
            txtFornecedor.Text = "";
            txtDiretor.Text = "";
            txtElenco.Text = "";
            txtCategoria.Text = "";
            datePickerData.SelectedDate = null;

        }




    }
}

