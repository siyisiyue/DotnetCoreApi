using Microsoft.EntityFrameworkCore.Migrations;

namespace DotnetCoreApi.Migrations
{
    public partial class upd_filds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Other1",
                table: "ShuiNiHunLingTu",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Other2",
                table: "ShuiNiHunLingTu",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Other3",
                table: "ShuiNiHunLingTu",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Other1",
                table: "ShuiNiHunLingTu");

            migrationBuilder.DropColumn(
                name: "Other2",
                table: "ShuiNiHunLingTu");

            migrationBuilder.DropColumn(
                name: "Other3",
                table: "ShuiNiHunLingTu");
        }
    }
}
