﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApi.Datos;

#nullable disable

namespace WebApi.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220620022706_CorrigiendoElNombreDeLaTablaCategoria")]
    partial class CorrigiendoElNombreDeLaTablaCategoria
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("WebApi.Models.Articulo", b =>
                {
                    b.Property<int>("ArticuloId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ArticuloId"), 1L, 1);

                    b.Property<double>("Calificacion")
                        .HasColumnType("float");

                    b.Property<int>("CategoriaID")
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("ArticuloId");

                    b.HasIndex("CategoriaID");

                    b.ToTable("Articulos");
                });

            modelBuilder.Entity("WebApi.Models.ArticuloEtiqueta", b =>
                {
                    b.Property<int>("EtiquetaID")
                        .HasColumnType("int");

                    b.Property<int>("ArticuloId")
                        .HasColumnType("int");

                    b.HasKey("EtiquetaID", "ArticuloId");

                    b.HasIndex("ArticuloId");

                    b.ToTable("ArticuloEtiqueta");
                });

            modelBuilder.Entity("WebApi.Models.Categoria", b =>
                {
                    b.Property<int>("CategoriaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoriaId"), 1L, 1);

                    b.Property<string>("Nombre")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("CategoriaId");

                    b.ToTable("Categorias");
                });

            modelBuilder.Entity("WebApi.Models.DetalleUsuario", b =>
                {
                    b.Property<int>("DetalleUsuarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DetalleUsuarioId"), 1L, 1);

                    b.Property<string>("Cedula")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Deporte")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Mascota")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("DetalleUsuarioId");

                    b.ToTable("DetalleUsuarios");
                });

            modelBuilder.Entity("WebApi.Models.Etiqueta", b =>
                {
                    b.Property<int>("EtiquetaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EtiquetaID"), 1L, 1);

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("EtiquetaID");

                    b.ToTable("Etiquetas");
                });

            modelBuilder.Entity("WebApi.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("DetalleUsuarioId")
                        .HasColumnType("int");

                    b.Property<string>("Direccion")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Edad")
                        .HasMaxLength(50)
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DetalleUsuarioId")
                        .IsUnique();

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("WebApi.Models.Articulo", b =>
                {
                    b.HasOne("WebApi.Models.Categoria", "Categoria")
                        .WithMany("Articulo")
                        .HasForeignKey("CategoriaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categoria");
                });

            modelBuilder.Entity("WebApi.Models.ArticuloEtiqueta", b =>
                {
                    b.HasOne("WebApi.Models.Articulo", "Articulo")
                        .WithMany("ArticuloEtiqueta")
                        .HasForeignKey("ArticuloId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApi.Models.Etiqueta", "Etiqueta")
                        .WithMany("ArticuloEtiqueta")
                        .HasForeignKey("EtiquetaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Articulo");

                    b.Navigation("Etiqueta");
                });

            modelBuilder.Entity("WebApi.Models.Usuario", b =>
                {
                    b.HasOne("WebApi.Models.DetalleUsuario", "DetalleUsuario")
                        .WithOne("Usuario")
                        .HasForeignKey("WebApi.Models.Usuario", "DetalleUsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DetalleUsuario");
                });

            modelBuilder.Entity("WebApi.Models.Articulo", b =>
                {
                    b.Navigation("ArticuloEtiqueta");
                });

            modelBuilder.Entity("WebApi.Models.Categoria", b =>
                {
                    b.Navigation("Articulo");
                });

            modelBuilder.Entity("WebApi.Models.DetalleUsuario", b =>
                {
                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("WebApi.Models.Etiqueta", b =>
                {
                    b.Navigation("ArticuloEtiqueta");
                });
#pragma warning restore 612, 618
        }
    }
}
