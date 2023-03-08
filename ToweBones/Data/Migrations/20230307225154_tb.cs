using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToweBones.Data.Migrations
{
    /// <inheritdoc />
    public partial class tb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HiDebt",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "HiLevel",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "pfpID",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Devlogs",
                columns: table => new
                {
                    DevlogID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Devlogs", x => x.DevlogID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Devlogs");

            migrationBuilder.DropColumn(
                name: "HiDebt",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "HiLevel",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "pfpID",
                table: "AspNetUsers");
        }
    }
}
