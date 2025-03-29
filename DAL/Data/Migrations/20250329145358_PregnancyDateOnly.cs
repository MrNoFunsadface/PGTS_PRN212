using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class PregnancyDateOnly : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateOnly>(
                name: "DueDate",
                table: "Pregnancies",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "ConceptionDate",
                table: "Pregnancies",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.UpdateData(
                table: "Pregnancies",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConceptionDate", "DueDate" },
                values: new object[] { new DateOnly(2021, 1, 1), new DateOnly(2021, 9, 1) });

            migrationBuilder.UpdateData(
                table: "Pregnancies",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConceptionDate", "DueDate" },
                values: new object[] { new DateOnly(2021, 2, 1), new DateOnly(2021, 10, 1) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DueDate",
                table: "Pregnancies",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ConceptionDate",
                table: "Pregnancies",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.UpdateData(
                table: "Pregnancies",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConceptionDate", "DueDate" },
                values: new object[] { new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Pregnancies",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConceptionDate", "DueDate" },
                values: new object[] { new DateTime(2021, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }
    }
}
