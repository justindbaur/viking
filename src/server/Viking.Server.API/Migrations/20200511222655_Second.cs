using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Viking.Server.API.Migrations
{
    public partial class Second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Interaction",
                table: "Interaction");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Interaction");

            migrationBuilder.AddColumn<Guid>(
                name: "RowId",
                table: "Interaction",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Interaction",
                table: "Interaction",
                column: "RowId");

            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    Name = table.Column<string>(nullable: false),
                    RowId = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedTime = table.Column<DateTime>(nullable: false),
                    LastRevisedBy = table.Column<string>(nullable: true),
                    LastRevisedTime = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.Name);
                    table.UniqueConstraint("AK_Company_RowId", x => x.RowId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Company");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Interaction",
                table: "Interaction");

            migrationBuilder.DropColumn(
                name: "RowId",
                table: "Interaction");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "Interaction",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Interaction",
                table: "Interaction",
                column: "Id");
        }
    }
}
