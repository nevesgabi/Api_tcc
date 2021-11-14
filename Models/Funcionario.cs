using System;

namespace api_tcc.Models
{
    public class Funcionario
    {
        public int IdFunc { get; set; }

        public string NomeFunc { get; set; }

        public string EmailFunc { get; set; }

        public string UserFunc { get; set; }

        public string SenhaFunc { get; set; }

        public string TelFunc { get; set; }

        public int NivelAcesso { get; set; }
    }
}
