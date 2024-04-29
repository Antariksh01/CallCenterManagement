using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CallCentreOperations.Migrations
{
    public partial class AddedTimeStampProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "TimestampUtc",
                table: "Agents",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TimestampUtc",
                table: "Agents");
        }
    }
}
