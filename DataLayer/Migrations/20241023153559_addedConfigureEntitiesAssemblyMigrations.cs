using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class addedConfigureEntitiesAssemblyMigrations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("080cd899-ef20-4772-bc31-b0067e6a55d6"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("0d4680d4-c0b4-4309-b428-28b5b70a73db"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("53cdcf36-9a0e-4d8b-80d7-75016c2fc359"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("760b54d9-1f32-47a2-a108-ab4a51577c1d"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("7d4e4476-2a57-4f35-aaeb-734ed723a16d"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("a3e2766a-01e4-47c7-8ec7-5dad220c061b"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("ba21eb0b-7fca-4b48-bfc6-e41187cf9233"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("c8b42480-99bb-4b89-b7bb-7671d2bfff0d"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("de6f3915-de14-4ab3-a858-24fca0eae158"));

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "Users",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Categories",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name", "Type" },
                values: new object[,]
                {
                    { new Guid("080cd899-ef20-4772-bc31-b0067e6a55d6"), "Education Expense", "Expense" },
                    { new Guid("0d4680d4-c0b4-4309-b428-28b5b70a73db"), "Investment Income", "Income" },
                    { new Guid("53cdcf36-9a0e-4d8b-80d7-75016c2fc359"), "Rental Income", "Income" },
                    { new Guid("760b54d9-1f32-47a2-a108-ab4a51577c1d"), "Entertainment Expense", "Expense" },
                    { new Guid("7d4e4476-2a57-4f35-aaeb-734ed723a16d"), "Other Income", "Income" },
                    { new Guid("a3e2766a-01e4-47c7-8ec7-5dad220c061b"), "Salary", "Income" },
                    { new Guid("ba21eb0b-7fca-4b48-bfc6-e41187cf9233"), "Car Expense", "Expense" },
                    { new Guid("c8b42480-99bb-4b89-b7bb-7671d2bfff0d"), "Other Expenses", "Expense" },
                    { new Guid("de6f3915-de14-4ab3-a858-24fca0eae158"), "Rent Expense", "Expense" }
                });
        }
    }
}
