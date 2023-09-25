using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CarFleet.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    FullName = table.Column<string>(type: "text", nullable: true),
                    Address = table.Column<string>(type: "text", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VehicleCategories",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CompanyReviews",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Message = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyReviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompanyReviews_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    RoleId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRoles_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    CategoryId = table.Column<string>(type: "text", nullable: true),
                    Brand = table.Column<string>(type: "text", nullable: true),
                    Model = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Price = table.Column<int>(type: "integer", nullable: false),
                    Horsepower = table.Column<int>(type: "integer", nullable: false),
                    NumberOfSeats = table.Column<int>(type: "integer", nullable: false),
                    Mileage = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vehicles_VehicleCategories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "VehicleCategories",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    PickupDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    PickupPlace = table.Column<string>(type: "text", nullable: true),
                    DropoffDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DropoffPlace = table.Column<string>(type: "text", nullable: true),
                    IsClosed = table.Column<bool>(type: "boolean", nullable: false),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    VehicleId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VehicleReviews",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Message = table.Column<string>(type: "text", nullable: true),
                    Score = table.Column<int>(type: "integer", nullable: false),
                    VehicleId = table.Column<string>(type: "text", nullable: false),
                    UserId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleReviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VehicleReviews_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VehicleReviews_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "VehicleCategories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { "0", "Econom" },
                    { "1", "Comfort" },
                    { "2", "Premium" },
                    { "3", "Luxury" }
                });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "Brand", "CategoryId", "Description", "Horsepower", "Mileage", "Model", "NumberOfSeats", "Price" },
                values: new object[,]
                {
                    { "1b3d78f3-ea42-453b-b3db-9e72d2be25d4", "Kia", "2", "Kia Stinger — это бескомпромиссный автомобиль для водителя. Здесь все сделано специально для вас, от сидений со спортивной поддержкой до современных технологий. Вы сможете совершать самые продолжительные поездки, не чувствуя усталости.", 300, 80, "Stinger", 5, 30 },
                    { "25f2c2f8-305a-4e93-a390-32ce220f0a33", "Hyundai", "0", "Hyundai Solaris — субкомпактный автомобиль южнокорейской компании Hyundai Motors. Автомобиль представляет собой локализованную версию автомобиля Hyundai Accent, адаптированную для эксплуатации в российских условиях.", 100, 300, "Solaris", 5, 10 },
                    { "4766cca3-4560-472c-ba63-5ff7f93d60bd", "Tesla", "3", "Tesla Model X — полноразмерный электрический кроссовер производства компании Tesla.", 800, 50, "Model X", 5, 50 },
                    { "4d6085ca-385c-49c4-9ed9-fb4b75a947b2", "Mercedes-Benz", "3", "В отличие от иных серий транспортных средств торговой марки Mercedes-Benz, автомобили G-класса сохраняют свой уникальный внешний вид независимо от модификации, будь то заводская или высокопроизводительная", 430, 320, "G-Wagen", 5, 40 },
                    { "d2b2a8ea-7c15-4d5a-8ec2-3af1a1395a88", "Mercedes-Benz", "2", "Четырехдверный седан E63 AMG сочетает в себе великолепные ходовые качества и высочайщий комфорт.", 520, 180, "E63", 5, 35 },
                    { "da70aa0b-7134-401f-b44f-104ad1fa0f42", "Kia", "1", "Kia K5 (также известен как Kia Optima или Kia Magentis) — седан среднего класса южнокорейской автомобилестроительной компании Kia Motors, производство которого было начато в 2000-м году. ", 290, 230, "K5", 5, 15 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CompanyReviews_UserId",
                table: "CompanyReviews",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_VehicleId",
                table: "Orders",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "Role",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "User",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "User",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                table: "UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleReviews_UserId",
                table: "VehicleReviews",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleReviews_VehicleId",
                table: "VehicleReviews",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_CategoryId",
                table: "Vehicles",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompanyReviews");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "VehicleReviews");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Vehicles");

            migrationBuilder.DropTable(
                name: "VehicleCategories");
        }
    }
}
