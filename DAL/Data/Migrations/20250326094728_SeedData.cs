using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Name", "Password", "isAdmin" },
                values: new object[,]
                {
                    { 1, "admin@example.com", "Admin", "Admin@123", true },
                    { 2, "user1@example.org", "Elizabeth Taylor", "User1@123", false },
                    { 3, "user2@example.org", "Victoria Beckham", "User2@123", false }
                });

            migrationBuilder.InsertData(
                table: "Pregnancies",
                columns: new[] { "Id", "ConceptionDate", "DueDate", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 2, new DateTime(2021, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 }
                });

            migrationBuilder.InsertData(
                table: "FetusDatas",
                columns: new[] { "Id", "Date", "HeadCircumference", "Height", "PregnancyId", "Weight" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 30.0m, 50.0m, 1, 3.5m },
                    { 2, new DateTime(2021, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 32.0m, 55.0m, 1, 4.0m },
                    { 3, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 28.0m, 45.0m, 2, 3.0m },
                    { 4, new DateTime(2021, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 30.0m, 50.0m, 2, 3.5m }
                });

            migrationBuilder.InsertData(
                table: "Milestones",
                columns: new[] { "Id", "Date", "Descriptions", "PregnancyId" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "First Trimester", 1 },
                    { 2, new DateTime(2021, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Second Trimester", 1 },
                    { 3, new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Third Trimester", 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "FetusDatas",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "FetusDatas",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "FetusDatas",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "FetusDatas",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Milestones",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Milestones",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Milestones",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Pregnancies",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Pregnancies",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
