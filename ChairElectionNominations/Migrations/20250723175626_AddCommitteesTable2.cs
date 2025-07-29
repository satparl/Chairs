using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChairElectionNominations.Migrations
{
    /// <inheritdoc />
    public partial class AddCommitteesTable2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChairNominations_Committees_CommitteeId",
                table: "ChairNominations");

            migrationBuilder.DropIndex(
                name: "IX_ChairNominations_CommitteeId",
                table: "ChairNominations");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_ChairNominations_CommitteeId",
                table: "ChairNominations",
                column: "CommitteeId");

            migrationBuilder.AddForeignKey(
                name: "FK_ChairNominations_Committees_CommitteeId",
                table: "ChairNominations",
                column: "CommitteeId",
                principalTable: "Committees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
