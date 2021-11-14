using System.Collections.Generic;
using MySql.Data.MySqlClient;
using api_tcc.Models;
using System.Data;

namespace api_tcc.Repositorio
{
    public class FuncionarioRepositorio
    {
        //metodos CadastrarFuncionario, ConsultarFuncionario, DeletarFuncionario, EditarFuncionario, ListarFuncionario, ConsultarLoginFuncionario
            Conexao cn = new Conexao();
            MySqlCommand cmd = new MySqlCommand();

            public long CadastrarFuncionario(Funcionario func)
            {
                MySqlCommand cmd = new MySqlCommand("Insert into funcionario (nome_func, email_func, user_func, senha_func, tel_func, nivel_acesso) Values ( @nomeFunc, @emailFunc, @userFunc, @senhaFunc, @telFunc, @nivelAcesso)", cn.ConectarBD());
                cmd.Parameters.Add("@nomeFunc", MySqlDbType.VarChar).Value = func.NomeFunc;
                cmd.Parameters.Add("@emailFunc", MySqlDbType.VarChar).Value = func.EmailFunc;
                cmd.Parameters.Add("@userFunc", MySqlDbType.VarChar).Value = func.UserFunc;
                cmd.Parameters.Add("@senhaFunc", MySqlDbType.VarChar).Value = func.SenhaFunc;
                cmd.Parameters.Add("@telFunc", MySqlDbType.VarChar).Value = func.TelFunc;
                cmd.Parameters.Add("@nivelAcesso", MySqlDbType.Int16).Value = func.NivelAcesso;

                cmd.Parameters.Add("@idFunc", MySqlDbType.Int16, 4).Direction = ParameterDirection.Output;

                cmd.ExecuteNonQuery();

                long id = cmd.LastInsertedId;

                cn.DesconectarBD();

                return id;
            }

            public Funcionario ConsultarFuncionario(int id)
            {
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM funcionario where id_func = @id_func", cn.ConectarBD());
                cmd.Parameters.Add("@id_func", MySqlDbType.Int16).Value = id;

                cmd.ExecuteNonQuery();

                MySqlDataReader reader = cmd.ExecuteReader();

                Funcionario func = new Funcionario();

                while (reader.Read())
                {
                func.IdFunc = reader.GetInt16(reader.GetOrdinal("id_func"));
                func.NomeFunc = reader.GetString(reader.GetOrdinal("nome_func"));
                func.EmailFunc = reader.GetString(reader.GetOrdinal("email_func"));
                func.UserFunc = reader.GetString(reader.GetOrdinal("user_func"));
                func.SenhaFunc = reader.GetString(reader.GetOrdinal("senha_func"));
                func.TelFunc = reader.GetString(reader.GetOrdinal("tel_func"));
                func.NivelAcesso = reader.GetInt16(reader.GetOrdinal("nivel_acesso"));
                }

                reader.Close();

                cn.DesconectarBD();

                return func;
            }

        public Funcionario ConsultarUserFuncionario(string user)
        {
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM funcionario where user_func = @user_func", cn.ConectarBD());
            cmd.Parameters.Add("@user_func", MySqlDbType.VarChar).Value = user;

            cmd.ExecuteNonQuery();

            MySqlDataReader reader = cmd.ExecuteReader();

            Funcionario func = new Funcionario();

            while (reader.Read())
            {
                func.IdFunc = reader.GetInt16(reader.GetOrdinal("id_func"));
                func.NomeFunc = reader.GetString(reader.GetOrdinal("nome_func"));
                func.EmailFunc = reader.GetString(reader.GetOrdinal("email_func"));
                func.UserFunc = reader.GetString(reader.GetOrdinal("user_func"));
                func.SenhaFunc = reader.GetString(reader.GetOrdinal("senha_func"));
                func.TelFunc = reader.GetString(reader.GetOrdinal("tel_func"));
                func.NivelAcesso = reader.GetInt16(reader.GetOrdinal("nivel_acesso"));
            }

            reader.Close();

            cn.DesconectarBD();

            return func;
        }

        public Funcionario ConsultarNomeFuncionario(string nome)
        {
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM funcionario where nome_func = @nome_func", cn.ConectarBD());
            cmd.Parameters.Add("@nome_func", MySqlDbType.VarChar).Value = nome;

            cmd.ExecuteNonQuery();

            MySqlDataReader reader = cmd.ExecuteReader();

            Funcionario func = new Funcionario();

            while (reader.Read())
            {
                func.IdFunc = reader.GetInt16(reader.GetOrdinal("id_func"));
                func.NomeFunc = reader.GetString(reader.GetOrdinal("nome_func"));
                func.EmailFunc = reader.GetString(reader.GetOrdinal("email_func"));
                func.UserFunc = reader.GetString(reader.GetOrdinal("user_func"));
                func.SenhaFunc = reader.GetString(reader.GetOrdinal("senha_func"));
                func.TelFunc = reader.GetString(reader.GetOrdinal("tel_func"));
                func.NivelAcesso = reader.GetInt16(reader.GetOrdinal("nivel_acesso"));
            }

            reader.Close();

            cn.DesconectarBD();

            return func;
        }

        public bool DeletarFuncionario(int id)
            {

                MySqlCommand cmd = new MySqlCommand("DELETE FROM funcionario WHERE id_func = @id_func", cn.ConectarBD());
                cmd.Parameters.Add("@id_func", MySqlDbType.Int16).Value = id;

                int deletar = cmd.ExecuteNonQuery();

                return deletar > 0;
            }

            public long EditarFuncionario(Funcionario func, int idFunc)
            {
                MySqlCommand cmd = new MySqlCommand("update funcionario set nome_func = @nomeFunc, email_func = @emailFunc, user_func = @userFunc, senha_func = @senhaFunc, tel_func = @telFunc, nivel_acesso = @nivelAcesso "
                + "where id_func = " + idFunc + " ", cn.ConectarBD());

                cmd.Parameters.AddWithValue("@idFunc", idFunc);
                cmd.Parameters.AddWithValue("@nomeFunc", func.NomeFunc);
                cmd.Parameters.AddWithValue("@emailFunc", func.EmailFunc);
                cmd.Parameters.AddWithValue("@userFunc", func.UserFunc);
                cmd.Parameters.AddWithValue("@senhaFunc", func.SenhaFunc);
                cmd.Parameters.AddWithValue("@telFunc", func.TelFunc);
                cmd.Parameters.AddWithValue("@nivelAcesso", func.NivelAcesso);

                cmd.ExecuteNonQuery();

                long id = cmd.LastInsertedId;

                cn.DesconectarBD();

                return id;
            }

            public List<Funcionario> ListarFuncionario()
            {
                List<Funcionario> funcionario = new List<Funcionario>();

                MySqlCommand cmd = new MySqlCommand("Select * from funcionario", cn.ConectarBD());

                cmd.ExecuteNonQuery();

                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Funcionario func = new Funcionario();

                    func.IdFunc = reader.GetInt16(reader.GetOrdinal("id_func"));
                    func.NomeFunc = reader.GetString(reader.GetOrdinal("nome_func"));
                    func.EmailFunc = reader.GetString(reader.GetOrdinal("email_func"));
                    func.UserFunc = reader.GetString(reader.GetOrdinal("user_func"));
                    func.SenhaFunc = reader.GetString(reader.GetOrdinal("senha_func"));
                    func.TelFunc = reader.GetString(reader.GetOrdinal("tel_func"));
                    func.NivelAcesso = reader.GetInt16(reader.GetOrdinal("nivel_acesso"));
                    funcionario.Add(func);
                }

                return funcionario;
            }

            //conferir se vai ser consultarlogincliente ou geral
            public Funcionario ConsultarLoginFuncionario(Funcionario func)
            {
                MySqlCommand cmd = new MySqlCommand("Select * from funcionario where user_func  = @userFunc and senha_func = @senhaFunc;", cn.ConectarBD());

                cmd.Parameters.Add("@userFunc", MySqlDbType.VarChar).Value = func.UserFunc;
                cmd.Parameters.Add("@senhaFunc", MySqlDbType.VarChar).Value = func.SenhaFunc;

                cmd.ExecuteNonQuery();

                MySqlDataReader reader = cmd.ExecuteReader();

                Funcionario funcionario = new Funcionario();

                while (reader.Read())
                {
                    funcionario.IdFunc = reader.GetInt16(reader.GetOrdinal("id_func"));
                    funcionario.NomeFunc = reader.GetString(reader.GetOrdinal("nome_func"));
                    funcionario.EmailFunc = reader.GetString(reader.GetOrdinal("email_func"));
                    funcionario.UserFunc = reader.GetString(reader.GetOrdinal("user_func"));
                    funcionario.SenhaFunc = reader.GetString(reader.GetOrdinal("senha_func"));
                    funcionario.TelFunc = reader.GetString(reader.GetOrdinal("tel_func"));
                    funcionario.NivelAcesso = reader.GetInt16(reader.GetOrdinal("nivel_acesso"));
                }

                reader.Close();

                cn.DesconectarBD();

                return funcionario;
            }
        }
    }
