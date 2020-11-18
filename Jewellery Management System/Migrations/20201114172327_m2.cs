using Microsoft.EntityFrameworkCore.Migrations;

namespace Jewellery_Management_System.Migrations
{
    public partial class m2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ProductName",
                table: "OwnerDebts",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreditorName",
                table: "OwnerDebts",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "TotalAmount",
                table: "Bills",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<float>(
                name: "CurrentGoldPrice",
                table: "Bills",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "TotalWeight",
                table: "Bills",
                nullable: false,
                defaultValue: 0f);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrentGoldPrice",
                table: "Bills");

            migrationBuilder.DropColumn(
                name: "TotalWeight",
                table: "Bills");

            migrationBuilder.AlterColumn<string>(
                name: "ProductName",
                table: "OwnerDebts",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "CreditorName",
                table: "OwnerDebts",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<int>(
                name: "TotalAmount",
                table: "Bills",
                type: "int",
                nullable: false,
                oldClrType: typeof(float));
        }
    }
}
