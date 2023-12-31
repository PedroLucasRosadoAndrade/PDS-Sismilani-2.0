﻿using PDS_Sismilani.Interfaces;
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
    internal class FuncionarioDAO : IDAO<Funcionario>
    {
        private static Conexao conn;

        public FuncionarioDAO()
        {
            conn = new Conexao();
        }

        public void Delete(Funcionario t)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = "DELETE FROM funcionario WHERE id_fun = @id";

                query.Parameters.AddWithValue("@id", t.Id);

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

       public Funcionario GetById(int id)
       {
            try
            {
                var query = conn.Query();
                //query.CommandText = "SELECT * FROM funcionario " +
                //                                "LEFT JOIN sexo ON cod_sex = cod_sex_fk " +
                //                                "LEFT JOIN endereco ON cod_end = cod_end_fk " +
                //                                "WHERE cod_func = @id";
                query.CommandText = "SELECT * FROM funcionario WHERE id_fun = @id";

                query.Parameters.AddWithValue("@id", id);

                MySqlDataReader reader = query.ExecuteReader();

                if (!reader.HasRows)
                    throw new Exception("Nenhum registro foi encontrado!");

                var funcionario = new Funcionario();

                while (reader.Read())
                {

                    funcionario.Id = reader.GetInt32("id_fun");
                    funcionario.Nome = reader.GetString("Nome_fun");
                    funcionario.DataNascimento = DAOHelper.GetDateTime(reader, "nascimento_fun");
                    funcionario.CPF = reader.GetString("cpf_fun");
                    funcionario.Salario = DAOHelper.GetDouble(reader, "salario_fun");
                    funcionario.Funcao = reader.GetString("funcao_fun");
                    funcionario.Celular = reader.GetString("telefone_fun");
                    funcionario.Email = reader.GetString("email_fun");
                    funcionario.RG = reader.GetString("rg_fun");
                    funcionario.Sexo = reader.GetString("sexo_fun");

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

                return funcionario;
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

       public void Insert(Funcionario t)
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
                query.CommandText = "INSERT INTO funcionario " +
                    "(Nome_fun, nascimento_fun, cpf_fun, salario_fun, funcao_fun, email_fun, telefone_fun, rg_fun, sexo_fun) " +
                    "VALUES (@nome, @datanasc, @cpf, @salario, @funcao, @email, @celular, @rg, @sexo)";

                //query.CommandText = "CALL inserir_funcionario(@nome, @datanasc, @cpf, @salario, @salario, @funcao, @email, @celular, @rg, @sexo)";

                //query.Parameters.AddWithValue("id", t.Id);
                query.Parameters.AddWithValue("@nome", t.Nome);
                query.Parameters.AddWithValue("@datanasc", t.DataNascimento?.ToString("yyyy-MM-dd")); //"10/11/1990" -> "1990-11-10"
                query.Parameters.AddWithValue("@cpf", t.CPF);
                query.Parameters.AddWithValue("@salario", t.Salario);
                query.Parameters.AddWithValue("@funcao", t.Funcao);
                query.Parameters.AddWithValue("@email", t.Email);
                query.Parameters.AddWithValue("@celular", t.Celular);
                query.Parameters.AddWithValue("@rg", t.RG);
                query.Parameters.AddWithValue("@sexo", t.Sexo);

                var result = query.ExecuteNonQuery();

                if (result == 0)
                    throw new Exception("O registro não foi inserido. Verifique e tente novamente");

                
                MySqlDataReader reader = query.ExecuteReader();

                while (reader.Read())
                {
                    if(reader.GetName(0).Equals("Alerta"))
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

       
        public List<Funcionario> List()
        {
            try
            {
                List<Funcionario> list = new List<Funcionario>();

                var query = conn.Query();
                //query.CommandText = "SELECT * FROM funcionario LEFT JOIN sexo ON cod_sex = cod_sex_fk";
                query.CommandText = "SELECT * FROM Funcionario";

                MySqlDataReader reader = query.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(new Funcionario()
                    {
                        Id = reader.GetInt32("id_fun"),
                        Nome = DAOHelper.GetString(reader, "Nome_fun"),
                        DataNascimento = DAOHelper.GetDateTime(reader, "nascimento_fun"),
                        CPF = DAOHelper.GetString(reader, "cpf_fun"),
                        Salario = DAOHelper.GetDouble(reader, "salario_fun"),
                        Funcao = DAOHelper.GetString(reader, "funcao_fun"),
                        Email = DAOHelper.GetString(reader, "email_fun"),
                        Celular = DAOHelper.GetString(reader, "telefone_fun"),
                        RG = DAOHelper.GetString(reader, "rg_fun"),
                        Sexo = DAOHelper.GetString(reader, "sexo_fun")

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

        public void Update(Funcionario t)
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

                query.CommandText = "UPDATE funcionario SET Nome_fun = @nome, cpf_fun = @cpf, rg_fun = @rg, nascimento_fun = @datanasc, " +
                    "email_fun = @email, telefone_fun = @celular, funcao_fun = @funcao, salario_fun = @salario, " +
                    "sexo_fun = @sexo WHERE id_fun = @id";

                query.Parameters.AddWithValue("@nome", t.Nome);
                query.Parameters.AddWithValue("@datanasc", t.DataNascimento?.ToString("yyyy-MM-dd")); //"10/11/1990" -> "1990-11-10"
                query.Parameters.AddWithValue("@cpf", t.CPF);
                query.Parameters.AddWithValue("@funcao", t.Funcao);
                query.Parameters.AddWithValue("@salario", t.Salario);
                query.Parameters.AddWithValue("@email", t.Email);
                query.Parameters.AddWithValue("@celular", t.Celular);
                query.Parameters.AddWithValue("@rg", t.RG);
                query.Parameters.AddWithValue("@sexo", t.Sexo);
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
        List<Funcionario> IDAO<Funcionario>.List()
        {
            throw new NotImplementedException();
        }

        public int TotalFuncionarios()
        {
            var query = conn.Query();

            query.CommandText = "SELECT COUNT(*) FROM funcionario";

            //MySqlDataReader reader = query.ExecuteReader();

            int totalFuncionarios = (int)query.ExecuteScalar();

            return totalFuncionarios;

        }
    }
}
