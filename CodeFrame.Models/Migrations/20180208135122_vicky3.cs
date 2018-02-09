using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CodeFrame.Models.Migrations
{
    public partial class vicky3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreteTime",
                table: "t_sys_UserInfo");

            migrationBuilder.DropColumn(
                name: "CreteTime",
                table: "t_sys_Table");

            migrationBuilder.DropColumn(
                name: "CreteTime",
                table: "t_sys_SubSystem");

            migrationBuilder.DropColumn(
                name: "CreteTime",
                table: "t_sys_RolePower");

            migrationBuilder.DropColumn(
                name: "CreteTime",
                table: "t_sys_RoleInfo");

            migrationBuilder.DropColumn(
                name: "CreteTime",
                table: "t_sys_MenuInfo");

            migrationBuilder.DropColumn(
                name: "CreteTime",
                table: "t_sys_DepartMent");

            migrationBuilder.DropColumn(
                name: "CreteTime",
                table: "t_sys_Column");

            migrationBuilder.DropColumn(
                name: "CreteTime",
                table: "t_sys_Button");

            migrationBuilder.RenameColumn(
                name: "CreteUser",
                table: "t_sys_UserInfo",
                newName: "CreateTime");

            migrationBuilder.RenameColumn(
                name: "CreteUser",
                table: "t_sys_Table",
                newName: "CreateTime");

            migrationBuilder.RenameColumn(
                name: "CreteUser",
                table: "t_sys_SubSystem",
                newName: "CreateTime");

            migrationBuilder.RenameColumn(
                name: "CreteUser",
                table: "t_sys_RolePower",
                newName: "CreateTime");

            migrationBuilder.RenameColumn(
                name: "CreteUser",
                table: "t_sys_RoleInfo",
                newName: "CreateTime");

            migrationBuilder.RenameColumn(
                name: "CreteUser",
                table: "t_sys_MenuInfo",
                newName: "CreateTime");

            migrationBuilder.RenameColumn(
                name: "CreteUser",
                table: "t_sys_DepartMent",
                newName: "CreateTime");

            migrationBuilder.RenameColumn(
                name: "CreteUser",
                table: "t_sys_Column",
                newName: "CreateTime");

            migrationBuilder.RenameColumn(
                name: "CreteUser",
                table: "t_sys_Button",
                newName: "CreateTime");

            migrationBuilder.AlterColumn<string>(
                name: "UpdateUser",
                table: "t_sys_UserInfo",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreateUser",
                table: "t_sys_UserInfo",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreateUserId",
                table: "t_sys_UserInfo",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UpdateUserId",
                table: "t_sys_UserInfo",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UpdateUser",
                table: "t_sys_Table",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreateUser",
                table: "t_sys_Table",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreateUserId",
                table: "t_sys_Table",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UpdateUserId",
                table: "t_sys_Table",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UpdateUser",
                table: "t_sys_SubSystem",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreateUser",
                table: "t_sys_SubSystem",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreateUserId",
                table: "t_sys_SubSystem",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UpdateUserId",
                table: "t_sys_SubSystem",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UpdateUser",
                table: "t_sys_RolePower",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreateUser",
                table: "t_sys_RolePower",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreateUserId",
                table: "t_sys_RolePower",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UpdateUserId",
                table: "t_sys_RolePower",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UpdateUser",
                table: "t_sys_RoleInfo",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreateUser",
                table: "t_sys_RoleInfo",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreateUserId",
                table: "t_sys_RoleInfo",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UpdateUserId",
                table: "t_sys_RoleInfo",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UpdateUser",
                table: "t_sys_MenuInfo",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreateUser",
                table: "t_sys_MenuInfo",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreateUserId",
                table: "t_sys_MenuInfo",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UpdateUserId",
                table: "t_sys_MenuInfo",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UpdateUser",
                table: "t_sys_DepartMent",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreateUser",
                table: "t_sys_DepartMent",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreateUserId",
                table: "t_sys_DepartMent",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UpdateUserId",
                table: "t_sys_DepartMent",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UpdateUser",
                table: "t_sys_Column",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreateUser",
                table: "t_sys_Column",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreateUserId",
                table: "t_sys_Column",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UpdateUserId",
                table: "t_sys_Column",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UpdateUser",
                table: "t_sys_Button",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreateUser",
                table: "t_sys_Button",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreateUserId",
                table: "t_sys_Button",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UpdateUserId",
                table: "t_sys_Button",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreateUser",
                table: "t_sys_UserInfo");

            migrationBuilder.DropColumn(
                name: "CreateUserId",
                table: "t_sys_UserInfo");

            migrationBuilder.DropColumn(
                name: "UpdateUserId",
                table: "t_sys_UserInfo");

            migrationBuilder.DropColumn(
                name: "CreateUser",
                table: "t_sys_Table");

            migrationBuilder.DropColumn(
                name: "CreateUserId",
                table: "t_sys_Table");

            migrationBuilder.DropColumn(
                name: "UpdateUserId",
                table: "t_sys_Table");

            migrationBuilder.DropColumn(
                name: "CreateUser",
                table: "t_sys_SubSystem");

            migrationBuilder.DropColumn(
                name: "CreateUserId",
                table: "t_sys_SubSystem");

            migrationBuilder.DropColumn(
                name: "UpdateUserId",
                table: "t_sys_SubSystem");

            migrationBuilder.DropColumn(
                name: "CreateUser",
                table: "t_sys_RolePower");

            migrationBuilder.DropColumn(
                name: "CreateUserId",
                table: "t_sys_RolePower");

            migrationBuilder.DropColumn(
                name: "UpdateUserId",
                table: "t_sys_RolePower");

            migrationBuilder.DropColumn(
                name: "CreateUser",
                table: "t_sys_RoleInfo");

            migrationBuilder.DropColumn(
                name: "CreateUserId",
                table: "t_sys_RoleInfo");

            migrationBuilder.DropColumn(
                name: "UpdateUserId",
                table: "t_sys_RoleInfo");

            migrationBuilder.DropColumn(
                name: "CreateUser",
                table: "t_sys_MenuInfo");

            migrationBuilder.DropColumn(
                name: "CreateUserId",
                table: "t_sys_MenuInfo");

            migrationBuilder.DropColumn(
                name: "UpdateUserId",
                table: "t_sys_MenuInfo");

            migrationBuilder.DropColumn(
                name: "CreateUser",
                table: "t_sys_DepartMent");

            migrationBuilder.DropColumn(
                name: "CreateUserId",
                table: "t_sys_DepartMent");

            migrationBuilder.DropColumn(
                name: "UpdateUserId",
                table: "t_sys_DepartMent");

            migrationBuilder.DropColumn(
                name: "CreateUser",
                table: "t_sys_Column");

            migrationBuilder.DropColumn(
                name: "CreateUserId",
                table: "t_sys_Column");

            migrationBuilder.DropColumn(
                name: "UpdateUserId",
                table: "t_sys_Column");

            migrationBuilder.DropColumn(
                name: "CreateUser",
                table: "t_sys_Button");

            migrationBuilder.DropColumn(
                name: "CreateUserId",
                table: "t_sys_Button");

            migrationBuilder.DropColumn(
                name: "UpdateUserId",
                table: "t_sys_Button");

            migrationBuilder.RenameColumn(
                name: "CreateTime",
                table: "t_sys_UserInfo",
                newName: "CreteUser");

            migrationBuilder.RenameColumn(
                name: "CreateTime",
                table: "t_sys_Table",
                newName: "CreteUser");

            migrationBuilder.RenameColumn(
                name: "CreateTime",
                table: "t_sys_SubSystem",
                newName: "CreteUser");

            migrationBuilder.RenameColumn(
                name: "CreateTime",
                table: "t_sys_RolePower",
                newName: "CreteUser");

            migrationBuilder.RenameColumn(
                name: "CreateTime",
                table: "t_sys_RoleInfo",
                newName: "CreteUser");

            migrationBuilder.RenameColumn(
                name: "CreateTime",
                table: "t_sys_MenuInfo",
                newName: "CreteUser");

            migrationBuilder.RenameColumn(
                name: "CreateTime",
                table: "t_sys_DepartMent",
                newName: "CreteUser");

            migrationBuilder.RenameColumn(
                name: "CreateTime",
                table: "t_sys_Column",
                newName: "CreteUser");

            migrationBuilder.RenameColumn(
                name: "CreateTime",
                table: "t_sys_Button",
                newName: "CreteUser");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateUser",
                table: "t_sys_UserInfo",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreteTime",
                table: "t_sys_UserInfo",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateUser",
                table: "t_sys_Table",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreteTime",
                table: "t_sys_Table",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateUser",
                table: "t_sys_SubSystem",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreteTime",
                table: "t_sys_SubSystem",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateUser",
                table: "t_sys_RolePower",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreteTime",
                table: "t_sys_RolePower",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateUser",
                table: "t_sys_RoleInfo",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreteTime",
                table: "t_sys_RoleInfo",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateUser",
                table: "t_sys_MenuInfo",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreteTime",
                table: "t_sys_MenuInfo",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateUser",
                table: "t_sys_DepartMent",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreteTime",
                table: "t_sys_DepartMent",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateUser",
                table: "t_sys_Column",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreteTime",
                table: "t_sys_Column",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateUser",
                table: "t_sys_Button",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreteTime",
                table: "t_sys_Button",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
