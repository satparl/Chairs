using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChairElectionNominations.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Committees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Status = table.Column<string>(type: "TEXT", nullable: false),
                    DateModified = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CurrentChairId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Committees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ChairNominations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CommitteeId = table.Column<int>(type: "INTEGER", nullable: false),
                    NomineeId = table.Column<int>(type: "INTEGER", nullable: false),
                    NominatedById = table.Column<int>(type: "INTEGER", nullable: false),
                    NominationSummary = table.Column<string>(type: "TEXT", nullable: false),
                    NominationDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChairNominations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChairNominations_Committees_CommitteeId",
                        column: x => x.CommitteeId,
                        principalTable: "Committees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChairNominations_CommitteeId",
                table: "ChairNominations",
                column: "CommitteeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChairNominations");

            migrationBuilder.DropTable(
                name: "Committees");
        }
    }
}
