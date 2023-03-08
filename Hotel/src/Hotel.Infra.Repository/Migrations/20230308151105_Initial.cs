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
                    { new Guid("0121e7c3-281d-4550-a5d3-52810055a759"), new DateTime(1971, 2, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 3, 8, 12, 11, 4, 923, DateTimeKind.Local).AddTicks(1613), "randy@mail.com", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Randy Blythe", 111456222 },
                    { new Guid("44f8215f-df3f-48f3-b53d-5dc88eb33622"), new DateTime(1942, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 3, 8, 12, 11, 4, 923, DateTimeKind.Local).AddTicks(1623), "dio@mail.com", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ronnie James Dio", 222456333 },
                    { new Guid("94063471-607a-4143-9148-1c526c35f4cc"), new DateTime(1967, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 3, 8, 12, 11, 4, 923, DateTimeKind.Local).AddTicks(1588), "zakk@mail.com", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Zakk Wylde", 123456789 },
                    { new Guid("b835f178-9fef-417a-a396-be36ccd6af9c"), new DateTime(1948, 12, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 3, 8, 12, 11, 4, 923, DateTimeKind.Local).AddTicks(1604), "ozzy@mail.com", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ozzy Osbourne", 987654321 },
                    { new Guid("ddeffc9e-7cea-4d9d-823b-e2bbbfa6dc97"), new DateTime(1963, 8, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 3, 8, 12, 11, 4, 923, DateTimeKind.Local).AddTicks(1633), "james@mail.com", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "James Hetfield", 333456444 }
                });

            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "HotelID", "CreatedDate", "LastUpdate", "Name" },
                values: new object[] { new Guid("60581ea7-a79e-4df4-abcb-a956f3316639"), new DateTime(2023, 3, 8, 12, 11, 4, 923, DateTimeKind.Local).AddTicks(1130), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hotel A" });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "RoomID", "CreatedDate", "DailyRate", "HotelID", "IsAvailable", "LastUpdate", "NextBookingAvailableDate", "Number" },
                values: new object[,]
                {
                    { new Guid("31342b41-1dee-491a-8dd6-6c03af271b9b"), new DateTime(2023, 3, 8, 12, 11, 4, 923, DateTimeKind.Local).AddTicks(1752), 100m, new Guid("60581ea7-a79e-4df4-abcb-a956f3316639"), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 3, 11, 12, 11, 4, 923, DateTimeKind.Local).AddTicks(1755), 1 },
                    { new Guid("780c62af-43c2-4a67-820c-1d6c38409249"), new DateTime(2023, 3, 8, 12, 11, 4, 923, DateTimeKind.Local).AddTicks(1776), 100m, new Guid("60581ea7-a79e-4df4-abcb-a956f3316639"), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5 },
                    { new Guid("b6172848-ad8f-4a60-8fbd-4b69a7226732"), new DateTime(2023, 3, 8, 12, 11, 4, 923, DateTimeKind.Local).AddTicks(1764), 100m, new Guid("60581ea7-a79e-4df4-abcb-a956f3316639"), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 3, 11, 12, 11, 4, 923, DateTimeKind.Local).AddTicks(1765), 3 },
                    { new Guid("c6643f13-4937-4014-9730-5e444efac094"), new DateTime(2023, 3, 8, 12, 11, 4, 923, DateTimeKind.Local).AddTicks(1760), 100m, new Guid("60581ea7-a79e-4df4-abcb-a956f3316639"), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 3, 11, 12, 11, 4, 923, DateTimeKind.Local).AddTicks(1761), 2 },
                    { new Guid("d5c82e94-c3af-4780-8d73-8b05ee00a683"), new DateTime(2023, 3, 8, 12, 11, 4, 923, DateTimeKind.Local).AddTicks(1768), 100m, new Guid("60581ea7-a79e-4df4-abcb-a956f3316639"), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 3, 11, 12, 11, 4, 923, DateTimeKind.Local).AddTicks(1769), 4 }
                });

            migrationBuilder.InsertData(
                table: "Bookings",
                columns: new[] { "BookingID", "CheckinDate", "CheckoutDate", "CreatedDate", "CustomerID", "HotelID", "LastUpdate", "RoomID", "TotalCost" },
                values: new object[,]
                {
                    { new Guid("b44e8583-3f36-41fc-9533-131f02632c9f"), new DateTime(2023, 3, 9, 12, 11, 4, 923, DateTimeKind.Local).AddTicks(1701), new DateTime(2023, 3, 10, 12, 11, 4, 923, DateTimeKind.Local).AddTicks(1702), new DateTime(2023, 3, 8, 12, 11, 4, 923, DateTimeKind.Local).AddTicks(1703), new Guid("b835f178-9fef-417a-a396-be36ccd6af9c"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("c6643f13-4937-4014-9730-5e444efac094"), 100m },
                    { new Guid("c88e50f5-98b7-47e7-8902-622062a3f3e8"), new DateTime(2023, 3, 9, 12, 11, 4, 923, DateTimeKind.Local).AddTicks(1709), new DateTime(2023, 3, 10, 12, 11, 4, 923, DateTimeKind.Local).AddTicks(1710), new DateTime(2023, 3, 8, 12, 11, 4, 923, DateTimeKind.Local).AddTicks(1711), new Guid("0121e7c3-281d-4550-a5d3-52810055a759"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("b6172848-ad8f-4a60-8fbd-4b69a7226732"), 100m },
                    { new Guid("e5152512-aacc-4f9e-9f6c-b93a943549ea"), new DateTime(2023, 3, 9, 12, 11, 4, 923, DateTimeKind.Local).AddTicks(1675), new DateTime(2023, 3, 10, 12, 11, 4, 923, DateTimeKind.Local).AddTicks(1684), new DateTime(2023, 3, 8, 12, 11, 4, 923, DateTimeKind.Local).AddTicks(1685), new Guid("94063471-607a-4143-9148-1c526c35f4cc"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("31342b41-1dee-491a-8dd6-6c03af271b9b"), 100m },
                    { new Guid("ffdbac65-422c-4543-ad30-68720e5a16ee"), new DateTime(2023, 3, 9, 12, 11, 4, 923, DateTimeKind.Local).AddTicks(1715), new DateTime(2023, 3, 10, 12, 11, 4, 923, DateTimeKind.Local).AddTicks(1715), new DateTime(2023, 3, 8, 12, 11, 4, 923, DateTimeKind.Local).AddTicks(1716), new Guid("44f8215f-df3f-48f3-b53d-5dc88eb33622"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d5c82e94-c3af-4780-8d73-8b05ee00a683"), 100m }
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
