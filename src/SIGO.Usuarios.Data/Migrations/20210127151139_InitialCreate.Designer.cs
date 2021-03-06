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
    [Migration("20210127151139_InitialCreate")]
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
                            DataInclusao = new DateTimeOffset(new DateTime(2021, 1, 27, 15, 11, 38, 159, DateTimeKind.Unspecified).AddTicks(686), new TimeSpan(0, 0, 0, 0, 0)),
                            Nome = "usuarios",
                            NomeExibicao = "Gerenciamento de Usuários"
                        },
                        new
                        {
                            Id = 2,
                            DataInclusao = new DateTimeOffset(new DateTime(2021, 1, 27, 15, 11, 38, 159, DateTimeKind.Unspecified).AddTicks(785), new TimeSpan(0, 0, 0, 0, 0)),
                            Nome = "normas-tecnicas",
                            NomeExibicao = "Normas Técnicas"
                        },
                        new
                        {
                            Id = 3,
                            DataInclusao = new DateTimeOffset(new DateTime(2021, 1, 27, 15, 11, 38, 159, DateTimeKind.Unspecified).AddTicks(790), new TimeSpan(0, 0, 0, 0, 0)),
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

                    b.Property<bool>("UsuarioExterno")
                        .HasColumnType("boolean")
                        .HasColumnName("usuario_externo");

                    b.HasKey("Id");

                    b.ToTable("usuarios");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Celular = "AC6D5A87D5F3656E4D46A5224CD2D52A",
                            DataInclusao = new DateTimeOffset(new DateTime(2021, 1, 27, 15, 11, 38, 154, DateTimeKind.Unspecified).AddTicks(7758), new TimeSpan(0, 0, 0, 0, 0)),
                            Email = "D837ECDE06F1C5BD58C8439D226B0B2CF5FD68AAD16B014DF691065FF1D3C90D",
                            Nome = "Murilo",
                            Senha = "96c90eb59dc05559ba78f4f6e76def228f18d0bad15d32a7886996ceb5d63d1a8a9c905d8667451de20cbaac46a3379d4a5469a1e285d692005b9f7b55aefb23",
                            UsuarioExterno = false
                        },
                        new
                        {
                            Id = 2,
                            Celular = "AC6D5A87D5F3656E4D46A5224CD2D52A",
                            DataInclusao = new DateTimeOffset(new DateTime(2021, 1, 27, 15, 11, 38, 154, DateTimeKind.Unspecified).AddTicks(8699), new TimeSpan(0, 0, 0, 0, 0)),
                            Email = "C7BAFB527E21B2D84C246EA6B07C4FBE03C429CE62B43C57F8DE48AF48A9F52B",
                            Nome = "José Carlos Santos",
                            Senha = "96c90eb59dc05559ba78f4f6e76def228f18d0bad15d32a7886996ceb5d63d1a8a9c905d8667451de20cbaac46a3379d4a5469a1e285d692005b9f7b55aefb23",
                            UsuarioExterno = true
                        },
                        new
                        {
                            Id = 3,
                            Celular = "AC6D5A87D5F3656E4D46A5224CD2D52A",
                            DataInclusao = new DateTimeOffset(new DateTime(2021, 1, 27, 15, 11, 38, 154, DateTimeKind.Unspecified).AddTicks(9359), new TimeSpan(0, 0, 0, 0, 0)),
                            Email = "C7BAFB527E21B2D84C246EA6B07C4FBE6155E04E10E1A0AA0ECD6596F7512C95",
                            Nome = "Ana Maria Oliveira",
                            Senha = "96c90eb59dc05559ba78f4f6e76def228f18d0bad15d32a7886996ceb5d63d1a8a9c905d8667451de20cbaac46a3379d4a5469a1e285d692005b9f7b55aefb23",
                            UsuarioExterno = true
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

                    b.HasKey("Id");

                    b.HasIndex("ModuloId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("usuarios_modulos");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DataInclusao = new DateTimeOffset(new DateTime(2021, 1, 27, 15, 11, 38, 186, DateTimeKind.Unspecified).AddTicks(5670), new TimeSpan(0, 0, 0, 0, 0)),
                            ModuloId = 1,
                            UsuarioId = 1
                        },
                        new
                        {
                            Id = 2,
                            DataInclusao = new DateTimeOffset(new DateTime(2021, 1, 27, 15, 11, 38, 186, DateTimeKind.Unspecified).AddTicks(5745), new TimeSpan(0, 0, 0, 0, 0)),
                            ModuloId = 2,
                            UsuarioId = 1
                        },
                        new
                        {
                            Id = 3,
                            DataInclusao = new DateTimeOffset(new DateTime(2021, 1, 27, 15, 11, 38, 186, DateTimeKind.Unspecified).AddTicks(5748), new TimeSpan(0, 0, 0, 0, 0)),
                            ModuloId = 3,
                            UsuarioId = 1
                        },
                        new
                        {
                            Id = 4,
                            DataInclusao = new DateTimeOffset(new DateTime(2021, 1, 27, 15, 11, 38, 186, DateTimeKind.Unspecified).AddTicks(5750), new TimeSpan(0, 0, 0, 0, 0)),
                            ModuloId = 3,
                            UsuarioId = 2
                        },
                        new
                        {
                            Id = 5,
                            DataInclusao = new DateTimeOffset(new DateTime(2021, 1, 27, 15, 11, 38, 186, DateTimeKind.Unspecified).AddTicks(5751), new TimeSpan(0, 0, 0, 0, 0)),
                            ModuloId = 3,
                            UsuarioId = 3
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
                        .WithMany("Modulos")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

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
