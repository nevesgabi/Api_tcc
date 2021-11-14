using System;

namespace api_tcc.Models
{
    public class Carrinho
    {
        public int IdCarrinho { get; set; }

        public string CepCarrinho { get; set; }

        public string LogradouroCarrinho { get; set; }

        public int NumCarrinho { get; set; }

        public string ComplementoCarrinho { get; set; }
        //fk
        public int IdPedido { get; set; }
        //fk
        public int IdCli { get; set; }
    }
}
