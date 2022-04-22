using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KanbanAPI.Migrations
{
    public partial class RemovedColunaCard : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Coluna_Card");

            migrationBuilder.AddColumn<int>(
                name: "ColunaId",
                table: "Card",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Posicao",
                table: "Card",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Card",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ColunaId", "DataPrevista", "Posicao" },
                values: new object[] { 1, new DateTime(2022, 4, 24, 3, 0, 48, 708, DateTimeKind.Local).AddTicks(1031), 1 });

            migrationBuilder.UpdateData(
                table: "Card",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ColunaId", "DataPrevista", "Posicao" },
                values: new object[] { 1, new DateTime(2022, 4, 23, 3, 0, 48, 709, DateTimeKind.Local).AddTicks(2128), 2 });

            migrationBuilder.UpdateData(
                table: "Card",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ColunaId", "DataPrevista", "Posicao" },
                values: new object[] { 2, new DateTime(2022, 4, 26, 3, 0, 48, 709, DateTimeKind.Local).AddTicks(2181), 1 });

            migrationBuilder.UpdateData(
                table: "Card",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ColunaId", "DataPrevista", "Posicao" },
                values: new object[] { 2, new DateTime(2022, 4, 28, 3, 0, 48, 709, DateTimeKind.Local).AddTicks(2186), 2 });

            migrationBuilder.CreateIndex(
                name: "IX_Card_ColunaId",
                table: "Card",
                column: "ColunaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Card_Coluna_ColunaId",
                table: "Card",
                column: "ColunaId",
                principalTable: "Coluna",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Card_Coluna_ColunaId",
                table: "Card");

            migrationBuilder.DropIndex(
                name: "IX_Card_ColunaId",
                table: "Card");

            migrationBuilder.DropColumn(
                name: "ColunaId",
                table: "Card");

            migrationBuilder.DropColumn(
                name: "Posicao",
                table: "Card");

            migrationBuilder.CreateTable(
                name: "Coluna_Card",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CardId = table.Column<int>(type: "int", nullable: false),
                    ColunaId = table.Column<int>(type: "int", nullable: false),
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

            migrationBuilder.UpdateData(
                table: "Card",
                keyColumn: "Id",
                keyValue: 1,
                column: "DataPrevista",
                value: new DateTime(2022, 4, 23, 23, 53, 17, 887, DateTimeKind.Local).AddTicks(8216));

            migrationBuilder.UpdateData(
                table: "Card",
                keyColumn: "Id",
                keyValue: 2,
                column: "DataPrevista",
                value: new DateTime(2022, 4, 22, 23, 53, 17, 888, DateTimeKind.Local).AddTicks(8572));

            migrationBuilder.UpdateData(
                table: "Card",
                keyColumn: "Id",
                keyValue: 3,
                column: "DataPrevista",
                value: new DateTime(2022, 4, 25, 23, 53, 17, 888, DateTimeKind.Local).AddTicks(8612));

            migrationBuilder.UpdateData(
                table: "Card",
                keyColumn: "Id",
                keyValue: 4,
                column: "DataPrevista",
                value: new DateTime(2022, 4, 27, 23, 53, 17, 888, DateTimeKind.Local).AddTicks(8616));

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
                name: "IX_Coluna_Card_CardId",
                table: "Coluna_Card",
                column: "CardId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Coluna_Card_ColunaId",
                table: "Coluna_Card",
                column: "ColunaId");
        }
    }
}
