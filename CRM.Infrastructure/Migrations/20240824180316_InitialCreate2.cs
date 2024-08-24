using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CRM.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "EmailConfirmed", "NormalizedEmail", "PasswordHash" },
                values: new object[] { "5f8621bf-23d9-4a25-8349-d8934da72982", true, "ADMIN@EXAMPLE.COM", "AQAAAAIAAYagAAAAEB+tcayqp2o5w7fjXT3hqVWe5lzLaKSOcnvWALyr2SQ0R2N6CLUim5kY1l33urYc5Q==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "EmailConfirmed", "NormalizedEmail", "PasswordHash" },
                values: new object[] { "0b5997da-df85-466f-b234-425fddeb27e1", false, null, "AQAAAAIAAYagAAAAEGq0wdn0m3eQDTEwsh5DbTwxSZWA3vXkTxQrtfua/l9r9mXgGzumcZDguuejX0+kqg==" });
        }
    }
}
