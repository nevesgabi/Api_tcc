using System.Collections.Generic;
using MySql.Data.MySqlClient;
using api_tcc.Models;
using System.Data;

namespace api_tcc.Repositorio
{
    //metodos CadastrarCarrinho, ConsultarCarrinho, DeletarCarrinho, EditarCarrinho, ListarCarrinho
    public class CarrinhoRepositorio
    {
        Conexao cn = new Conexao();
        MySqlCommand cmd = new MySqlCommand();

        public long CadastrarCarrinho(Carrinho car)
        {
            MySqlCommand cmd = new MySqlCommand("Insert into carrinho (cep_carrinho, logradouro_carrinho, num_carrinho, complemento_carrinho, id_pedido, id_cli) Values ( @cepCarrinho, @logradouroCarrinho, @numCarrinho, @complementoCarrinho, @idPedido, @idCli)", cn.ConectarBD());
            cmd.Parameters.Add("@cepCarrinho", MySqlDbType.VarChar).Value = car.CepCarrinho;
            cmd.Parameters.Add("@logradouroCarrinho", MySqlDbType.VarChar).Value = car.LogradouroCarrinho;
            cmd.Parameters.Add("@numCarrinho", MySqlDbType.Int24).Value = car.NumCarrinho;
            cmd.Parameters.Add("@complementoCarrinho", MySqlDbType.VarChar).Value = car.ComplementoCarrinho;
            cmd.Parameters.Add("@idPedido", MySqlDbType.Int16).Value = car.IdPedido;
            cmd.Parameters.Add("@idCli", MySqlDbType.Int16).Value = car.IdCli;

            cmd.Parameters.Add("@idCarrinho", MySqlDbType.Int16, 4).Direction = ParameterDirection.Output;

            cmd.ExecuteNonQuery();

            long id = cmd.LastInsertedId;

            cn.DesconectarBD();

            return id;
        }

        public Carrinho ConsultarCarrinho(int id)
        {
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM carrinho where id_carrinho = @id_carrinho", cn.ConectarBD());
            cmd.Parameters.Add("@id_carrinho", MySqlDbType.Int16).Value = id;

            cmd.ExecuteNonQuery();

            MySqlDataReader reader = cmd.ExecuteReader();

            Carrinho car = new Carrinho();

            while (reader.Read())
            {
                car.IdCarrinho = reader.GetInt16(reader.GetOrdinal("id_carrinho"));
                car.CepCarrinho = reader.GetString(reader.GetOrdinal("cep_carrinho"));
                car.LogradouroCarrinho = reader.GetString(reader.GetOrdinal("logradouro_carrinho"));
                car.NumCarrinho = reader.GetInt32(reader.GetOrdinal("num_carrinho"));
                if (!reader.IsDBNull(reader.GetOrdinal("complemento_carrinho")))
                    car.ComplementoCarrinho = reader.GetString(reader.GetOrdinal("complemento_carrinho"));
                car.IdPedido = reader.GetInt16(reader.GetOrdinal("id_pedido"));
                car.IdCli = reader.GetInt16(reader.GetOrdinal("id_cli"));
            }

            reader.Close();

            cn.DesconectarBD();

            return car;
        }

        public bool DeletarCarrinho(int id)
        {

            MySqlCommand cmd = new MySqlCommand("DELETE FROM carrinho WHERE id_carrinho = @id_carrinho", cn.ConectarBD());
            cmd.Parameters.Add("@id_carrinho", MySqlDbType.Int16).Value = id;

            int deletar = cmd.ExecuteNonQuery();

            return deletar > 0;
        }

        public long EditarCarrinho(Carrinho car, int idCarrinho)
        {
            MySqlCommand cmd = new MySqlCommand("update carrinho set cep_carrinho = @cepCarrinho, logradouro_carrinho = @logradouroCarrinho, num_carrinho = @numCarrinho, complemento_carrinho = @complementoCarrinho, id_pedido = @idPedido, id_cli = @idCli "
            + "where id_carrinho = " + idCarrinho + " ", cn.ConectarBD());

            cmd.Parameters.AddWithValue("@idCarrinho", idCarrinho);
            cmd.Parameters.AddWithValue("@cepCarrinho", car.CepCarrinho);
            cmd.Parameters.AddWithValue("@logradouroCarrinho", car.LogradouroCarrinho);
            cmd.Parameters.AddWithValue("@numCarrinho", car.NumCarrinho);
            if (car.ComplementoCarrinho == null)
            {
                car.ComplementoCarrinho = "";
            }
            cmd.Parameters.AddWithValue("@complementoCarrinho", car.ComplementoCarrinho);
            cmd.Parameters.AddWithValue("@idPedido", car.IdPedido);
            cmd.Parameters.AddWithValue("@idCli", car.IdCli);

            cmd.ExecuteNonQuery();

            long id = cmd.LastInsertedId;

            cn.DesconectarBD();

            return id;
        }

        public List<Carrinho> ListarCarrinho()
        {
            List<Carrinho> carinho = new List<Carrinho>();

            MySqlCommand cmd = new MySqlCommand("Select * from carrinho", cn.ConectarBD());

            cmd.ExecuteNonQuery();

            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Carrinho car = new Carrinho();

                car.IdCarrinho = reader.GetInt16(reader.GetOrdinal("id_carrinho"));
                car.CepCarrinho = reader.GetString(reader.GetOrdinal("cep_carrinho"));
                car.LogradouroCarrinho = reader.GetString(reader.GetOrdinal("logradouro_carrinho"));
                car.NumCarrinho = reader.GetInt32(reader.GetOrdinal("num_carrinho"));
                if (!reader.IsDBNull(reader.GetOrdinal("complemento_carrinho")))
                    car.ComplementoCarrinho = reader.GetString(reader.GetOrdinal("complemento_carrinho"));
                car.IdPedido = reader.GetInt16(reader.GetOrdinal("id_pedido"));
                car.IdCli = reader.GetInt16(reader.GetOrdinal("id_cli"));
                carinho.Add(car);
            }

            return carinho;
        }
    }
}
