using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusinessObjects.Migrations
{
    /// <inheritdoc />
    public partial class AddCreatedAtToSubmittion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Content",
                table: "Submittions");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Submittions",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Submittions",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FilePath",
                table: "Submittions",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Submittions");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Submittions");

            migrationBuilder.DropColumn(
                name: "FilePath",
                table: "Submittions");

            migrationBuilder.AddColumn<string>(
                name: "Content",
                table: "Submittions",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
