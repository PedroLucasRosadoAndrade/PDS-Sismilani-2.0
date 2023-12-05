using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PDS_Sismilani.DataBase;

namespace PDS_Sismilani.Models
{
    internal class ProdutoraDAO
    {
        private static Conexao conn;

        public ProdutoraDAO()
        {
            conn = new Conexao();
        }

        public void Delete(Produtoracla t)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = "DELETE FROM Produtora WHERE id_produ = @id";

                query.Parameters.AddWithValue("@id", t.id);

                var retorno = query.ExecuteNonQuery();

                if (retorno == 0)

                    throw new Exception("Registro não removido. Verifique e tente novamente.");

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

        public void Insert(Produtoracla t)
        {
            try
            {

                var query = conn.Query();
                query.CommandText = "INSERT INTO produtora (nome_produ, CNPJ_produ, telefone_produ, razaoSocial_produ, Tipo_produ, historico_produ) " +
                                      "VALUES (@_nome, @_cnpj, @_telefone, @_razaoSocial, @_tipo, @_historico)";

                query.Parameters.AddWithValue("@_nome", t.nome);
                query.Parameters.AddWithValue("@_cnpj", t.cnpj);
                query.Parameters.AddWithValue("@_telefone", t.telefone);
                query.Parameters.AddWithValue("@_razaoSocial", t.rasao_social);
                query.Parameters.AddWithValue("@_tipo", t.tipo);
                query.Parameters.AddWithValue("@_historico", t.historico);


                var retorno = query.ExecuteNonQuery();


                if (retorno == 0)
                    throw new Exception("Não foi possível comcluir o registro.");
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

        public Produtoracla GetById(int id)
        {
            try
            {
                var query = conn.Query();
                MySqlDataReader reader = query.ExecuteReader();

                if (!reader.HasRows)

                    throw new Exception("Nenhum registro foi encontrado.");

                var produtora = new Produtoracla();

                while (reader.Read())
                {
                    produtora.id = reader.GetInt32("id_produ");
                    produtora.nome = reader.GetString("nome_produ");
                    produtora.cnpj = reader.GetString("CNPJ_produ");
                    produtora.telefone = reader.GetString("telefone_produ");
                    produtora.rasao_social = reader.GetString("razaoSocial_produ");
                    produtora.tipo = reader.GetString("Tipo_produ");
                    produtora.historico = reader.GetString("historico_produ");

                }
                return produtora;

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

        public List<Produtoracla> List()
        {
            try
            {
                List<Produtoracla> list = new List<Produtoracla>();

                var query = conn.Query();
                //query.CommandText = "SELECT * FROM funcionario LEFT JOIN sexo ON cod_sex = cod_sex_fk";

                MySqlDataReader reader = query.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(new Produtoracla()
                    {
                        id = reader.GetInt32("id_produ"),
                        nome = DAOHelper.GetString(reader, "nome_produ"),
                        cnpj = DAOHelper.GetString(reader, "CNPJ_produ"),
                        telefone = DAOHelper.GetString(reader, "telefone_produ"),
                        rasao_social = DAOHelper.GetString(reader, "razaoSocial_produ"),
                        tipo = DAOHelper.GetString(reader, "Tipo_produ"),
                        historico = DAOHelper.GetString(reader, "historico_produ"),

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
        public void Update(Produtoracla t)
        {
            try
            {
                //    long enderecoId = t.Endereco.Id;
                //    var endDAO = new EnderecoDAO();

                //    if (enderecoId > 0)
                //        endDAO.Update(t.Endereco);
                //    else
                //        enderecoId = endDAO.Insert(t.Endereco);

                var query = conn.Query();
                query.CommandText = "INSERT INTO produtora (nome_produ, CNPJ_produ, telefone_produ, razaoSocial_produ, Tipo_produ, historico_produ) " +
                                      "VALUES (@_nome, @_cnpj, @_telefone, @_razaoSocial, @_tipo, @_historico)";

                query.Parameters.AddWithValue("@_nome", t.nome);
                query.Parameters.AddWithValue("@_cnpj", t.cnpj);
                query.Parameters.AddWithValue("@_telefone", t.telefone);
                query.Parameters.AddWithValue("@_razaoSocial", t.rasao_social);
                query.Parameters.AddWithValue("@_tipo", t.tipo);
                query.Parameters.AddWithValue("@_historico", t.historico);

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
    }
}
