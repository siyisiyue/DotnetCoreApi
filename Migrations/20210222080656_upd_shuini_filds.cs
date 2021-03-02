using Microsoft.EntityFrameworkCore.Migrations;

namespace DotnetCoreApi.Migrations
{
    public partial class upd_shuini_filds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GaoChaPc",
                table: "ShuiNiHunLingTu");

            migrationBuilder.DropColumn(
                name: "ShenDuPc",
                table: "ShuiNiHunLingTu");

            migrationBuilder.DropColumn(
                name: "ShunZhiDuPc",
                table: "ShuiNiHunLingTu");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "GaoChaPc",
                table: "ShuiNiHunLingTu",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ShenDuPc",
                table: "ShuiNiHunLingTu",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ShunZhiDuPc",
                table: "ShuiNiHunLingTu",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
