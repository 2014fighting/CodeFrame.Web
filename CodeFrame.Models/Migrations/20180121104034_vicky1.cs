using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CodeFrame.Models.Migrations
{
    public partial class vicky1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_t_sys_Column_t_sys_Table_TableId",
                table: "t_sys_Column");

            migrationBuilder.DropForeignKey(
                name: "FK_t_sys_MenuInfo_t_sys_SubSystem_SubSystemId",
                table: "t_sys_MenuInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_t_sys_UserInfo_t_sys_DepartMent_DepartMentId",
                table: "t_sys_UserInfo");

            migrationBuilder.AlterColumn<int>(
                name: "DepartMentId",
                table: "t_sys_UserInfo",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "SysTableId",
                table: "t_sys_MenuInfo",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "SubSystemId",
                table: "t_sys_MenuInfo",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "ParentMenuId",
                table: "t_sys_MenuInfo",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "TableId",
                table: "t_sys_Column",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_t_sys_Column_t_sys_Table_TableId",
                table: "t_sys_Column",
                column: "TableId",
                principalTable: "t_sys_Table",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_t_sys_MenuInfo_t_sys_SubSystem_SubSystemId",
                table: "t_sys_MenuInfo",
                column: "SubSystemId",
                principalTable: "t_sys_SubSystem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_t_sys_UserInfo_t_sys_DepartMent_DepartMentId",
                table: "t_sys_UserInfo",
                column: "DepartMentId",
                principalTable: "t_sys_DepartMent",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_t_sys_Column_t_sys_Table_TableId",
                table: "t_sys_Column");

            migrationBuilder.DropForeignKey(
                name: "FK_t_sys_MenuInfo_t_sys_SubSystem_SubSystemId",
                table: "t_sys_MenuInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_t_sys_UserInfo_t_sys_DepartMent_DepartMentId",
                table: "t_sys_UserInfo");

            migrationBuilder.AlterColumn<int>(
                name: "DepartMentId",
                table: "t_sys_UserInfo",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SysTableId",
                table: "t_sys_MenuInfo",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SubSystemId",
                table: "t_sys_MenuInfo",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ParentMenuId",
                table: "t_sys_MenuInfo",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TableId",
                table: "t_sys_Column",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_t_sys_Column_t_sys_Table_TableId",
                table: "t_sys_Column",
                column: "TableId",
                principalTable: "t_sys_Table",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_t_sys_MenuInfo_t_sys_SubSystem_SubSystemId",
                table: "t_sys_MenuInfo",
                column: "SubSystemId",
                principalTable: "t_sys_SubSystem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_t_sys_UserInfo_t_sys_DepartMent_DepartMentId",
                table: "t_sys_UserInfo",
                column: "DepartMentId",
                principalTable: "t_sys_DepartMent",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
