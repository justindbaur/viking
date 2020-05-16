using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Viking.Server.API.Migrations
{
    public partial class Third : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PurchaseOrder",
                columns: table => new
                {
                    Company = table.Column<string>(nullable: false),
                    PONum = table.Column<string>(nullable: false),
                    RowId = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedTime = table.Column<DateTime>(nullable: false),
                    LastRevisedBy = table.Column<string>(nullable: true),
                    LastRevisedTime = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseOrder", x => new { x.Company, x.PONum });
                    table.UniqueConstraint("AK_PurchaseOrder_RowId", x => x.RowId);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseOrderLine",
                columns: table => new
                {
                    Company = table.Column<string>(nullable: false),
                    PONum = table.Column<string>(nullable: false),
                    LineNum = table.Column<int>(nullable: false),
                    RowId = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedTime = table.Column<DateTime>(nullable: false),
                    LastRevisedBy = table.Column<string>(nullable: true),
                    LastRevisedTime = table.Column<DateTime>(nullable: true),
                    PurchaseOrderCompany = table.Column<string>(nullable: true),
                    PurchaseOrderPONum = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseOrderLine", x => new { x.Company, x.PONum, x.LineNum });
                    table.UniqueConstraint("AK_PurchaseOrderLine_RowId", x => x.RowId);
                    table.ForeignKey(
                        name: "FK_PurchaseOrderLine_PurchaseOrder_PurchaseOrderCompany_PurchaseOrderPONum",
                        columns: x => new { x.PurchaseOrderCompany, x.PurchaseOrderPONum },
                        principalTable: "PurchaseOrder",
                        principalColumns: new[] { "Company", "PONum" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrderLine_PurchaseOrderCompany_PurchaseOrderPONum",
                table: "PurchaseOrderLine",
                columns: new[] { "PurchaseOrderCompany", "PurchaseOrderPONum" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PurchaseOrderLine");

            migrationBuilder.DropTable(
                name: "PurchaseOrder");
        }
    }
}
