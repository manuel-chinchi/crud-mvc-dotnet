using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace crud_mvc_aspnet_core.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Articles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Description = table.Column<string>(maxLength: 50, nullable: true),
                    Quantity = table.Column<int>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateUpdated = table.Column<DateTime>(nullable: true),
                    CategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Articles_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "DateCreated", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 11, 4, 13, 59, 42, 820, DateTimeKind.Local).AddTicks(1746), "Indumentaria" },
                    { 2, new DateTime(2023, 11, 4, 13, 59, 42, 821, DateTimeKind.Local).AddTicks(7930), "Herramientas" },
                    { 3, new DateTime(2023, 11, 4, 13, 59, 42, 821, DateTimeKind.Local).AddTicks(7991), "Electrodomésticos" },
                    { 4, new DateTime(2023, 11, 4, 13, 59, 42, 821, DateTimeKind.Local).AddTicks(7994), "Ocio" },
                    { 5, new DateTime(2023, 11, 4, 13, 59, 42, 821, DateTimeKind.Local).AddTicks(7996), "Otro" }
                });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "CategoryId", "DateCreated", "DateUpdated", "Description", "Name", "Quantity" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2023, 11, 4, 16, 59, 42, 823, DateTimeKind.Utc).AddTicks(1481), null, "Adidas, poliester", "camisa deportiva", 90 },
                    { 19, 4, new DateTime(2023, 11, 4, 16, 59, 42, 823, DateTimeKind.Utc).AddTicks(3862), null, "original, a reparar/nuevas", "consola playstation 2", 120 },
                    { 18, 4, new DateTime(2023, 11, 4, 16, 59, 42, 823, DateTimeKind.Utc).AddTicks(3860), null, "modelo Genesis 3, a reparar/nuevas", "sega", 80 },
                    { 17, 4, new DateTime(2023, 11, 4, 16, 59, 42, 823, DateTimeKind.Utc).AddTicks(3859), null, "Microsoft, nuevas", "consola xbox", 200 },
                    { 16, 3, new DateTime(2023, 11, 4, 16, 59, 42, 823, DateTimeKind.Utc).AddTicks(3857), null, "Sanyo, año 2005", "lavavajillas", 20 },
                    { 15, 3, new DateTime(2023, 11, 4, 16, 59, 42, 823, DateTimeKind.Utc).AddTicks(3855), null, "LG, reacondicionadas/nuevas", "heladera", 100 },
                    { 14, 3, new DateTime(2023, 11, 4, 16, 59, 42, 823, DateTimeKind.Utc).AddTicks(3853), null, "LG, año 2012", "heladera", 30 },
                    { 13, 3, new DateTime(2023, 11, 4, 16, 59, 42, 823, DateTimeKind.Utc).AddTicks(3852), null, "General Electric", "cocina", 50 },
                    { 12, 3, new DateTime(2023, 11, 4, 16, 59, 42, 823, DateTimeKind.Utc).AddTicks(3850), null, "Electroluz", "lavarropas", 40 },
                    { 20, 4, new DateTime(2023, 11, 4, 16, 59, 42, 823, DateTimeKind.Utc).AddTicks(3864), null, "generico", "lapiz 3D impresora", 100 },
                    { 11, 3, new DateTime(2023, 11, 4, 16, 59, 42, 823, DateTimeKind.Utc).AddTicks(3848), null, "Gaffa", "heladera", 60 },
                    { 9, 2, new DateTime(2023, 11, 4, 16, 59, 42, 823, DateTimeKind.Utc).AddTicks(3845), null, "Stanley, año 2015", "amoladora", 30 },
                    { 8, 2, new DateTime(2023, 11, 4, 16, 59, 42, 823, DateTimeKind.Utc).AddTicks(3843), null, "Makita, año 2010", "desmalezadora", 120 },
                    { 7, 2, new DateTime(2023, 11, 4, 16, 59, 42, 823, DateTimeKind.Utc).AddTicks(3842), null, "Bosch", "martillo neumatico", 120 },
                    { 6, 1, new DateTime(2023, 11, 4, 16, 59, 42, 823, DateTimeKind.Utc).AddTicks(3840), null, "Gucci", "jean", 180 },
                    { 5, 1, new DateTime(2023, 11, 4, 16, 59, 42, 823, DateTimeKind.Utc).AddTicks(3838), null, "Nike", "jean", 150 },
                    { 4, 1, new DateTime(2023, 11, 4, 16, 59, 42, 823, DateTimeKind.Utc).AddTicks(3836), null, "Kevingston", "calzones boxer", 50 },
                    { 3, 1, new DateTime(2023, 11, 4, 16, 59, 42, 823, DateTimeKind.Utc).AddTicks(3834), null, "Calvin Klein", "calzones boxer", 100 },
                    { 2, 1, new DateTime(2023, 11, 4, 16, 59, 42, 823, DateTimeKind.Utc).AddTicks(3749), null, "Adidas, poliester 95%", "pantalon deportivo", 120 },
                    { 10, 2, new DateTime(2023, 11, 4, 16, 59, 42, 823, DateTimeKind.Utc).AddTicks(3847), null, "Hyundai", "desmalezadora", 60 },
                    { 21, 4, new DateTime(2023, 11, 4, 16, 59, 42, 823, DateTimeKind.Utc).AddTicks(3867), null, "Hasbro, año 2000", "monopoli", 30 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Articles_CategoryId",
                table: "Articles",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Articles");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
