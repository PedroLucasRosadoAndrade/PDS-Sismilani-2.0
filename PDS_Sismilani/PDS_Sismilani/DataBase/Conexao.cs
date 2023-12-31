﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace PDS_Sismilani.DataBase
{
     class Conexao
     {
        private static string host = "localhost";

        private static string port = "3306";
        
        private static string user = "root";

        private static string password = "root";

        private static string dbName = "cinemilani_bd";


        private static MySqlConnection connection;

        private static MySqlCommand command;
            
        public Conexao() { 
            try
            {
                connection = new MySqlConnection($"server={host};database={dbName};port={port};user={user};password={password}");
                connection.Open();
                  
            } catch(Exception e)
            {
                
                throw e;
                
            }
        }

        public MySqlCommand Query()
        {
            try
            {
                command = connection.CreateCommand();
                command.CommandType = CommandType.Text;

                return command;
            }
            catch (Exception)
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
