using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restaurant.Migrations
{
    /// <inheritdoc />
    public partial class Add_column_Description_To_MenuItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "MenuItem",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "MenuItem");
        }
    }
}
