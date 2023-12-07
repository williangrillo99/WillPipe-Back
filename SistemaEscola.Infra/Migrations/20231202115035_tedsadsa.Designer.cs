﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SistemaEscola.Infra;

#nullable disable

namespace SistemaEscola.Infra.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20231202115035_tedsadsa")]
    partial class tedsadsa
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SistemaEscola.Dominio.Baords.Entidade.Board", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Baords");
                });

            modelBuilder.Entity("SistemaEscola.Dominio.Cartoes.Entidade.Cartao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ColunaId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataFim")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataInicio")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Index")
                        .HasColumnType("int");

                    b.Property<int>("Progresso")
                        .HasColumnType("int");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UsuarioResponsavelId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ColunaId");

                    b.HasIndex("UsuarioResponsavelId");

                    b.ToTable("Cartaos");
                });

            modelBuilder.Entity("SistemaEscola.Dominio.Colunas.Entidade.Coluna", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BoardId")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BoardId");

                    b.ToTable("Colunas");
                });

            modelBuilder.Entity("SistemaEscola.Dominio.Comentarios.Entidade.Comentario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CartaoId")
                        .HasColumnType("int");

                    b.Property<string>("Texto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CartaoId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Comentarios");
                });

            modelBuilder.Entity("SistemaEscola.Dominio.Tarefas.Entidade.Tarefa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CartaoId")
                        .HasColumnType("int");

                    b.Property<bool>("Completo")
                        .HasColumnType("bit");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CartaoId");

                    b.ToTable("Tarefas");
                });

            modelBuilder.Entity("SistemaEscola.Dominio.Usuarios.Entidade.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Dominio")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TipoUsuarioEnum")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("SistemaEscola.Dominio.Cartoes.Entidade.Cartao", b =>
                {
                    b.HasOne("SistemaEscola.Dominio.Colunas.Entidade.Coluna", "Coluna")
                        .WithMany("Cartoes")
                        .HasForeignKey("ColunaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SistemaEscola.Dominio.Usuarios.Entidade.Usuario", "UsuarioResponsavel")
                        .WithMany()
                        .HasForeignKey("UsuarioResponsavelId");

                    b.Navigation("Coluna");

                    b.Navigation("UsuarioResponsavel");
                });

            modelBuilder.Entity("SistemaEscola.Dominio.Colunas.Entidade.Coluna", b =>
                {
                    b.HasOne("SistemaEscola.Dominio.Baords.Entidade.Board", "Board")
                        .WithMany("Colunas")
                        .HasForeignKey("BoardId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Board");
                });

            modelBuilder.Entity("SistemaEscola.Dominio.Comentarios.Entidade.Comentario", b =>
                {
                    b.HasOne("SistemaEscola.Dominio.Cartoes.Entidade.Cartao", null)
                        .WithMany("Comentarios")
                        .HasForeignKey("CartaoId");

                    b.HasOne("SistemaEscola.Dominio.Usuarios.Entidade.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("SistemaEscola.Dominio.Tarefas.Entidade.Tarefa", b =>
                {
                    b.HasOne("SistemaEscola.Dominio.Cartoes.Entidade.Cartao", "Cartao")
                        .WithMany("Tarefas")
                        .HasForeignKey("CartaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cartao");
                });

            modelBuilder.Entity("SistemaEscola.Dominio.Baords.Entidade.Board", b =>
                {
                    b.Navigation("Colunas");
                });

            modelBuilder.Entity("SistemaEscola.Dominio.Cartoes.Entidade.Cartao", b =>
                {
                    b.Navigation("Comentarios");

                    b.Navigation("Tarefas");
                });

            modelBuilder.Entity("SistemaEscola.Dominio.Colunas.Entidade.Coluna", b =>
                {
                    b.Navigation("Cartoes");
                });
#pragma warning restore 612, 618
        }
    }
}
