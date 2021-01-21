using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace SIGO.Usuarios.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "modulos",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    nome_exibicao = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    data_inclusao = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    data_alteracao = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_modulos", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "usuarios",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    email = table.Column<string>(type: "character varying(512)", maxLength: 512, nullable: true),
                    celular = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: true),
                    senha = table.Column<string>(type: "character varying(512)", maxLength: 512, nullable: true),
                    codigo_verificacao = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    expiracao_codigo_verificacao = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    data_inclusao = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    data_alteracao = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuarios", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "usuarios_modulos",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_usuario = table.Column<int>(type: "integer", nullable: false),
                    id_modulo = table.Column<int>(type: "integer", nullable: false),
                    UsuarioId1 = table.Column<int>(type: "integer", nullable: true),
                    data_inclusao = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    data_alteracao = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuarios_modulos", x => x.id);
                    table.ForeignKey(
                        name: "FK_usuarios_modulos_modulos_id_modulo",
                        column: x => x.id_modulo,
                        principalTable: "modulos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_usuarios_modulos_usuarios_id_usuario",
                        column: x => x.id_usuario,
                        principalTable: "usuarios",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_usuarios_modulos_usuarios_UsuarioId1",
                        column: x => x.UsuarioId1,
                        principalTable: "usuarios",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "modulos",
                columns: new[] { "id", "data_alteracao", "data_inclusao", "nome", "nome_exibicao" },
                values: new object[,]
                {
                    { 1, null, new DateTimeOffset(new DateTime(2021, 1, 21, 21, 37, 34, 920, DateTimeKind.Unspecified).AddTicks(2111), new TimeSpan(0, 0, 0, 0, 0)), "usuarios", "Gerenciamento de Usuários" },
                    { 2, null, new DateTimeOffset(new DateTime(2021, 1, 21, 21, 37, 34, 920, DateTimeKind.Unspecified).AddTicks(2172), new TimeSpan(0, 0, 0, 0, 0)), "normas-tecnicas", "Normas Técnicas" },
                    { 3, null, new DateTimeOffset(new DateTime(2021, 1, 21, 21, 37, 34, 920, DateTimeKind.Unspecified).AddTicks(2175), new TimeSpan(0, 0, 0, 0, 0)), "assessorias-consultorias", "Assessorias e Consultorias" }
                });

            migrationBuilder.InsertData(
                table: "usuarios",
                columns: new[] { "id", "celular", "codigo_verificacao", "data_alteracao", "data_inclusao", "email", "expiracao_codigo_verificacao", "nome", "senha" },
                values: new object[] { 1, "1199999999", null, null, new DateTimeOffset(new DateTime(2021, 1, 21, 21, 37, 34, 917, DateTimeKind.Unspecified).AddTicks(9843), new TimeSpan(0, 0, 0, 0, 0)), "d830635c6cc19bb67f732cf95653100d55c7f17b4523b2bab3a62408b81c00f3f7f71e8a910693ed8767b7f84aa95c463b4eee614957043200a9931e02ecfc80", null, "Administrador", "4c7ad029115071a8cdfaa17aae1a997b9e5f891033b771d38b79b07fd44a887909144ce6f015ed7b62efefdf6564079d7b4407db226065147dd1e48cc0a868df" });

            migrationBuilder.InsertData(
                table: "usuarios_modulos",
                columns: new[] { "id", "data_alteracao", "data_inclusao", "id_modulo", "id_usuario", "UsuarioId1" },
                values: new object[,]
                {
                    { 1, null, new DateTimeOffset(new DateTime(2021, 1, 21, 21, 37, 34, 931, DateTimeKind.Unspecified).AddTicks(9987), new TimeSpan(0, 0, 0, 0, 0)), 1, 1, null },
                    { 2, null, new DateTimeOffset(new DateTime(2021, 1, 21, 21, 37, 34, 932, DateTimeKind.Unspecified).AddTicks(61), new TimeSpan(0, 0, 0, 0, 0)), 2, 1, null },
                    { 3, null, new DateTimeOffset(new DateTime(2021, 1, 21, 21, 37, 34, 932, DateTimeKind.Unspecified).AddTicks(63), new TimeSpan(0, 0, 0, 0, 0)), 3, 1, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_usuarios_modulos_id_modulo",
                table: "usuarios_modulos",
                column: "id_modulo");

            migrationBuilder.CreateIndex(
                name: "IX_usuarios_modulos_id_usuario",
                table: "usuarios_modulos",
                column: "id_usuario");

            migrationBuilder.CreateIndex(
                name: "IX_usuarios_modulos_UsuarioId1",
                table: "usuarios_modulos",
                column: "UsuarioId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "usuarios_modulos");

            migrationBuilder.DropTable(
                name: "modulos");

            migrationBuilder.DropTable(
                name: "usuarios");
        }
    }
}
