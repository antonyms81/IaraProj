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

            entityTypeBuilder.Property(x => x.NumeroItem)
               .IsRequired(true)
               .HasColumnName("NumeroItem")
               .HasColumnType("int");

            entityTypeBuilder.Property(x => x.Preco)
               .IsRequired(true)
               .HasColumnName("Preco")
               .HasColumnType("float");

            entityTypeBuilder.Property(x => x.Quantidade)
               .IsRequired(true)
               .HasColumnName("Quantidade")
               .HasColumnType("int");

            entityTypeBuilder.Property(x => x.Marca)
               .IsRequired(true)
               .HasColumnName("Marca")
               .HasColumnType("varchar(50)");

            entityTypeBuilder.Property(x => x.Unidade)
              .IsRequired(true)
              .HasColumnName("Unidade")
              .HasColumnType("varchar(50)");

            entityTypeBuilder.HasOne(x => x.Cotacao)
              .WithMany(x => x.CotacaoItens)
              .HasForeignKey(x => x.IdCotacao)
              .OnDelete(DeleteBehavior.NoAction)
              .IsRequired(true);
        }
    }
}
