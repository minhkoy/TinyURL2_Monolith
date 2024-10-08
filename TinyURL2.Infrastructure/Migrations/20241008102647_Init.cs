using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TinyURL2.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "TinyURL2");

            migrationBuilder.EnsureSchema(
                name: "TinyUrl2");

            migrationBuilder.CreateTable(
                name: "AuthenticationMethod",
                schema: "TinyURL2",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthenticationMethod", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Account",
                schema: "TinyURL2",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Salt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HashedPassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AuthenticationMethodId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Avatar = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    LastestOTP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastestOTPTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Account_AuthenticationMethod_AuthenticationMethodId",
                        column: x => x.AuthenticationMethodId,
                        principalSchema: "TinyURL2",
                        principalTable: "AuthenticationMethod",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Url",
                schema: "TinyUrl2",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OriginalUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Clicks = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Url", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Url_Account_CreatedBy",
                        column: x => x.CreatedBy,
                        principalSchema: "TinyURL2",
                        principalTable: "Account",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Account_AuthenticationMethodId",
                schema: "TinyURL2",
                table: "Account",
                column: "AuthenticationMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_Url_Code",
                schema: "TinyUrl2",
                table: "Url",
                column: "Code");

            migrationBuilder.CreateIndex(
                name: "IX_Url_CreatedBy",
                schema: "TinyUrl2",
                table: "Url",
                column: "CreatedBy");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Url",
                schema: "TinyUrl2");

            migrationBuilder.DropTable(
                name: "Account",
                schema: "TinyURL2");

            migrationBuilder.DropTable(
                name: "AuthenticationMethod",
                schema: "TinyURL2");
        }
    }
}
