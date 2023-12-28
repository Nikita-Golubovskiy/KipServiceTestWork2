using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.KipServiceTestWork.Database.Migrations
{
    /// <inheritdoc />
    public partial class Initialization : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Logs",
                columns: table => new
                {
                    RequestsID = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    RequestAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    Request = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Response = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logs", x => x.RequestsID);
                });

            migrationBuilder.CreateTable(
                name: "UserSigns",
                columns: table => new
                {
                    UserID = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    SignDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSigns", x => new { x.UserID, x.SignDate });
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Logs");

            migrationBuilder.DropTable(
                name: "UserSigns");
        }
    }
}
