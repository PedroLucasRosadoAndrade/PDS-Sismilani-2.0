using MySql.Data.MySqlClient;
using PDS_Sismilani.DataBase;
using PDS_Sismilani.Helpers;
using PDS_Sismilani.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PDS_Sismilani.Views;

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

    public Produto GetById(int id)
    {
        try
        {
            var query = conn.Query();
            query.CommandText = "SELECT * FROM produto WHERE id_prod = @id";
            query.Parameters.AddWithValue("@id", id);

            MySqlDataReader reader = query.ExecuteReader();

            if (!reader.HasRows)
                throw new Exception("Nenhum registro foi encontrado!");

            var produto = new Produto();

            while (reader.Read())
            {
                produto.Id = reader.GetInt32("id_prod");
                produto.Nome = reader.GetString("nome_prod");
                produto.Marca = reader.GetString("Marca_prod");
                produto.Tipo = reader.GetString(" tipo_prod");
                produto.Quantidade = reader.GetInt32("quantidade_prod");
                produto.Validade = reader.GetDateTime("validade_prod");
                produto.Valor = reader.GetInt32("valor_prod");
            }
                reader.Close();
                return produto;
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

    public void Insert(Produto t)
    {
        try
        {

            var query = conn.Query();
            query.CommandText = "INSERT INTO Produto(nome_prod,Marca_prod ,tipo_prod,quantidade_prod,validade_prod, valor_prod) " +
                                "VALUES (@_nome_prod,@_Marca_prod,@_tipo_prod,@_quantidade_prod, @_validade_prod,@_valor_prod)";

            //query.Parameters.AddWithValue("@id", t.Id);
            query.Parameters.AddWithValue("@_nome_prod", t.Nome);
            query.Parameters.AddWithValue("@_Marca_prod", t.Marca);
            query.Parameters.AddWithValue("@_tipo_prod", t.Tipo);
            query.Parameters.AddWithValue("@_quantidade_prod", t.Quantidade);
            query.Parameters.AddWithValue("@_validade_prod", t.Validade);
            query.Parameters.AddWithValue("@_valor_prod", t.Valor);


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
                    Id = reader.GetInt32("id_prod"),
                    Nome = DAOHelper.GetString(reader, "nome_prod"),
                    Marca = DAOHelper.GetString(reader, "Marca_prod"),
                    Tipo = DAOHelper.GetString(reader, "tipo_prod"),
                    Quantidade = DAOHelper.GetInt32(reader, "quantidade_prod"),
                    Validade = DAOHelper.GetDateTime(reader, "validade_prod"),
                    Valor = DAOHelper.GetInt32(reader, "valor_prod")
                });
            }
               reader.Close();
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


        //List<Produto> IDAO<Produto>.List()
        //{
        //    throw new NotImplementedException();
        //}

        public void Update(Produto t)
        {

        try
        {
            var query = conn.Query();
            query.CommandText = "UPDATE produto SET nome_prod = @_nome_prod, Marca_prod = @_Marca_prod,tipo_prod = @_tipo_prod," +
                "quantidade_prod = @_quantidade_prod, validade_prod = @_validade_prod, valor_prod = @_valor_prod WHERE id_prod = @_id";


            query.Parameters.AddWithValue("@_nome_prod", t.Nome);
            query.Parameters.AddWithValue("@_marca_prod", t.Marca);
            query.Parameters.AddWithValue("@_tipo_prod", t.Tipo);
            query.Parameters.AddWithValue("@_quantidade_prod", t.Quantidade);
            query.Parameters.AddWithValue("@_validade_prod", t.Validade?.ToString("yyyy-MM-dd"));
            query.Parameters.AddWithValue("@_valor_prod", t.Valor);
            query.Parameters.AddWithValue("@_id", t.Id);


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

    


        public int TotalProdutos()
        {
            var query = conn.Query();

            query.CommandText = "SELECT COUNT(*) FROM produto";


            int totalProdutos = (int)query.ExecuteScalar();

            return totalProdutos;

        }
    }
}
 
