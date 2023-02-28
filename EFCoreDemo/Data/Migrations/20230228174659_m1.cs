using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCoreDemo.Data.Migrations
{
    public partial class m1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence<int>(
                name: "StudentId",
                startValue: 10L,
                incrementBy: 4);

            migrationBuilder.AddColumn<int>(
                name: "UserLevel",
                table: "Users",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Name", "Password", "UserLevel" },
                values: new object[] { 1, "", "FGFFG FFFG", "", 0 });

            migrationBuilder.CreateIndex(
                name: "User_Name_IDX",
                table: "Users",
                column: "Name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "User_Name_IDX",
                table: "Users");

            migrationBuilder.DropSequence(
                name: "StudentId");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "UserLevel",
                table: "Users");
        }
    }
}
