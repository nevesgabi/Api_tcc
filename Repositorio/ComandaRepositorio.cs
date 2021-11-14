using System.Collections.Generic;
using MySql.Data.MySqlClient;
using api_tcc.Models;
using System.Data;

namespace api_tcc.Repositorio
{
    public class ComandaRepositorio
    {
    //metodos CadastrarComanda, ConsultarComanda, DeletarComanda, EditarComanda, ListarComanda
    Conexao cn = new Conexao();
    MySqlCommand cmd = new MySqlCommand();

    public long CadastrarComanda(Comanda com)
    {
        MySqlCommand cmd = new MySqlCommand("Insert into comanda ( id_func, id_pedido, id_mesa) Values ( @idFunc, @idPedido, @idMesa)", cn.ConectarBD());
        cmd.Parameters.Add("@idFunc", MySqlDbType.Int16).Value = com.IdFunc;
        cmd.Parameters.Add("@idPedido", MySqlDbType.Int16).Value = com.IdPedido;
        cmd.Parameters.Add("@idMesa", MySqlDbType.Int16).Value = com.IdMesa;

        cmd.Parameters.Add("@idComanda", MySqlDbType.Int16, 4).Direction = ParameterDirection.Output;

        cmd.ExecuteNonQuery();

        long id = cmd.LastInsertedId;

        cn.DesconectarBD();

        return id;
    }

    public Comanda ConsultarComanda(int id)
    {
        MySqlCommand cmd = new MySqlCommand("SELECT * FROM comanda where id_comanda = @id_comanda", cn.ConectarBD());
        cmd.Parameters.Add("@id_comanda", MySqlDbType.Int16).Value = id;

        cmd.ExecuteNonQuery();

        MySqlDataReader reader = cmd.ExecuteReader();

        Comanda com = new Comanda();

        while (reader.Read())
        {
            com.IdComanda = reader.GetInt16(reader.GetOrdinal("id_comanda"));
            com.IdFunc = reader.GetInt16(reader.GetOrdinal("id_func"));
            com.IdPedido = reader.GetInt16(reader.GetOrdinal("id_pedido"));
            com.IdMesa = reader.GetInt16(reader.GetOrdinal("id_mesa"));
        }

        reader.Close();

        cn.DesconectarBD();

        return com;
    }

    public bool DeletarComanda(int id)
    {

        MySqlCommand cmd = new MySqlCommand("DELETE FROM comanda WHERE id_comanda = @id_comanda", cn.ConectarBD());
        cmd.Parameters.Add("@id_comanda", MySqlDbType.Int16).Value = id;

        int deletar = cmd.ExecuteNonQuery();

        return deletar > 0;
    }

    public long EditarComanda(Comanda com, int idComanda)
    {
        MySqlCommand cmd = new MySqlCommand("update comanda set id_comanda = @idComanda, id_func = @idFunc, id_pedido = @idPedido, id_mesa = @idMesa "
        + "where id_comanda = " + idComanda + " ", cn.ConectarBD());

        cmd.Parameters.AddWithValue("@idComanda", idComanda);
        cmd.Parameters.AddWithValue("@idFunc", com.IdFunc);
        cmd.Parameters.AddWithValue("@idPedido", com.IdPedido);
        cmd.Parameters.AddWithValue("@idMesa", com.IdMesa);

        cmd.ExecuteNonQuery();

        long id = cmd.LastInsertedId;

        cn.DesconectarBD();

        return id;
    }

    public List<Comanda> ListarComanda()
    {
        List<Comanda> comanda = new List<Comanda>();

        MySqlCommand cmd = new MySqlCommand("Select * from comanda", cn.ConectarBD());

        cmd.ExecuteNonQuery();

        MySqlDataReader reader = cmd.ExecuteReader();

        while (reader.Read())
        {
        Comanda com = new Comanda();

        com.IdComanda = reader.GetInt16(reader.GetOrdinal("id_comanda"));
        com.IdFunc = reader.GetInt16(reader.GetOrdinal("id_func"));
        com.IdPedido = reader.GetInt16(reader.GetOrdinal("id_pedido"));
        com.IdMesa = reader.GetInt16(reader.GetOrdinal("id_mesa"));
        comanda.Add(com);
        }
         return comanda;
        }
    }
}
