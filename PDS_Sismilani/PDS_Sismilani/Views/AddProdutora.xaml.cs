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
    /// Lógica interna para AddProdutora.xaml
    /// </summary>
    public partial class AddProdutora : Window
    {
        private ProdutoraDAO _dao;
        private Produtoracla _produtora; 

        public AddProdutora()
        {
            InitializeComponent();
            _dao = new ProdutoraDAO();
            _produtora = new Produtoracla(); // Inicialize a produtora
        }

        internal AddProdutora(Produtoracla produtora) : this()
        {
            _produtora = produtora;
            txtId.Text = produtora.Id.ToString();
            txtNome.Text = produtora.Nome;
            txtCNPJ.Text = produtora.CNPJ;
            txtTelefone.Text = produtora.Telefone;
            txtRazaoSocial.Text = produtora.RazaoSocial;
            txtTipo.Text = produtora.Tipo;
            txtHistorico.Text = produtora.Historico;
        }

        private void btnSalvar_Click(object sender, RoutedEventArgs e)
        {
            // Coleta os dados dos TextBoxes e atualiza o objeto _produtora
            _produtora.Nome = txtNome.Text;
            _produtora.CNPJ = txtCNPJ.Text;
            _produtora.Telefone = txtTelefone.Text;
            _produtora.RazaoSocial = txtRazaoSocial.Text;
            _produtora.Tipo = txtTipo.Text;
            _produtora.Historico = txtHistorico.Text;

            try
            {
                if (_produtora.Id > 0)
                {
                    // Se o ID é maior que 0, então é uma atualização
                    _dao.Update(_produtora);
                }
                else
                {
                    // Caso contrário, é uma inserção
                    _dao.Insert(_produtora);
                }
                MessageBox.Show("Produtora salva com sucesso!", "Sucesso", MessageBoxButton.OK, MessageBoxImage.Information);
                this.DialogResult = true;
                this.Close(); // Fecha a janela após salvar

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao salvar a produtora: " + ex.Message, "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
        }

        private void btnVoltar_Click(object sender, RoutedEventArgs e)
        {
            this.Close(); // Simplesmente fecha a janela

        }
    }
}
