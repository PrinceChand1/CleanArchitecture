using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanArchitecture.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class changing_errorlog_to_log : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ErrorLog");

            migrationBuilder.CreateTable(
                name: "Log",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Userid = table.Column<int>(type: "int", maxLength: 200, nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Method = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Operation = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Path = table.Column<string>(type: "nvarchar(max)", maxLength: 10000, nullable: false),
                    InnerException = table.Column<string>(type: "nvarchar(max)", maxLength: 10000, nullable: true),
                    ErrorMessage = table.Column<string>(type: "nvarchar(max)", maxLength: 10000, nullable: false),
                    StackTrace = table.Column<string>(type: "nvarchar(max)", maxLength: 10000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Log", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "EmailConfig",
                keyColumn: "Id",
                keyValue: -1,
                columns: new[] { "CreatedBy", "CreatedOn" },
                values: new object[] { "Admin", new DateTime(2024, 10, 21, 6, 54, 40, 889, DateTimeKind.Utc).AddTicks(7181) });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: -1,
                columns: new[] { "CreatedBy", "CreatedOn" },
                values: new object[] { "Admin", new DateTime(2024, 10, 21, 12, 24, 40, 890, DateTimeKind.Local).AddTicks(2764) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Log");

            migrationBuilder.CreateTable(
                name: "ErrorLog",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ErrorMessage = table.Column<string>(type: "nvarchar(max)", maxLength: 10000, nullable: false),
                    InnerException = table.Column<string>(type: "nvarchar(max)", maxLength: 10000, nullable: true),
                    Method = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Operation = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Path = table.Column<string>(type: "nvarchar(max)", maxLength: 10000, nullable: false),
                    StackTrace = table.Column<string>(type: "nvarchar(max)", maxLength: 10000, nullable: false),
                    Userid = table.Column<int>(type: "int", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ErrorLog", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "EmailConfig",
                keyColumn: "Id",
                keyValue: -1,
                columns: new[] { "CreatedBy", "CreatedOn" },
                values: new object[] { "", new DateTime(2024, 10, 21, 6, 32, 54, 996, DateTimeKind.Utc).AddTicks(6426) });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: -1,
                columns: new[] { "CreatedBy", "CreatedOn" },
                values: new object[] { "", new DateTime(2024, 10, 21, 12, 2, 54, 997, DateTimeKind.Local).AddTicks(4552) });
        }
    }
}