using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuaVoz.Models
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }
        public DbSet<Denuncia> Denuncias { get; set; }
        public DbSet<Genero> Generos { get; set; }
        public DbSet<Regiao> Regioes { get; set; }
        public DbSet<TipoViolencia> TiposViolencia { get; set; }
        public DbSet<FaixaEtaria> FaixasEtarias { get; set; }
    }
}
