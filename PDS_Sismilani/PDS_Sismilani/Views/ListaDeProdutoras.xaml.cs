using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
//using MySqlX.XDevAPI;
using PDS_Sismilani.Models;
using static System.Net.Mime.MediaTypeNames;
using Button = System.Windows.Controls.Button;

namespace PDS_Sismilani.Views
{
    /// <summary>
    /// Lógica interna para ListaDeProdutoras.xaml
    /// </summary>
    public partial class ListaDeProdutoras : Window
    {
        ObservableCollection<Produtoracla> Produtoras = new ObservableCollection<Produtoracla>();

        public ListaDeProdutoras()
        {
            InitializeComponent();
            ProdutorasDataGrid.ItemsSource = Produtoras;
            this.DataContext = this;
            LoadDataGrid();
        }

        private void LoadDataGrid()
        {
            try
            {
                var dao = new ProdutoraDAO();
                var produtorasList = dao.List();
                Produtoras.Clear();
                foreach (var produtora in produtorasList)
                {
                    Produtoras.Add(produtora);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro ao carregar produtoras", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BotaoFechar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        
        private void BotaoAdd_Click(object sender, RoutedEventArgs e)
        {
            var addProdutoraWindow = new AddProdutora();
            var result = addProdutoraWindow.ShowDialog();

            if (result.HasValue && result.Value)
            {
                // Recarregar a lista se uma nova produtora foi adicionada
                LoadDataGrid();
            }
        }

        private void BotaoEditar_Click(object sender, RoutedEventArgs e)
        {
            // Obtenha o item selecionado para editar
            if (ProdutorasDataGrid.SelectedItem is Produtoracla selectedProdutora)
            {
                // Abra a janela de edição e passe o item selecionado
                var editWindow = new AddProdutora(selectedProdutora);
                editWindow.ShowDialog();

                // Recarregue a lista para refletir as alterações
                LoadDataGrid();
            }
            else
            {
                MessageBox.Show("Por favor, selecione uma produtora para editar.", "Seleção Necessária", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void BotaoDeletar_Click(object sender, RoutedEventArgs e)
        {
            // Obtenha o item selecionado para deletar
            if (ProdutorasDataGrid.SelectedItem is Produtoracla selectedProdutora)
            {
                var result = MessageBox.Show($"Deseja realmente remover a produtora '{selectedProdutora.Nome}'?", "Confirmação de Exclusão",
                    MessageBoxButton.YesNo, MessageBoxImage.Warning);

                if (result == MessageBoxResult.Yes)
                {
                    try
                    {
                        var dao = new ProdutoraDAO();
                        dao.Delete(selectedProdutora);
                        Produtoras.Remove(selectedProdutora);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Erro ao deletar produtora", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecione uma produtora para deletar.", "Seleção Necessária", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void BtaoFilmes_Click(object sender, RoutedEventArgs e)
        {
            var Filmes = new ListaDeFilmes();
            Filmes.ShowDialog();
        }

        private void BtaoHome_Click(object sender, RoutedEventArgs e)
        {
            var home = new Home().ShowDialog();
            var cadastrarFun = new CadastrarFuncionario();
            cadastrarFun.Close();
        }
    }
    
}
