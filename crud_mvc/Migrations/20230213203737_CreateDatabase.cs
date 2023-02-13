using Microsoft.EntityFrameworkCore.Migrations;

namespace crud_mvc.Migrations
{
    public partial class CreateDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Articles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Description = table.Column<string>(maxLength: 100, nullable: true),
                    Category = table.Column<string>(maxLength: 50, nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    IsEnabled = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "Category", "Description", "IsEnabled", "Name", "Quantity" },
                values: new object[] { 1, "Otro", "1.2m", true, "Escoba", 20 });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "Category", "Description", "IsEnabled", "Name", "Quantity" },
                values: new object[] { 2, "Otro", "4l", true, "Balde", 50 });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "Category", "Description", "IsEnabled", "Name", "Quantity" },
                values: new object[] { 3, "Otro", "Sony, usada", true, "Playstation 2", 5 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Articles");
        }
    }
}
