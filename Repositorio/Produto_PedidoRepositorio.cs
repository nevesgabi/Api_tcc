using System.Collections.Generic;
using MySql.Data.MySqlClient;
using api_tcc.Models;
using System.Data;

namespace api_tcc.Repositorio
{
    //metodos CadastrarProdutoPedido, ConsultarProdutoPedido, DeletarProdutoPedido, EditarProdutoPedido, ListarProdutoPedido
    public class Produto_PedidoRepositorio
    {
        Conexao cn = new Conexao();
        MySqlCommand cmd = new MySqlCommand();

        public long CadastrarProdutoPedido(Produto_pedido prod_ped)
        {
            MySqlCommand cmd = new MySqlCommand("Insert into produto_pedido (qtd_produto, id_pedido, id_prod) Values ( @qtdProduto, @idPedido, @idProd)", cn.ConectarBD());
            cmd.Parameters.Add("@qtdProduto", MySqlDbType.Int16).Value = prod_ped.QtdProduto;
            cmd.Parameters.Add("@idPedido", MySqlDbType.Int16).Value = prod_ped.IdPedido;
            cmd.Parameters.Add("@idProd", MySqlDbType.Int16).Value = prod_ped.IdProd;

            cmd.Parameters.Add("@idProdutoPedido", MySqlDbType.Int16, 4).Direction = ParameterDirection.Output;

            cmd.ExecuteNonQuery();

            long id = cmd.LastInsertedId;

            cn.DesconectarBD();

            return id;
        }

        public Produto_pedido ConsultarProdutoPedido(int id)
        {
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM produto_pedido where id_produto_pedido = @id_produto_pedido", cn.ConectarBD());
            cmd.Parameters.Add("@id_produto_pedido", MySqlDbType.Int16).Value = id;

            cmd.ExecuteNonQuery();

            MySqlDataReader reader = cmd.ExecuteReader();

            Produto_pedido prod_ped = new Produto_pedido();

            while (reader.Read())
            {
                prod_ped.IdProdutoPedido = reader.GetInt16(reader.GetOrdinal("id_produto_pedido"));
                prod_ped.QtdProduto = reader.GetInt16(reader.GetOrdinal("qtd_produto"));
                prod_ped.IdPedido = reader.GetInt16(reader.GetOrdinal("id_pedido"));
                prod_ped.IdProd = reader.GetInt16(reader.GetOrdinal("id_prod"));
            }

            reader.Close();

            cn.DesconectarBD();

            return prod_ped;
        }

        public bool DeletarProdutoPedido(int id)
        {

            MySqlCommand cmd = new MySqlCommand("DELETE FROM produto_pedido WHERE id_produto_pedido  = @id_produto_pedido ", cn.ConectarBD());
            cmd.Parameters.Add("@id_produto_pedido", MySqlDbType.Int16).Value = id;

            int deletar = cmd.ExecuteNonQuery();

            return deletar > 0;
        }

        public long EditarProdutoPedido(Produto_pedido prod_ped, int idProdPed)
        {
            MySqlCommand cmd = new MySqlCommand("update produto_pedido set qtd_produto = @qtdProduto, id_pedido  = @idPedido, id_prod = @idProd "
            + "where id_produto_pedido = " + idProdPed + " ", cn.ConectarBD());

            cmd.Parameters.AddWithValue("@idProdutoPedido", idProdPed);
            cmd.Parameters.AddWithValue("@qtdProduto", prod_ped.QtdProduto);
            cmd.Parameters.AddWithValue("@idPedido", prod_ped.IdPedido);
            cmd.Parameters.AddWithValue("@idProd", prod_ped.IdProd);

            cmd.ExecuteNonQuery();

            long id = cmd.LastInsertedId;

            cn.DesconectarBD();

            return id;
        }

        public List<Produto_pedido> ListarProdutoPedido()
        {
            List<Produto_pedido> produto_pedido = new List<Produto_pedido>();

            MySqlCommand cmd = new MySqlCommand("Select * from produto_pedido", cn.ConectarBD());

            cmd.ExecuteNonQuery();

            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Produto_pedido prod_ped = new Produto_pedido();

                prod_ped.IdProdutoPedido = reader.GetInt16(reader.GetOrdinal("id_produto_pedido"));
                prod_ped.QtdProduto = reader.GetInt16(reader.GetOrdinal("qtd_produto"));
                prod_ped.IdPedido = reader.GetInt16(reader.GetOrdinal("id_pedido"));
                prod_ped.IdProd = reader.GetInt16(reader.GetOrdinal("id_prod"));
                produto_pedido.Add(prod_ped);
            }

            return produto_pedido;
        }
    }
}

