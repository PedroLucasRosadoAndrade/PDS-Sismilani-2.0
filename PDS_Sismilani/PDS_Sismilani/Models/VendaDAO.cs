using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using PDS_Sismilani.Helpers;
using PDS_Sismilani.Interfaces;
using PDS_Sismilani.Models;
using PDS_Sismilani.DataBase;
using PDS_Sismilani.Views;

namespace PDS_Sismilani.Models
{
    internal class VendaDAO : IDAO<Venda>
    {
        private static Conexao conn;

        public VendaDAO()
        {
            conn = new Conexao();
        }

        public void Delete(Venda t)
        {
            throw new NotImplementedException();
        }

        public Venda GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Venda t)
        {
            throw new NotImplementedException();
        }

        public List<Venda> List()
        {
            try
            {
                List<Venda> list = new List<Venda>();

                var query = conn.Query();
                //query.CommandText = "SELECT * FROM funcionario LEFT JOIN sexo ON cod_sex = cod_sex_fk";
                query.CommandText = "SELECT * FROM Funcionario";

                MySqlDataReader reader = query.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(new Venda()
                    {
                        Id = reader.GetInt32("id_ven"),
                        DataVen = (DateTime)DAOHelper.GetDateTime(reader, "Data_ven"),
                        Hora = (DateTime)DAOHelper.GetDateTime(reader, "hota_ven"),
                        QuantidadesDeprodutos = DAOHelper.GetString(reader, "quantidade_ven"),
                        Descricao = DAOHelper.GetString(reader, "descricao_ven"),
                        IdFun = reader.GetInt32("rg_fun"),
                        IdRec = reader.GetInt32("nascimento_fun")

                    });
                }

                return list;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                conn.Close();
            }
        }

        public void Update(Venda t)
        {
            throw new NotImplementedException();
        }
        List<Venda> IDAO<Venda>.List()
        {
            throw new NotImplementedException();
        }
    }
}
