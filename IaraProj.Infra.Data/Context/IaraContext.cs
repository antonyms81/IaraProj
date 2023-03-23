using IaraProj.Domain.Entities;
using IaraProj.Infra.Data.EntityConfig;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace IaraProj.Infra.Data.Context
{
    public class IaraContext : DbContext
    {
        public IaraContext()
        {

        }

        public IaraContext(DbContextOptions<IaraContext> options) : base(options)
        {

        }

        public DbSet<Cotacao> Cotacoes { get; set; }
        public DbSet<CotacaoItem> CotacaoItens { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer("Server=(LocalDB)\\Local;Database=DbIara;Integrated Security=true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Cotacao>(new CotacaoConfig().Configure);
        }
    }
}
