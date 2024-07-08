using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HNG_Backend_Stage_Two_User_Auth.Migrations
{
    /// <inheritdoc />
    public partial class CreatedUserOrganisations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Organisations",
                columns: table => new
                {
                    OrgId = table.Column<string>(type: "text", nullable: false, defaultValueSql: "'ORG' || LPAD(NEXTVAL('organisation_id_seq')::TEXT, 5, '0')"),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organisations", x => x.OrgId);
                });

            migrationBuilder.CreateTable(
                name: "UserOrganisations",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "character varying(255)", nullable: false),
                    OrgId = table.Column<string>(type: "text", nullable: false),
                    CreationDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserOrganisations", x => new { x.UserId, x.OrgId });
                    table.ForeignKey(
                        name: "FK_UserOrganisations_Organisations_OrgId",
                        column: x => x.OrgId,
                        principalTable: "Organisations",
                        principalColumn: "OrgId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserOrganisations_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserOrganisations_OrgId",
                table: "UserOrganisations",
                column: "OrgId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserOrganisations");

            migrationBuilder.DropTable(
                name: "Organisations");
        }
    }
}
