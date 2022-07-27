using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PFMproject.Migrations
{
    public partial class FinalMigration1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    code = table.Column<string>(type: "text", nullable: false),
                    name = table.Column<string>(type: "text", nullable: true),
                    parent_code = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categories", x => x.code);
                });

            migrationBuilder.CreateTable(
                name: "transactions",
                columns: table => new
                {
                    id = table.Column<string>(type: "text", nullable: false),
                    beneficiaryname = table.Column<string>(type: "text", nullable: true),
                    date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Directions = table.Column<string>(type: "text", nullable: false),
                    amount = table.Column<double>(type: "double precision", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    currency = table.Column<string>(type: "character varying(3)", maxLength: 3, nullable: false),
                    TransactionKind = table.Column<string>(type: "text", nullable: false),
                    mcc = table.Column<int>(type: "integer", nullable: false),
                    catcode = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_transactions", x => x.id);
                    table.ForeignKey(
                        name: "FK_transactions_categories_catcode",
                        column: x => x.catcode,
                        principalTable: "categories",
                        principalColumn: "code");
                });

            migrationBuilder.CreateTable(
                name: "junction",
                columns: table => new
                {
                    vreme = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    TransactionID = table.Column<string>(type: "text", nullable: true),
                    CategoryId = table.Column<string>(type: "text", nullable: true),
                    amount = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_junction", x => x.vreme);
                    table.ForeignKey(
                        name: "FK_junction_categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "categories",
                        principalColumn: "code");
                    table.ForeignKey(
                        name: "FK_junction_transactions_TransactionID",
                        column: x => x.TransactionID,
                        principalTable: "transactions",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_junction_CategoryId",
                table: "junction",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_junction_TransactionID",
                table: "junction",
                column: "TransactionID");

            migrationBuilder.CreateIndex(
                name: "IX_transactions_catcode",
                table: "transactions",
                column: "catcode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "junction");

            migrationBuilder.DropTable(
                name: "transactions");

            migrationBuilder.DropTable(
                name: "categories");
        }
    }
}
