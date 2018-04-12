using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CodeFrame.Models.Migrations
{
    public partial class vickey9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_t_sys_Button_t_sys_Table_TableId",
                table: "t_sys_Button");

            migrationBuilder.RenameColumn(
                name: "TableId",
                table: "t_sys_Button",
                newName: "MenuId");

            migrationBuilder.RenameIndex(
                name: "IX_t_sys_Button_TableId",
                table: "t_sys_Button",
                newName: "IX_t_sys_Button_MenuId");

            migrationBuilder.AddForeignKey(
                name: "FK_t_sys_Button_t_sys_MenuInfo_MenuId",
                table: "t_sys_Button",
                column: "MenuId",
                principalTable: "t_sys_MenuInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_t_sys_Button_t_sys_MenuInfo_MenuId",
                table: "t_sys_Button");

            migrationBuilder.RenameColumn(
                name: "MenuId",
                table: "t_sys_Button",
                newName: "TableId");

            migrationBuilder.RenameIndex(
                name: "IX_t_sys_Button_MenuId",
                table: "t_sys_Button",
                newName: "IX_t_sys_Button_TableId");

            migrationBuilder.AddForeignKey(
                name: "FK_t_sys_Button_t_sys_Table_TableId",
                table: "t_sys_Button",
                column: "TableId",
                principalTable: "t_sys_Table",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
