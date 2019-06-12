using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Commerce.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                "People",
                table => new
                {
                    PersonId = table.Column<string>(),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(),
                    TwoFactorEnabled = table.Column<bool>(),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(),
                    AccessFailedCount = table.Column<int>(),
                    FirstName = table.Column<string>(nullable: true),
                    SurName = table.Column<string>(nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_People", x => x.PersonId); });

            migrationBuilder.CreateTable(
                "Products",
                table => new
                {
                    Id = table.Column<int>()
                        .Annotation("SqlServer:ValueGenerationStrategy",
                            SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Price = table.Column<double>(),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_Products", x => x.Id); });

            migrationBuilder.CreateTable(
                "Roles",
                table => new
                {
                    RoleId = table.Column<string>(),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_Roles", x => x.RoleId); });

            migrationBuilder.CreateTable(
                "AspNetUserTokens",
                table => new
                {
                    UserId = table.Column<string>(),
                    LoginProvider = table.Column<string>(),
                    Name = table.Column<string>(),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new {x.UserId, x.LoginProvider, x.Name});
                    table.ForeignKey(
                        "FK_AspNetUserTokens_People_UserId",
                        x => x.UserId,
                        "People",
                        "PersonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "UserClaim",
                table => new
                {
                    UserClaimId = table.Column<int>()
                        .Annotation("SqlServer:ValueGenerationStrategy",
                            SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaim", x => x.UserClaimId);
                    table.ForeignKey(
                        "FK_UserClaim_People_UserId",
                        x => x.UserId,
                        "People",
                        "PersonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "UserLogin",
                table => new
                {
                    LoginProvider = table.Column<string>(),
                    ProviderKey = table.Column<string>(),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>()
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogin", x => new {x.LoginProvider, x.ProviderKey});
                    table.ForeignKey(
                        "FK_UserLogin_People_UserId",
                        x => x.UserId,
                        "People",
                        "PersonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "AspNetRoleClaims",
                table => new
                {
                    Id = table.Column<int>()
                        .Annotation("SqlServer:ValueGenerationStrategy",
                            SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>(),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        "FK_AspNetRoleClaims_Roles_RoleId",
                        x => x.RoleId,
                        "Roles",
                        "RoleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "UserRole",
                table => new
                {
                    UserId = table.Column<string>(),
                    RoleId = table.Column<string>()
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => new {x.UserId, x.RoleId});
                    table.ForeignKey(
                        "FK_UserRole_Roles_RoleId",
                        x => x.RoleId,
                        "Roles",
                        "RoleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        "FK_UserRole_People_UserId",
                        x => x.UserId,
                        "People",
                        "PersonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                "IX_AspNetRoleClaims_RoleId",
                "AspNetRoleClaims",
                "RoleId");

            migrationBuilder.CreateIndex(
                "EmailIndex",
                "People",
                "NormalizedEmail");

            migrationBuilder.CreateIndex(
                "UserNameIndex",
                "People",
                "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                "RoleNameIndex",
                "Roles",
                "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                "IX_UserClaim_UserId",
                "UserClaim",
                "UserId");

            migrationBuilder.CreateIndex(
                "IX_UserLogin_UserId",
                "UserLogin",
                "UserId");

            migrationBuilder.CreateIndex(
                "IX_UserRole_RoleId",
                "UserRole",
                "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                "AspNetRoleClaims");

            migrationBuilder.DropTable(
                "AspNetUserTokens");

            migrationBuilder.DropTable(
                "Products");

            migrationBuilder.DropTable(
                "UserClaim");

            migrationBuilder.DropTable(
                "UserLogin");

            migrationBuilder.DropTable(
                "UserRole");

            migrationBuilder.DropTable(
                "Roles");

            migrationBuilder.DropTable(
                "People");
        }
    }
}