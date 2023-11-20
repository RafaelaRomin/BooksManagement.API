﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BooksManagement.API.Migrations
{
    /// <inheritdoc />
    public partial class MigrationBookLoan : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Devolution",
                table: "BookLoans",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Devolution",
                table: "BookLoans");
        }
    }
}
