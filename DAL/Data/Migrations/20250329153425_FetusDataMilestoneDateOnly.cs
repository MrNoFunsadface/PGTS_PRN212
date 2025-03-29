using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class FetusDataMilestoneDateOnly : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateOnly>(
                name: "Date",
                table: "Milestones",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "Date",
                table: "FetusDatas",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.UpdateData(
                table: "FetusDatas",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateOnly(2021, 1, 1));

            migrationBuilder.UpdateData(
                table: "FetusDatas",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateOnly(2021, 2, 1));

            migrationBuilder.UpdateData(
                table: "FetusDatas",
                keyColumn: "Id",
                keyValue: 3,
                column: "Date",
                value: new DateOnly(2021, 1, 1));

            migrationBuilder.UpdateData(
                table: "FetusDatas",
                keyColumn: "Id",
                keyValue: 4,
                column: "Date",
                value: new DateOnly(2021, 2, 1));

            migrationBuilder.UpdateData(
                table: "Milestones",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateOnly(2021, 1, 1));

            migrationBuilder.UpdateData(
                table: "Milestones",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateOnly(2021, 4, 1));

            migrationBuilder.UpdateData(
                table: "Milestones",
                keyColumn: "Id",
                keyValue: 3,
                column: "Date",
                value: new DateOnly(2021, 7, 1));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Milestones",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "FetusDatas",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.UpdateData(
                table: "FetusDatas",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "FetusDatas",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2021, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "FetusDatas",
                keyColumn: "Id",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "FetusDatas",
                keyColumn: "Id",
                keyValue: 4,
                column: "Date",
                value: new DateTime(2021, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Milestones",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Milestones",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2021, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Milestones",
                keyColumn: "Id",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
