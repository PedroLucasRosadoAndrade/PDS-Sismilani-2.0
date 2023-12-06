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
using System.Windows.Navigation;
using System.Windows.Shapes;
using PDS_Sismilani.Models;
using static System.Net.Mime.MediaTypeNames;
using Button = System.Windows.Controls.Button;

namespace PDS_Sismilani.Views
{
    /// <summary>
    /// Interação lógica para ListaDeFornecedores.xam
    /// </summary>
    public partial class ListaDeFornecedores : Window
    {
        ObservableCollection<Fornecedor> Fornecedores = new ObservableCollection<Fornecedor>();

        public ListaDeFornecedores()
        {
            InitializeComponent();
            FornecedoresDataGrid.ItemsSource = Fornecedores;
            this.DataContext = this;
            LoadDataGrid();
        }

        private void LoadDataGrid()
        {
            try
            {
                var dao = new FornecedorDAO();
                var fornecedoresList = dao.List();
                Fornecedores.Clear();
                foreach (var fornecedor in fornecedoresList)
                {
                    Fornecedores.Add(fornecedor);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro ao carregar fornecedores", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BotaoFechar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BotaoAdd_Click(object sender, RoutedEventArgs e)
        {
            var addFornecedorWindow = new CadastrarFornecedor();
            var result = addFornecedorWindow.ShowDialog();

            if (result.HasValue && result.Value)
            {
                LoadDataGrid();
            }

        }

        private void BotaoEditar_Click(object sender, RoutedEventArgs e)
        {
            if (FornecedoresDataGrid.SelectedItem is Fornecedor selectedFornecedor)
            {
                // Instanciação corrigida sem passar argumentos
                var editWindow = new CadastrarFornecedor();
                editWindow.ShowDialog();
                LoadDataGrid();
            }
            else
            {
                MessageBox.Show("Por favor, selecione um fornecedor para editar.", "Seleção Necessária", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void BotaoDeletar_Click(object sender, RoutedEventArgs e)
        {
            if (FornecedoresDataGrid.SelectedItem is Fornecedor selectedFornecedor)
            {
                var result = MessageBox.Show($"Deseja realmente remover o fornecedor '{selectedFornecedor.Nome}'?", "Confirmação de Exclusão",
                    MessageBoxButton.YesNo, MessageBoxImage.Warning);

                if (result == MessageBoxResult.Yes)
                {
                    try
                    {
                        var dao = new FornecedorDAO();
                        dao.Delete(selectedFornecedor);
                        Fornecedores.Remove(selectedFornecedor);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Erro ao deletar fornecedor", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecione um fornecedor para deletar.", "Seleção Necessária", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        

        // Outros botões e lógica aqui, conforme necessário
    }

}
