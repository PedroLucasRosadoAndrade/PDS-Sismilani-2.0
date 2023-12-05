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
using PDS_Sismilani.Interfaces;
using System.Windows.Documents;

namespace PDS_Sismilani.Models
{
    internal class ProdutDAO : IDAO<Produt>
    {
        private Conexao conn;

        public ProdutDAO()
        {
            conn = new Conexao();
        }

        public void Delete(Produt t)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = "DELETE FROM Produto WHERE id_prod = @id";

                query.Parameters.AddWithValue("@id", t.id);

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

        public Produt GetById(int id)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = "SELECT * FROM produto WHERE id_prod = @id";

                query.Parameters.AddWithValue("@id", id);

                MySqlDataReader reader = query.ExecuteReader();

                if (!reader.HasRows)
                    throw new Exception("Nenhum registro foi encontrado!");

                var produt = new Produt();

                while (reader.Read())
                {

                    produt.id = reader.GetInt32("id_prod");
                    produt.nome = reader.GetString("nome_prod");
                    produt.marca = reader.GetString("Marca_prod");
                    produt.tipo = reader.GetString("tipo_prod");
                    produt.quantidade = reader.GetInt32("quantidade_prod");
                    produt.validade = DAOHelper.GetDateTime(reader, "validade_prod");
                    produt.valor = reader.GetDouble("valor_prod");
                    produt.idFor = reader.GetInt32("id_for_fk");
                    produt.idEst = reader.GetInt32("id_est_fk");
                   
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

                return produt;
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

        public void Insert(Produt t)
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
                query.CommandText = "INSERT INTO produto " +
                    "(nome_prod, Marca_prod, tipo_prod, quantidade_prod, validade_prod, valor_prod, id_for_fk, id_est_fk) " +
                    "VALUES (@nome, @marca, @tipo, @quntidade, @validade, @valor, @idfor, @idest)";

                //query.CommandText = "CALL inserir_funcionario(@nome, @datanasc, @cpf, @salario, @salario, @funcao, @email, @celular, @rg, @sexo)";

                //query.Parameters.AddWithValue("id", t.Id);
                query.Parameters.AddWithValue("@nome", t.nome);
                query.Parameters.AddWithValue("@marca", t.marca);
                query.Parameters.AddWithValue("@tipo", t.tipo);
                query.Parameters.AddWithValue("@quntidade", t.quantidade);
                query.Parameters.AddWithValue("@validade", t.validade?.ToString("yyyy-MM-dd")); //"10/11/1990" -> "1990-11-10"
                query.Parameters.AddWithValue("@valor", t.valor);
                query.Parameters.AddWithValue("@idfor", t.idFor);
                query.Parameters.AddWithValue("@idest", t.idEst);

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

        public List<Produt> List()
        {
            try
            {
                List<Produt> list = new List<Produt>();

                var query = conn.Query();
                //query.CommandText = "SELECT * FROM funcionario LEFT JOIN sexo ON cod_sex = cod_sex_fk";
                query.CommandText = "SELECT * FROM produto";

                MySqlDataReader reader = query.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(new Produt()
                    {
                        id = reader.GetInt32("id_prod"),
                        nome = DAOHelper.GetString(reader, "nome_prod"),
                        marca = DAOHelper.GetString(reader, "Marca_prod"),
                        tipo = DAOHelper.GetString(reader, "tipo_prod"),
                        quantidade = DAOHelper.GetInt32(reader, "quantidade_prod"),
                        validade = DAOHelper.GetDateTime(reader, "validade_prod"),
                        valor = DAOHelper.GetDouble(reader, "valor_prod"),
                        idFor = DAOHelper.GetInt32(reader, "id_for_fk"),
                        idEst = DAOHelper.GetInt32(reader, "id_est_fk")

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

        public void Update(Produt t)
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

                query.CommandText = "UPDATE produto SET nome_prod = @nome, Marca_prod = @marca, tipo_prod = @tipo, quantidade_prod = @quntidade, " +
                    "validade_prod = @validade, valor_prod = @valor, idfor = @idfor, id_est_fk = @idest WHERE id_prod = @id";

                query.Parameters.AddWithValue("@nome", t.nome);
                query.Parameters.AddWithValue("@marca", t.marca);
                query.Parameters.AddWithValue("@tipo", t.tipo);
                query.Parameters.AddWithValue("@quntidade", t.quantidade);
                query.Parameters.AddWithValue("@validade", t.validade?.ToString("yyyy-MM-dd")); //"10/11/1990" -> "1990-11-10"
                query.Parameters.AddWithValue("@valor", t.valor);
                query.Parameters.AddWithValue("@idfor", t.idFor);
                query.Parameters.AddWithValue("@idest", t.idEst);
                query.Parameters.AddWithValue("@id", t.id);

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
        List<Produt> IDAO<Produt>.List()
        {
            throw new NotImplementedException();
        }
    }
}
