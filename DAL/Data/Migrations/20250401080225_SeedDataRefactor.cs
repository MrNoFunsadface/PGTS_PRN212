using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataRefactor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "FetusDatas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date", "HeadCircumference", "Height", "Weight" },
                values: new object[] { new DateOnly(2023, 1, 1), 28.0m, 45.0m, 3.0m });

            migrationBuilder.UpdateData(
                table: "FetusDatas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Date", "HeadCircumference", "Height", "Weight" },
                values: new object[] { new DateOnly(2023, 1, 8), 28.4m, 45.8m, 3.3m });

            migrationBuilder.UpdateData(
                table: "FetusDatas",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Date", "HeadCircumference", "Height", "PregnancyId", "Weight" },
                values: new object[] { new DateOnly(2023, 1, 15), 28.9m, 46.5m, 1, 3.5m });

            migrationBuilder.UpdateData(
                table: "FetusDatas",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Date", "HeadCircumference", "Height", "PregnancyId", "Weight" },
                values: new object[] { new DateOnly(2023, 1, 22), 29.3m, 47.2m, 1, 3.7m });

            migrationBuilder.InsertData(
                table: "FetusDatas",
                columns: new[] { "Id", "Date", "HeadCircumference", "Height", "PregnancyId", "Weight" },
                values: new object[,]
                {
                    { 5, new DateOnly(2023, 1, 29), 29.8m, 48.0m, 1, 4.0m },
                    { 6, new DateOnly(2023, 2, 5), 30.2m, 49.0m, 1, 4.2m },
                    { 7, new DateOnly(2023, 2, 12), 30.7m, 50.2m, 1, 4.5m },
                    { 8, new DateOnly(2023, 2, 19), 31.1m, 51.0m, 1, 4.7m },
                    { 9, new DateOnly(2023, 2, 26), 31.6m, 52.3m, 1, 5.0m },
                    { 10, new DateOnly(2023, 3, 5), 32.0m, 53.5m, 1, 5.3m },
                    { 11, new DateOnly(2023, 3, 12), 32.6m, 54.8m, 1, 5.6m },
                    { 12, new DateOnly(2023, 3, 19), 33.0m, 55.5m, 1, 5.8m },
                    { 13, new DateOnly(2023, 3, 26), 33.5m, 56.8m, 1, 6.1m },
                    { 14, new DateOnly(2023, 4, 2), 34.0m, 57.5m, 1, 6.3m },
                    { 15, new DateOnly(2023, 4, 9), 34.4m, 58.3m, 1, 6.6m },
                    { 16, new DateOnly(2023, 4, 16), 34.9m, 59.0m, 1, 6.9m },
                    { 17, new DateOnly(2023, 4, 23), 35.3m, 60.2m, 1, 7.1m },
                    { 18, new DateOnly(2023, 4, 30), 35.8m, 61.0m, 1, 7.4m },
                    { 19, new DateOnly(2023, 5, 7), 36.2m, 62.5m, 1, 7.7m },
                    { 20, new DateOnly(2023, 5, 14), 36.7m, 62.5m, 1, 7.5m },
                    { 21, new DateOnly(2023, 5, 21), 38.0m, 65.0m, 1, 7.0m },
                    { 22, new DateOnly(2023, 5, 28), 38.5m, 66.0m, 1, 7.2m },
                    { 23, new DateOnly(2023, 6, 4), 39.0m, 67.0m, 1, 7.4m },
                    { 24, new DateOnly(2023, 6, 11), 39.5m, 68.0m, 1, 7.6m },
                    { 25, new DateOnly(2023, 6, 18), 40.0m, 69.0m, 1, 7.8m },
                    { 26, new DateOnly(2023, 6, 25), 40.5m, 70.0m, 1, 8.0m },
                    { 27, new DateOnly(2023, 7, 2), 41.0m, 71.0m, 1, 8.2m },
                    { 28, new DateOnly(2023, 7, 9), 41.5m, 72.0m, 1, 8.4m },
                    { 29, new DateOnly(2023, 7, 16), 42.0m, 73.0m, 1, 8.6m },
                    { 30, new DateOnly(2023, 7, 23), 42.5m, 74.0m, 1, 8.8m },
                    { 31, new DateOnly(2023, 7, 30), 43.1m, 75.2m, 1, 9.1m },
                    { 32, new DateOnly(2023, 8, 6), 43.6m, 76.5m, 1, 9.3m },
                    { 33, new DateOnly(2023, 8, 13), 44.2m, 77.3m, 1, 9.5m },
                    { 34, new DateOnly(2023, 8, 20), 44.7m, 78.1m, 1, 9.7m },
                    { 35, new DateOnly(2023, 8, 27), 45.3m, 79.4m, 1, 9.9m },
                    { 36, new DateOnly(2023, 9, 3), 45.8m, 80.2m, 1, 10.1m },
                    { 37, new DateOnly(2023, 9, 10), 46.4m, 81.5m, 1, 10.4m },
                    { 38, new DateOnly(2023, 9, 17), 46.9m, 82.3m, 1, 10.6m },
                    { 39, new DateOnly(2023, 9, 24), 47.3m, 83.7m, 1, 10.7m },
                    { 40, new DateOnly(2023, 10, 1), 47.8m, 84.5m, 1, 10.9m }
                });

            migrationBuilder.UpdateData(
                table: "Milestones",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateOnly(2023, 1, 1));

            migrationBuilder.UpdateData(
                table: "Milestones",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Date", "Descriptions" },
                values: new object[] { new DateOnly(2023, 1, 15), "First Doctor Visit" });

            migrationBuilder.UpdateData(
                table: "Milestones",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Date", "Descriptions" },
                values: new object[] { new DateOnly(2023, 4, 1), "Second Trimester" });

            migrationBuilder.InsertData(
                table: "Milestones",
                columns: new[] { "Id", "Date", "Descriptions", "PregnancyId" },
                values: new object[,]
                {
                    { 4, new DateOnly(2023, 5, 1), "Baby's First Kick", 1 },
                    { 5, new DateOnly(2023, 6, 1), "Gender Reveal", 1 },
                    { 6, new DateOnly(2023, 7, 1), "Third Trimester", 1 },
                    { 7, new DateOnly(2023, 8, 1), "Ultrasound Checkup", 1 },
                    { 8, new DateOnly(2023, 8, 15), "Baby Shower", 1 },
                    { 9, new DateOnly(2023, 9, 15), "Final Doctor Visit", 1 },
                    { 10, new DateOnly(2023, 10, 1), "Due Date", 1 }
                });

            migrationBuilder.UpdateData(
                table: "Pregnancies",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConceptionDate", "DueDate" },
                values: new object[] { new DateOnly(2023, 1, 1), new DateOnly(2023, 10, 1) });

            migrationBuilder.UpdateData(
                table: "Pregnancies",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConceptionDate", "DueDate", "UserId" },
                values: new object[] { new DateOnly(2024, 1, 1), new DateOnly(2024, 9, 25), 2 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Phone",
                value: "0905123000");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Email", "Password", "Phone" },
                values: new object[] { "active.user@example.com", "ActiveUser@123", "0905123001" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Email", "Password", "Phone" },
                values: new object[] { "inactive.user@example.com", "InactiveUser@123", "0905123002" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "FetusDatas",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "FetusDatas",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "FetusDatas",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "FetusDatas",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "FetusDatas",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "FetusDatas",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "FetusDatas",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "FetusDatas",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "FetusDatas",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "FetusDatas",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "FetusDatas",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "FetusDatas",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "FetusDatas",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "FetusDatas",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "FetusDatas",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "FetusDatas",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "FetusDatas",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "FetusDatas",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "FetusDatas",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "FetusDatas",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "FetusDatas",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "FetusDatas",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "FetusDatas",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "FetusDatas",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "FetusDatas",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "FetusDatas",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "FetusDatas",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "FetusDatas",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "FetusDatas",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "FetusDatas",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "FetusDatas",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "FetusDatas",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "FetusDatas",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "FetusDatas",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "FetusDatas",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "FetusDatas",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Milestones",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Milestones",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Milestones",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Milestones",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Milestones",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Milestones",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Milestones",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.UpdateData(
                table: "FetusDatas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date", "HeadCircumference", "Height", "Weight" },
                values: new object[] { new DateOnly(2021, 1, 1), 30.0m, 50.0m, 3.5m });

            migrationBuilder.UpdateData(
                table: "FetusDatas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Date", "HeadCircumference", "Height", "Weight" },
                values: new object[] { new DateOnly(2021, 2, 1), 32.0m, 55.0m, 4.0m });

            migrationBuilder.UpdateData(
                table: "FetusDatas",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Date", "HeadCircumference", "Height", "PregnancyId", "Weight" },
                values: new object[] { new DateOnly(2021, 1, 1), 28.0m, 45.0m, 2, 3.0m });

            migrationBuilder.UpdateData(
                table: "FetusDatas",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Date", "HeadCircumference", "Height", "PregnancyId", "Weight" },
                values: new object[] { new DateOnly(2021, 2, 1), 30.0m, 50.0m, 2, 3.5m });

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
                columns: new[] { "Date", "Descriptions" },
                values: new object[] { new DateOnly(2021, 4, 1), "Second Trimester" });

            migrationBuilder.UpdateData(
                table: "Milestones",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Date", "Descriptions" },
                values: new object[] { new DateOnly(2021, 7, 1), "Third Trimester" });

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
                columns: new[] { "ConceptionDate", "DueDate", "UserId" },
                values: new object[] { new DateOnly(2021, 2, 1), new DateOnly(2021, 10, 1), 3 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Phone",
                value: "0905123456");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Email", "Password", "Phone" },
                values: new object[] { "user1@example.com", "User1@123", "0905123457" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Email", "Password", "Phone" },
                values: new object[] { "user2@example.com", "User2@123", "0905123458" });
        }
    }
}
