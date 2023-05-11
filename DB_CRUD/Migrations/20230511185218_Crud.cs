using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DB_CRUD.Migrations
{
    /// <inheritdoc />
    public partial class Crud : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OrderCost = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    ItemsDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShippingAddress = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderID);
                    table.ForeignKey(
                        name: "FK_Orders_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserID", "DateOfBirth", "FirstName", "Gender", "LastName", "Login", "Password" },
                values: new object[,]
                {
                    { 1, new DateTime(2002, 12, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Test1", "M", "test1", "redredred", "redredred" },
                    { 2, new DateTime(2000, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Test2", "F", "test2", "blueblueblue", "blueblueblue" },
                    { 3, new DateTime(1998, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Test3", "F", "test3", "blueblue", "blueblue" }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "OrderID", "ItemsDescription", "OrderCost", "OrderDate", "ShippingAddress", "UserID" },
                values: new object[] { 1, "red", 1m, new DateTime(2023, 5, 11, 21, 52, 18, 650, DateTimeKind.Local).AddTicks(8492), "Lviv", 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserID",
                table: "Orders",
                column: "UserID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
