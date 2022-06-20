﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApi.Datos;

#nullable disable

namespace WebApi.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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
                    b.Property<int>("Etiqueta_ID")
                        .HasColumnType("int");

                    b.Property<int>("ArticuloId")
                        .HasColumnType("int");

                    b.HasKey("Etiqueta_ID", "ArticuloId");

                    b.HasIndex("ArticuloId");

                    b.ToTable("ArticuloEtiqueta");
                });

            modelBuilder.Entity("WebApi.Models.Categoria", b =>
                {
                    b.Property<int>("Categoria_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Categoria_Id"), 1L, 1);

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Categoria_Id");

                    b.ToTable("Categorias");
                });

            modelBuilder.Entity("WebApi.Models.DetalleUsuario", b =>
                {
                    b.Property<int>("DetalleUsuarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DetalleUsuarioId"), 1L, 1);

                    b.Property<string>("Cedula")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Deporte")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Mascota")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DetalleUsuarioId");

                    b.ToTable("DetalleUsuarios");
                });

            modelBuilder.Entity("WebApi.Models.Etiqueta", b =>
                {
                    b.Property<int>("Etiqueta_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Etiqueta_ID"), 1L, 1);

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<string>("Titulo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Etiqueta_ID");

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
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

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
                        .HasForeignKey("Etiqueta_ID")
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
