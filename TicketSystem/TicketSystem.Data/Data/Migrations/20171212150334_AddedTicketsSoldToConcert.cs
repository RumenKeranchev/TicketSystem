﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace TicketSystem.Data.Data.Migrations
{
    public partial class AddedTicketsSoldToConcert : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TicketsSold",
                table: "Concerts",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TicketsSold",
                table: "Concerts");
        }
    }
}
