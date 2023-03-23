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
    public class CotacaoConfig : IEntityTypeConfiguration<Cotacao>
    {
        public void Configure(EntityTypeBuilder<Cotacao> entityTypeBuilder)
        {
            entityTypeBuilder.ToTable("Cotacao");

            entityTypeBuilder.HasKey(x => x.Id);

            entityTypeBuilder.Property(x => x.CnpjComprador)
                .IsRequired(true)
                .HasColumnName("CnpjComprador")
                .HasColumnType("varchar(14)");

        }
    }
}
