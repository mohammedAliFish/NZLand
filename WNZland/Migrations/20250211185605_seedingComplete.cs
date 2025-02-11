using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WNZland.Migrations
{
    /// <inheritdoc />
    public partial class seedingComplete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Difficulties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("1ed5deec-7b0c-441a-a7ea-a67d11864f77"), "Hard" },
                    { new Guid("67b2151d-b948-4a32-ab60-f8cbf48b1349"), "Moderate" },
                    { new Guid("6db438f6-9747-4be6-8e62-8c34957719e1"), "Easy" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Code", "Name", "RegionImageUrl" },
                values: new object[,]
                {
                    { new Guid("1ed5deec-7b0c-441a-a7ea-a67d11864f73"), "W", "Waikato", "https://www.wnz.org.nz/wp-content/uploads/2021/06/Te-Henga-Walkway-3.jpg" },
                    { new Guid("67b2151d-b948-4a32-ab60-f8cbf48b1343"), "A", "Auckland", "https://www.wnz.org.nz/wp-content/uploads/2021/06/Te-Henga-Walkway-2.jpg" },
                    { new Guid("6db438f6-9747-4be6-8e62-8c34957719e3"), "N", "Northland", "https://www.wnz.org.nz/wp-content/uploads/2021/06/Te-Henga-Walkway-1.jpg" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("1ed5deec-7b0c-441a-a7ea-a67d11864f77"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("67b2151d-b948-4a32-ab60-f8cbf48b1349"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("6db438f6-9747-4be6-8e62-8c34957719e1"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("1ed5deec-7b0c-441a-a7ea-a67d11864f73"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("67b2151d-b948-4a32-ab60-f8cbf48b1343"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("6db438f6-9747-4be6-8e62-8c34957719e3"));
        }
    }
}
