using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDS_Sismilani.DataBase
{
     class Conexao
     {
        private static string host = "localhost";

          string conexaoString = "server=localhost;database=cinemilani_bd;user=root;password=root;port=3306";
            /*conexao = new MySqlConnection(conexaoString);
            comando = conexao.CreateCommand();*/

        private static string port = "3306";
        
        private static string user = "root";

        private static string password = "root";

        private static string dbName = "bd_Sismilani";


        private static MySqlConnection connection;

        private static MySqlCommand command;
            
        public Conexao() { 
            try
            {
                connection = new MySqlConnection($"server={host};database={dbName};port={port};user={user};password={password}");
                connection.Open();
                  
            } catch(Exception)
            {

                throw;
            }
        }
        public void Close()
        {
            connection.Clone();
        }
     }
}
