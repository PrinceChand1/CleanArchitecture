using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanArchitecture.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class updation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "EmailConfig",
                keyColumn: "Id",
                keyValue: -1,
                column: "CreatedOn",
                value: new DateTime(2024, 10, 22, 5, 38, 26, 470, DateTimeKind.Utc).AddTicks(8838));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: -1,
                column: "CreatedOn",
                value: new DateTime(2024, 10, 22, 11, 8, 26, 471, DateTimeKind.Local).AddTicks(1345));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "EmailConfig",
                keyColumn: "Id",
                keyValue: -1,
                column: "CreatedOn",
                value: new DateTime(2024, 10, 21, 6, 54, 40, 889, DateTimeKind.Utc).AddTicks(7181));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: -1,
                column: "CreatedOn",
                value: new DateTime(2024, 10, 21, 12, 24, 40, 890, DateTimeKind.Local).AddTicks(2764));
        }
    }
}
