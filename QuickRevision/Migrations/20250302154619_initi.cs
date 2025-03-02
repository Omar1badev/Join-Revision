using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuickRevision.Migrations
{
    /// <inheritdoc />
    public partial class initi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Deps_Students_StudentId",
                table: "Deps");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Deps",
                table: "Deps");

            migrationBuilder.RenameTable(
                name: "Deps",
                newName: "Dep");

            migrationBuilder.RenameIndex(
                name: "IX_Deps_StudentId",
                table: "Dep",
                newName: "IX_Dep_StudentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Dep",
                table: "Dep",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Dep_Students_StudentId",
                table: "Dep",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dep_Students_StudentId",
                table: "Dep");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Dep",
                table: "Dep");

            migrationBuilder.RenameTable(
                name: "Dep",
                newName: "Deps");

            migrationBuilder.RenameIndex(
                name: "IX_Dep_StudentId",
                table: "Deps",
                newName: "IX_Deps_StudentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Deps",
                table: "Deps",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Deps_Students_StudentId",
                table: "Deps",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
