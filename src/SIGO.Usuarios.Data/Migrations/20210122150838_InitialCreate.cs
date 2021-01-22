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
                    celular = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: true),
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
                });

            migrationBuilder.InsertData(
                table: "modulos",
                columns: new[] { "id", "data_alteracao", "data_inclusao", "nome", "nome_exibicao" },
                values: new object[,]
                {
                    { 1, null, new DateTimeOffset(new DateTime(2021, 1, 22, 15, 8, 37, 496, DateTimeKind.Unspecified).AddTicks(9110), new TimeSpan(0, 0, 0, 0, 0)), "usuarios", "Gerenciamento de Usuários" },
                    { 2, null, new DateTimeOffset(new DateTime(2021, 1, 22, 15, 8, 37, 496, DateTimeKind.Unspecified).AddTicks(9204), new TimeSpan(0, 0, 0, 0, 0)), "normas-tecnicas", "Normas Técnicas" },
                    { 3, null, new DateTimeOffset(new DateTime(2021, 1, 22, 15, 8, 37, 496, DateTimeKind.Unspecified).AddTicks(9210), new TimeSpan(0, 0, 0, 0, 0)), "assessorias-consultorias", "Assessorias e Consultorias" }
                });

            migrationBuilder.InsertData(
                table: "usuarios",
                columns: new[] { "id", "celular", "codigo_verificacao", "data_alteracao", "data_inclusao", "email", "expiracao_codigo_verificacao", "nome", "senha" },
                values: new object[] { 1, "AC6D5A87D5F3656E4D46A5224CD2D52A", null, null, new DateTimeOffset(new DateTime(2021, 1, 22, 15, 8, 37, 494, DateTimeKind.Unspecified).AddTicks(548), new TimeSpan(0, 0, 0, 0, 0)), "6CA8AD90817B9A591E1EEDC5C183F4C9E4E2B32E1DD6EFDD688D2A47A0A83A79", null, "Administrador", "4c7ad029115071a8cdfaa17aae1a997b9e5f891033b771d38b79b07fd44a887909144ce6f015ed7b62efefdf6564079d7b4407db226065147dd1e48cc0a868df" });

            migrationBuilder.InsertData(
                table: "usuarios_modulos",
                columns: new[] { "id", "data_alteracao", "data_inclusao", "id_modulo", "id_usuario" },
                values: new object[,]
                {
                    { 1, null, new DateTimeOffset(new DateTime(2021, 1, 22, 15, 8, 37, 514, DateTimeKind.Unspecified).AddTicks(1088), new TimeSpan(0, 0, 0, 0, 0)), 1, 1 },
                    { 2, null, new DateTimeOffset(new DateTime(2021, 1, 22, 15, 8, 37, 514, DateTimeKind.Unspecified).AddTicks(1173), new TimeSpan(0, 0, 0, 0, 0)), 2, 1 },
                    { 3, null, new DateTimeOffset(new DateTime(2021, 1, 22, 15, 8, 37, 514, DateTimeKind.Unspecified).AddTicks(1176), new TimeSpan(0, 0, 0, 0, 0)), 3, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_usuarios_modulos_id_modulo",
                table: "usuarios_modulos",
                column: "id_modulo");

            migrationBuilder.CreateIndex(
                name: "IX_usuarios_modulos_id_usuario",
                table: "usuarios_modulos",
                column: "id_usuario");
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
