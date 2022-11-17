using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Student.Migrations
{
    public partial class updating : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SelectTeacher",
                table: "Students",
                newName: "TeacherId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TeacherId",
                table: "Students",
                newName: "SelectTeacher");
        }
    }
}
