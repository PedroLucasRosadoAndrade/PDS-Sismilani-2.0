using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Common;
using PDS_Sismilani.DataBase;
using PDS_Sismilani.Helpers;
using PDS_Sismilani.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

                query.CommandText = "SELECT * FROM filme ";

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
                    filme.Sinopse = reader.GetString(" sinopse_film");
                    filme.Categoria = reader.GetString("categoria_film");
                    filme.Diretor = reader.GetString("diretor_film");
                    filme.Elenco = reader.GetString("elenco_film");
                    //filme.DataLancamento = DAOHelper.GetDateTime(reader, "data_film");

                }
                return filme;
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

        public void Insert(Filme t)
        {
            try
            {

                var query = conn.Query();
                query.CommandText = "INSERT INTO Filme (titulo_film,fornecedor_film ,categoria_film,dataLancamento_film, sinopse_film,elenco_film,diretor_film ) " +
                                    "VALUES (@_titulo_film,@_fornecedor_film ,@_categoria_film,@_dataLancamento_film, @_sinopse_film,@_elenco_film, @_diretor_film)";

                query.Parameters.AddWithValue("@id", t.Id);
                query.Parameters.AddWithValue("@_titulo", t.Titulo);
                query.Parameters.AddWithValue("@_fornecedor", t.Fornecedor);
                query.Parameters.AddWithValue("@_categoria", t.Categoria);
                query.Parameters.AddWithValue("@_dataLancamento", t.DataLancamento);
                query.Parameters.AddWithValue("@_sinopse", t.Sinopse);
                query.Parameters.AddWithValue("@_elenco", t.Elenco);
                query.Parameters.AddWithValue("@_diretor", t.Diretor);

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
                        Titulo = DAOHelper.GetString(reader, "titulo_film"),
                        Fornecedor = DAOHelper.GetString(reader, "fornecedor_film"),
                        Sinopse = DAOHelper.GetString(reader, "sinopse_film"),
                        Categoria = DAOHelper.GetString(reader, "categoria_film"),
                        Diretor = DAOHelper.GetString(reader, "diretor_film"),
                        Elenco = DAOHelper.GetString(reader, "elenco_film"),
                        DataLancamento = (DateTime)DAOHelper.GetDateTime(reader, "data_film")

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

        public void Update(Filme t)
        {

            try
            {
                var query = conn.Query();
                query.CommandText = "UPDATE filme set titulo_film = @_titulo_film, fornecedor_film = @_fornecedor_film ,categoria_film = @_categoria_film,dataLancamento_film = @_dataLancamento_film," +
                    "sinopse_film = @_sinopse_film, elenco_film = @_elenco_film,diretor_film = @_diretor_film";

                query.Parameters.AddWithValue("@_titulo", t.Titulo);
                query.Parameters.AddWithValue("@_fornecedor", t.Fornecedor);
                query.Parameters.AddWithValue("@_categoria", t.Categoria);
                query.Parameters.AddWithValue("@_dataLancamento",t.DataLancamento);
                query.Parameters.AddWithValue("@_sinopse", t.Sinopse);
                query.Parameters.AddWithValue("@_elenco", t.Elenco);
                query.Parameters.AddWithValue("@_diretor", t.Diretor);

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

