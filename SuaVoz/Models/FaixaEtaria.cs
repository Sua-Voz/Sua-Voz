﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuaVoz.Models
{
    public class FaixaEtaria
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public IList<Denuncia> Denuncias { get; set; }
    }
}
