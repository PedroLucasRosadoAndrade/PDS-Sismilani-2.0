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
    internal class ProdutoDAO : IDAO<Produto>
    {
        private static Conexao conn;

        public ProdutoDAO()
        {
            conn = new Conexao();
        }


        public void Delete(Produto t)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = "DELETE FROM produto WHERE id_prod = @id";

                query.Parameters.AddWithValue("@id", t.id);

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

        public Produto GetById(int id)
        {
            try
            {
                var query = conn.Query();

                query.CommandText = "SELECT * FROM produto ";

                query.Parameters.AddWithValue("@id", id);

                MySqlDataReader reader = query.ExecuteReader();

                if (!reader.HasRows)
                    throw new Exception("Nenhum registro foi encontrado!");

                var produto = new Produto();

                while (reader.Read())
                {
                    produto.id = reader.GetInt32("id_prod");
                    produto.marca = reader.GetString("marca_prod");
                    produto.nome = reader.GetString("nome_prod");
                    produto.tipo = reader.GetString(" tipo_prod");
                    produto.quantidade = reader.GetInt32("quantidade_prod");
                    produto.validade = reader.GetDateTime("validade_prod");
                    produto.valor = reader.GetInt32("valor_prod");

                }
                return produto;
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

        public void Insert(Produto t)
        {
            try
            {

                var query = conn.Query();
                query.CommandText = "INSERT INTO Produto (nome_prod,marca_prod ,tipo_prod,quantidade_prod,validade_prod, valor_prod) " +
                                    "VALUES (@_nome_prod,@_ marca_prod,@_tipo_prod,@_quantidade_prod, @_validade_prod,@_valor_prod)";

                query.Parameters.AddWithValue("@id", t.id);
                query.Parameters.AddWithValue("@_nome_prod", t.nome);
                query.Parameters.AddWithValue("@_marca_prod", t.marca);
                query.Parameters.AddWithValue("@_tipo_prod", t.tipo);
                query.Parameters.AddWithValue("@_quantidade_prod", t.quantidade);
                query.Parameters.AddWithValue("@_validade_prod", t.validade);
                query.Parameters.AddWithValue("@_valor_prod", t.valor);


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

        public List<Produto> List()
        {
            try
            {
                List<Produto> list = new List<Produto>();

                var query = conn.Query();
                query.CommandText = "SELECT * FROM Produto";

                MySqlDataReader reader = query.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(new Produto()
                    {
                        nome = DAOHelper.GetString(reader, "nome_prod"),
                        marca = DAOHelper.GetString(reader, "marca_prod"),
                        tipo = DAOHelper.GetString(reader, "tipo_prod"),
                        quantidade = DAOHelper.GetInt32(reader, "quantidade_prod"),
                        validade = (DateTime)DAOHelper.GetDateTime(reader, "validade_prod"),
                        valor = DAOHelper.GetInt32(reader, "valor_prod"),

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

        public void Update(Produto t)
        {

            try
            {
                var query = conn.Query();
                query.CommandText = "UPDATE produto set nome_prod = @_nome_prod, marca_prod = @_marca_prod ,tipo_prod = @_tipo_prod,quantidade_prod = @_quantidade_prod,validade_prod = @_validade_prod,valor_prod = @_valor_prod";


                query.Parameters.AddWithValue("@_nome", t.nome);
                query.Parameters.AddWithValue("@_marca", t.marca);
                query.Parameters.AddWithValue("@_tipo", t.tipo);
                query.Parameters.AddWithValue("@_quantidade", t.quantidade);
                query.Parameters.AddWithValue("@_validade", t.validade);
                query.Parameters.AddWithValue("@_valor", t.valor);

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
