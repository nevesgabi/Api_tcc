using System.Collections.Generic;
using MySql.Data.MySqlClient;
using api_tcc.Models;
using System.Data;

namespace api_tcc.Repositorio
{
    //metodos CadastrarMesa, ConsultarMesa, DeletarMesa, EditarMesa, ListarMesa
    public class MesaRepositorio
    {
        Conexao cn = new Conexao();
        MySqlCommand cmd = new MySqlCommand();

        public long CadastrarMesa(Mesa mesa)
        {
            MySqlCommand cmd = new MySqlCommand("Insert into mesa (num_mesa, num_assentos, status_mesa) Values ( @numMesa, @numAssentos, @statusMesa)", cn.ConectarBD());
            cmd.Parameters.Add("@numMesa", MySqlDbType.Int16).Value = mesa.NumMesa;
            cmd.Parameters.Add("@numAssentos", MySqlDbType.Int16).Value = mesa.NumAssentos;
            cmd.Parameters.Add("@statusMesa", MySqlDbType.VarChar).Value = mesa.StatusMesa;

            cmd.Parameters.Add("@idMesa", MySqlDbType.Int16, 4).Direction = ParameterDirection.Output;

            cmd.ExecuteNonQuery();

            long id = cmd.LastInsertedId;

            cn.DesconectarBD();

            return id;
        }

        public Mesa ConsultarMesa(int id)
        {
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM mesa where id_mesa = @id_mesa", cn.ConectarBD());
            cmd.Parameters.Add("@id_mesa", MySqlDbType.Int16).Value = id;

            cmd.ExecuteNonQuery();

            MySqlDataReader reader = cmd.ExecuteReader();

            Mesa mesa = new Mesa();

            while (reader.Read())
            {
                mesa.IdMesa = reader.GetInt16(reader.GetOrdinal("id_mesa"));
                mesa.NumMesa = reader.GetInt16(reader.GetOrdinal("num_mesa"));
                mesa.NumAssentos = reader.GetInt16(reader.GetOrdinal("num_assentos"));
                mesa.StatusMesa = reader.GetString(reader.GetOrdinal("status_mesa"));
            }

            reader.Close();

            cn.DesconectarBD();

            return mesa;
        }

        public bool DeletarMesa(int id)
        {

            MySqlCommand cmd = new MySqlCommand("DELETE FROM mesa WHERE id_mesa = @id_mesa", cn.ConectarBD());
            cmd.Parameters.Add("@id_mesa", MySqlDbType.Int16).Value = id;

            int deletar = cmd.ExecuteNonQuery();

            return deletar > 0;
        }

        public long EditarMesa(Mesa mesa, int idMesa)
        {
            MySqlCommand cmd = new MySqlCommand("update mesa set num_mesa = @numMesa, num_assentos = @numAssentos, status_mesa = @statusMesa "
            + "where id_mesa = " + idMesa + " ", cn.ConectarBD());

            cmd.Parameters.AddWithValue("@idMesa", idMesa);
            cmd.Parameters.AddWithValue("@numMesa", mesa.NumMesa);
            cmd.Parameters.AddWithValue("@numAssentos", mesa.NumAssentos);
            cmd.Parameters.AddWithValue("@statusMesa", mesa.StatusMesa);

            cmd.ExecuteNonQuery();

            long id = cmd.LastInsertedId;

            cn.DesconectarBD();

            return id;
        }

        public List<Mesa> ListarMesa()
        {
            List<Mesa> mesa = new List<Mesa>();

            MySqlCommand cmd = new MySqlCommand("Select * from mesa", cn.ConectarBD());

            cmd.ExecuteNonQuery();

            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Mesa me = new Mesa();

                me.IdMesa = reader.GetInt16(reader.GetOrdinal("id_mesa"));
                me.NumMesa = reader.GetInt16(reader.GetOrdinal("num_mesa"));
                me.NumAssentos = reader.GetInt16(reader.GetOrdinal("num_assentos"));
                me.StatusMesa = reader.GetString(reader.GetOrdinal("status_mesa"));
                mesa.Add(me);
            }

            return mesa;
        }
    }
}
