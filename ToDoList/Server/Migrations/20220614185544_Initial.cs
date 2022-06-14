using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDoList.Server.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserTasks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTasks", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "UserTasks",
                columns: new[] { "Id", "Text" },
                values: new object[] { 1, "I need to book a ticket for tomorrow's interview" });

            migrationBuilder.InsertData(
                table: "UserTasks",
                columns: new[] { "Id", "Text" },
                values: new object[] { 2, "My ticket to London next week needs to have an Open Return." });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserTasks");
        }
    }
}
