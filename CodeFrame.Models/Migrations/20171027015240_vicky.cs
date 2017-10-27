using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CodeFrame.Models.Migrations
{
    public partial class vicky : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "t_sys_RoleInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreteTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Describe = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    RoleName = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    RowVersion = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_sys_RoleInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "t_sys_UserInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreteTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Password = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    PhoneNo = table.Column<string>(type: "varchar(11)", maxLength: 11, nullable: true),
                    RowVersion = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    TrueName = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    UserName = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_sys_UserInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "t_sys_UserRole",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_sys_UserRole", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_t_sys_UserRole_t_sys_RoleInfo_RoleId",
                        column: x => x.RoleId,
                        principalTable: "t_sys_RoleInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_t_sys_UserRole_t_sys_UserInfo_UserId",
                        column: x => x.UserId,
                        principalTable: "t_sys_UserInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_t_sys_UserRole_RoleId",
                table: "t_sys_UserRole",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "t_sys_UserRole");

            migrationBuilder.DropTable(
                name: "t_sys_RoleInfo");

            migrationBuilder.DropTable(
                name: "t_sys_UserInfo");
        }
    }
}
