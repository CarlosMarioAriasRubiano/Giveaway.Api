using Microsoft.EntityFrameworkCore.Migrations;

namespace Giveaway.Infrastructure.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Identification = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Identification = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Award",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Award", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Award_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomerUser",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerUser", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerUser_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerUser_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AwardRange",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AwardId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InitialRange = table.Column<int>(type: "int", nullable: false),
                    EndRange = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AwardRange", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AwardRange_Award_AwardId",
                        column: x => x.AwardId,
                        principalTable: "Award",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AwardRangeDetail",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AwardRangeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AssignedNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AwardRangeDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AwardRangeDetail_AwardRange_AwardRangeId",
                        column: x => x.AwardRangeId,
                        principalTable: "AwardRange",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AwardRangeDetail_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Customer",
                columns: new[] { "Id", "Address", "Identification", "Name" },
                values: new object[,]
                {
                    { new Guid("4c6cdaae-4e12-4f18-afb1-58ed33513284"), "Carrera 15", "654321", "Sistema ERP" },
                    { new Guid("513038a6-4719-46fd-b762-dfa4436c82e5"), "Calle 46", "123456", "Sistema POS" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Email", "Identification", "Name" },
                values: new object[,]
                {
                    { new Guid("2c5868b7-ea20-471d-9659-f562d6cde3ff"), "", "33333", "Carlos Mario Arias" },
                    { new Guid("5ae5a174-98cc-4ed5-9dca-39c8b8d2bc3c"), "", "55555", "Lina María González" }
                });

            migrationBuilder.InsertData(
                table: "CustomerUser",
                columns: new[] { "Id", "CustomerId", "UserId" },
                values: new object[,]
                {
                    { new Guid("2310e7f3-960e-47f3-8316-c60e3c78f785"), new Guid("4c6cdaae-4e12-4f18-afb1-58ed33513284"), new Guid("2c5868b7-ea20-471d-9659-f562d6cde3ff") },
                    { new Guid("3a5b99ab-0489-4324-989e-a193e79a0c00"), new Guid("4c6cdaae-4e12-4f18-afb1-58ed33513284"), new Guid("5ae5a174-98cc-4ed5-9dca-39c8b8d2bc3c") },
                    { new Guid("c791ff70-76bc-4bee-b331-2900580d765d"), new Guid("513038a6-4719-46fd-b762-dfa4436c82e5"), new Guid("2c5868b7-ea20-471d-9659-f562d6cde3ff") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Award_CustomerId",
                table: "Award",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_AwardRange_AwardId",
                table: "AwardRange",
                column: "AwardId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AwardRangeDetail_AwardRangeId",
                table: "AwardRangeDetail",
                column: "AwardRangeId");

            migrationBuilder.CreateIndex(
                name: "IX_AwardRangeDetail_UserId",
                table: "AwardRangeDetail",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerUser_CustomerId",
                table: "CustomerUser",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerUser_UserId",
                table: "CustomerUser",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AwardRangeDetail");

            migrationBuilder.DropTable(
                name: "CustomerUser");

            migrationBuilder.DropTable(
                name: "AwardRange");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Award");

            migrationBuilder.DropTable(
                name: "Customer");
        }
    }
}
