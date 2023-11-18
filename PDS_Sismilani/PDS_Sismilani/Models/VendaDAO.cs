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
            try
            {
                var query = conn.Query();
                //query.CommandText = "SELECT * FROM funcionario " +
                //                                "LEFT JOIN sexo ON cod_sex = cod_sex_fk " +
                //                                "LEFT JOIN endereco ON cod_end = cod_end_fk " +
                //                                "WHERE cod_func = @id";
                query.CommandText = "SELECT * FROM vendas";

                query.Parameters.AddWithValue("@id", id);

                MySqlDataReader reader = query.ExecuteReader();

                if (!reader.HasRows)
                    throw new Exception("Nenhum registro foi encontrado!");

                var venda = new Venda();

                while (reader.Read())
                {

                    venda.Id = reader.GetInt32("id_fun");
                    venda.DataVen = (DateTime)DAOHelper.GetDateTime(reader, "Data_ven");
                    venda.Hora = (DateTime)DAOHelper.GetDateTime(reader, "nascimento_fun");
                    venda.QuantidadesDeprodutos = DAOHelper.GetString(reader, "quantidade_ven");
                    venda.Descricao = DAOHelper.GetString(reader, "descricao_ven");
                    venda.IdRec = reader.GetInt32("Funcionario_id_fun");
                    venda.IdFun = reader.GetInt32("recebimento_id_rec");
                   
                    //if (!DAOHelper.IsNull(reader, "cod_sex_fk"))
                    //    funcionario.Sexo = new Sexo()
                    //    {
                    //        Id = reader.GetInt32("cod_sex"),
                    //        Nome = reader.GetString("nome_sex")
                    //    };

                    //if (!DAOHelper.IsNull(reader, "cod_end_fk"))
                    //    funcionario.Endereco = new Endereco()
                    //    {
                    //        Id = reader.GetInt32("cod_end"),
                    //        Rua = reader.GetString("rua_end"),
                    //        Numero = reader.GetInt32("numero_end"),
                    //        Bairro = reader.GetString("bairro_end"),
                    //        Cidade = reader.GetString("cidade_end"),
                    //        Estado = reader.GetString("estado_end")
                    //    };
                }

                return venda;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                conn.Query();
            }
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
                        IdFun = reader.GetInt32("Funcionario_id_fun"),
                        IdRec = reader.GetInt32("recebimento_id_rec")

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
