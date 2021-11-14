using System;

namespace api_tcc.Models
{
    public class Pagamento
    {
        public int IdPag { get; set; }

        public string TotalPag { get; set; }

        public string TotalPagado { get; set; }

        public string TrocoPag { get; set; }

        public string TipoPag { get; set; }

        public string CpfPag { get; set; }
        //fk
        public int IdPedido { get; set; }
    }
}
