using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EF_Core_postgres2.Migrations
{
    public partial class InitialCreate5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "GrouppId",
                table: "Students",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Students_GrouppId",
                table: "Students",
                column: "GrouppId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Groups_GrouppId",
                table: "Students",
                column: "GrouppId",
                principalTable: "Groups",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Groups_GrouppId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_GrouppId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "GrouppId",
                table: "Students");
        }
    }
}
