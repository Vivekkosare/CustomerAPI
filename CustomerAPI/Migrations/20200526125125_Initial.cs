using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CustomerAPI.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    CountryId = table.Column<Guid>(nullable: false),
                    CountryCode = table.Column<string>(nullable: true),
                    CountryName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.CountryId);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<Guid>(nullable: false),
                    PersonalNumber = table.Column<string>(maxLength: 12, nullable: false),
                    Email = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    AddressId = table.Column<Guid>(nullable: false),
                    ZipCode = table.Column<int>(maxLength: 5, nullable: false),
                    CountryId = table.Column<Guid>(nullable: false),
                    CustomerId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.AddressId);
                    table.ForeignKey(
                        name: "FK_Addresses_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "CountryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Addresses_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PhoneNumbers",
                columns: table => new
                {
                    PhoneId = table.Column<Guid>(nullable: false),
                    CountryId = table.Column<Guid>(nullable: false),
                    Phone = table.Column<string>(maxLength: 15, nullable: false),
                    CustomerId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhoneNumbers", x => x.PhoneId);
                    table.ForeignKey(
                        name: "FK_PhoneNumbers_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "CountryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PhoneNumbers_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "CountryId", "CountryCode", "CountryName" },
                values: new object[,]
                {
                    { new Guid("991e0c2f-a768-40b9-9eaa-b7c31eb3fcc4"), "+46", "Sweden" },
                    { new Guid("ba2dc307-32bf-4d24-8cd2-45f070975889"), "+45", "Denmark" },
                    { new Guid("0f72123d-6095-490e-a051-6bb7fbcbc010"), "+47", "Norway" },
                    { new Guid("01d942ed-522e-4e5f-908b-cae029c820d7"), "+358", "Finland" }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "Email", "PersonalNumber" },
                values: new object[,]
                {
                    { new Guid("e2c46906-2ea4-4672-a81f-bd69890c9b16"), "user1@domain.com", "199205251045" },
                    { new Guid("21d937d1-f020-4e4f-9f26-add9801b6e75"), "user2@domain.com", "199307121428" },
                    { new Guid("5cee819a-f78d-49a9-866e-b69aba44c4f4"), "user3@domain.com", "198904208493" },
                    { new Guid("fbf6dc01-93f9-4772-891f-46e5a79d6e2a"), "user4@domain.com", "198602182748" }
                });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "AddressId", "CountryId", "CustomerId", "ZipCode" },
                values: new object[,]
                {
                    { new Guid("78cebe6c-6dac-403e-82bd-43f3142ea805"), new Guid("991e0c2f-a768-40b9-9eaa-b7c31eb3fcc4"), new Guid("e2c46906-2ea4-4672-a81f-bd69890c9b16"), 15132 },
                    { new Guid("a02b03b7-36cb-4839-911c-f782bb3009e9"), new Guid("ba2dc307-32bf-4d24-8cd2-45f070975889"), new Guid("21d937d1-f020-4e4f-9f26-add9801b6e75"), 4268 },
                    { new Guid("5c3ac12f-ec83-449e-a37e-de7442cde7da"), new Guid("0f72123d-6095-490e-a051-6bb7fbcbc010"), new Guid("5cee819a-f78d-49a9-866e-b69aba44c4f4"), 30415 },
                    { new Guid("b84178a0-b0ff-4721-96cc-5d271d93f6b9"), new Guid("01d942ed-522e-4e5f-908b-cae029c820d7"), new Guid("fbf6dc01-93f9-4772-891f-46e5a79d6e2a"), 55603 }
                });

            migrationBuilder.InsertData(
                table: "PhoneNumbers",
                columns: new[] { "PhoneId", "CountryId", "CustomerId", "Phone" },
                values: new object[,]
                {
                    { new Guid("540c9172-2391-4990-8503-985083ae34e8"), new Guid("991e0c2f-a768-40b9-9eaa-b7c31eb3fcc4"), new Guid("e2c46906-2ea4-4672-a81f-bd69890c9b16"), "7455535" },
                    { new Guid("bdbcc5c5-1b8f-45b1-be22-6f6bad98308e"), new Guid("ba2dc307-32bf-4d24-8cd2-45f070975889"), new Guid("21d937d1-f020-4e4f-9f26-add9801b6e75"), "60555269" },
                    { new Guid("1c8f1f5d-9d68-4019-98e3-87a9c5b9a55b"), new Guid("0f72123d-6095-490e-a051-6bb7fbcbc010"), new Guid("5cee819a-f78d-49a9-866e-b69aba44c4f4"), "95552843" },
                    { new Guid("173c9951-a374-4ba4-b5fe-29a894e48279"), new Guid("01d942ed-522e-4e5f-908b-cae029c820d7"), new Guid("fbf6dc01-93f9-4772-891f-46e5a79d6e2a"), "5005557352" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_CountryId",
                table: "Addresses",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_CustomerId",
                table: "Addresses",
                column: "CustomerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PhoneNumbers_CountryId",
                table: "PhoneNumbers",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_PhoneNumbers_CustomerId",
                table: "PhoneNumbers",
                column: "CustomerId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "PhoneNumbers");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
