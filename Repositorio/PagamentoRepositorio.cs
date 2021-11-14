using System.Collections.Generic;
using MySql.Data.MySqlClient;
using api_tcc.Models;
using System.Data;

namespace api_tcc.Repositorio
{
    //metodos CadastrarPagamento, ConsultarPagamento, DeletarPagamento, EditarPagamento, ListarPagamento
    public class PagamentoRepositorio
    {
        Conexao cn = new Conexao();
        MySqlCommand cmd = new MySqlCommand();

        public long CadastrarPagamento(Pagamento pag)
        {
            MySqlCommand cmd = new MySqlCommand("Insert into pagamento (total_pag, total_pagado, troco_pag, tipo_pag, cpf_pag, id_pedido) Values ( @totalPag, @totalPagado, @trocoPag, @tipoPag, @cpfPag, @idPedido)", cn.ConectarBD());
            cmd.Parameters.Add("@totalPag", MySqlDbType.Decimal).Value = pag.TotalPag;
            cmd.Parameters.Add("@totalPagado", MySqlDbType.Decimal).Value = pag.TotalPagado;
            cmd.Parameters.Add("@trocoPag", MySqlDbType.Decimal).Value = pag.TrocoPag;
            cmd.Parameters.Add("@tipoPag", MySqlDbType.VarChar).Value = pag.TipoPag;
            cmd.Parameters.Add("@cpfPag", MySqlDbType.VarChar).Value = pag.CpfPag;
            cmd.Parameters.Add("@idPedido", MySqlDbType.Int16).Value = pag.IdPedido;

            cmd.Parameters.Add("@idPag", MySqlDbType.Int16, 4).Direction = ParameterDirection.Output;

            cmd.ExecuteNonQuery();

            long id = cmd.LastInsertedId;

            cn.DesconectarBD();

            return id;
        }
        
        public Pagamento ConsultarPagamento(int id)
        {
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM pagamento where id_pag = @id_pag", cn.ConectarBD());
            cmd.Parameters.Add("@id_pag", MySqlDbType.Int16).Value = id;

            cmd.ExecuteNonQuery();

            MySqlDataReader reader = cmd.ExecuteReader();

            Pagamento pag = new Pagamento();

            while (reader.Read())
            {
                pag.IdPag = reader.GetInt16(reader.GetOrdinal("id_pag"));
                pag.TotalPag = reader.GetString(reader.GetOrdinal("total_pag"));
                pag.TotalPagado = reader.GetString(reader.GetOrdinal("total_pagado"));
                if (!reader.IsDBNull(reader.GetOrdinal("troco_pag")))
                    pag.TrocoPag = reader.GetString(reader.GetOrdinal("troco_pag"));
                pag.TipoPag = reader.GetString(reader.GetOrdinal("tipo_pag"));
                pag.CpfPag = reader.GetString(reader.GetOrdinal("cpf_pag"));
                pag.IdPedido = reader.GetInt16(reader.GetOrdinal("id_pedido"));
            }

            reader.Close();

            cn.DesconectarBD();

            return pag;
        }

        public bool DeletarPagamento(int id)
        {

            MySqlCommand cmd = new MySqlCommand("DELETE FROM pagamento WHERE id_pag = @id_pag", cn.ConectarBD());
            cmd.Parameters.Add("@id_pag", MySqlDbType.Int16).Value = id;

            int deletar = cmd.ExecuteNonQuery();

            return deletar > 0;
        }
        
        public long EditarPagamento(Pagamento pag, int idPag)
        {
            MySqlCommand cmd = new MySqlCommand("update pagamento set total_pag = @totalPag, total_pagado = @totalPagado, troco_pag = @trocoPag, tipo_pag = @tipoPag, cpf_pag = @cpfPag, id_pedido = @idPedido "
            + "where id_pag = " + idPag + " ", cn.ConectarBD());
            
            cmd.Parameters.Add("@idPag", MySqlDbType.Int16).Value = pag.IdPag;
            cmd.Parameters.Add("@totalPag", MySqlDbType.Decimal).Value = pag.TotalPag;
            cmd.Parameters.Add("@totalPagado", MySqlDbType.Decimal).Value = pag.TotalPagado;
            cmd.Parameters.Add("@trocoPag", MySqlDbType.Decimal).Value = pag.TrocoPag;
            cmd.Parameters.Add("@tipoPag", MySqlDbType.VarChar).Value = pag.TipoPag;
            cmd.Parameters.Add("@cpfPag", MySqlDbType.VarChar).Value = pag.CpfPag;
            cmd.Parameters.Add("@idPedido", MySqlDbType.Int16).Value = pag.IdPedido;

            cmd.ExecuteNonQuery();

            long id = cmd.LastInsertedId;

            cn.DesconectarBD();

            return id;
        }
        
        public List<Pagamento> ListarPagamento()
        {
            List<Pagamento> pagamento = new List<Pagamento>();

            MySqlCommand cmd = new MySqlCommand("Select * from pagamento", cn.ConectarBD());

            cmd.ExecuteNonQuery();

            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Pagamento pag = new Pagamento();

                pag.IdPag = reader.GetInt16(reader.GetOrdinal("id_pag"));
                pag.TotalPag = reader.GetString(reader.GetOrdinal("total_pag"));
                pag.TotalPagado = reader.GetString(reader.GetOrdinal("total_pagado"));
                if (!reader.IsDBNull(reader.GetOrdinal("troco_pag")))
                    pag.TrocoPag = reader.GetString(reader.GetOrdinal("troco_pag"));
                pag.TipoPag = reader.GetString(reader.GetOrdinal("tipo_pag"));
                pag.CpfPag = reader.GetString(reader.GetOrdinal("cpf_pag"));
                pag.IdPedido = reader.GetInt16(reader.GetOrdinal("id_pedido"));
                pagamento.Add(pag);
            }

            return pagamento;
        }
    }
}
