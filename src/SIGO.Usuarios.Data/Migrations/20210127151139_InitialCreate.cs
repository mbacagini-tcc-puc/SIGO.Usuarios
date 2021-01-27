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
                    usuario_externo = table.Column<bool>(type: "boolean", nullable: false),
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
                    { 1, null, new DateTimeOffset(new DateTime(2021, 1, 27, 15, 11, 38, 159, DateTimeKind.Unspecified).AddTicks(686), new TimeSpan(0, 0, 0, 0, 0)), "usuarios", "Gerenciamento de Usuários" },
                    { 2, null, new DateTimeOffset(new DateTime(2021, 1, 27, 15, 11, 38, 159, DateTimeKind.Unspecified).AddTicks(785), new TimeSpan(0, 0, 0, 0, 0)), "normas-tecnicas", "Normas Técnicas" },
                    { 3, null, new DateTimeOffset(new DateTime(2021, 1, 27, 15, 11, 38, 159, DateTimeKind.Unspecified).AddTicks(790), new TimeSpan(0, 0, 0, 0, 0)), "assessorias-consultorias", "Assessorias e Consultorias" }
                });

            migrationBuilder.InsertData(
                table: "usuarios",
                columns: new[] { "id", "celular", "codigo_verificacao", "data_alteracao", "data_inclusao", "email", "expiracao_codigo_verificacao", "nome", "senha", "usuario_externo" },
                values: new object[,]
                {
                    { 1, "AC6D5A87D5F3656E4D46A5224CD2D52A", null, null, new DateTimeOffset(new DateTime(2021, 1, 27, 15, 11, 38, 154, DateTimeKind.Unspecified).AddTicks(7758), new TimeSpan(0, 0, 0, 0, 0)), "D837ECDE06F1C5BD58C8439D226B0B2CF5FD68AAD16B014DF691065FF1D3C90D", null, "Murilo", "96c90eb59dc05559ba78f4f6e76def228f18d0bad15d32a7886996ceb5d63d1a8a9c905d8667451de20cbaac46a3379d4a5469a1e285d692005b9f7b55aefb23", false },
                    { 2, "AC6D5A87D5F3656E4D46A5224CD2D52A", null, null, new DateTimeOffset(new DateTime(2021, 1, 27, 15, 11, 38, 154, DateTimeKind.Unspecified).AddTicks(8699), new TimeSpan(0, 0, 0, 0, 0)), "C7BAFB527E21B2D84C246EA6B07C4FBE03C429CE62B43C57F8DE48AF48A9F52B", null, "José Carlos Santos", "96c90eb59dc05559ba78f4f6e76def228f18d0bad15d32a7886996ceb5d63d1a8a9c905d8667451de20cbaac46a3379d4a5469a1e285d692005b9f7b55aefb23", true },
                    { 3, "AC6D5A87D5F3656E4D46A5224CD2D52A", null, null, new DateTimeOffset(new DateTime(2021, 1, 27, 15, 11, 38, 154, DateTimeKind.Unspecified).AddTicks(9359), new TimeSpan(0, 0, 0, 0, 0)), "C7BAFB527E21B2D84C246EA6B07C4FBE6155E04E10E1A0AA0ECD6596F7512C95", null, "Ana Maria Oliveira", "96c90eb59dc05559ba78f4f6e76def228f18d0bad15d32a7886996ceb5d63d1a8a9c905d8667451de20cbaac46a3379d4a5469a1e285d692005b9f7b55aefb23", true }
                });

            migrationBuilder.InsertData(
                table: "usuarios_modulos",
                columns: new[] { "id", "data_alteracao", "data_inclusao", "id_modulo", "id_usuario" },
                values: new object[,]
                {
                    { 1, null, new DateTimeOffset(new DateTime(2021, 1, 27, 15, 11, 38, 186, DateTimeKind.Unspecified).AddTicks(5670), new TimeSpan(0, 0, 0, 0, 0)), 1, 1 },
                    { 2, null, new DateTimeOffset(new DateTime(2021, 1, 27, 15, 11, 38, 186, DateTimeKind.Unspecified).AddTicks(5745), new TimeSpan(0, 0, 0, 0, 0)), 2, 1 },
                    { 3, null, new DateTimeOffset(new DateTime(2021, 1, 27, 15, 11, 38, 186, DateTimeKind.Unspecified).AddTicks(5748), new TimeSpan(0, 0, 0, 0, 0)), 3, 1 },
                    { 4, null, new DateTimeOffset(new DateTime(2021, 1, 27, 15, 11, 38, 186, DateTimeKind.Unspecified).AddTicks(5750), new TimeSpan(0, 0, 0, 0, 0)), 3, 2 },
                    { 5, null, new DateTimeOffset(new DateTime(2021, 1, 27, 15, 11, 38, 186, DateTimeKind.Unspecified).AddTicks(5751), new TimeSpan(0, 0, 0, 0, 0)), 3, 3 }
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
