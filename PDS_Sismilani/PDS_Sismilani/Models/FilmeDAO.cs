using PDS_Sismilani.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PDS_Sismilani.Helpers;
using PDS_Sismilani.Models;
using MySql.Data.MySqlClient;
using PDS_Sismilani.DataBase;
using PDS_Sismilani.Views;

namespace PDS_Sismilani.Models
{
    internal class FilmeDAO : IDAO<Filme>
    {
        private static Conexao conn;

        public FilmeDAO()
        {
            conn = new Conexao();
        }


        public void Delete(Filme t)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = "DELETE FROM filme WHERE id_film = @id";
                query.Parameters.AddWithValue("@id", t.Id);

                var result = query.ExecuteNonQuery();
                if (result == 0)
                    throw new Exception("Registro não deletado da base de dados. Verifique e tente novamente.");
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
        public Filme GetById(int id)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = "SELECT * FROM filme WHERE id_film = @id";
                query.Parameters.AddWithValue("@id", id);

                MySqlDataReader reader = query.ExecuteReader();
                if (!reader.HasRows)
                    throw new Exception("Nenhum registro foi encontrado!");

                var filme = new Filme();
                while (reader.Read())
                {
                    filme.Id = reader.GetInt32("id_film");
                    filme.Titulo = reader.GetString("titulo_film");
                    filme.Fornecedor = reader.GetString("fornecedor_film");
                    filme.Sinopse = reader.GetString("sinopse_film");
                    filme.Categoria = reader.GetString("categoria_film");
                    filme.Diretor = reader.GetString("diretor_film");
                    filme.Elenco = reader.GetString("elenco_film");
                    filme.DataLancamento = reader.GetDateTime("data_film");
                }
                reader.Close(); // Não esqueça de fechar o reader
                return filme;
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

        public void Insert(Filme t)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = "INSERT INTO Filme (titulo_film, fornecedor_film, categoria_film, dataLancamento_film, sinopse_film, elenco_film, diretor_film) " +
                                    "VALUES (@_titulo_film, @_fornecedor_film, @_categoria_film, @_dataLancamento_film, @_sinopse_film, @_elenco_film, @_diretor_film)";

                // Corrigir os nomes dos parâmetros para corresponder à query
                query.Parameters.AddWithValue("@_titulo_film", t.Titulo);
                query.Parameters.AddWithValue("@_fornecedor_film", t.Fornecedor);
                query.Parameters.AddWithValue("@_categoria_film", t.Categoria);
                query.Parameters.AddWithValue("@_dataLancamento_film", t.DataLancamento ?? (object)DBNull.Value); // Lida com DataLancamento nula
                query.Parameters.AddWithValue("@_sinopse_film", t.Sinopse);
                query.Parameters.AddWithValue("@_elenco_film", t.Elenco);
                query.Parameters.AddWithValue("@_diretor_film", t.Diretor);

                var result = query.ExecuteNonQuery();

                if (result == 0)
                    throw new Exception("O registro não foi inserido. Verifique e tente novamente");
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


        public List<Filme> List()
        {
            try
            {
                List<Filme> list = new List<Filme>();
                var query = conn.Query();
                query.CommandText = "SELECT * FROM Filme";

                MySqlDataReader reader = query.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new Filme()
                    {
                        Id = reader.GetInt32("id_film"), // Você também precisa obter o ID aqui
                        Titulo = DAOHelper.GetString(reader, "titulo_film"),
                        Fornecedor = DAOHelper.GetString(reader, "fornecedor_film"),
                        Sinopse = DAOHelper.GetString(reader, "sinopse_film"),
                        Categoria = DAOHelper.GetString(reader, "categoria_film"),
                        Diretor = DAOHelper.GetString(reader, "diretor_film"),
                        Elenco = DAOHelper.GetString(reader, "elenco_film"),
                        DataLancamento = DAOHelper.GetDateTime(reader, "data_film")
                    });
                }
                reader.Close(); // Não esqueça de fechar o reader
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

        public void Update(Filme t)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = "UPDATE filme SET titulo_film = @_titulo_film, fornecedor_film = @_fornecedor_film, categoria_film = @_categoria_film, dataLancamento_film = @_dataLancamento_film, " +
                    "sinopse_film = @_sinopse_film, elenco_film = @_elenco_film, diretor_film = @_diretor_film WHERE id_film = @_id";

                // Corrigir os nomes dos parâmetros para corresponder à query e adicionar o parâmetro do ID
                query.Parameters.AddWithValue("@_id", t.Id);
                query.Parameters.AddWithValue("@_titulo_film", t.Titulo);
                query.Parameters.AddWithValue("@_fornecedor_film", t.Fornecedor);
                query.Parameters.AddWithValue("@_categoria_film", t.Categoria);
                query.Parameters.AddWithValue("@_dataLancamento_film", t.DataLancamento ?? (object)DBNull.Value); // Lida com DataLancamento nula
                query.Parameters.AddWithValue("@_sinopse_film", t.Sinopse);
                query.Parameters.AddWithValue("@_elenco_film", t.Elenco);
                query.Parameters.AddWithValue("@_diretor_film", t.Diretor);

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

