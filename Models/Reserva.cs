using System;

namespace api_tcc.Models
{
    public class Reserva
    {
        public int IdReserva { get; set; }

        public int NumPessoas { get; set; }

        public DateTime DataHoraReserva { get; set; }

        public string StatusReserva { get; set; }
        //fk
        public int IdCli { get; set; }
        //fk
        public int IdMesa { get; set; }
    }
}
