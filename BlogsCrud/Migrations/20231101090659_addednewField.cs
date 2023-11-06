using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogsCrud.Migrations
{
    public partial class addednewField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "likes",
                table: "Blogs",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "likes",
                table: "Blogs");
        }
    }
}
