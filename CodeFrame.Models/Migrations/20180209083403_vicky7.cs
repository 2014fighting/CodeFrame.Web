using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CodeFrame.Models.Migrations
{
    public partial class vicky7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Width",
                table: "t_sys_Column",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsSpecial",
                table: "t_sys_Button",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Width",
                table: "t_sys_Column");

            migrationBuilder.DropColumn(
                name: "IsSpecial",
                table: "t_sys_Button");
        }
    }
}
