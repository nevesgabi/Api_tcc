using System.Collections.Generic;
using MySql.Data.MySqlClient;
using api_tcc.Models;
using System.Data;

namespace api_tcc.Repositorio
{
    //metodos CadastrarProduto, ConsultarProduto, DeletarProduto, EditarProduto, ListarProduto
    public class ProdutoRepositorio
    {
        Conexao cn = new Conexao();
        MySqlCommand cmd = new MySqlCommand();

        public long CadastrarProduto(Produto produto)
        {
            MySqlCommand cmd = new MySqlCommand("Insert into produto (nome_prod, desc_prod, preco_prod, categoria_prod, status_prod) Values ( @nomeProd, @descProd, @precoProd, @categoriaProd, @statusProd)", cn.ConectarBD());
            cmd.Parameters.Add("@nomeProd", MySqlDbType.VarChar).Value = produto.NomeProd;
            cmd.Parameters.Add("@descProd", MySqlDbType.VarChar).Value = produto.DescProd;
            cmd.Parameters.Add("@precoProd", MySqlDbType.Decimal).Value = produto.PrecoProd;
            cmd.Parameters.Add("@categoriaProd", MySqlDbType.VarChar).Value = produto.CategoriaProd;
            cmd.Parameters.Add("@statusProd", MySqlDbType.VarChar).Value = produto.StatusProd;

            cmd.Parameters.Add("@idProd", MySqlDbType.Int16, 4).Direction = ParameterDirection.Output;

            cmd.ExecuteNonQuery();

            long id = cmd.LastInsertedId;

            cn.DesconectarBD();

            return id;
        }
        
        public Produto ConsultarProduto(int id)
        {
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM produto where id_prod = @id_prod", cn.ConectarBD());
            cmd.Parameters.Add("@id_prod", MySqlDbType.Int16).Value = id;

            cmd.ExecuteNonQuery();

            MySqlDataReader reader = cmd.ExecuteReader();

            Produto prod = new Produto();

            while (reader.Read())
            {
                prod.IdProd = reader.GetInt16(reader.GetOrdinal("id_prod"));
                prod.NomeProd = reader.GetString(reader.GetOrdinal("nome_prod"));
                prod.DescProd = reader.GetString(reader.GetOrdinal("desc_prod"));
                prod.PrecoProd = reader.GetString(reader.GetOrdinal("preco_prod"));
                prod.CategoriaProd = reader.GetString(reader.GetOrdinal("categoria_prod"));
                prod.StatusProd = reader.GetString(reader.GetOrdinal("status_prod"));
            }

            reader.Close();

            cn.DesconectarBD();

            return prod;
        }

        public Produto ConsultarNomeProduto(string nome)
        {
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM produto where nome_prod = @nome_prod", cn.ConectarBD());
            cmd.Parameters.Add("@nome_prod", MySqlDbType.VarChar).Value = nome;

            cmd.ExecuteNonQuery();

            MySqlDataReader reader = cmd.ExecuteReader();

            Produto prod = new Produto();

            while (reader.Read())
            {
                prod.IdProd = reader.GetInt16(reader.GetOrdinal("id_prod"));
                prod.NomeProd = reader.GetString(reader.GetOrdinal("nome_prod"));
                prod.DescProd = reader.GetString(reader.GetOrdinal("desc_prod"));
                prod.PrecoProd = reader.GetString(reader.GetOrdinal("preco_prod"));
                prod.CategoriaProd = reader.GetString(reader.GetOrdinal("categoria_prod"));
                prod.StatusProd = reader.GetString(reader.GetOrdinal("status_prod"));
            }

            reader.Close();

            cn.DesconectarBD();

            return prod;
        }

        public bool DeletarProduto(int id)
        {

            MySqlCommand cmd = new MySqlCommand("DELETE FROM produto WHERE id_prod = @id_prod", cn.ConectarBD());
            cmd.Parameters.Add("@id_prod", MySqlDbType.Int16).Value = id;

            int deletar = cmd.ExecuteNonQuery();

            return deletar > 0;
        }

        public long EditarProduto(Produto produto, int idProd)
        {
            MySqlCommand cmd = new MySqlCommand("update produto set nome_prod = @nomeProd, desc_prod = @descProd, preco_prod = @precoProd, categoria_prod = @categoriaProd, status_prod = @statusProd "
            + "where id_prod = " + idProd + " ", cn.ConectarBD());
            
            cmd.Parameters.Add("@idProd", MySqlDbType.Int16).Value = produto.IdProd;
            cmd.Parameters.Add("@nomeProd", MySqlDbType.VarChar).Value = produto.NomeProd;
            cmd.Parameters.Add("@descProd", MySqlDbType.VarChar).Value = produto.DescProd;
            cmd.Parameters.Add("@precoProd", MySqlDbType.Decimal).Value = produto.PrecoProd;
            cmd.Parameters.Add("@categoriaProd", MySqlDbType.VarChar).Value = produto.CategoriaProd;
            cmd.Parameters.Add("@statusProd", MySqlDbType.VarChar).Value = produto.StatusProd;

            cmd.ExecuteNonQuery();

            long id = cmd.LastInsertedId;

            cn.DesconectarBD();

            return id;
        }
        
        public List<Produto> ListarProduto()
        {
            List<Produto> produto = new List<Produto>();

            MySqlCommand cmd = new MySqlCommand("Select * from produto", cn.ConectarBD());

            cmd.ExecuteNonQuery();

            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Produto prod = new Produto();

                prod.IdProd = reader.GetInt16(reader.GetOrdinal("id_prod"));
                prod.NomeProd = reader.GetString(reader.GetOrdinal("nome_prod"));
                prod.DescProd = reader.GetString(reader.GetOrdinal("desc_prod"));
                prod.PrecoProd = reader.GetString(reader.GetOrdinal("preco_prod"));
                prod.CategoriaProd = reader.GetString(reader.GetOrdinal("categoria_prod"));
                prod.StatusProd = reader.GetString(reader.GetOrdinal("status_prod"));
                produto.Add(prod);
            }

            return produto;
        }
    }
}
