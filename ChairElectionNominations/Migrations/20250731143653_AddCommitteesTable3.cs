using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChairElectionNominations.Migrations
{
    /// <inheritdoc />
    public partial class AddCommitteesTable3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AssignedParty",
                table: "Committees",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "RegisteredInterest",
                table: "ChairNominations",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AssignedParty",
                table: "Committees");

            migrationBuilder.DropColumn(
                name: "RegisteredInterest",
                table: "ChairNominations");
        }
    }
}
