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
            query.CommandText = "INSERT INTO Produto" + 
                    "(nome_prod,Marca_prod ,tipo_prod,quantidade_prod,validade_prod, valor_prod) " +
                     "VALUES (@nome,@Marca,@tipo,@quantidade, @validade,@valor)";

            //query.Parameters.AddWithValue("@id", t.Id);
            query.Parameters.AddWithValue("@nome", t.Nome);
            query.Parameters.AddWithValue("@Marca", t.Marca);
            query.Parameters.AddWithValue("@tipo", t.Tipo);
            query.Parameters.AddWithValue("@quantidade", t.Quantidade);
            query.Parameters.AddWithValue("@validade", t.Validade);
            query.Parameters.AddWithValue("@valor", t.Valor);


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
                    Valor = DAOHelper.GetInt32(reader, "valor_prod"),

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


        List<Produto> IDAO<Produto>.List()
        {
            throw new NotImplementedException();
        }

        public void Update(Produto t)
        {

        try
        {
            var query = conn.Query();
            query.CommandText = "UPDATE produto Set nome_prod = @nome, Marca_prod = @marca ,tipo_prod = @tipo ," +
                "quantidade_prod = @quantidade,validade_prod = @validade,valor_prod = @valor,WHERE id_prod = @id";


            query.Parameters.AddWithValue("@_nome", t.Nome);
            query.Parameters.AddWithValue("@_marca", t.Marca);
            query.Parameters.AddWithValue("@_tipo", t.Tipo);
            query.Parameters.AddWithValue("@_quantidade", t.Quantidade);
            query.Parameters.AddWithValue("@_validade", t.Validade?.ToString("yyyy-MM-dd"));
            query.Parameters.AddWithValue("@_valor", t.Valor);
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

    


        public int TotalProdutos()
        {
            var query = conn.Query();

            query.CommandText = "SELECT COUNT(*) FROM produto";


            int totalProdutos = (int)query.ExecuteScalar();

            return totalProdutos;

        }
    }
}
 
