using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SuaVoz.Models
{
    public class Denuncia
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public int GeneroId { get; set; }
        public Genero Genero { get; set; }

        public int FaixaEtariaId { get; set; }
        public FaixaEtaria FaixaEtaria { get; set; }

        public int RegiaoId { get; set; }
        public Regiao Regiao { get; set; }

        public int TipoViolenciaId { get; set; }
        public TipoViolencia TipoViolencia { get; set; }

        [Column(TypeName = "date")]
        public DateTime DataOcorrencia { get; set; }

        [Column(TypeName = "text")]
        public string Relato { get; set; }
    }
}
