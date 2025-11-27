using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NotificationService.EntityFrameworkCore.Migrations
{
    /// <inheritdoc />
    public partial class Added_ExtraProps : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ExtraProperties",
                table: "Notifications",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExtraProperties",
                table: "Notifications");
        }
    }
}
