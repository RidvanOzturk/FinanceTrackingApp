using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class addedNameandTypeCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name", "Type" },
                values: new object[,]
                {
                    { new Guid("171896b5-a68e-4458-82b3-676d4036eaac"), "Kira Geliri", "Gelir" },
                    { new Guid("3e1aa256-c540-4611-805c-ebd456d1aae2"), "Yatırım Geliri", "Gelir" },
                    { new Guid("46335c1b-25a5-4e97-ab9b-953fa4170078"), "Maaş", "Gelir" },
                    { new Guid("6799046f-9b37-403c-93ac-6612b44e4141"), "Diğer Gelirler", "Gelir" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("171896b5-a68e-4458-82b3-676d4036eaac"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("3e1aa256-c540-4611-805c-ebd456d1aae2"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("46335c1b-25a5-4e97-ab9b-953fa4170078"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("6799046f-9b37-403c-93ac-6612b44e4141"));
        }
    }
}
