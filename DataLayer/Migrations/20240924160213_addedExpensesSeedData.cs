using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class addedExpensesSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                    { new Guid("171896b5-a68e-4458-82b3-676d4036eaac"), "Kira Geliri", "Gelir" },
                    { new Guid("3e1aa256-c540-4611-805c-ebd456d1aae2"), "Yatırım Geliri", "Gelir" },
                    { new Guid("46335c1b-25a5-4e97-ab9b-953fa4170078"), "Maaş", "Gelir" },
                    { new Guid("6799046f-9b37-403c-93ac-6612b44e4141"), "Diğer Gelirler", "Gelir" }
                });
        }
    }
}
