﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using SIGO.Usuarios.Data;

namespace SIGO.Usuarios.Data.Migrations
{
    [DbContext(typeof(UsuariosContext))]
    [Migration("20210122015536_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityByDefaultColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("SIGO.Usuarios.Entities.Modulo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .UseIdentityByDefaultColumn();

                    b.Property<DateTimeOffset?>("DataAlteracao")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("data_alteracao");

                    b.Property<DateTimeOffset>("DataInclusao")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("data_inclusao");

                    b.Property<string>("Nome")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("nome");

                    b.Property<string>("NomeExibicao")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("nome_exibicao");

                    b.HasKey("Id");

                    b.ToTable("modulos");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DataInclusao = new DateTimeOffset(new DateTime(2021, 1, 22, 1, 55, 35, 662, DateTimeKind.Unspecified).AddTicks(3945), new TimeSpan(0, 0, 0, 0, 0)),
                            Nome = "usuarios",
                            NomeExibicao = "Gerenciamento de Usuários"
                        },
                        new
                        {
                            Id = 2,
                            DataInclusao = new DateTimeOffset(new DateTime(2021, 1, 22, 1, 55, 35, 662, DateTimeKind.Unspecified).AddTicks(4054), new TimeSpan(0, 0, 0, 0, 0)),
                            Nome = "normas-tecnicas",
                            NomeExibicao = "Normas Técnicas"
                        },
                        new
                        {
                            Id = 3,
                            DataInclusao = new DateTimeOffset(new DateTime(2021, 1, 22, 1, 55, 35, 662, DateTimeKind.Unspecified).AddTicks(4060), new TimeSpan(0, 0, 0, 0, 0)),
                            Nome = "assessorias-consultorias",
                            NomeExibicao = "Assessorias e Consultorias"
                        });
                });

            modelBuilder.Entity("SIGO.Usuarios.Entities.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("Celular")
                        .HasMaxLength(40)
                        .HasColumnType("character varying(40)")
                        .HasColumnName("celular");

                    b.Property<string>("CodigoVerificacao")
                        .HasMaxLength(6)
                        .HasColumnType("character varying(6)")
                        .HasColumnName("codigo_verificacao");

                    b.Property<DateTimeOffset?>("DataAlteracao")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("data_alteracao");

                    b.Property<DateTimeOffset>("DataInclusao")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("data_inclusao");

                    b.Property<string>("Email")
                        .HasMaxLength(512)
                        .HasColumnType("character varying(512)")
                        .HasColumnName("email");

                    b.Property<DateTimeOffset?>("ExpiracaoCodigoVerificacao")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("expiracao_codigo_verificacao");

                    b.Property<string>("Nome")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("nome");

                    b.Property<string>("Senha")
                        .HasMaxLength(512)
                        .HasColumnType("character varying(512)")
                        .HasColumnName("senha");

                    b.HasKey("Id");

                    b.ToTable("usuarios");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Celular = "AC6D5A87D5F3656E4D46A5224CD2D52A",
                            DataInclusao = new DateTimeOffset(new DateTime(2021, 1, 22, 1, 55, 35, 655, DateTimeKind.Unspecified).AddTicks(9706), new TimeSpan(0, 0, 0, 0, 0)),
                            Email = "6CA8AD90817B9A591E1EEDC5C183F4C9E4E2B32E1DD6EFDD688D2A47A0A83A79",
                            Nome = "Administrador",
                            Senha = "4c7ad029115071a8cdfaa17aae1a997b9e5f891033b771d38b79b07fd44a887909144ce6f015ed7b62efefdf6564079d7b4407db226065147dd1e48cc0a868df"
                        });
                });

            modelBuilder.Entity("SIGO.Usuarios.Entities.UsuarioModulo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .UseIdentityByDefaultColumn();

                    b.Property<DateTimeOffset?>("DataAlteracao")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("data_alteracao");

                    b.Property<DateTimeOffset>("DataInclusao")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("data_inclusao");

                    b.Property<int>("ModuloId")
                        .HasColumnType("integer")
                        .HasColumnName("id_modulo");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("integer")
                        .HasColumnName("id_usuario");

                    b.Property<int?>("UsuarioId1")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ModuloId");

                    b.HasIndex("UsuarioId");

                    b.HasIndex("UsuarioId1");

                    b.ToTable("usuarios_modulos");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DataInclusao = new DateTimeOffset(new DateTime(2021, 1, 22, 1, 55, 35, 676, DateTimeKind.Unspecified).AddTicks(8433), new TimeSpan(0, 0, 0, 0, 0)),
                            ModuloId = 1,
                            UsuarioId = 1
                        },
                        new
                        {
                            Id = 2,
                            DataInclusao = new DateTimeOffset(new DateTime(2021, 1, 22, 1, 55, 35, 676, DateTimeKind.Unspecified).AddTicks(8513), new TimeSpan(0, 0, 0, 0, 0)),
                            ModuloId = 2,
                            UsuarioId = 1
                        },
                        new
                        {
                            Id = 3,
                            DataInclusao = new DateTimeOffset(new DateTime(2021, 1, 22, 1, 55, 35, 676, DateTimeKind.Unspecified).AddTicks(8516), new TimeSpan(0, 0, 0, 0, 0)),
                            ModuloId = 3,
                            UsuarioId = 1
                        });
                });

            modelBuilder.Entity("SIGO.Usuarios.Entities.UsuarioModulo", b =>
                {
                    b.HasOne("SIGO.Usuarios.Entities.Modulo", "Modulo")
                        .WithMany()
                        .HasForeignKey("ModuloId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SIGO.Usuarios.Entities.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SIGO.Usuarios.Entities.Usuario", null)
                        .WithMany("Modulos")
                        .HasForeignKey("UsuarioId1");

                    b.Navigation("Modulo");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("SIGO.Usuarios.Entities.Usuario", b =>
                {
                    b.Navigation("Modulos");
                });
#pragma warning restore 612, 618
        }
    }
}