using MySql.Data.MySqlClient;
using PDS_Sismilani.DataBase;
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
{
    /// <summary>
    /// Lógica interna para AddFilme.xaml
    /// </summary>
    public partial class AddFilme : Window
    {
        MySqlConnection conexao;
        MySqlCommand comando;
      
        public AddFilme()
        {
            InitializeComponent();
        }


        private void Conexao()
        {
            string conexaoString = "server=localhost;database=cinemilani_bd;user=root;password=root;port=3360";
            conexao = new MySqlConnection(conexaoString);
            comando = conexao.CreateCommand();

            conexao.Open();


        }
    }
}
