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

namespace PDS_Sismilani.Views

/// <summary>
/// Lógica interna para CadastrarDespesa.xaml
/// </summary>
{
    public partial class CadastrarDespesa : Window
    {
        public CadastrarDespesa()
        {
            InitializeComponent();
        }

        private void btSalvar_Click(object sender, RoutedEventArgs e)
        {
            string descricao = txtDescricao.Text;
            string cnpj = txtCNPJ.Text;
            string formaPagamento = FormaDePagamento.ToString();
            double valor;

            if (double.TryParse(txtValor.Text, out valor))
            {
                DateTime data = dpData.SelectedDate ?? DateTime.Now;



                MessageBox.Show("Valor inválido. Insira um valor numérico.");
            }
        }


        private void btVoltar(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}