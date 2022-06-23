using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MobileStore.Migrations
{
    public partial class AboutPhone : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AboutPhones_Phone_PhoneID",
                table: "AboutPhones");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AboutPhones",
                table: "AboutPhones");

            migrationBuilder.RenameTable(
                name: "AboutPhones",
                newName: "AboutPhone");

            migrationBuilder.RenameIndex(
                name: "IX_AboutPhones_PhoneID",
                table: "AboutPhone",
                newName: "IX_AboutPhone_PhoneID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AboutPhone",
                table: "AboutPhone",
                column: "AboutPhoneID");

            migrationBuilder.AddForeignKey(
                name: "FK_AboutPhone_Phone_PhoneID",
                table: "AboutPhone",
                column: "PhoneID",
                principalTable: "Phone",
                principalColumn: "PhoneID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AboutPhone_Phone_PhoneID",
                table: "AboutPhone");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AboutPhone",
                table: "AboutPhone");

            migrationBuilder.RenameTable(
                name: "AboutPhone",
                newName: "AboutPhones");

            migrationBuilder.RenameIndex(
                name: "IX_AboutPhone_PhoneID",
                table: "AboutPhones",
                newName: "IX_AboutPhones_PhoneID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AboutPhones",
                table: "AboutPhones",
                column: "AboutPhoneID");

            migrationBuilder.AddForeignKey(
                name: "FK_AboutPhones_Phone_PhoneID",
                table: "AboutPhones",
                column: "PhoneID",
                principalTable: "Phone",
                principalColumn: "PhoneID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
