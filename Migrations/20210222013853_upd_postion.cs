using Microsoft.EntityFrameworkCore.Migrations;

namespace DotnetCoreApi.Migrations
{
    public partial class upd_postion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PostionY",
                table: "PostionTemp",
                newName: "RowCount");

            migrationBuilder.RenameColumn(
                name: "PostionX",
                table: "PostionTemp",
                newName: "Row");

            migrationBuilder.AddColumn<int>(
                name: "Col",
                table: "PostionTemp",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ColCount",
                table: "PostionTemp",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "PostionTemp",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Col",
                table: "PostionTemp");

            migrationBuilder.DropColumn(
                name: "ColCount",
                table: "PostionTemp");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "PostionTemp");

            migrationBuilder.RenameColumn(
                name: "RowCount",
                table: "PostionTemp",
                newName: "PostionY");

            migrationBuilder.RenameColumn(
                name: "Row",
                table: "PostionTemp",
                newName: "PostionX");
        }
    }
}
