using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IaraProj.Domain.Entities;

namespace IaraProj.Infra.Data.EntityConfig
{
    public class CotacaoItemConfig : IEntityTypeConfiguration<CotacaoItem>
    {
        public void Configure(EntityTypeBuilder<CotacaoItem> entityTypeBuilder)
        {
            entityTypeBuilder.ToTable("CotacaoItem");

            entityTypeBuilder.HasKey(x => x.Id);

            entityTypeBuilder.Property(x => x.Descricao)
                .IsRequired(true)
                .HasColumnName("Descricao")
                .HasColumnType("varchar(500)");

            entityTypeBuilder.HasOne(x => x.Cotacao)
              .WithMany(x => x.CotacaoItens)
              .HasForeignKey(x => x.IdCotacao)
              .OnDelete(DeleteBehavior.NoAction)
              .IsRequired(true);
        }
    }
}
