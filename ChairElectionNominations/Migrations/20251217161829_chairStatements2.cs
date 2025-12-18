using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChairElectionNominations.Migrations
{
    /// <inheritdoc />
    public partial class chairStatements2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ChairStatements",
                columns: table => new
                {
                    ChairStatementId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MemberId = table.Column<int>(type: "INTEGER", nullable: false),
                    CommitteeId = table.Column<int>(type: "INTEGER", nullable: false),
                    ChairStatementText = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChairStatements", x => x.ChairStatementId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChairStatements");
        }
    }
}
