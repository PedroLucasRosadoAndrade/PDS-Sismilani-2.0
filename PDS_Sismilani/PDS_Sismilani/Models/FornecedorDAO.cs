using MySql.Data.MySqlClient;
using PDS_Sismilani.DataBase;
using PDS_Sismilani.Helpers;
using PDS_Sismilani.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDS_Sismilani.Models
{
    internal class FornecedorDAO : IDAO<Fornecedor>
    {
        private static Conexao conn;

        public FornecedorDAO()
        {
            conn = new Conexao();
        }
        public void Delete(Fornecedor t)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = "DELETE FROM Fornecedor WHERE id_for = @id";

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

        public Fornecedor GetById(int id)
        {
            try
            {
                var query = conn.Query();
                //query.CommandText = "SELECT * FROM funcionario " +
                //                                "LEFT JOIN sexo ON cod_sex = cod_sex_fk " +
                //                                "LEFT JOIN endereco ON cod_end = cod_end_fk " +
                //                                "WHERE cod_func = @id";
                query.CommandText = "SELECT * FROM forncedor";

                query.Parameters.AddWithValue("@id", id);

                MySqlDataReader reader = query.ExecuteReader();

                if (!reader.HasRows)
                    throw new Exception("Nenhum registro foi encontrado!");

                var fornecedor = new Fornecedor();

                while (reader.Read())
                {

                    fornecedor.Id = reader.GetInt32("id_for");
                    fornecedor.Nome = reader.GetString("Nome_for");
                    fornecedor.CNPJ = reader.GetString("CNPJ_for");
                    fornecedor.tipo = reader.GetString("tipo_for");
                    fornecedor.telefone = reader.GetString("telefone_for");
                    fornecedor.historico = reader.GetString("historico_for");
                    
                }

                return fornecedor;
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

        public void Insert(Fornecedor t)
        {
            try
            {
 
                var query = conn.Query();
                query.CommandText = "INSERT INTO Fornecedor " +
                    "(Nome_for, CNPJ_for, tipo_for, telefone_for, historico_for) " +
                    "VALUES (@nome, @cnpj, @tipo, @telefone, @historico)";

                //query.CommandText = "CALL inserir_funcionario(@nome, @datanasc, @cpf, @salario, @salario, @funcao, @email, @celular, @rg, @sexo)";

                //query.Parameters.AddWithValue("id", t.Id);
                query.Parameters.AddWithValue("@nome", t.Nome);
                query.Parameters.AddWithValue("@cnpj", t.CNPJ); //"10/11/1990" -> "1990-11-10"
                query.Parameters.AddWithValue("@tipo", t.tipo);
                query.Parameters.AddWithValue("@telefone", t.telefone);
                query.Parameters.AddWithValue("@historico", t.historico);
                

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

        public List<Fornecedor> List()
        {
            try
            {
                List<Fornecedor> list = new List<Fornecedor>();

                var query = conn.Query();
                query.CommandText = "SELECT * FROM Fornecedor";

                MySqlDataReader reader = query.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(new Fornecedor()
                    {
                        Id = reader.GetInt32("id_for"),
                        Nome = DAOHelper.GetString(reader, "Nome_for"),
                        CNPJ = DAOHelper.GetString(reader, "CNPJ_for"),
                        tipo = DAOHelper.GetString(reader, "tipo_for"),
                        telefone = DAOHelper.GetString(reader, "telefone_for"),
                        historico = DAOHelper.GetString(reader, "historico_for")


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

        public void Update(Fornecedor t)
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
                
                query.CommandText = "UPDATE Fornecedor SET Nome_for = @nome, CNPJ_for = @cnpj, tipo_for = @tipo, telefone_for = @telefone, " +
                    "historico_for = @historico WHERE id_for = @id";

                query.Parameters.AddWithValue("@nome", t.Nome);
                query.Parameters.AddWithValue("@cnpj", t.CNPJ); //"10/11/1990" -> "1990-11-10"
                query.Parameters.AddWithValue("@tipo", t.tipo);
                query.Parameters.AddWithValue("@telefone", t.telefone);
                query.Parameters.AddWithValue("@historico", t.historico);
                query.Parameters.AddWithValue("@id", t.Id);

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
    }
}
