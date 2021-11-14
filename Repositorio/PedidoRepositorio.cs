using System.Collections.Generic;
using MySql.Data.MySqlClient;
using api_tcc.Models;
using System.Data;

namespace api_tcc.Repositorio
{
    //metodos CadastrarPedido, ConsultarPedido, DeletarPedido, EditarPedido, ListarPedido
    public class PedidoRepositorio
    {
        Conexao cn = new Conexao();
        MySqlCommand cmd = new MySqlCommand();

        public long CadastrarPedido(Pedido pedido)
        {
            MySqlCommand cmd = new MySqlCommand("Insert into pedido (data_hora_pedido, status_pedido) Values ( @dataHoraPedido, @statusPedido)", cn.ConectarBD());
            cmd.Parameters.Add("@dataHoraPedido", MySqlDbType.DateTime).Value = pedido.DataHoraPedido;
            cmd.Parameters.Add("@statusPedido", MySqlDbType.VarChar).Value = pedido.StatusPedido;

            cmd.Parameters.Add("@idPedido", MySqlDbType.Int16, 4).Direction = ParameterDirection.Output;

            cmd.ExecuteNonQuery();

            long id = cmd.LastInsertedId;

            cn.DesconectarBD();

            return id;
        }

        public Pedido ConsultarPedido(int id)
        {
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM pedido where id_pedido = @id_pedido", cn.ConectarBD());
            cmd.Parameters.Add("@id_pedido", MySqlDbType.Int16).Value = id;

            cmd.ExecuteNonQuery();

            MySqlDataReader reader = cmd.ExecuteReader();

            Pedido pedido = new Pedido();

            while (reader.Read())
            {
                pedido.IdPedido = reader.GetInt16(reader.GetOrdinal("id_pedido"));
                pedido.DataHoraPedido = reader.GetDateTime(reader.GetOrdinal("data_hora_pedido"));
                pedido.StatusPedido = reader.GetString(reader.GetOrdinal("status_pedido"));
            }

            reader.Close();

            cn.DesconectarBD();

            return pedido;
        }

        public bool DeletarPedido(int id)
        {

            MySqlCommand cmd = new MySqlCommand("DELETE FROM pedido WHERE id_pedido = @id_pedido", cn.ConectarBD());
            cmd.Parameters.Add("@id_pedido", MySqlDbType.Int16).Value = id;

            int deletar = cmd.ExecuteNonQuery();

            return deletar > 0;
        }

        public long EditarPedido(Pedido pedido, int idPedido)
        {
            MySqlCommand cmd = new MySqlCommand("update pedido set data_hora_pedido = @dataHoraPedido, status_pedido = @statusPedido "
            + "where id_pedido = " + idPedido + " ", cn.ConectarBD());

            cmd.Parameters.AddWithValue("@idPedido", idPedido);
            cmd.Parameters.AddWithValue("@dataHoraPedido", pedido.DataHoraPedido);
            cmd.Parameters.AddWithValue("@statusPedido", pedido.StatusPedido);

            cmd.ExecuteNonQuery();

            long id = cmd.LastInsertedId;

            cn.DesconectarBD();

            return id;
        }

        public List<Pedido> ListarPedido()
        {
            List<Pedido> pedido = new List<Pedido>();

            MySqlCommand cmd = new MySqlCommand("Select * from pedido", cn.ConectarBD());

            cmd.ExecuteNonQuery();

            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Pedido ped = new Pedido();

                ped.IdPedido = reader.GetInt16(reader.GetOrdinal("id_pedido"));
                ped.DataHoraPedido = reader.GetDateTime(reader.GetOrdinal("data_hora_pedido"));
                ped.StatusPedido = reader.GetString(reader.GetOrdinal("status_pedido"));
                pedido.Add(ped);
            }

            return pedido;
        }
    }
}
