using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Design.Migrations
{
    public partial class CreatTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "clients",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(nullable: true),
                    phone = table.Column<int>(nullable: false),
                    size = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clients", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "employers",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(nullable: true),
                    position = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "typeOfItems",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_typeOfItems", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "typeOfServices",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_typeOfServices", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "orders",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    clientid = table.Column<int>(nullable: true),
                    typeOfServid = table.Column<int>(nullable: true),
                    typeOfItemid = table.Column<int>(nullable: true),
                    timeOfReciept = table.Column<DateTime>(nullable: true),
                    timeFit = table.Column<DateTime>(nullable: true),
                    timeReady = table.Column<DateTime>(nullable: true),
                    employerid = table.Column<int>(nullable: true),
                    price = table.Column<float>(nullable: false),
                    prepaymant = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orders", x => x.id);
                    table.ForeignKey(
                        name: "FK_orders_clients_clientid",
                        column: x => x.clientid,
                        principalTable: "clients",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_orders_employers_employerid",
                        column: x => x.employerid,
                        principalTable: "employers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_orders_typeOfItems_typeOfItemid",
                        column: x => x.typeOfItemid,
                        principalTable: "typeOfItems",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_orders_typeOfServices_typeOfServid",
                        column: x => x.typeOfServid,
                        principalTable: "typeOfServices",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tariffs",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    typeOfItemid = table.Column<int>(nullable: true),
                    typeOfServiceid = table.Column<int>(nullable: true),
                    price = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tariffs", x => x.id);
                    table.ForeignKey(
                        name: "FK_tariffs_typeOfItems_typeOfItemid",
                        column: x => x.typeOfItemid,
                        principalTable: "typeOfItems",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tariffs_typeOfServices_typeOfServiceid",
                        column: x => x.typeOfServiceid,
                        principalTable: "typeOfServices",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_orders_clientid",
                table: "orders",
                column: "clientid");

            migrationBuilder.CreateIndex(
                name: "IX_orders_employerid",
                table: "orders",
                column: "employerid");

            migrationBuilder.CreateIndex(
                name: "IX_orders_typeOfItemid",
                table: "orders",
                column: "typeOfItemid");

            migrationBuilder.CreateIndex(
                name: "IX_orders_typeOfServid",
                table: "orders",
                column: "typeOfServid");

            migrationBuilder.CreateIndex(
                name: "IX_tariffs_typeOfItemid",
                table: "tariffs",
                column: "typeOfItemid");

            migrationBuilder.CreateIndex(
                name: "IX_tariffs_typeOfServiceid",
                table: "tariffs",
                column: "typeOfServiceid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "orders");

            migrationBuilder.DropTable(
                name: "tariffs");

            migrationBuilder.DropTable(
                name: "clients");

            migrationBuilder.DropTable(
                name: "employers");

            migrationBuilder.DropTable(
                name: "typeOfItems");

            migrationBuilder.DropTable(
                name: "typeOfServices");
        }
    }
}
