using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanArchitecture.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class updatingColChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "EmailConfig",
                keyColumn: "Id",
                keyValue: -1,
                column: "CreatedOn",
                value: new DateTime(2024, 10, 23, 11, 31, 54, 664, DateTimeKind.Utc).AddTicks(7903));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: -1,
                column: "CreatedOn",
                value: new DateTime(2024, 10, 23, 17, 1, 54, 665, DateTimeKind.Local).AddTicks(1887));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
