using System;

namespace api_tcc.Models
{
    public class Pedido
    {
        public int IdPedido { get; set; }

        public DateTime DataHoraPedido { get; set; }

        public string StatusPedido { get; set; }
    }
}
