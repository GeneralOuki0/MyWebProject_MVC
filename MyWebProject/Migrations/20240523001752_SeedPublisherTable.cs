using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyWebProject.Migrations
{
    /// <inheritdoc />
    public partial class SeedPublisherTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Publishers",
                columns: new[] { "PublisherId", "PublisherName", "YearOfPublication" },
                values: new object[] { 1, "Michael", 2007 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Publishers",
                keyColumn: "PublisherId",
                keyValue: 1);
        }
    }
}
