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
//            var query = conn.Query();
//            query.CommandText = "INSERT INTO Cliente (nome_cli, rg_cli, telefone_cli, email_cli, data_nasc_cli, cpf_cli, sexo_cli, endereco_cli) " +
//                                   "VALUES (@_nome, @_rg, @_telefone, @_email, @_data_nascimento, @_cpf, @_sexo, @_endereco)";

//            query.Parameters.AddWithValue("@_nome", t.nome);
//            query.Parameters.AddWithValue("@_rg", t.rg);
//            query.Parameters.AddWithValue("@_telefone", t.telefone);
//            query.Parameters.AddWithValue("@_email", t.email);
//            query.Parameters.AddWithValue("@_data_nascimento", t.dataNasc);
//            query.Parameters.AddWithValue("@_cpf", t.cpf);
//            query.Parameters.AddWithValue("@_sexo", t.sexo);
//            query.Parameters.AddWithValue("@_endereco", t.endereco);


//            var retorno = query.ExecuteNonQuery();

//            if (retorno == 0)
//                throw new Exception("Não foi possível");

//        }
//        public Funcionario GetById(int id)
//        {
            

//        }

//        public List<Cliente> List()
//        {
//            try
//            {
//                List<Cliente> list = new List<Cliente>();

//                var query = conn.Query();
//                query.CommandText = "SELECT * FROM funcionario LEFT JOIN sexo ON cod_sex = cod_sex_fk";

//                MySqlDataReader reader = query.ExecuteReader();

//                while (reader.Read())
//                {
//                    list.Add(new Funcionario()
//                    {
//                        Id = reader.GetInt32("cod_func"),
//                        Nome = DAOHelper.GetString(reader, "nome_func"),
//                        CPF = DAOHelper.GetString(reader, "cpf_func"),
//                        RG = DAOHelper.GetString(reader, "rg_func"),
//                        DataNascimento = DAOHelper.GetDateTime(reader, "datanasc_func"),
//                        Email = DAOHelper.GetString(reader, "email_func"),
//                        Celular = DAOHelper.GetString(reader, "celular_func"),
//                        Funcao = DAOHelper.GetString(reader, "funcao_func"),
//                        Salario = DAOHelper.GetDouble(reader, "salario_func"),
//                        Sexo = DAOHelper.IsNull(reader, "cod_sex_fk") ? null : new Sexo() { Id = reader.GetInt32("cod_sex"), Nome = reader.GetString("nome_sex") }
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

//        public void Update(Cliente t)
//        {
//            try
//            {
//                long enderecoId = t.Endereco.Id;
//                var endDAO = new EnderecoDAO();

//                if (enderecoId > 0)
//                    endDAO.Update(t.Endereco);
//                else
//                    enderecoId = endDAO.Insert(t.Endereco);

//                var query = conn.Query();
//                query.CommandText = "UPDATE funcionario SET nome_func = @nome, cpf_func = @cpf, rg_func = @rg, datanasc_func = @datanasc, " +
//                    "email_func = @email, celular_func = @celular, funcao_func = @funcao, salario_func = @salario, " +
//                    "cod_sex_fk = @sexo, cod_end_fk = @enderecoId WHERE cod_func = @id";

//                query.Parameters.AddWithValue("@nome", t.Nome);
//                query.Parameters.AddWithValue("@cpf", t.CPF);
//                query.Parameters.AddWithValue("@rg", t.RG);
//                query.Parameters.AddWithValue("@datanasc", t.DataNascimento?.ToString("yyyy-MM-dd")); //"10/11/1990" -> "1990-11-10"
//                query.Parameters.AddWithValue("@email", t.Email);
//                query.Parameters.AddWithValue("@celular", t.Celular);
//                query.Parameters.AddWithValue("@funcao", t.Funcao);
//                query.Parameters.AddWithValue("@salario", t.Salario);
//                query.Parameters.AddWithValue("@sexo", t.Sexo.Id);
//                query.Parameters.AddWithValue("@enderecoId", enderecoId);

//                query.Parameters.AddWithValue("@id", t.Id);

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
