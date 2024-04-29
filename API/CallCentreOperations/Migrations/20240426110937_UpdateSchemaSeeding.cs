using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CallCentreOperations.Migrations
{
    public partial class UpdateSchemaSeeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "State",
                table: "Agents");

            migrationBuilder.AddColumn<string>(
                name: "AgentState",
                table: "Agents",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 101,
                column: "AgentState",
                value: "NA");

            migrationBuilder.UpdateData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 102,
                column: "AgentState",
                value: "NA");

            migrationBuilder.UpdateData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 103,
                column: "AgentState",
                value: "NA");

            migrationBuilder.UpdateData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 104,
                column: "AgentState",
                value: "NA");

            migrationBuilder.UpdateData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 105,
                column: "AgentState",
                value: "NA");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AgentState",
                table: "Agents");

            migrationBuilder.AddColumn<int>(
                name: "State",
                table: "Agents",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
