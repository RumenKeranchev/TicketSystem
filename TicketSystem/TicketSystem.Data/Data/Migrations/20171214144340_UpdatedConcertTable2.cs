﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace TicketSystem.Data.Data.Migrations
{
    public partial class UpdatedConcertTable2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "StreamUrl",
                table: "Concerts",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StreamUrl",
                table: "Concerts");
        }
    }
}
