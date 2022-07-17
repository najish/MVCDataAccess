using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVCDataAccess.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Address", "Name" },
                values: new object[,]
                {
                    { 1, "Rafiganj", "Zafer Eqbal" },
                    { 2, "NewArea", "Taukir Alam" },
                    { 3, "Basariya", "Arbaaz Khan" },
                    { 4, "Rajabagicha", "Harsh Babu" },
                    { 5, "Duniya Mohalla", "Ravish Kumar" },
                    { 6, "Daudnagar", "Yasin Ekbal" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Students");
        }
    }
}
