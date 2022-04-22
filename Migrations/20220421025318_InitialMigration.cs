using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KanbanAPI.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Colaborador",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colaborador", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Coluna",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coluna", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Projeto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projeto", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Card",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TempoPrevisto = table.Column<int>(type: "int", nullable: false),
                    TempoCorrido = table.Column<int>(type: "int", nullable: false),
                    DataPrevista = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProjetoId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Card", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Card_Projeto_ProjetoId",
                        column: x => x.ProjetoId,
                        principalTable: "Projeto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Colaborador_Card",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ColaboradorId = table.Column<int>(type: "int", nullable: false),
                    CardId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colaborador_Card", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Colaborador_Card_Card_CardId",
                        column: x => x.CardId,
                        principalTable: "Card",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Colaborador_Card_Colaborador_ColaboradorId",
                        column: x => x.ColaboradorId,
                        principalTable: "Colaborador",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Coluna_Card",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ColunaId = table.Column<int>(type: "int", nullable: false),
                    CardId = table.Column<int>(type: "int", nullable: false),
                    Posicao = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coluna_Card", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Coluna_Card_Card_CardId",
                        column: x => x.CardId,
                        principalTable: "Card",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Coluna_Card_Coluna_ColunaId",
                        column: x => x.ColunaId,
                        principalTable: "Coluna",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Colaborador",
                columns: new[] { "Id", "Nome" },
                values: new object[,]
                {
                    { 1, "Mauro Guterres" },
                    { 2, "Afonso Solano" },
                    { 3, "Anderson Gaveta" }
                });

            migrationBuilder.InsertData(
                table: "Coluna",
                columns: new[] { "Id", "Nome" },
                values: new object[,]
                {
                    { 1, "Aguardando" },
                    { 2, "Em Andamento" },
                    { 3, "Pendência" },
                    { 4, "Finalizado" },
                    { 5, "Outros" }
                });

            migrationBuilder.InsertData(
                table: "Projeto",
                columns: new[] { "Id", "Nome" },
                values: new object[,]
                {
                    { 1, "Some Company" },
                    { 2, "Some Group" },
                    { 3, "Some Corp" }
                });

            migrationBuilder.InsertData(
                table: "Card",
                columns: new[] { "Id", "Codigo", "DataPrevista", "Descricao", "ProjetoId", "Status", "TempoCorrido", "TempoPrevisto", "Titulo" },
                values: new object[,]
                {
                    { 1, "XYB-12345", new DateTime(2022, 4, 23, 23, 53, 17, 887, DateTimeKind.Local).AddTicks(8216), "Criação de relatórios para asdrubal company", 1, 0, 0, 120, "Criar Relatório" },
                    { 2, "XYA-12345", new DateTime(2022, 4, 22, 23, 53, 17, 888, DateTimeKind.Local).AddTicks(8572), "Criação de sofware sorteador de números para asdrubal company", 1, 0, 0, 60, "Criar Sorteador" },
                    { 3, "XYC-12345", new DateTime(2022, 4, 25, 23, 53, 17, 888, DateTimeKind.Local).AddTicks(8612), "Criação de listagem para asdrubal group", 2, 0, 0, 60, "Criar Listagem" },
                    { 4, "XYP-12345", new DateTime(2022, 4, 27, 23, 53, 17, 888, DateTimeKind.Local).AddTicks(8616), "Criação de paginação para asdrubal corp", 3, 0, 0, 90, "Criar Paginação" }
                });

            migrationBuilder.InsertData(
                table: "Colaborador_Card",
                columns: new[] { "Id", "CardId", "ColaboradorId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 1 },
                    { 3, 3, 2 },
                    { 4, 4, 3 }
                });

            migrationBuilder.InsertData(
                table: "Coluna_Card",
                columns: new[] { "Id", "CardId", "ColunaId", "Posicao" },
                values: new object[,]
                {
                    { 1, 1, 1, 1 },
                    { 2, 2, 1, 2 },
                    { 3, 3, 1, 3 },
                    { 4, 4, 1, 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Card_ProjetoId",
                table: "Card",
                column: "ProjetoId");

            migrationBuilder.CreateIndex(
                name: "IX_Colaborador_Card_CardId",
                table: "Colaborador_Card",
                column: "CardId");

            migrationBuilder.CreateIndex(
                name: "IX_Colaborador_Card_ColaboradorId",
                table: "Colaborador_Card",
                column: "ColaboradorId");

            migrationBuilder.CreateIndex(
                name: "IX_Coluna_Card_CardId",
                table: "Coluna_Card",
                column: "CardId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Coluna_Card_ColunaId",
                table: "Coluna_Card",
                column: "ColunaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Colaborador_Card");

            migrationBuilder.DropTable(
                name: "Coluna_Card");

            migrationBuilder.DropTable(
                name: "Colaborador");

            migrationBuilder.DropTable(
                name: "Card");

            migrationBuilder.DropTable(
                name: "Coluna");

            migrationBuilder.DropTable(
                name: "Projeto");
        }
    }
}
