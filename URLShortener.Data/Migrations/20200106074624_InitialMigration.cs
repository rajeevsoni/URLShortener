using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace URLShortener.Data.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "URLInfos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    URL = table.Column<string>(maxLength: 2000, nullable: false),
                    HashedURL = table.Column<string>(maxLength: 100, nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_URLInfos", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_URLInfos_HashedURL",
                table: "URLInfos",
                column: "HashedURL",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "URLInfos");
        }
    }
}
