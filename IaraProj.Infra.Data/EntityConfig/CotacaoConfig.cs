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
                .IsRequired()
                .HasColumnName("CnpjComprador")
                .HasColumnType("varchar(14)");

            entityTypeBuilder.Property(x => x.CNPJFornecedor)
               .IsRequired()
               .HasColumnName("CNPJFornecedor")
               .HasColumnType("varchar(14)");

            entityTypeBuilder.Property(x => x.NumeroCotacao)
               .IsRequired()
               .HasColumnName("NumeroCotacao")
               .HasColumnType("int");

            entityTypeBuilder.Property(x => x.DataCotacao)
               .IsRequired()
               .HasColumnName("DataCotacao")
               .HasColumnType("datetime");

            entityTypeBuilder.Property(x => x.DataEntregaCotacao)
               .IsRequired()
               .HasColumnName("DataEntregaCotacao")
               .HasColumnType("datetime");

            entityTypeBuilder.Property(x => x.CEP)
               .IsRequired()
               .HasColumnName("CEP")
               .HasColumnType("varchar(14)");

            entityTypeBuilder.Property(x => x.Logradouro)
               .HasColumnName("Logradouro")
               .HasColumnType("varchar(50)");

            entityTypeBuilder.Property(x => x.Complemento)
               .HasColumnName("Complemento")
               .HasColumnType("varchar(50)");

            entityTypeBuilder.Property(x => x.Bairro)
               .HasColumnName("Bairro")
               .HasColumnType("varchar(50)");

            entityTypeBuilder.Property(x => x.UF)
               .HasColumnName("UF")
               .HasColumnType("varchar(5)");

            entityTypeBuilder.Property(x => x.Observacao)
               .HasColumnName("Observacao")
               .HasColumnType("nvarchar(max)");

        }
    }
}
