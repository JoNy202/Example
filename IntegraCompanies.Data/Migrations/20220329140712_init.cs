using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IntegraCompanies.Data.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ConnectionServer",
                columns: table => new
                {
                    ConnectionServerId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    Source = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    User = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Password = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConnectionServer", x => x.ConnectionServerId);
                });

            migrationBuilder.CreateTable(
                name: "JurPerson",
                columns: table => new
                {
                    JurPersonId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    Note = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JurPerson", x => x.JurPersonId);
                });

            migrationBuilder.CreateTable(
                name: "Connection",
                columns: table => new
                {
                    ConnectionId = table.Column<Guid>(type: "uuid", nullable: false),
                    ConnectionServerId = table.Column<Guid>(type: "uuid", nullable: false),
                    DatabaseName = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    IsRazdel = table.Column<bool>(type: "boolean", nullable: false),
                    Note = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Connection", x => x.ConnectionId);
                    table.ForeignKey(
                        name: "FK_Connection_ConnectionServer_ConnectionServerId",
                        column: x => x.ConnectionServerId,
                        principalTable: "ConnectionServer",
                        principalColumn: "ConnectionServerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    CompanyId = table.Column<Guid>(type: "uuid", nullable: false),
                    JurPersonId = table.Column<Guid>(type: "uuid", nullable: false),
                    ConnectionId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    Note = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.CompanyId);
                    table.ForeignKey(
                        name: "FK_Company_Connection_ConnectionId",
                        column: x => x.ConnectionId,
                        principalTable: "Connection",
                        principalColumn: "ConnectionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Company_JurPerson_JurPersonId",
                        column: x => x.JurPersonId,
                        principalTable: "JurPerson",
                        principalColumn: "JurPersonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CompanyMask",
                columns: table => new
                {
                    CompanyMaskId = table.Column<Guid>(type: "uuid", nullable: false),
                    CompanyId = table.Column<Guid>(type: "uuid", nullable: false),
                    Mask = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyMask", x => x.CompanyMaskId);
                    table.ForeignKey(
                        name: "FK_CompanyMask_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Company_ConnectionId",
                table: "Company",
                column: "ConnectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Company_JurPersonId",
                table: "Company",
                column: "JurPersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Company_Name",
                table: "Company",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CompanyMask_CompanyId_Mask",
                table: "CompanyMask",
                columns: new[] { "CompanyId", "Mask" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CompanyMask_Mask",
                table: "CompanyMask",
                column: "Mask");

            migrationBuilder.CreateIndex(
                name: "IX_Connection_ConnectionServerId_DatabaseName",
                table: "Connection",
                columns: new[] { "ConnectionServerId", "DatabaseName" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_JurPerson_Name",
                table: "JurPerson",
                column: "Name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompanyMask");

            migrationBuilder.DropTable(
                name: "Company");

            migrationBuilder.DropTable(
                name: "Connection");

            migrationBuilder.DropTable(
                name: "JurPerson");

            migrationBuilder.DropTable(
                name: "ConnectionServer");
        }
    }
}
