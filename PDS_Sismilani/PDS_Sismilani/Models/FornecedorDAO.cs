using MySql.Data.MySqlClient;
using PDS_Sismilani.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDS_Sismilani.Models
{
    internal class FornecedorDAO
    {
        private static Conexao conn;

        public FornecedorDAO()
        {
            conn = new Conexao();
        }

        public Fornecedor GetById(int id)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = "SELECT * FROM Fornecedor WHERE id_for = @id";
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
                    // Adicione outras propriedades conforme necessário
                }
                reader.Close();
                return fornecedor;
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
            var lista = new List<Fornecedor>();
            var query = conn.Query();
            query.CommandText = "SELECT * FROM Fornecedor";

            try
            {
                MySqlDataReader reader = query.ExecuteReader();
                while (reader.Read())
                {
                    lista.Add(new Fornecedor()
                    {
                        Id = reader.GetInt32("id_for"),
                        Nome = reader.GetString("Nome_for"),
                        CNPJ = reader.GetString("CNPJ_for"),
                        tipo = reader.GetString("tipo_for"),
                        telefone = reader.GetString("telefone_for"),
                        historico = reader.GetString("historico_for"),

                        // Adicione outras propriedades conforme necessário
                    });
                }
                reader.Close();
                return lista;
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

        public void Insert(Fornecedor fornecedor)
        {
            var query = conn.Query();
            query.CommandText = "INSERT INTO Fornecedor (Nome_fornec, CNPJ_fornec, telefone_fornec) " +
                                "VALUES (@nome, @cnpj, @telefone)";

            query.Parameters.AddWithValue("@nome", fornecedor.Nome);
            query.Parameters.AddWithValue("@cnpj", fornecedor.CNPJ);
            query.Parameters.AddWithValue("@tipo", fornecedor.tipo);
            query.Parameters.AddWithValue("@telefone", fornecedor.telefone);
            query.Parameters.AddWithValue("@historico", fornecedor.historico);
            // Adicione outras propriedades conforme necessário

            try
            {
                query.ExecuteNonQuery();
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

        public void Update(Fornecedor fornecedor)
        {
            var query = conn.Query();
            query.CommandText = "UPDATE Fornecedor SET Nome_for = @nome, CNPJ_for = @cnpj, telefone_for = @telefone WHERE id_for = @id";

            query.Parameters.AddWithValue("@id", fornecedor.Id);
            query.Parameters.AddWithValue("@nome", fornecedor.Nome);
            query.Parameters.AddWithValue("@cnpj", fornecedor.CNPJ);
            query.Parameters.AddWithValue("@tipo", fornecedor.tipo);
            query.Parameters.AddWithValue("@telefone", fornecedor.telefone);
            query.Parameters.AddWithValue("@historico", fornecedor.historico);
            // Adicione outras propriedades conforme necessário

            try
            {
                query.ExecuteNonQuery();
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

        public void Delete(Fornecedor fornecedor)
        {
            var query = conn.Query();
            query.CommandText = "DELETE FROM Fornecedor WHERE id_for = @id";
            query.Parameters.AddWithValue("@id", fornecedor.Id);

            try
            {
                query.ExecuteNonQuery();
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
