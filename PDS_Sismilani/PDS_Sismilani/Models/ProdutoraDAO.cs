using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PDS_Sismilani.DataBase;
using MySql.Data.MySqlClient;
using PDS_Sismilani.Models;
using PDS_Sismilani.Helpers;

namespace PDS_Sismilani.Models
{
    internal class ProdutoraDAO
    {
        private static Conexao conn;

        public ProdutoraDAO()
        {
            conn = new Conexao();
        }

        public Produtoracla GetById(int id)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = "SELECT * FROM Produtora WHERE id_produ = @id";
                query.Parameters.AddWithValue("@id", id);

                MySqlDataReader reader = query.ExecuteReader();
                if (!reader.HasRows)
                    throw new Exception("Nenhum registro foi encontrado!");

                var produtora = new Produtoracla();
                while (reader.Read())
                {
                    produtora.Id = reader.GetInt32("id_produ");
                    produtora.Nome = reader.GetString("Nome_produ");
                    produtora.CNPJ = reader.GetString("CNPJ_produ");
                    produtora.Telefone = reader.GetString("telefone_produ");
                    produtora.RazaoSocial = reader.GetString("razaoSocial_produ");
                    produtora.Tipo = reader.GetString("Tipo_produ");
                    produtora.Historico = reader.GetString("historico_produ");
                }
                reader.Close(); // Feche o reader
                return produtora;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                conn.Close(); // Feche a conexão
            }
        }


        public List<Produtoracla> List()
        {
            var lista = new List<Produtoracla>();
            var query = conn.Query();
            query.CommandText = "SELECT * FROM Produtora";

            try
            {
                MySqlDataReader reader = query.ExecuteReader();
                while (reader.Read())
                {
                    lista.Add(new Produtoracla()
                    {
                        Id = reader.GetInt32("id_produ"),
                        Nome = reader.GetString("Nome_produ"),
                        CNPJ = reader.GetString("CNPJ_produ"),
                        Telefone = reader.GetString("telefone_produ"),
                        RazaoSocial = reader.GetString("razaoSocial_produ"),
                        Tipo = reader.GetString("Tipo_produ"),
                        Historico = reader.GetString("historico_produ")
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

        public void Insert(Produtoracla produtora)
        {
            var query = conn.Query();
            query.CommandText = "INSERT INTO Produtora (Nome_produ, CNPJ_produ, telefone_produ, razaoSocial_produ, Tipo_produ, historico_produ) " +
                                "VALUES (@nome, @cnpj, @telefone, @razaoSocial, @tipo, @historico)";

            query.Parameters.AddWithValue("@nome", produtora.Nome);
            query.Parameters.AddWithValue("@cnpj", produtora.CNPJ);
            query.Parameters.AddWithValue("@telefone", produtora.Telefone);
            query.Parameters.AddWithValue("@razaoSocial", produtora.RazaoSocial);
            query.Parameters.AddWithValue("@tipo", produtora.Tipo);
            query.Parameters.AddWithValue("@historico", produtora.Historico);

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

        public void Update(Produtoracla produtora)
        {
            var query = conn.Query();
            query.CommandText = "UPDATE Produtora SET Nome_produ = @nome, CNPJ_produ = @cnpj, telefone_produ = @telefone, " +
                                "razaoSocial_produ = @razaoSocial, Tipo_produ = @tipo, historico_produ = @historico WHERE id_produ = @id";

            query.Parameters.AddWithValue("@id", produtora.Id);
            query.Parameters.AddWithValue("@nome", produtora.Nome);
            query.Parameters.AddWithValue("@cnpj", produtora.CNPJ);
            query.Parameters.AddWithValue("@telefone", produtora.Telefone);
            query.Parameters.AddWithValue("@razaoSocial", produtora.RazaoSocial);
            query.Parameters.AddWithValue("@tipo", produtora.Tipo);
            query.Parameters.AddWithValue("@historico", produtora.Historico);

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

        public void Delete(Produtoracla produtora)
        {
            var query = conn.Query();
            query.CommandText = "DELETE FROM Produtora WHERE id_produ = @id";
            query.Parameters.AddWithValue("@id", produtora.Id);

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
