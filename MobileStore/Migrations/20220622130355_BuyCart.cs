using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MobileStore.Migrations
{
    public partial class BuyCart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BuyCart",
                columns: table => new
                {
                    PhoneID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientID = table.Column<int>(type: "int", nullable: false),
                    Firm = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuyCart", x => x.PhoneID);
                    table.ForeignKey(
                        name: "FK_BuyCart_Client_ClientID",
                        column: x => x.ClientID,
                        principalTable: "Client",
                        principalColumn: "ClientID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BuyCartPhone",
                columns: table => new
                {
                    BuyCartsPhoneID = table.Column<int>(type: "int", nullable: false),
                    PhonesPhoneID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuyCartPhone", x => new { x.BuyCartsPhoneID, x.PhonesPhoneID });
                    table.ForeignKey(
                        name: "FK_BuyCartPhone_BuyCart_BuyCartsPhoneID",
                        column: x => x.BuyCartsPhoneID,
                        principalTable: "BuyCart",
                        principalColumn: "PhoneID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BuyCartPhone_Phone_PhonesPhoneID",
                        column: x => x.PhonesPhoneID,
                        principalTable: "Phone",
                        principalColumn: "PhoneID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BuyCart_ClientID",
                table: "BuyCart",
                column: "ClientID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BuyCartPhone_PhonesPhoneID",
                table: "BuyCartPhone",
                column: "PhonesPhoneID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BuyCartPhone");

            migrationBuilder.DropTable(
                name: "BuyCart");
        }
    }
}
