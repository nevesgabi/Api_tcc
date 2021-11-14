using System.Collections.Generic;
using MySql.Data.MySqlClient;
using api_tcc.Models;
using System.Data;

namespace api_tcc.Repositorio
{
    //metodos CadastrarCliente, ConsultarCliente, DeletarCliente, EditarCliente, ListarCliente, ConsultarLoginCliente
    public class ClienteRepositorio
    {
        Conexao cn = new Conexao();
        MySqlCommand cmd = new MySqlCommand();

        public long CadastrarCliente(Cliente cli)
        {
            MySqlCommand cmd = new MySqlCommand("Insert into cliente (nome_cli, email_cli, user_cli, senha_cli, tel_cli, cep_cli, logradouro_cli, num_cli, complemento_cli) Values ( @nomeCli, @emailCli, @userCli, @senhaCli, @telCli, @cepCli, @logradouroCli, @numCli, @complementoCli)", cn.ConectarBD());
            cmd.Parameters.Add("@nomeCli", MySqlDbType.VarChar).Value = cli.NomeCli;
            cmd.Parameters.Add("@emailCli", MySqlDbType.VarChar).Value = cli.EmailCli;
            cmd.Parameters.Add("@userCli", MySqlDbType.VarChar).Value = cli.UserCli;
            cmd.Parameters.Add("@senhaCli", MySqlDbType.VarChar).Value = cli.SenhaCli;
            cmd.Parameters.Add("@telCli", MySqlDbType.VarChar).Value = cli.TelefoneCli;
            cmd.Parameters.Add("@cepCli", MySqlDbType.VarChar).Value = cli.CepCli;
            cmd.Parameters.Add("@logradouroCli", MySqlDbType.VarChar).Value = cli.LogradouroCli;
            cmd.Parameters.Add("@numCli", MySqlDbType.Int16).Value = cli.NumCli;
            cmd.Parameters.Add("@complementoCli", MySqlDbType.VarChar).Value = cli.ComplementoCli;

            cmd.Parameters.Add("@idCli", MySqlDbType.Int16, 4).Direction = ParameterDirection.Output;

            cmd.ExecuteNonQuery();

            long id = cmd.LastInsertedId;

            cn.DesconectarBD();

            return id;
        }

        public Cliente ConsultarCliente(int id)
        {
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM cliente where id_cli = @id_cli", cn.ConectarBD());
            cmd.Parameters.Add("@id_cli", MySqlDbType.Int16).Value = id;

            cmd.ExecuteNonQuery();

            MySqlDataReader reader = cmd.ExecuteReader();

            Cliente cli = new Cliente();

            while (reader.Read())
            {
                cli.IdCli = reader.GetInt16(reader.GetOrdinal("id_cli"));
                cli.NomeCli = reader.GetString(reader.GetOrdinal("nome_cli"));
                cli.EmailCli = reader.GetString(reader.GetOrdinal("email_cli"));
                cli.UserCli = reader.GetString(reader.GetOrdinal("user_cli"));
                cli.SenhaCli = reader.GetString(reader.GetOrdinal("senha_cli"));
                cli.TelefoneCli = reader.GetString(reader.GetOrdinal("tel_cli"));
                if (!reader.IsDBNull(reader.GetOrdinal("cep_cli")))
                    cli.CepCli = reader.GetString(reader.GetOrdinal("cep_cli"));
                if (!reader.IsDBNull(reader.GetOrdinal("logradouro_cli")))
                    cli.LogradouroCli = reader.GetString(reader.GetOrdinal("logradouro_cli"));
                if (!reader.IsDBNull(reader.GetOrdinal("num_cli")))
                    cli.NumCli = reader.GetInt16(reader.GetOrdinal("num_cli"));
                if (!reader.IsDBNull(reader.GetOrdinal("complemento_cli")))
                    cli.ComplementoCli = reader.GetString(reader.GetOrdinal("complemento_cli"));
            }

            reader.Close();

            cn.DesconectarBD();

            return cli;
        }

        public Cliente ConsultarNomeCliente(string nome)
        {
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM cliente where nome_cli = @nome_cli", cn.ConectarBD());
            cmd.Parameters.Add("@nome_cli", MySqlDbType.VarChar).Value = nome;

            cmd.ExecuteNonQuery();

            MySqlDataReader reader = cmd.ExecuteReader();

            Cliente cli = new Cliente();

            while (reader.Read())
            {
                cli.IdCli = reader.GetInt16(reader.GetOrdinal("id_cli"));
                cli.NomeCli = reader.GetString(reader.GetOrdinal("nome_cli"));
                cli.EmailCli = reader.GetString(reader.GetOrdinal("email_cli"));
                cli.UserCli = reader.GetString(reader.GetOrdinal("user_cli"));
                cli.SenhaCli = reader.GetString(reader.GetOrdinal("senha_cli"));
                cli.TelefoneCli = reader.GetString(reader.GetOrdinal("tel_cli"));
                if (!reader.IsDBNull(reader.GetOrdinal("cep_cli")))
                    cli.CepCli = reader.GetString(reader.GetOrdinal("cep_cli"));
                if (!reader.IsDBNull(reader.GetOrdinal("logradouro_cli")))
                    cli.LogradouroCli = reader.GetString(reader.GetOrdinal("logradouro_cli"));
                if (!reader.IsDBNull(reader.GetOrdinal("num_cli")))
                    cli.NumCli = reader.GetInt16(reader.GetOrdinal("num_cli"));
                if (!reader.IsDBNull(reader.GetOrdinal("complemento_cli")))
                    cli.ComplementoCli = reader.GetString(reader.GetOrdinal("complemento_cli"));
            }

            reader.Close();

            cn.DesconectarBD();

            return cli;
        }

        public Cliente ConsultarUserCliente(string user)
        {
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM cliente where user_cli = @user_cli", cn.ConectarBD());
            cmd.Parameters.Add("@user_cli", MySqlDbType.VarChar).Value = user;

            cmd.ExecuteNonQuery();

            MySqlDataReader reader = cmd.ExecuteReader();

            Cliente cli = new Cliente();

            while (reader.Read())
            {
                cli.IdCli = reader.GetInt16(reader.GetOrdinal("id_cli"));
                cli.NomeCli = reader.GetString(reader.GetOrdinal("nome_cli"));
                cli.EmailCli = reader.GetString(reader.GetOrdinal("email_cli"));
                cli.UserCli = reader.GetString(reader.GetOrdinal("user_cli"));
                cli.SenhaCli = reader.GetString(reader.GetOrdinal("senha_cli"));
                cli.TelefoneCli = reader.GetString(reader.GetOrdinal("tel_cli"));
                if (!reader.IsDBNull(reader.GetOrdinal("cep_cli")))
                    cli.CepCli = reader.GetString(reader.GetOrdinal("cep_cli"));
                if (!reader.IsDBNull(reader.GetOrdinal("logradouro_cli")))
                    cli.LogradouroCli = reader.GetString(reader.GetOrdinal("logradouro_cli"));
                if (!reader.IsDBNull(reader.GetOrdinal("num_cli")))
                    cli.NumCli = reader.GetInt16(reader.GetOrdinal("num_cli"));
                if (!reader.IsDBNull(reader.GetOrdinal("complemento_cli")))
                    cli.ComplementoCli = reader.GetString(reader.GetOrdinal("complemento_cli"));
            }

            reader.Close();

            cn.DesconectarBD();

            return cli;
        }

        public bool DeletarCliente(int id)
        {

            MySqlCommand cmd = new MySqlCommand("DELETE FROM cliente WHERE id_cli = @id_cli", cn.ConectarBD());
            cmd.Parameters.Add("@id_cli", MySqlDbType.Int16).Value = id;

            int deletar = cmd.ExecuteNonQuery();

            return deletar > 0;
        }

        public long EditarCliente(Cliente cli, int idCli)
        {
            MySqlCommand cmd = new MySqlCommand("update cliente set nome_cli = @nomeCli, email_cli = @emailCli, user_cli = @userCli, senha_cli = @senhaCli, tel_cli = @telCli, cep_cli = @cepCli, logradouro_cli = @logradouroCli, num_cli = @numCli, complemento_cli = @complementoCli "
            + "where id_cli = " + idCli + " ", cn.ConectarBD());

            cmd.Parameters.AddWithValue("@idCli", idCli);
            cmd.Parameters.AddWithValue("@nomeCli", cli.NomeCli);
            cmd.Parameters.AddWithValue("@emailCli", cli.EmailCli);
            cmd.Parameters.AddWithValue("@userCli", cli.UserCli);
            cmd.Parameters.AddWithValue("@senhaCli", cli.SenhaCli);
            cmd.Parameters.AddWithValue("@telCli", cli.TelefoneCli);
            cmd.Parameters.AddWithValue("@cepCli", cli.CepCli);
            cmd.Parameters.AddWithValue("@logradouroCli", cli.LogradouroCli);
            cmd.Parameters.AddWithValue("@numCli", cli.NumCli);
            cmd.Parameters.AddWithValue("@complementoCli", cli.ComplementoCli);

            cmd.ExecuteNonQuery();

            long id = cmd.LastInsertedId;

            cn.DesconectarBD();

            return id;
        }

        public List<Cliente> ListarCliente()
        {
            List<Cliente> cliente = new List<Cliente>();

            MySqlCommand cmd = new MySqlCommand("Select * from cliente", cn.ConectarBD());

            cmd.ExecuteNonQuery();

            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Cliente cli = new Cliente();

                cli.IdCli = reader.GetInt16(reader.GetOrdinal("id_cli"));
                cli.NomeCli = reader.GetString(reader.GetOrdinal("nome_cli"));
                cli.EmailCli = reader.GetString(reader.GetOrdinal("email_cli"));
                cli.UserCli = reader.GetString(reader.GetOrdinal("user_cli"));
                cli.SenhaCli = reader.GetString(reader.GetOrdinal("senha_cli"));
                cli.TelefoneCli = reader.GetString(reader.GetOrdinal("tel_cli"));
                if (!reader.IsDBNull(reader.GetOrdinal("cep_cli")))
                    cli.CepCli = reader.GetString(reader.GetOrdinal("cep_cli"));
                if (!reader.IsDBNull(reader.GetOrdinal("logradouro_cli")))
                    cli.LogradouroCli = reader.GetString(reader.GetOrdinal("logradouro_cli"));
                if (!reader.IsDBNull(reader.GetOrdinal("num_cli")))
                    cli.NumCli = reader.GetInt16(reader.GetOrdinal("num_cli"));
                if (!reader.IsDBNull(reader.GetOrdinal("complemento_cli")))
                    cli.ComplementoCli = reader.GetString(reader.GetOrdinal("complemento_cli"));
                cliente.Add(cli);
            }

            return cliente;
        }

        //conferir se vai ser consultarlogincliente ou geral
        public Cliente ConsultarLoginCliente(Cliente cli)
        {
            MySqlCommand cmd = new MySqlCommand("Select * from cliente where user_cli  = @userCli and senha_cli = @senhaCli;", cn.ConectarBD());

            cmd.Parameters.Add("@userCli", MySqlDbType.VarChar).Value = cli.UserCli;
            cmd.Parameters.Add("@senhaCli", MySqlDbType.VarChar).Value = cli.SenhaCli;

            cmd.ExecuteNonQuery();

            MySqlDataReader reader = cmd.ExecuteReader();

            Cliente cliente = new Cliente();

            while (reader.Read())
            {
                cliente.IdCli = reader.GetInt16(reader.GetOrdinal("id_cli"));
                cliente.NomeCli = reader.GetString(reader.GetOrdinal("nome_cli"));
                cliente.EmailCli = reader.GetString(reader.GetOrdinal("email_cli"));
                cliente.UserCli = reader.GetString(reader.GetOrdinal("user_cli"));
                cliente.SenhaCli = reader.GetString(reader.GetOrdinal("senha_cli"));
                cliente.TelefoneCli = reader.GetString(reader.GetOrdinal("tel_cli"));
                if (!reader.IsDBNull(reader.GetOrdinal("cep_cli")))
                    cliente.CepCli = reader.GetString(reader.GetOrdinal("cep_cli"));
                if (!reader.IsDBNull(reader.GetOrdinal("logradouro_cli")))
                    cliente.LogradouroCli = reader.GetString(reader.GetOrdinal("logradouro_cli"));
                if (!reader.IsDBNull(reader.GetOrdinal("num_cli")))
                    cliente.NumCli = reader.GetInt16(reader.GetOrdinal("num_cli"));
                if (!reader.IsDBNull(reader.GetOrdinal("complemento_cli")))
                    cliente.ComplementoCli = reader.GetString(reader.GetOrdinal("complemento_cli"));
            }

            reader.Close();

            cn.DesconectarBD();

            return cliente;
        }
    }
}
