﻿// <auto-generated />
using System;
using Fiap.Web.AspNet3.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Fiap.Web.AspNet3.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20220801224005_ProdutoLoja")]
    partial class ProdutoLoja
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Fiap.Web.AspNet3.Models.ClientModel", b =>
                {
                    b.Property<int>("ClientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClientId"), 1L, 1);

                    b.Property<DateTime>("Birth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("nvarchar(70)");

                    b.Property<string>("Observation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RepresentanteId")
                        .HasColumnType("int");

                    b.HasKey("ClientId");

                    b.HasIndex("RepresentanteId");

                    b.ToTable("ClientAsp");
                });

            modelBuilder.Entity("Fiap.Web.AspNet3.Models.FornecedorModel", b =>
                {
                    b.Property<int>("FornecedorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("FornecedorId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FornecedorId"), 1L, 1);

                    b.Property<string>("Cnpj")
                        .IsRequired()
                        .HasMaxLength(14)
                        .HasColumnType("nvarchar(14)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FornecedorNome")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("nvarchar(70)");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.HasKey("FornecedorId");

                    b.ToTable("Fornecedor");
                });

            modelBuilder.Entity("Fiap.Web.AspNet3.Models.GerenteModel", b =>
                {
                    b.Property<int>("GerenteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("RepresentanteId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GerenteId"), 1L, 1);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Sobrenome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("GerenteId");

                    b.ToTable("Gerente");
                });

            modelBuilder.Entity("Fiap.Web.AspNet3.Models.LojaModel", b =>
                {
                    b.Property<int>("LojaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LojaId"), 1L, 1);

                    b.Property<string>("LojaNome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LojaId");

                    b.ToTable("Loja");
                });

            modelBuilder.Entity("Fiap.Web.AspNet3.Models.ProdutoLojaModel", b =>
                {
                    b.Property<int>("ProdutoLojaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProdutoLojaId"), 1L, 1);

                    b.Property<int>("LojaId")
                        .HasColumnType("int");

                    b.Property<int>("ProdutoId")
                        .HasColumnType("int");

                    b.HasKey("ProdutoLojaId");

                    b.HasIndex("LojaId");

                    b.HasIndex("ProdutoId");

                    b.ToTable("ProdutoLoja");
                });

            modelBuilder.Entity("Fiap.Web.AspNet3.Models.ProdutoModel", b =>
                {
                    b.Property<int>("ProdutoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProdutoId"), 1L, 1);

                    b.Property<string>("ProdutoNome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProdutoId");

                    b.ToTable("Produto");
                });

            modelBuilder.Entity("Fiap.Web.AspNet3.Models.RepresentanteModel", b =>
                {
                    b.Property<int>("RepresentanteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("RepresentanteId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RepresentanteId"), 1L, 1);

                    b.Property<string>("NomeRepresentante")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("RepresentanteId");

                    b.ToTable("Representante");
                });

            modelBuilder.Entity("Fiap.Web.AspNet3.Models.ClientModel", b =>
                {
                    b.HasOne("Fiap.Web.AspNet3.Models.RepresentanteModel", "Representante")
                        .WithMany("Clientes")
                        .HasForeignKey("RepresentanteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Representante");
                });

            modelBuilder.Entity("Fiap.Web.AspNet3.Models.ProdutoLojaModel", b =>
                {
                    b.HasOne("Fiap.Web.AspNet3.Models.LojaModel", "Loja")
                        .WithMany()
                        .HasForeignKey("LojaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Fiap.Web.AspNet3.Models.ProdutoModel", "Produto")
                        .WithMany()
                        .HasForeignKey("ProdutoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Loja");

                    b.Navigation("Produto");
                });

            modelBuilder.Entity("Fiap.Web.AspNet3.Models.RepresentanteModel", b =>
                {
                    b.Navigation("Clientes");
                });
#pragma warning restore 612, 618
        }
    }
}