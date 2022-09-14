using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EF_Core_postgres2.Migrations
{
    public partial class InitialCreate6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "GroupId",
                table: "Visits",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Visits_GroupId",
                table: "Visits",
                column: "GroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Visits_Groups_GroupId",
                table: "Visits",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Visits_Groups_GroupId",
                table: "Visits");

            migrationBuilder.DropIndex(
                name: "IX_Visits_GroupId",
                table: "Visits");

            migrationBuilder.DropColumn(
                name: "GroupId",
                table: "Visits");
        }
    }
}
