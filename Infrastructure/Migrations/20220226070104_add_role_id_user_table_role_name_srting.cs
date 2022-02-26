using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class add_role_id_user_table_role_name_srting : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "roleId",
                schema: "dbo",
                table: "Users");

            migrationBuilder.AddColumn<string>(
                name: "roleName",
                schema: "dbo",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "roleName",
                schema: "dbo",
                table: "Users");

            migrationBuilder.AddColumn<int>(
                name: "roleId",
                schema: "dbo",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
