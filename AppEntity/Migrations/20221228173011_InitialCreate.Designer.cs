﻿// <auto-generated />
using AppEntity.Contexto;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AppEntity.Migrations
{
    [DbContext(typeof(TareasContext))]
    [Migration("20221228173011_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("AppEntity.Modelos.Categoria", b =>
                {
                    b.Property<int>("CategoriaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoriaId"), 1L, 1);

                    b.Property<string>("CategoriaName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("CategoriaId");

                    b.ToTable("Categorias", (string)null);
                });

            modelBuilder.Entity("AppEntity.Modelos.Tarea", b =>
                {
                    b.Property<int>("TareaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TareaId"), 1L, 1);

                    b.Property<int>("IdCategoria")
                        .HasColumnType("int");

                    b.Property<string>("TareaName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TareaId");

                    b.HasIndex("IdCategoria");

                    b.ToTable("TareasNovedosasSuperExclusivas", (string)null);
                });

            modelBuilder.Entity("AppEntity.Modelos.Tarea", b =>
                {
                    b.HasOne("AppEntity.Modelos.Categoria", "categoria")
                        .WithMany("tareas")
                        .HasForeignKey("IdCategoria")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("categoria");
                });

            modelBuilder.Entity("AppEntity.Modelos.Categoria", b =>
                {
                    b.Navigation("tareas");
                });
#pragma warning restore 612, 618
        }
    }
}