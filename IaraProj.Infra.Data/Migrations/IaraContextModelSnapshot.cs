﻿// <auto-generated />
using System;
using IaraProj.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace IaraProj.Infra.Data.Migrations
{
    [DbContext(typeof(IaraContext))]
    partial class IaraContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("IaraProj.Domain.Entities.Cotacao", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Bairro")
                        .HasColumnType("varchar(50)")
                        .HasColumnName("Bairro");

                    b.Property<string>("CEP")
                        .IsRequired()
                        .HasColumnType("varchar(14)")
                        .HasColumnName("CEP");

                    b.Property<string>("CNPJFornecedor")
                        .IsRequired()
                        .HasColumnType("varchar(14)")
                        .HasColumnName("CNPJFornecedor");

                    b.Property<string>("CnpjComprador")
                        .IsRequired()
                        .HasColumnType("varchar(14)")
                        .HasColumnName("CnpjComprador");

                    b.Property<string>("Complemento")
                        .HasColumnType("varchar(50)")
                        .HasColumnName("Complemento");

                    b.Property<DateTime>("DataCotacao")
                        .HasColumnType("datetime")
                        .HasColumnName("DataCotacao");

                    b.Property<DateTime>("DataEntregaCotacao")
                        .HasColumnType("datetime")
                        .HasColumnName("DataEntregaCotacao");

                    b.Property<string>("Logradouro")
                        .HasColumnType("varchar(50)")
                        .HasColumnName("Logradouro");

                    b.Property<int>("NumeroCotacao")
                        .HasColumnType("int")
                        .HasColumnName("NumeroCotacao");

                    b.Property<string>("Observacao")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Observacao");

                    b.Property<string>("UF")
                        .HasColumnType("varchar(5)")
                        .HasColumnName("UF");

                    b.HasKey("Id");

                    b.ToTable("Cotacao", (string)null);
                });

            modelBuilder.Entity("IaraProj.Domain.Entities.CotacaoItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("varchar(500)")
                        .HasColumnName("Descricao");

                    b.Property<Guid>("IdCotacao")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Marca")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasColumnName("Marca");

                    b.Property<int>("NumeroItem")
                        .HasColumnType("int")
                        .HasColumnName("NumeroItem");

                    b.Property<double>("Preco")
                        .HasColumnType("float")
                        .HasColumnName("Preco");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int")
                        .HasColumnName("Quantidade");

                    b.Property<string>("Unidade")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasColumnName("Unidade");

                    b.HasKey("Id");

                    b.HasIndex("IdCotacao");

                    b.ToTable("CotacaoItem", (string)null);
                });

            modelBuilder.Entity("IaraProj.Domain.Entities.CotacaoItem", b =>
                {
                    b.HasOne("IaraProj.Domain.Entities.Cotacao", "Cotacao")
                        .WithMany("CotacaoItens")
                        .HasForeignKey("IdCotacao")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Cotacao");
                });

            modelBuilder.Entity("IaraProj.Domain.Entities.Cotacao", b =>
                {
                    b.Navigation("CotacaoItens");
                });
#pragma warning restore 612, 618
        }
    }
}
