using Microsoft.EntityFrameworkCore.Migrations;

namespace TicketSystem.Data.Data.Migrations
{
    public partial class UpdatedConcertTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PosterUrl",
                table: "Concerts",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PosterUrl",
                table: "Concerts");
        }
    }
}
