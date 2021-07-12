using Microsoft.EntityFrameworkCore.Migrations;

namespace testASPwMvc.Data.Migrations
{
    public partial class AddRelationship2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PersonId",
                table: "Help",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Help_PersonId",
                table: "Help",
                column: "PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Help_Person_PersonId",
                table: "Help",
                column: "PersonId",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Help_Person_PersonId",
                table: "Help");

            migrationBuilder.DropTable(
                name: "Person");

            migrationBuilder.DropIndex(
                name: "IX_Help_PersonId",
                table: "Help");

            migrationBuilder.DropColumn(
                name: "PersonId",
                table: "Help");
        }
    }
}
