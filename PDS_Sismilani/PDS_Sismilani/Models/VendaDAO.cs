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
using Org.BouncyCastle.Utilities.Collections;
using System.Windows.Markup;

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
            try
            {
                var query = conn.Query();
                query.CommandText = "DELETE FROM vendas WHERE id_ven = @id";

                query.Parameters.AddWithValue("@id", t.Id);

                var result = query.ExecuteNonQuery();

                if (result == 0)
                    throw new Exception("Registro não removido da base de dados. Verifique e tente novamente.");

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
                    venda.Hora = DAOHelper.GetString(reader, "nascimento_fun");
                    venda.QuantidadesDeprodutos = DAOHelper.GetString(reader, "quantidade_ven");
                    venda.Descricao = DAOHelper.GetString(reader, "descricao_ven");
                    venda.IdRec = reader.GetInt32("Funcionario_id_fun");
                    venda.IdFun = reader.GetInt32("recebimento_id_rec");

                    //if (!DAOHelper.IsNull(reader, "recebimento_id_rec"))
                    //    venda.IdRec = new IdRec()
                    //    {
                    //        Id = reader.GetInt32("recebimento_id_rec"),
                    //        Nome = reader.GetString("nome_sex")
                    //    };

                    //if (!DAOHelper.IsNull(reader, "Funcionario_id_fun"))
                    //    venda.IdFun = new IdFun()
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
            try
            {
                //Inserção do Endereço do Funcionário
                //var enderecoId = new EnderecoDAO().Insert(t.Endereco);


                //PROCEDURE `inserir_funcionario`(IN nome varchar(200), IN cpf varchar(20), IN rg varchar(20),
                //                                     IN datanasc date, IN email varchar(200), IN celular varchar(50), 
                //                                    IN funcao varchar(50),
                //                                     IN salario double)

                var query = conn.Query();
                query.CommandText = "INSERT INTO vendas " +
                    "(Data_ven, Data_ven, hota_ven, quantidade_ven, descricao_ven, recebimento_id_rec, telefone_fun, rg_fun, sexo_fun) " +
                    "VALUES (@data, @horav, @qunatidade,  @descricao, @idfunc, @idrec)";

                //query.CommandText = "CALL inserir_funcionario(@nome, @datanasc, @cpf, @salario, @salario, @funcao, @email, @celular, @rg, @sexo)";

                //query.Parameters.AddWithValue("id", t.Id);
                query.Parameters.AddWithValue("@data", t.DataVen?.ToString("yyyy-MM-dd")); //"10/11/1990" -> "1990-11-10"
                query.Parameters.AddWithValue("@horav", t.Hora);
                query.Parameters.AddWithValue("@qunatidade", t.QuantidadesDeprodutos);
                query.Parameters.AddWithValue("@descricao", t.Descricao);
                query.Parameters.AddWithValue("@idfunc", t.IdFun);
                query.Parameters.AddWithValue("@idrec", t.IdRec);

                var result = query.ExecuteNonQuery();

                if (result == 0)
                    throw new Exception("O registro não foi inserido. Verifique e tente novamente");


                MySqlDataReader reader = query.ExecuteReader();

                while (reader.Read())
                {
                    if (reader.GetName(0).Equals("Alerta"))
                    {
                        throw new Exception(reader.GetString("Alerta"));
                    }
                }


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

        public List<Venda> List()
        {
            try
            {
                List<Venda> list = new List<Venda>();

                var query = conn.Query();
                //query.CommandText = "SELECT * FROM funcionario LEFT JOIN sexo ON cod_sex = cod_sex_fk";
                query.CommandText = "SELECT * FROM vendas";

                MySqlDataReader reader = query.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(new Venda()
                    {
                        Id = reader.GetInt32("id_ven"),
                        DataVen = (DateTime)DAOHelper.GetDateTime(reader, "Data_ven"),
                        Hora = DAOHelper.GetString(reader, "hota_ven"),
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

            try
            {
                //long enderecoId = t.Endereco.Id;
                //var endDAO = new EnderecoDAO();

                //if (enderecoId > 0)
                //    endDAO.Update(t.Endereco);
                //else
                //    enderecoId = endDAO.Insert(t.Endereco);

                var query = conn.Query();

                query.CommandText = "UPDATE vendas SET Data_ven = @data, hota_ven = @horav, quantidade_ven = @qunatidade, descricao_ven = @descricao, " +
                    "Funcionario_id_fun = @idfunc, recebimento_id_rec = @idrec WHERE id_ven = @id";

                query.Parameters.AddWithValue("@data", t.DataVen?.ToString("yyyy-MM-dd")); //"10/11/1990" -> "1990-11-10"
                query.Parameters.AddWithValue("@horav", t.Hora);
                query.Parameters.AddWithValue("@quantidade", t.QuantidadesDeprodutos);
                query.Parameters.AddWithValue("@descricao", t.Descricao);
                query.Parameters.AddWithValue("@idfunc", t.IdFun);
                query.Parameters.AddWithValue("@idrec", t.IdRec);
                query.Parameters.AddWithValue("@data", t.Id);


                var result = query.ExecuteNonQuery();

                if (result == 0)
                    throw new Exception("Atualização do registro não foi realizada.");

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
        List<Venda> IDAO<Venda>.List()
        {
            throw new NotImplementedException();
        }
    }
}
