using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChairElectionNominations.Migrations
{
    /// <inheritdoc />
    public partial class AddCommitteesTable4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RegisteredInterests",
                columns: table => new
                {
                    RegisteredInterestId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MemberId = table.Column<int>(type: "INTEGER", nullable: false),
                    CommitteeId = table.Column<int>(type: "INTEGER", nullable: false),
                    RegisteredInterestText = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegisteredInterests", x => x.RegisteredInterestId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RegisteredInterests");
        }
    }
}
