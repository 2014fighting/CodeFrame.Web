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
                name: "t_sys_DepartMent",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreteTime = table.Column<DateTime>(nullable: false),
                    CreteUser = table.Column<DateTime>(nullable: false),
                    DptName = table.Column<string>(maxLength: 20, nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    OrderBy = table.Column<int>(nullable: false),
                    ParentId = table.Column<int>(nullable: false),
                    ReMark = table.Column<string>(nullable: true),
                    RowVersion = table.Column<DateTime>(nullable: false),
                    UpdateTime = table.Column<DateTime>(nullable: true),
                    UpdateUser = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_sys_DepartMent", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "t_sys_RoleInfo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreteTime = table.Column<DateTime>(nullable: false),
                    CreteUser = table.Column<DateTime>(nullable: false),
                    Describe = table.Column<string>(maxLength: 20, nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    RoleName = table.Column<string>(maxLength: 20, nullable: false),
                    RowVersion = table.Column<DateTime>(nullable: false),
                    UpdateTime = table.Column<DateTime>(nullable: true),
                    UpdateUser = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_sys_RoleInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "t_sys_RolePower",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ButtonId = table.Column<int>(nullable: false),
                    CreteTime = table.Column<DateTime>(nullable: false),
                    CreteUser = table.Column<DateTime>(nullable: false),
                    MentId = table.Column<int>(nullable: false),
                    RoleId = table.Column<int>(nullable: false),
                    RowVersion = table.Column<DateTime>(nullable: false),
                    Type = table.Column<int>(nullable: false),
                    UpdateTime = table.Column<DateTime>(nullable: true),
                    UpdateUser = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_sys_RolePower", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "t_sys_SubSystem",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreteTime = table.Column<DateTime>(nullable: false),
                    CreteUser = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    Link = table.Column<string>(nullable: true),
                    OrderBy = table.Column<int>(nullable: false),
                    ReMark = table.Column<string>(nullable: true),
                    RowVersion = table.Column<DateTime>(nullable: false),
                    SystemIcon = table.Column<string>(nullable: true),
                    SystemName = table.Column<string>(nullable: true),
                    UpdateTime = table.Column<DateTime>(nullable: true),
                    UpdateUser = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_sys_SubSystem", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "t_sys_Table",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreteTime = table.Column<DateTime>(nullable: false),
                    CreteUser = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    IsMultiple = table.Column<bool>(nullable: false),
                    IsPaging = table.Column<bool>(nullable: false),
                    OrderBy = table.Column<int>(nullable: false),
                    ReMark = table.Column<string>(nullable: true),
                    RowVersion = table.Column<DateTime>(nullable: false),
                    ShowName = table.Column<string>(nullable: true),
                    TableName = table.Column<string>(nullable: true),
                    UpdateTime = table.Column<DateTime>(nullable: true),
                    UpdateUser = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_sys_Table", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "t_sys_UserInfo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreteTime = table.Column<DateTime>(nullable: false),
                    CreteUser = table.Column<DateTime>(nullable: false),
                    DepartMentId = table.Column<int>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    Password = table.Column<string>(maxLength: 30, nullable: false),
                    PhoneNo = table.Column<string>(maxLength: 11, nullable: true),
                    RowVersion = table.Column<DateTime>(nullable: false),
                    TrueName = table.Column<string>(maxLength: 20, nullable: false),
                    UpdateTime = table.Column<DateTime>(nullable: true),
                    UpdateUser = table.Column<DateTime>(nullable: true),
                    UserName = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_sys_UserInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_t_sys_UserInfo_t_sys_DepartMent_DepartMentId",
                        column: x => x.DepartMentId,
                        principalTable: "t_sys_DepartMent",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "t_sys_Button",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    BtnClass = table.Column<string>(maxLength: 50, nullable: true),
                    BtnIcon = table.Column<string>(maxLength: 50, nullable: true),
                    BtnName = table.Column<string>(maxLength: 20, nullable: true),
                    BtnScript = table.Column<string>(maxLength: 50, nullable: true),
                    BtnTip = table.Column<string>(maxLength: 50, nullable: true),
                    BtnUrl = table.Column<string>(maxLength: 300, nullable: true),
                    CreteTime = table.Column<DateTime>(nullable: false),
                    CreteUser = table.Column<DateTime>(nullable: false),
                    DisplayCondition = table.Column<string>(maxLength: 500, nullable: true),
                    EditType = table.Column<int>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    OrderBy = table.Column<int>(nullable: false),
                    RowVersion = table.Column<DateTime>(nullable: false),
                    SpName = table.Column<string>(maxLength: 50, nullable: true),
                    SysTableId = table.Column<int>(nullable: false),
                    TableId = table.Column<int>(nullable: true),
                    UpdateTime = table.Column<DateTime>(nullable: true),
                    UpdateUser = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_sys_Button", x => x.Id);
                    table.ForeignKey(
                        name: "FK_t_sys_Button_t_sys_Table_TableId",
                        column: x => x.TableId,
                        principalTable: "t_sys_Table",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "t_sys_Column",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ColumnName = table.Column<string>(maxLength: 30, nullable: true),
                    ColumnType = table.Column<int>(nullable: false),
                    CreteTime = table.Column<DateTime>(nullable: false),
                    CreteUser = table.Column<DateTime>(nullable: false),
                    DataOptions = table.Column<string>(maxLength: 300, nullable: true),
                    DisplayType = table.Column<int>(nullable: false),
                    FkTableId = table.Column<int>(nullable: false),
                    IsIndexed = table.Column<bool>(nullable: false),
                    IsShow = table.Column<bool>(nullable: false),
                    OrderBy = table.Column<int>(nullable: false),
                    ReMark = table.Column<string>(nullable: true),
                    RowVersion = table.Column<DateTime>(nullable: false),
                    ShowName = table.Column<string>(maxLength: 20, nullable: true),
                    TableId = table.Column<int>(nullable: false),
                    Tip = table.Column<string>(maxLength: 100, nullable: true),
                    UpdateTime = table.Column<DateTime>(nullable: true),
                    UpdateUser = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_sys_Column", x => x.Id);
                    table.ForeignKey(
                        name: "FK_t_sys_Column_t_sys_Table_TableId",
                        column: x => x.TableId,
                        principalTable: "t_sys_Table",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "t_sys_MenuInfo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreteTime = table.Column<DateTime>(nullable: false),
                    CreteUser = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    MenuName = table.Column<string>(maxLength: 20, nullable: true),
                    MenuUrl = table.Column<string>(maxLength: 500, nullable: true),
                    OrderBy = table.Column<int>(nullable: false),
                    ParentMenuId = table.Column<int>(nullable: false),
                    RowVersion = table.Column<DateTime>(nullable: false),
                    SubSystemId = table.Column<int>(nullable: false),
                    SysTableId = table.Column<int>(nullable: false),
                    TableId = table.Column<int>(nullable: true),
                    UpdateTime = table.Column<DateTime>(nullable: true),
                    UpdateUser = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_sys_MenuInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_t_sys_MenuInfo_t_sys_SubSystem_SubSystemId",
                        column: x => x.SubSystemId,
                        principalTable: "t_sys_SubSystem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_t_sys_MenuInfo_t_sys_Table_TableId",
                        column: x => x.TableId,
                        principalTable: "t_sys_Table",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "t_sys_UserRole",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    RoleId = table.Column<int>(nullable: false)
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
                name: "IX_t_sys_Button_TableId",
                table: "t_sys_Button",
                column: "TableId");

            migrationBuilder.CreateIndex(
                name: "IX_t_sys_Column_TableId",
                table: "t_sys_Column",
                column: "TableId");

            migrationBuilder.CreateIndex(
                name: "IX_t_sys_MenuInfo_SubSystemId",
                table: "t_sys_MenuInfo",
                column: "SubSystemId");

            migrationBuilder.CreateIndex(
                name: "IX_t_sys_MenuInfo_TableId",
                table: "t_sys_MenuInfo",
                column: "TableId");

            migrationBuilder.CreateIndex(
                name: "IX_t_sys_UserInfo_DepartMentId",
                table: "t_sys_UserInfo",
                column: "DepartMentId");

            migrationBuilder.CreateIndex(
                name: "IX_t_sys_UserRole_RoleId",
                table: "t_sys_UserRole",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "t_sys_Button");

            migrationBuilder.DropTable(
                name: "t_sys_Column");

            migrationBuilder.DropTable(
                name: "t_sys_MenuInfo");

            migrationBuilder.DropTable(
                name: "t_sys_RolePower");

            migrationBuilder.DropTable(
                name: "t_sys_UserRole");

            migrationBuilder.DropTable(
                name: "t_sys_SubSystem");

            migrationBuilder.DropTable(
                name: "t_sys_Table");

            migrationBuilder.DropTable(
                name: "t_sys_RoleInfo");

            migrationBuilder.DropTable(
                name: "t_sys_UserInfo");

            migrationBuilder.DropTable(
                name: "t_sys_DepartMent");
        }
    }
}
