using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Product_Management_System.Context.Migrations
{
    /// <inheritdoc />
    public partial class AddCreatedDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Product",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Product");
        }
    }
}
