﻿// <auto-generated />
using System;
using LocacaoImoveis.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LocacaoImoveis.Infrastructure.Migrations
{
    [DbContext(typeof(ImovelContext))]
    partial class ImovelContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("LocacaoImoveis.Business.Models.Endereco", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Cep")
                        .IsRequired()
                        .HasColumnType("varchar(8)");

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Complemento")
                        .IsRequired()
                        .HasColumnType("varchar(250)");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<int>("ImovelId")
                        .HasColumnType("int");

                    b.Property<string>("Logradouro")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("ImovelId")
                        .IsUnique();

                    b.ToTable("ENDERECO");
                });

            modelBuilder.Entity("LocacaoImoveis.Domain.v1.Models.Imagem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("CaminhoImagem")
                        .IsRequired()
                        .HasColumnType("varchar(300)");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime2");

                    b.Property<int>("ImovelId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ImovelId");

                    b.ToTable("IMAGEM");
                });

            modelBuilder.Entity("LocacaoImoveis.Domain.v1.Models.Imovel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("DataAnuncio")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<int>("Metros2")
                        .HasColumnType("int");

                    b.Property<string>("NomProprietario")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<int>("VagasGaragem")
                        .HasColumnType("int");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("tipoImovel")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("IMOVEL");
                });

            modelBuilder.Entity("LocacaoImoveis.Business.Models.Endereco", b =>
                {
                    b.HasOne("LocacaoImoveis.Domain.v1.Models.Imovel", "Imovel")
                        .WithOne("Endereco")
                        .HasForeignKey("LocacaoImoveis.Business.Models.Endereco", "ImovelId")
                        .IsRequired();

                    b.Navigation("Imovel");
                });

            modelBuilder.Entity("LocacaoImoveis.Domain.v1.Models.Imagem", b =>
                {
                    b.HasOne("LocacaoImoveis.Domain.v1.Models.Imovel", "Imovel")
                        .WithMany("Imagem")
                        .HasForeignKey("ImovelId")
                        .IsRequired();

                    b.Navigation("Imovel");
                });

            modelBuilder.Entity("LocacaoImoveis.Domain.v1.Models.Imovel", b =>
                {
                    b.Navigation("Endereco");

                    b.Navigation("Imagem");
                });
#pragma warning restore 612, 618
        }
    }
}
