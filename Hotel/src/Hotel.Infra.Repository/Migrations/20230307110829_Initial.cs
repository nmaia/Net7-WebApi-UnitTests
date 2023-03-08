using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Hotel.Infra.Repository.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "varchar(100)", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "date", nullable: false),
                    Email = table.Column<string>(type: "varchar(100)", nullable: false),
                    SIN = table.Column<int>(type: "integer", maxLength: 9, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerID);
                });

            migrationBuilder.CreateTable(
                name: "Hotels",
                columns: table => new
                {
                    HotelID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "varchar(50)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotels", x => x.HotelID);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    RoomID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Number = table.Column<int>(type: "integer", nullable: false),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false),
                    DailyRate = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    NextBookingAvailableDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HotelID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.RoomID);
                    table.ForeignKey(
                        name: "FK_Rooms_Hotels_HotelID",
                        column: x => x.HotelID,
                        principalTable: "Hotels",
                        principalColumn: "HotelID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    BookingID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CheckinDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CheckoutDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalCost = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CustomerID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoomID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HotelID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.BookingID);
                    table.ForeignKey(
                        name: "FK_Bookings_Customers_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "Customers",
                        principalColumn: "CustomerID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bookings_Hotels_HotelID",
                        column: x => x.HotelID,
                        principalTable: "Hotels",
                        principalColumn: "HotelID");
                    table.ForeignKey(
                        name: "FK_Bookings_Rooms_RoomID",
                        column: x => x.RoomID,
                        principalTable: "Rooms",
                        principalColumn: "RoomID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerID", "BirthDate", "CreatedDate", "Email", "LastUpdate", "Name", "SIN" },
                values: new object[,]
                {
                    { new Guid("82420972-db0f-4d3a-9ff2-b63654b8df82"), new DateTime(1963, 8, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 3, 7, 8, 8, 29, 577, DateTimeKind.Local).AddTicks(5037), "james@mail.com", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "James Hetfield", 333456444 },
                    { new Guid("898a0311-5b33-438f-a8e2-1060fa4f3922"), new DateTime(1942, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 3, 7, 8, 8, 29, 577, DateTimeKind.Local).AddTicks(5033), "dio@mail.com", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ronnie James Dio", 222456333 },
                    { new Guid("920ca78e-42de-4486-b168-e853a2c2f4f6"), new DateTime(1971, 2, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 3, 7, 8, 8, 29, 577, DateTimeKind.Local).AddTicks(5028), "randy@mail.com", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Randy Blythe", 111456222 },
                    { new Guid("bab9f53b-1162-48e3-8ca5-3665cdf7ed13"), new DateTime(1967, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 3, 7, 8, 8, 29, 577, DateTimeKind.Local).AddTicks(5016), "zakk@mail.com", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Zakk Wylde", 123456789 },
                    { new Guid("da31a0a5-c5aa-46a7-a057-92ed407a91ca"), new DateTime(1948, 12, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 3, 7, 8, 8, 29, 577, DateTimeKind.Local).AddTicks(5024), "ozzy@mail.com", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ozzy Osbourne", 987654321 }
                });

            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "HotelID", "CreatedDate", "LastUpdate", "Name" },
                values: new object[] { new Guid("42a5e8f5-5745-4231-8cd3-47a0e4c0f098"), new DateTime(2023, 3, 7, 8, 8, 29, 577, DateTimeKind.Local).AddTicks(4689), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hotel A" });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "RoomID", "CreatedDate", "DailyRate", "HotelID", "IsAvailable", "LastUpdate", "NextBookingAvailableDate", "Number" },
                values: new object[,]
                {
                    { new Guid("0f66e4ab-6e5d-4596-910d-ae5a1d3ffb44"), new DateTime(2023, 3, 7, 8, 8, 29, 577, DateTimeKind.Local).AddTicks(5107), 100m, new Guid("42a5e8f5-5745-4231-8cd3-47a0e4c0f098"), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 3, 10, 8, 8, 29, 577, DateTimeKind.Local).AddTicks(5108), 3 },
                    { new Guid("8cc47e03-8bc0-405f-80d3-a1736f69904e"), new DateTime(2023, 3, 7, 8, 8, 29, 577, DateTimeKind.Local).AddTicks(5113), 100m, new Guid("42a5e8f5-5745-4231-8cd3-47a0e4c0f098"), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5 },
                    { new Guid("9dce4c50-bd22-466b-a027-113b78fc2efc"), new DateTime(2023, 3, 7, 8, 8, 29, 577, DateTimeKind.Local).AddTicks(5101), 100m, new Guid("42a5e8f5-5745-4231-8cd3-47a0e4c0f098"), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 3, 10, 8, 8, 29, 577, DateTimeKind.Local).AddTicks(5102), 1 },
                    { new Guid("a384278b-e072-42cd-9ef9-0dc6195f3d85"), new DateTime(2023, 3, 7, 8, 8, 29, 577, DateTimeKind.Local).AddTicks(5104), 100m, new Guid("42a5e8f5-5745-4231-8cd3-47a0e4c0f098"), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 3, 10, 8, 8, 29, 577, DateTimeKind.Local).AddTicks(5105), 2 },
                    { new Guid("a53634f9-9fa1-4589-b6c5-dd5231554137"), new DateTime(2023, 3, 7, 8, 8, 29, 577, DateTimeKind.Local).AddTicks(5110), 100m, new Guid("42a5e8f5-5745-4231-8cd3-47a0e4c0f098"), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 3, 10, 8, 8, 29, 577, DateTimeKind.Local).AddTicks(5111), 4 }
                });

            migrationBuilder.InsertData(
                table: "Bookings",
                columns: new[] { "BookingID", "CheckinDate", "CheckoutDate", "CreatedDate", "CustomerID", "HotelID", "LastUpdate", "RoomID", "TotalCost" },
                values: new object[,]
                {
                    { new Guid("34957021-afa0-4d54-9839-5421cd0090a9"), new DateTime(2023, 3, 8, 8, 8, 29, 577, DateTimeKind.Local).AddTicks(5077), new DateTime(2023, 3, 9, 8, 8, 29, 577, DateTimeKind.Local).AddTicks(5078), new DateTime(2023, 3, 7, 8, 8, 29, 577, DateTimeKind.Local).AddTicks(5078), new Guid("920ca78e-42de-4486-b168-e853a2c2f4f6"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("0f66e4ab-6e5d-4596-910d-ae5a1d3ffb44"), 100m },
                    { new Guid("5609965f-1836-4bcb-a578-72eaf39ce08c"), new DateTime(2023, 3, 8, 8, 8, 29, 577, DateTimeKind.Local).AddTicks(5058), new DateTime(2023, 3, 9, 8, 8, 29, 577, DateTimeKind.Local).AddTicks(5064), new DateTime(2023, 3, 7, 8, 8, 29, 577, DateTimeKind.Local).AddTicks(5065), new Guid("bab9f53b-1162-48e3-8ca5-3665cdf7ed13"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("9dce4c50-bd22-466b-a027-113b78fc2efc"), 100m },
                    { new Guid("81447f3f-e4a9-48eb-90e5-fc7fc31ee9a6"), new DateTime(2023, 3, 8, 8, 8, 29, 577, DateTimeKind.Local).AddTicks(5071), new DateTime(2023, 3, 9, 8, 8, 29, 577, DateTimeKind.Local).AddTicks(5071), new DateTime(2023, 3, 7, 8, 8, 29, 577, DateTimeKind.Local).AddTicks(5072), new Guid("da31a0a5-c5aa-46a7-a057-92ed407a91ca"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("a384278b-e072-42cd-9ef9-0dc6195f3d85"), 100m },
                    { new Guid("911c220d-59c8-4fba-bb7d-50ed1ba184a9"), new DateTime(2023, 3, 8, 8, 8, 29, 577, DateTimeKind.Local).AddTicks(5080), new DateTime(2023, 3, 9, 8, 8, 29, 577, DateTimeKind.Local).AddTicks(5081), new DateTime(2023, 3, 7, 8, 8, 29, 577, DateTimeKind.Local).AddTicks(5081), new Guid("898a0311-5b33-438f-a8e2-1060fa4f3922"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("a53634f9-9fa1-4589-b6c5-dd5231554137"), 100m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_CustomerID",
                table: "Bookings",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_HotelID",
                table: "Bookings",
                column: "HotelID");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_RoomID",
                table: "Bookings",
                column: "RoomID");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_HotelID",
                table: "Rooms",
                column: "HotelID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "Hotels");
        }
    }
}
