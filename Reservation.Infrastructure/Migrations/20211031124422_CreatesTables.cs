using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ReservationProject.Infrastructure.Migrations
{
    public partial class CreatesTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "Cateogries",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(nullable: true),
                    categoryId = table.Column<long>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModifiedOn = table.Column<DateTime>(nullable: true),
                    Is_Deleted = table.Column<bool>(nullable: false),
                    deleteTime = table.Column<DateTime>(nullable: false),
                    userId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cateogries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cateogries_Cateogries_categoryId",
                        column: x => x.categoryId,
                        principalTable: "Cateogries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ServiceModal",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true),
                    price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    countAllowReserve = table.Column<int>(nullable: false),
                    isLock = table.Column<bool>(nullable: false),
                    hasDiscount = table.Column<bool>(nullable: false),
                    serviceProviderId = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModifiedOn = table.Column<DateTime>(nullable: true),
                    Is_Deleted = table.Column<bool>(nullable: false),
                    deleteTime = table.Column<DateTime>(nullable: false),
                    userId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceModal", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    ImgUrl = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AvailableServices",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    everyWeek = table.Column<bool>(nullable: false),
                    ServiceModalId = table.Column<long>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModifiedOn = table.Column<DateTime>(nullable: true),
                    Is_Deleted = table.Column<bool>(nullable: false),
                    deleteTime = table.Column<DateTime>(nullable: false),
                    userId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AvailableServices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AvailableServices_ServiceModal_ServiceModalId",
                        column: x => x.ServiceModalId,
                        principalTable: "ServiceModal",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Discount",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    discount = table.Column<int>(nullable: false),
                    serviceModalId = table.Column<long>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModifiedOn = table.Column<DateTime>(nullable: true),
                    Is_Deleted = table.Column<bool>(nullable: false),
                    deleteTime = table.Column<DateTime>(nullable: false),
                    userId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discount", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Discount_ServiceModal_serviceModalId",
                        column: x => x.serviceModalId,
                        principalTable: "ServiceModal",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    serviceId = table.Column<long>(nullable: false),
                    longitude = table.Column<float>(nullable: false),
                    latitude = table.Column<float>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModifiedOn = table.Column<DateTime>(nullable: true),
                    Is_Deleted = table.Column<bool>(nullable: false),
                    deleteTime = table.Column<DateTime>(nullable: false),
                    userId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Locations_ServiceModal_serviceId",
                        column: x => x.serviceId,
                        principalTable: "ServiceModal",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServicePolicy",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    version = table.Column<int>(nullable: false),
                    serviceId = table.Column<long>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModifiedOn = table.Column<DateTime>(nullable: true),
                    Is_Deleted = table.Column<bool>(nullable: false),
                    deleteTime = table.Column<DateTime>(nullable: false),
                    userId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServicePolicy", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServicePolicy_ServiceModal_serviceId",
                        column: x => x.serviceId,
                        principalTable: "ServiceModal",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RoleClaims",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleClaims_Roles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "dbo",
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserClaims",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserClaims_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserLogins",
                schema: "dbo",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_UserLogins_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                schema: "dbo",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "dbo",
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserTokens",
                schema: "dbo",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_UserTokens_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AvailableServiceTime",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    day = table.Column<string>(nullable: true),
                    fromTime = table.Column<string>(nullable: true),
                    toTime = table.Column<string>(nullable: true),
                    availableServiceId = table.Column<long>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModifiedOn = table.Column<DateTime>(nullable: true),
                    Is_Deleted = table.Column<bool>(nullable: false),
                    deleteTime = table.Column<DateTime>(nullable: false),
                    userId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AvailableServiceTime", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AvailableServiceTime_AvailableServices_availableServiceId",
                        column: x => x.availableServiceId,
                        principalTable: "AvailableServices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServicePolicyItem",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    item = table.Column<string>(nullable: true),
                    servicePolicyId = table.Column<long>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModifiedOn = table.Column<DateTime>(nullable: true),
                    Is_Deleted = table.Column<bool>(nullable: false),
                    deleteTime = table.Column<DateTime>(nullable: false),
                    userId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServicePolicyItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServicePolicyItem_ServicePolicy_servicePolicyId",
                        column: x => x.servicePolicyId,
                        principalTable: "ServicePolicy",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AvailableServices_ServiceModalId",
                table: "AvailableServices",
                column: "ServiceModalId");

            migrationBuilder.CreateIndex(
                name: "IX_AvailableServiceTime_availableServiceId",
                table: "AvailableServiceTime",
                column: "availableServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Cateogries_categoryId",
                table: "Cateogries",
                column: "categoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Discount_serviceModalId",
                table: "Discount",
                column: "serviceModalId");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_serviceId",
                table: "Locations",
                column: "serviceId");

            migrationBuilder.CreateIndex(
                name: "IX_ServicePolicy_serviceId",
                table: "ServicePolicy",
                column: "serviceId");

            migrationBuilder.CreateIndex(
                name: "IX_ServicePolicyItem_servicePolicyId",
                table: "ServicePolicyItem",
                column: "servicePolicyId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleClaims_RoleId",
                schema: "dbo",
                table: "RoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                schema: "dbo",
                table: "Roles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_UserClaims_UserId",
                schema: "dbo",
                table: "UserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLogins_UserId",
                schema: "dbo",
                table: "UserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                schema: "dbo",
                table: "UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                schema: "dbo",
                table: "Users",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                schema: "dbo",
                table: "Users",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AvailableServiceTime");

            migrationBuilder.DropTable(
                name: "Cateogries");

            migrationBuilder.DropTable(
                name: "Discount");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "ServicePolicyItem");

            migrationBuilder.DropTable(
                name: "RoleClaims",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "UserClaims",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "UserLogins",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "UserRoles",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "UserTokens",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "AvailableServices");

            migrationBuilder.DropTable(
                name: "ServicePolicy");

            migrationBuilder.DropTable(
                name: "Roles",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "ServiceModal");
        }
    }
}
