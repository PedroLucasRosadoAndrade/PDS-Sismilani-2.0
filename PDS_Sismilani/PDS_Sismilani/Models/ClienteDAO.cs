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
using System.Data.SqlClient;

namespace PDS_Sismilani.Models
{
    class ClienteDAO : IDAO<Cliente>
    {
        private static Conexao conn;
        public ClienteDAO()
        {
            conn = new Conexao();
        }
        public List<Cliente> List()
        {
            try
            {
                List<Cliente> list = new List<Cliente>();

                var query = conn.Query();
                //query.CommandText = "SELECT * FROM cliente LEFT JOIN sexo ON cod_sex = cod_sex_fk";
                query.CommandText = "SELECT * FROM cliente";

                MySqlDataReader reader = query.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(new Cliente()
                    {
                        id = reader.GetInt32("id_cli"),
                        nome = DAOHelper.GetString(reader, "nome_cli"),
                        cpf = DAOHelper.GetString(reader, "cpf_cli"),
                        rg = DAOHelper.GetString(reader, "rg_cli"),
                        dataNasc = (DateTime)DAOHelper.GetDateTime(reader, "data_nasc_cli"),
                        email = DAOHelper.GetString(reader, "email_cli"),
                        telefone = DAOHelper.GetString(reader, "telefone_cli"),
                        sexo = DAOHelper.GetString(reader, "sexo_cli"),
                        endereco = DAOHelper.GetString(reader, "endereco_cli")
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
        public Cliente GetById(int id)
        {
            try
            {
                var query = conn.Query();
                MySqlDataReader reader = query.ExecuteReader();

                if (!reader.HasRows)

                    throw new Exception("Nenhum registro foi encontrado.");

                var cliente = new Cliente();

                while (reader.Read())
                {
                    cliente.id = reader.GetInt32("id_cli");
                    cliente.nome = reader.GetString("nome_cli");
                    cliente.rg = reader.GetString("rg_cli");
                    cliente.telefone = reader.GetString("telefone_cli");
                    cliente.email = reader.GetString("email_cli");
                    cliente.dataNasc = reader.GetDateTime("data_nasc_cli");
                    cliente.cpf = reader.GetString("cpf_cli");
                    cliente.sexo = reader.GetString("sexo_cli");
                    cliente.endereco = reader.GetString("endereco_cli");
                }

                return cliente;
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
        public void Delete(Cliente t)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = "DELETE FROM Cliente WHERE id_cli = @id";

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


        public void Insert(Cliente t)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = "INSERT INTO cliente (nome_cli, rg_cli, telefone_cli, email_cli, data_nasc_cli, cpf_cli, sexo_cli, endereco_cli) " +
                                       "VALUES (@_nome, @_rg, @_telefone, @_email, @_data_nascimento, @_cpf, @_sexo, @_endereco)";

                query.Parameters.AddWithValue("@_nome", t.nome);
                query.Parameters.AddWithValue("@_rg", t.rg);
                query.Parameters.AddWithValue("@_telefone", t.telefone);
                query.Parameters.AddWithValue("@_email", t.email);
                query.Parameters.AddWithValue("@_data_nascimento", t.dataNasc);
                query.Parameters.AddWithValue("@_cpf", t.cpf);
                query.Parameters.AddWithValue("@_sexo", t.sexo);
                query.Parameters.AddWithValue("@_endereco", t.endereco);


                var retorno = query.ExecuteNonQuery();

                if (retorno == 0)
                    throw new Exception("Não foi possível comcluir o registro.");

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


        public void Update(Cliente t)
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
                query.CommandText = "UPDATE cliente SET nome_cli = @nome, cpf_cli = @cpf, rg_cli = @rg, data_nasc_cli = @datanasc, " +
                    "email_cli = @email, telefone_cli = @telefone, endereco_cli = @endereco_cli";


                query.Parameters.AddWithValue("@nome", t.nome);
                query.Parameters.AddWithValue("@cpf", t.cpf);
                query.Parameters.AddWithValue("@rg", t.rg);
                query.Parameters.AddWithValue("@datanasc", t.dataNasc.ToString("yyyy-MM-dd")); //"10/11/1990" -> "1990-11-10"
                query.Parameters.AddWithValue("@email", t.email);
                query.Parameters.AddWithValue("@telefone", t.telefone);
                query.Parameters.AddWithValue("@sexo", t.sexo);
                query.Parameters.AddWithValue("@endereco", t.endereco);

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

//using MySql.Data.MySqlClient;
//using PDS_Sismilani.DataBase;
//using PDS_Sismilani.Helpers;
//using PDS_Sismilani.Interfaces;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows;
//namespace PDS_Sismilani.Models
//{
//    class ClienteDAO : IDAO<Cliente>
//    {
//        private static Conexao conn;
//        public ClienteDAO()
//        {
//            conn = new Conexao();
//        }
//        public List<Cliente> List()
//        {
//            try
//            {
//                List<Cliente> list = new List<Cliente>();
//                var query = conn.Query();
//                query.CommandText = "SELECT * FROM cliente";
//                MySqlDataReader reader = query.ExecuteReader();
//                while (reader.Read())
//                {
//                    list.Add(new Cliente()
//                    {
//                        id = reader.GetInt32("id_cli"),
//                        nome = DAOHelper.GetString(reader, "nome_cli"),
//                        cpf = DAOHelper.GetString(reader, "cpf_cli"),
//                        rg = DAOHelper.GetString(reader, "rg_cli"),
//                        dataNasc = (DateTime)DAOHelper.GetDateTime(reader, "data_nasc_cli"),
//                        email = DAOHelper.GetString(reader, "email_cli"),
//                        telefone = DAOHelper.GetString(reader, "telefone_cli"),
//                        sexo = DAOHelper.GetString(reader, "sexo_cli"),
//                        endereco = DAOHelper.GetString(reader, "endereco_cli")
//                    });
//                }
//                return list;
//            }
//            catch (Exception e)
//            {
//                throw e;
//            }
//            finally
//            {
//                conn.Close();
//            }
//        }
//        public void Delete(Cliente t)
//        {
//            try
//            {
//                var query = conn.Query();
//                query.CommandText = "DELETE FROM Cliente WHERE id_cli = @id";
//                query.Parameters.AddWithValue("@id", t.id);
//                var retorno = query.ExecuteNonQuery();
//                if (retorno == 0)
//                    throw new Exception("Registro não removido. Verifique e tente novamente.");
//            }
//            catch (Exception e)
//            {
//                throw e;
//            }
//            finally
//            {
//                conn.Close();
//            }
//        }
//        public void Insert(Cliente t)
//        {
//            try
//            {
//                var query = conn.Query();
//                query.CommandText = "INSERT INTO cliente (nome_cli, rg_cli, telefone_cli, email_cli, data_nasc_cli, cpf_cli, sexo_cli, endereco_cli) " +
//                                       "VALUES (@_nome, @_rg, @_telefone, @_email, @_data_nascimento, @_cpf, @_sexo, @_endereco)";
//                query.Parameters.AddWithValue("@_nome", t.nome);
//                query.Parameters.AddWithValue("@_rg", t.rg);
//                query.Parameters.AddWithValue("@_telefone", t.telefone);
//                query.Parameters.AddWithValue("@_email", t.email);
//                query.Parameters.AddWithValue("@_data_nascimento", t.dataNasc);
//                query.Parameters.AddWithValue("@_cpf", t.cpf);
//                query.Parameters.AddWithValue("@_sexo", t.sexo);
//                query.Parameters.AddWithValue("@_endereco", t.endereco);
//                var retorno = query.ExecuteNonQuery();
//                if (retorno == 0)
//                    throw new Exception("Não foi possível comcluir o registro.");
//            }
//            catch (Exception e)
//            {
//                throw e;
//            }
//            finally
//            {
//                conn.Close();
//            }
//        }
//        public Cliente GetById(int id)
//        {
//            try
//            {
//                var query = conn.Query();
//                MySqlDataReader reader = query.ExecuteReader();
//                if (!reader.HasRows)
//                    throw new Exception("Nenhum registro foi encontrado.");
//                var cliente = new Cliente();
//                while (reader.Read())
//                {
//                    cliente.id = reader.GetInt32("id_cli");
//                    cliente.nome = reader.GetString("nome_cli");
//                    cliente.rg = reader.GetString("rg_cli");
//                    cliente.telefone = reader.GetString("telefone_cli");
//                    cliente.email = reader.GetString("email_cli");
//                    cliente.dataNasc = reader.GetDateTime("data_nasc_cli");
//                    cliente.cpf = reader.GetString("cpf_cli");
//                    cliente.sexo = reader.GetString("sexo_cli");
//                    cliente.endereco = reader.GetString("endereco_cli");
//                }

//                return cliente;
//            }
//            catch (Exception e)
//            {
//                throw e;
//            }
//            finally
//            {
//                conn.Close();
//            }
//        }

//        public void Update(Cliente t)
//        {
//            try
//            {
//                //    long enderecoId = t.Endereco.Id;
//                //    var endDAO = new EnderecoDAO();
//                //    if (enderecoId > 0)
//                //        endDAO.Update(t.Endereco);
//                //    else
//                //        enderecoId = endDAO.Insert(t.Endereco);
//                var query = conn.Query();
//                query.CommandText = "UPDATE cliente SET nome_cli = @nome, cpf_cli = @cpf, rg_cli = @rg, data_nasc_cli = @datanasc, " +
//                    "email_cli = @email, telefone_cli = @telefone, endereco_cli = @endereco_cli";
//                query.Parameters.AddWithValue("@nome", t.nome);
//                query.Parameters.AddWithValue("@cpf", t.cpf);
//                query.Parameters.AddWithValue("@rg", t.rg);
//                query.Parameters.AddWithValue("@datanasc", t.dataNasc.ToString("yyyy-MM-dd")); //"10/11/1990" -> "1990-11-10"
//                query.Parameters.AddWithValue("@email", t.email);
//                query.Parameters.AddWithValue("@telefone", t.telefone);
//                query.Parameters.AddWithValue("@sexo", t.sexo);
//                query.Parameters.AddWithValue("@endereco", t.endereco);
//                query.Parameters.AddWithValue("@id", t.id);
//                var result = query.ExecuteNonQuery();
//                if (result == 0)
//                    throw new Exception("Atualização do registro não foi realizada.");
//            }
//            catch (Exception e)
//            {
//                throw e;
//            }
//            finally
//            {
//                conn.Close();
//            }
//        }
//    }
//}
//--------------------------------------------------------------------------------


