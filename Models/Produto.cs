﻿using System;

namespace api_tcc.Models
{
    public class Produto
    {
        public int IdProd { get; set; }

        public string NomeProd { get; set; }

        public string DescProd { get; set; }
        
        public string PrecoProd { get; set; }

        public string CategoriaProd { get; set; }

        public string StatusProd { get; set; }
    }
}
