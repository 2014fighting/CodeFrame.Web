using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CodeFrame.Models.Migrations
{
    public partial class vicky5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Describe",
                table: "t_sys_UserInfo",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Gender",
                table: "t_sys_UserInfo",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Group",
                table: "t_sys_UserInfo",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GroupNum",
                table: "t_sys_UserInfo",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Picture",
                table: "t_sys_UserInfo",
                maxLength: 300,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Post",
                table: "t_sys_UserInfo",
                maxLength: 300,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Skill",
                table: "t_sys_UserInfo",
                maxLength: 100,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Describe",
                table: "t_sys_UserInfo");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "t_sys_UserInfo");

            migrationBuilder.DropColumn(
                name: "Group",
                table: "t_sys_UserInfo");

            migrationBuilder.DropColumn(
                name: "GroupNum",
                table: "t_sys_UserInfo");

            migrationBuilder.DropColumn(
                name: "Picture",
                table: "t_sys_UserInfo");

            migrationBuilder.DropColumn(
                name: "Post",
                table: "t_sys_UserInfo");

            migrationBuilder.DropColumn(
                name: "Skill",
                table: "t_sys_UserInfo");
        }
    }
}
