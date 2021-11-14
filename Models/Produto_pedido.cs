using System;

namespace api_tcc.Models
{
    public class Produto_pedido
    {
        public int IdProdutoPedido { get; set; }

        public int QtdProduto { get; set; }
        //fk
        public int IdPedido { get; set; }
        //fk
        public int IdProd { get; set; }
    }
}
