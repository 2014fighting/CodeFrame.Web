using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CodeFrame.Models.Migrations
{
    public partial class vicky4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_t_sys_Button_t_sys_Table_TableId",
                table: "t_sys_Button");

            migrationBuilder.DropColumn(
                name: "SysTableId",
                table: "t_sys_Button");

            migrationBuilder.AlterColumn<int>(
                name: "TableId",
                table: "t_sys_Button",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_t_sys_Button_t_sys_Table_TableId",
                table: "t_sys_Button",
                column: "TableId",
                principalTable: "t_sys_Table",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_t_sys_Button_t_sys_Table_TableId",
                table: "t_sys_Button");

            migrationBuilder.AlterColumn<int>(
                name: "TableId",
                table: "t_sys_Button",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "SysTableId",
                table: "t_sys_Button",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_t_sys_Button_t_sys_Table_TableId",
                table: "t_sys_Button",
                column: "TableId",
                principalTable: "t_sys_Table",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
