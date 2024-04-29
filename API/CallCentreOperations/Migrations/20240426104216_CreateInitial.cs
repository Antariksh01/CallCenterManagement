using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CallCentreOperations.Migrations
{
    public partial class CreateInitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Agents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AgentName = table.Column<string>(type: "text", nullable: false),
                    State = table.Column<int>(type: "integer", nullable: false),
                    Skills = table.Column<string[]>(type: "text[]", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agents", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Agents",
                columns: new[] { "Id", "AgentName", "Skills", "State" },
                values: new object[,]
                {
                    { 101, "James", new[] { "Communication", "Problem Solving" }, 0 },
                    { 102, "Roger", new[] { "Communication", "Sales" }, 0 },
                    { 103, "Sam", new[] { "Communication", "HR" }, 0 },
                    { 104, "Rafa", new[] { "Management", "Team Work" }, 0 },
                    { 105, "Ben", new[] { "Sales", "Problem Solving" }, 0 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Agents");
        }
    }
}
