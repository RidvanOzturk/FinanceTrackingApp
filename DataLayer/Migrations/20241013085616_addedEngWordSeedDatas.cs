using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class addedEngWordSeedDatas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("2fefcd3b-5b33-49ae-a58d-9ad2bc066bd0"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("47fc5307-72f6-4214-8ef2-bfd9589ae17f"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("75b4d483-a608-4d39-8d41-c79966001827"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("7fc75b7a-cbef-4199-887a-ad239d4bd503"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("82500fea-e057-4a17-a3a1-ba064b4841a6"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("8d4c867f-fe8c-440a-ad7f-a6d05e9487bd"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("be0b84d8-4bd4-4c8e-8b90-c268a4485b99"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("d854684d-7f66-4e35-b827-79d0f9c4fa90"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("ef449199-0456-4eb7-b2e4-8e3bcb1573df"));

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name", "Type" },
                values: new object[,]
                {
                    { new Guid("2fefcd3b-5b33-49ae-a58d-9ad2bc066bd0"), "Diğer Giderler", "Gider" },
                    { new Guid("47fc5307-72f6-4214-8ef2-bfd9589ae17f"), "Kira Geliri", "Gelir" },
                    { new Guid("75b4d483-a608-4d39-8d41-c79966001827"), "Kira Gideri", "Gider" },
                    { new Guid("7fc75b7a-cbef-4199-887a-ad239d4bd503"), "Yatırım Geliri", "Gelir" },
                    { new Guid("82500fea-e057-4a17-a3a1-ba064b4841a6"), "Diğer Gelirler", "Gelir" },
                    { new Guid("8d4c867f-fe8c-440a-ad7f-a6d05e9487bd"), "Maaş", "Gelir" },
                    { new Guid("be0b84d8-4bd4-4c8e-8b90-c268a4485b99"), "Eğitim Gideri", "Gider" },
                    { new Guid("d854684d-7f66-4e35-b827-79d0f9c4fa90"), "Araba Gideri", "Gider" },
                    { new Guid("ef449199-0456-4eb7-b2e4-8e3bcb1573df"), "Eğlence Gideri", "Gider" }
                });
        }
    }
}
