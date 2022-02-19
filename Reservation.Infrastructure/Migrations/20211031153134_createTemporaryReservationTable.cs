using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ReservationProject.Infrastructure.Migrations
{
    public partial class createTemporaryReservationTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "userId",
                table: "ServicePolicyItem",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "userId",
                table: "ServicePolicy",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "userId",
                table: "ServiceModal",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "userId",
                table: "Locations",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "userId",
                table: "Discount",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "userId",
                table: "Cateogries",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "userId",
                table: "AvailableServiceTime",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "userId",
                table: "AvailableServices",
                newName: "UserId");

            migrationBuilder.CreateTable(
                name: "TemporaryReservations",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReservationUserId = table.Column<string>(nullable: true),
                    serviceModalId = table.Column<long>(nullable: true),
                    ServicePolicyId = table.Column<long>(nullable: true),
                    dateOfReservation = table.Column<DateTime>(nullable: false),
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
                    table.PrimaryKey("PK_TemporaryReservations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TemporaryReservations_ServicePolicy_ServicePolicyId",
                        column: x => x.ServicePolicyId,
                        principalTable: "ServicePolicy",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TemporaryReservations_ServiceModal_serviceModalId",
                        column: x => x.serviceModalId,
                        principalTable: "ServiceModal",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TemporaryReservations_ServicePolicyId",
                table: "TemporaryReservations",
                column: "ServicePolicyId");

            migrationBuilder.CreateIndex(
                name: "IX_TemporaryReservations_serviceModalId",
                table: "TemporaryReservations",
                column: "serviceModalId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TemporaryReservations");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "ServicePolicyItem",
                newName: "userId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "ServicePolicy",
                newName: "userId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "ServiceModal",
                newName: "userId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Locations",
                newName: "userId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Discount",
                newName: "userId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Cateogries",
                newName: "userId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "AvailableServiceTime",
                newName: "userId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "AvailableServices",
                newName: "userId");
        }
    }
}
