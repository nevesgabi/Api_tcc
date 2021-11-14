using System.Collections.Generic;
using MySql.Data.MySqlClient;
using api_tcc.Models;
using System.Data;

namespace api_tcc.Repositorio
{
    //metodos CadastrarReserva, ConsultarReserva, DeletarReserva, EditarReserva, ListarReserva
    public class ReservaRepositorio
    {
        Conexao cn = new Conexao();
        MySqlCommand cmd = new MySqlCommand();

        public long CadastrarReserva(Reserva reserva)
        {
            MySqlCommand cmd = new MySqlCommand("Insert into reserva (num_pessoas, data_hora_reserva, status_reserva, id_cli, id_mesa) Values ( @numPessoas, @dataHoraReserva, @statusReserva, @idCli, @idMesa)", cn.ConectarBD());
            cmd.Parameters.Add("@numPessoas", MySqlDbType.Int16).Value = reserva.NumPessoas;
            cmd.Parameters.Add("@dataHoraReserva", MySqlDbType.DateTime).Value = reserva.DataHoraReserva;
            cmd.Parameters.Add("@statusReserva", MySqlDbType.VarChar).Value = reserva.StatusReserva;
            cmd.Parameters.Add("@idCli", MySqlDbType.VarChar).Value = reserva.IdCli;
            cmd.Parameters.Add("@idMesa", MySqlDbType.VarChar).Value = reserva.IdMesa;

            cmd.Parameters.Add("@idReserva", MySqlDbType.Int16, 4).Direction = ParameterDirection.Output;

            cmd.ExecuteNonQuery();

            long id = cmd.LastInsertedId;

            cn.DesconectarBD();

            return id;
        }

        public Reserva ConsultarReserva(int id)
        {
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM reserva where id_reserva = @id_reserva", cn.ConectarBD());
            cmd.Parameters.Add("@id_reserva", MySqlDbType.Int16).Value = id;

            cmd.ExecuteNonQuery();

            MySqlDataReader reader = cmd.ExecuteReader();

            Reserva reserva = new Reserva();

            while (reader.Read())
            {
                reserva.IdReserva = reader.GetInt16(reader.GetOrdinal("id_reserva"));
                reserva.NumPessoas = reader.GetInt16(reader.GetOrdinal("num_pessoas"));
                reserva.DataHoraReserva = reader.GetDateTime(reader.GetOrdinal("data_hora_reserva"));
                reserva.StatusReserva = reader.GetString(reader.GetOrdinal("status_reserva"));
                reserva.IdCli = reader.GetInt16(reader.GetOrdinal("id_cli"));
                reserva.IdMesa = reader.GetInt16(reader.GetOrdinal("id_mesa"));
            }

            reader.Close();

            cn.DesconectarBD();

            return reserva;
        }

        public bool DeletarReserva(int id)
        {

            MySqlCommand cmd = new MySqlCommand("DELETE FROM reserva WHERE id_reserva = @id_reserva", cn.ConectarBD());
            cmd.Parameters.Add("@id_reserva", MySqlDbType.Int16).Value = id;

            int deletar = cmd.ExecuteNonQuery();

            return deletar > 0;
        }

        public long EditarReserva(Reserva reserva, int idReserva)
        {
            MySqlCommand cmd = new MySqlCommand("update reserva set num_pessoas = @numPessoas, data_hora_reserva = @dataHoraReserva, status_reserva = @statusReserva, id_cli = @idCli, id_mesa = @idMesa "
            + "where id_reserva = " + idReserva + " ", cn.ConectarBD());

            cmd.Parameters.AddWithValue("@idReserva", idReserva);
            cmd.Parameters.AddWithValue("@numPessoas", reserva.NumPessoas);
            cmd.Parameters.AddWithValue("@dataHoraReserva", reserva.DataHoraReserva);
            cmd.Parameters.AddWithValue("@statusReserva", reserva.StatusReserva);
            cmd.Parameters.AddWithValue("@idCli", reserva.IdCli);
            cmd.Parameters.AddWithValue("@idMesa", reserva.IdMesa);

            cmd.ExecuteNonQuery();

            long id = cmd.LastInsertedId;

            cn.DesconectarBD();

            return id;
        }

        public List<Reserva> ListarReserva()
        {
            List<Reserva> reserva = new List<Reserva>();

            MySqlCommand cmd = new MySqlCommand("Select * from reserva", cn.ConectarBD());

            cmd.ExecuteNonQuery();

            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Reserva res = new Reserva();

                res.IdReserva = reader.GetInt16(reader.GetOrdinal("id_reserva"));
                res.NumPessoas = reader.GetInt16(reader.GetOrdinal("num_pessoas"));
                res.DataHoraReserva = reader.GetDateTime(reader.GetOrdinal("data_hora_reserva"));
                res.StatusReserva = reader.GetString(reader.GetOrdinal("status_reserva"));
                res.IdCli = reader.GetInt16(reader.GetOrdinal("id_cli"));
                res.IdMesa = reader.GetInt16(reader.GetOrdinal("id_mesa"));
                reserva.Add(res);
            }

            return reserva;
        }
    }
}
