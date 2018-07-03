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
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
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
                name: "t_sysDepartMent",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
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
                    table.PrimaryKey("PK_t_sysDepartMent", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "t_sysRoleInfo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
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
                    table.PrimaryKey("PK_t_sysRoleInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "t_sysRolePower",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
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
                    table.PrimaryKey("PK_t_sysRolePower", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "t_sysSubSystem",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
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
                    table.PrimaryKey("PK_t_sysSubSystem", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "t_sysTable",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
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
                    table.PrimaryKey("PK_t_sysTable", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "t_sysUserInfo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
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
                    table.PrimaryKey("PK_t_sysUserInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_t_sysUserInfo_t_sysDepartMent_DepartMentId",
                        column: x => x.DepartMentId,
                        principalTable: "t_sysDepartMent",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "t_sysColumn",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
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
                    table.PrimaryKey("PK_t_sysColumn", x => x.Id);
                    table.ForeignKey(
                        name: "FK_t_sysColumn_t_sysTable_TableId",
                        column: x => x.TableId,
                        principalTable: "t_sysTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "t_sysMenuInfo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
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
                    table.PrimaryKey("PK_t_sysMenuInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_t_sysMenuInfo_t_sysSubSystem_SubSystemId",
                        column: x => x.SubSystemId,
                        principalTable: "t_sysSubSystem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_t_sysMenuInfo_t_sysTable_TableId",
                        column: x => x.TableId,
                        principalTable: "t_sysTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "t_sysUserRole",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    RoleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_sysUserRole", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_t_sysUserRole_t_sysRoleInfo_RoleId",
                        column: x => x.RoleId,
                        principalTable: "t_sysRoleInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_t_sysUserRole_t_sysUserInfo_UserId",
                        column: x => x.UserId,
                        principalTable: "t_sysUserInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "t_sysButton",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
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
                    table.PrimaryKey("PK_t_sysButton", x => x.Id);
                    table.ForeignKey(
                        name: "FK_t_sysButton_t_sysMenuInfo_MenuId",
                        column: x => x.MenuId,
                        principalTable: "t_sysMenuInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_t_sysButton_MenuId",
                table: "t_sysButton",
                column: "MenuId");

            migrationBuilder.CreateIndex(
                name: "IX_t_sysColumn_TableId",
                table: "t_sysColumn",
                column: "TableId");

            migrationBuilder.CreateIndex(
                name: "IX_t_sysMenuInfo_SubSystemId",
                table: "t_sysMenuInfo",
                column: "SubSystemId");

            migrationBuilder.CreateIndex(
                name: "IX_t_sysMenuInfo_TableId",
                table: "t_sysMenuInfo",
                column: "TableId");

            migrationBuilder.CreateIndex(
                name: "IX_t_sysUserInfo_DepartMentId",
                table: "t_sysUserInfo",
                column: "DepartMentId");

            migrationBuilder.CreateIndex(
                name: "IX_t_sysUserRole_RoleId",
                table: "t_sysUserRole",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AutoHistory");

            migrationBuilder.DropTable(
                name: "t_sysButton");

            migrationBuilder.DropTable(
                name: "t_sysColumn");

            migrationBuilder.DropTable(
                name: "t_sysRolePower");

            migrationBuilder.DropTable(
                name: "t_sysUserRole");

            migrationBuilder.DropTable(
                name: "t_sysMenuInfo");

            migrationBuilder.DropTable(
                name: "t_sysRoleInfo");

            migrationBuilder.DropTable(
                name: "t_sysUserInfo");

            migrationBuilder.DropTable(
                name: "t_sysSubSystem");

            migrationBuilder.DropTable(
                name: "t_sysTable");

            migrationBuilder.DropTable(
                name: "t_sysDepartMent");
        }
    }
}
