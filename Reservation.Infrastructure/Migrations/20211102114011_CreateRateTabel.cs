using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ReservationProject.Infrastructure.Migrations
{
    public partial class CreateRateTabel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Rate",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    rate = table.Column<int>(nullable: false),
                    comment = table.Column<string>(nullable: true),
                    serviceModalId = table.Column<long>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModifiedOn = table.Column<DateTime>(nullable: true),
                    Is_Deleted = table.Column<bool>(nullable: false),
                    deleteTime = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rate_ServiceModal_serviceModalId",
                        column: x => x.serviceModalId,
                        principalTable: "ServiceModal",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rate_serviceModalId",
                table: "Rate",
                column: "serviceModalId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rate");
        }
    }
}
