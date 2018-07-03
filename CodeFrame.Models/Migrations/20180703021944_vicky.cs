using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CodeFrame.Models.Migrations
{
    public partial class vicky : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AutoHistory",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RowId = table.Column<string>(maxLength: 50, nullable: false),
                    TableName = table.Column<string>(maxLength: 128, nullable: false),
                    Changed = table.Column<string>(nullable: true),
                    Kind = table.Column<int>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AutoHistory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "t_sys_DepartMent",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RowVersion = table.Column<DateTime>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    UpdateTime = table.Column<DateTime>(nullable: true),
                    CreateUser = table.Column<string>(nullable: true),
                    UpdateUser = table.Column<string>(nullable: true),
                    CreateUserId = table.Column<int>(nullable: true),
                    UpdateUserId = table.Column<int>(nullable: true),
                    DptName = table.Column<string>(maxLength: 20, nullable: true),
                    ParentId = table.Column<int>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    OrderBy = table.Column<int>(nullable: false),
                    ReMark = table.Column<string>(nullable: true)
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
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RowVersion = table.Column<DateTime>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    UpdateTime = table.Column<DateTime>(nullable: true),
                    CreateUser = table.Column<string>(nullable: true),
                    UpdateUser = table.Column<string>(nullable: true),
                    CreateUserId = table.Column<int>(nullable: true),
                    UpdateUserId = table.Column<int>(nullable: true),
                    RoleName = table.Column<string>(maxLength: 20, nullable: false),
                    Describe = table.Column<string>(maxLength: 20, nullable: false),
                    IsActive = table.Column<bool>(nullable: false)
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
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RowVersion = table.Column<DateTime>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    UpdateTime = table.Column<DateTime>(nullable: true),
                    CreateUser = table.Column<string>(nullable: true),
                    UpdateUser = table.Column<string>(nullable: true),
                    CreateUserId = table.Column<int>(nullable: true),
                    UpdateUserId = table.Column<int>(nullable: true),
                    ButtonId = table.Column<int>(nullable: false),
                    RoleId = table.Column<int>(nullable: false),
                    MentId = table.Column<int>(nullable: false),
                    Type = table.Column<int>(nullable: false)
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
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RowVersion = table.Column<DateTime>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    UpdateTime = table.Column<DateTime>(nullable: true),
                    CreateUser = table.Column<string>(nullable: true),
                    UpdateUser = table.Column<string>(nullable: true),
                    CreateUserId = table.Column<int>(nullable: true),
                    UpdateUserId = table.Column<int>(nullable: true),
                    SystemName = table.Column<string>(nullable: true),
                    OrderBy = table.Column<int>(nullable: false),
                    Link = table.Column<string>(nullable: true),
                    SystemIcon = table.Column<string>(nullable: true),
                    ReMark = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
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
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RowVersion = table.Column<DateTime>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    UpdateTime = table.Column<DateTime>(nullable: true),
                    CreateUser = table.Column<string>(nullable: true),
                    UpdateUser = table.Column<string>(nullable: true),
                    CreateUserId = table.Column<int>(nullable: true),
                    UpdateUserId = table.Column<int>(nullable: true),
                    TableName = table.Column<string>(nullable: true),
                    ShowName = table.Column<string>(nullable: true),
                    IsMultiple = table.Column<bool>(nullable: false),
                    ReMark = table.Column<string>(nullable: true),
                    OrderBy = table.Column<int>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    IsPaging = table.Column<bool>(nullable: false)
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
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RowVersion = table.Column<DateTime>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    UpdateTime = table.Column<DateTime>(nullable: true),
                    CreateUser = table.Column<string>(nullable: true),
                    UpdateUser = table.Column<string>(nullable: true),
                    CreateUserId = table.Column<int>(nullable: true),
                    UpdateUserId = table.Column<int>(nullable: true),
                    UserName = table.Column<string>(maxLength: 20, nullable: false),
                    TrueName = table.Column<string>(maxLength: 20, nullable: false),
                    Password = table.Column<string>(maxLength: 30, nullable: false),
                    PhoneNo = table.Column<string>(maxLength: 11, nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    DepartMentId = table.Column<int>(nullable: true),
                    Gender = table.Column<int>(nullable: true),
                    GroupNum = table.Column<string>(maxLength: 100, nullable: true),
                    Skill = table.Column<string>(maxLength: 100, nullable: true),
                    Describe = table.Column<string>(maxLength: 500, nullable: true),
                    Picture = table.Column<string>(maxLength: 300, nullable: true),
                    Post = table.Column<string>(maxLength: 300, nullable: true),
                    Group = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_sys_UserInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_t_sys_UserInfo_t_sys_DepartMent_DepartMentId",
                        column: x => x.DepartMentId,
                        principalTable: "t_sys_DepartMent",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "t_sys_Column",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RowVersion = table.Column<DateTime>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    UpdateTime = table.Column<DateTime>(nullable: true),
                    CreateUser = table.Column<string>(nullable: true),
                    UpdateUser = table.Column<string>(nullable: true),
                    CreateUserId = table.Column<int>(nullable: true),
                    UpdateUserId = table.Column<int>(nullable: true),
                    TableId = table.Column<int>(nullable: true),
                    ShowName = table.Column<string>(maxLength: 20, nullable: true),
                    ColumnName = table.Column<string>(maxLength: 30, nullable: true),
                    OrderBy = table.Column<int>(nullable: false),
                    ReMark = table.Column<string>(nullable: true),
                    Tip = table.Column<string>(maxLength: 100, nullable: true),
                    IsShow = table.Column<bool>(nullable: false),
                    ColumnType = table.Column<int>(nullable: true),
                    DisplayType = table.Column<int>(nullable: true),
                    FkTableId = table.Column<int>(nullable: true),
                    Width = table.Column<int>(nullable: true),
                    IsIndexed = table.Column<bool>(nullable: false),
                    DataOptions = table.Column<string>(maxLength: 300, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_sys_Column", x => x.Id);
                    table.ForeignKey(
                        name: "FK_t_sys_Column_t_sys_Table_TableId",
                        column: x => x.TableId,
                        principalTable: "t_sys_Table",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "t_sys_MenuInfo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RowVersion = table.Column<DateTime>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    UpdateTime = table.Column<DateTime>(nullable: true),
                    CreateUser = table.Column<string>(nullable: true),
                    UpdateUser = table.Column<string>(nullable: true),
                    CreateUserId = table.Column<int>(nullable: true),
                    UpdateUserId = table.Column<int>(nullable: true),
                    MenuName = table.Column<string>(maxLength: 20, nullable: true),
                    ParentMenuId = table.Column<int>(nullable: true),
                    MenuIcon = table.Column<string>(nullable: true),
                    SubSystemId = table.Column<int>(nullable: true),
                    SysTableId = table.Column<int>(nullable: true),
                    TableId = table.Column<int>(nullable: true),
                    MenuUrl = table.Column<string>(maxLength: 500, nullable: true),
                    OrderBy = table.Column<int>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_sys_MenuInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_t_sys_MenuInfo_t_sys_SubSystem_SubSystemId",
                        column: x => x.SubSystemId,
                        principalTable: "t_sys_SubSystem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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

            migrationBuilder.CreateTable(
                name: "t_sys_Button",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RowVersion = table.Column<DateTime>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    UpdateTime = table.Column<DateTime>(nullable: true),
                    CreateUser = table.Column<string>(nullable: true),
                    UpdateUser = table.Column<string>(nullable: true),
                    CreateUserId = table.Column<int>(nullable: true),
                    UpdateUserId = table.Column<int>(nullable: true),
                    BtnName = table.Column<string>(maxLength: 20, nullable: true),
                    MenuId = table.Column<int>(nullable: false),
                    BtnUrl = table.Column<string>(maxLength: 300, nullable: true),
                    EditType = table.Column<int>(nullable: false),
                    OrderBy = table.Column<int>(nullable: false),
                    BtnScript = table.Column<string>(maxLength: 50, nullable: true),
                    SpName = table.Column<string>(maxLength: 50, nullable: true),
                    BtnClass = table.Column<string>(maxLength: 50, nullable: true),
                    BtnIcon = table.Column<string>(maxLength: 50, nullable: true),
                    BtnTip = table.Column<string>(maxLength: 50, nullable: true),
                    DisplayCondition = table.Column<string>(maxLength: 500, nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    IsSpecial = table.Column<bool>(nullable: false),
                    BtnPosition = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_sys_Button", x => x.Id);
                    table.ForeignKey(
                        name: "FK_t_sys_Button_t_sys_MenuInfo_MenuId",
                        column: x => x.MenuId,
                        principalTable: "t_sys_MenuInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_t_sys_Button_MenuId",
                table: "t_sys_Button",
                column: "MenuId");

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
                name: "AutoHistory");

            migrationBuilder.DropTable(
                name: "t_sys_Button");

            migrationBuilder.DropTable(
                name: "t_sys_Column");

            migrationBuilder.DropTable(
                name: "t_sys_RolePower");

            migrationBuilder.DropTable(
                name: "t_sys_UserRole");

            migrationBuilder.DropTable(
                name: "t_sys_MenuInfo");

            migrationBuilder.DropTable(
                name: "t_sys_RoleInfo");

            migrationBuilder.DropTable(
                name: "t_sys_UserInfo");

            migrationBuilder.DropTable(
                name: "t_sys_SubSystem");

            migrationBuilder.DropTable(
                name: "t_sys_Table");

            migrationBuilder.DropTable(
                name: "t_sys_DepartMent");
        }
    }
}
