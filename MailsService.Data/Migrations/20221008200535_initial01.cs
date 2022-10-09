using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MailsService.Data.Migrations
{
    public partial class initial01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "sentMessages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Subject = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Body = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Recipient = table.Column<string>(type: "nvarchar(260)", maxLength: 260, nullable: true),
                    Result = table.Column<byte>(type: "tinyint", maxLength: 10, nullable: true),
                    FailedMassage = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    SentDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sentMessages", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "sentMessages");
        }
    }
}
