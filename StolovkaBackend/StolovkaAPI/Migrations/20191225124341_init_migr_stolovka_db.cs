using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StolovkaWebAPI.Migrations
{
    public partial class init_migr_stolovka_db : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "canteens",
                columns: table => new
                {
                    id = table.Column<string>(maxLength: 255, nullable: false),
                    name = table.Column<string>(maxLength: 255, nullable: false),
                    address = table.Column<string>(maxLength: 255, nullable: false),
                    worktime = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_canteens", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "cards",
                columns: table => new
                {
                    card_number_crypted = table.Column<string>(maxLength: 255, nullable: false),
                    recognizeable_name = table.Column<string>(type: "character varying", nullable: true),
                    added_at = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("cards_pkey", x => x.card_number_crypted);
                });

            migrationBuilder.CreateTable(
                name: "cashiers",
                columns: table => new
                {
                    id = table.Column<string>(maxLength: 255, nullable: false),
                    login = table.Column<string>(maxLength: 65, nullable: false),
                    password_crypted = table.Column<string>(type: "character varying", nullable: false),
                    canteen_id = table.Column<string>(type: "character varying", nullable: false),
                    role = table.Column<string>(type: "character varying", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cashiers", x => x.id);
                    table.ForeignKey(
                        name: "cashiers_canteen_id_fkey",
                        column: x => x.canteen_id,
                        principalTable: "canteens",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "dishes",
                columns: table => new
                {
                    dish_id = table.Column<string>(maxLength: 255, nullable: false),
                    dish_name = table.Column<string>(maxLength: 65, nullable: false),
                    dish_price = table.Column<decimal>(type: "numeric", nullable: false),
                    canteen_id = table.Column<string>(type: "character varying", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("dishes_pkey", x => x.dish_id);
                    table.ForeignKey(
                        name: "dishes_canteen_id_fkey",
                        column: x => x.canteen_id,
                        principalTable: "canteens",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<string>(maxLength: 255, nullable: false),
                    firstname = table.Column<string>(maxLength: 65, nullable: true),
                    lastname = table.Column<string>(maxLength: 65, nullable: true),
                    token = table.Column<string>(type: "character varying", nullable: false),
                    email = table.Column<string>(type: "character varying", nullable: false),
                    card = table.Column<string>(type: "character varying", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.id);
                    table.ForeignKey(
                        name: "users_card_fkey",
                        column: x => x.card,
                        principalTable: "cards",
                        principalColumn: "card_number_crypted",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "orders",
                columns: table => new
                {
                    order_id = table.Column<string>(maxLength: 255, nullable: false),
                    user_id = table.Column<string>(maxLength: 255, nullable: false),
                    canteen_id = table.Column<string>(maxLength: 255, nullable: false),
                    status = table.Column<string>(type: "character varying", nullable: false),
                    created_at = table.Column<DateTime>(nullable: false),
                    processed_at = table.Column<DateTime>(nullable: true),
                    description = table.Column<string>(type: "character varying", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("orders_pkey", x => x.order_id);
                    table.ForeignKey(
                        name: "orders_canteen_id_fkey",
                        column: x => x.canteen_id,
                        principalTable: "canteens",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "orders_user_id_fkey",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_cashiers_canteen_id",
                table: "cashiers",
                column: "canteen_id");

            migrationBuilder.CreateIndex(
                name: "cashiers_login_key",
                table: "cashiers",
                column: "login",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_dishes_canteen_id",
                table: "dishes",
                column: "canteen_id");

            migrationBuilder.CreateIndex(
                name: "IX_orders_canteen_id",
                table: "orders",
                column: "canteen_id");

            migrationBuilder.CreateIndex(
                name: "IX_orders_user_id",
                table: "orders",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_users_card",
                table: "users",
                column: "card");

            migrationBuilder.CreateIndex(
                name: "users_email_key",
                table: "users",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "users_token_key",
                table: "users",
                column: "token",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cashiers");

            migrationBuilder.DropTable(
                name: "dishes");

            migrationBuilder.DropTable(
                name: "orders");

            migrationBuilder.DropTable(
                name: "canteens");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "cards");
        }
    }
}
