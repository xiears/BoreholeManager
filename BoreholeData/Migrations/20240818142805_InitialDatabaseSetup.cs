using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BoreholeData.Migrations
{
    /// <inheritdoc />
    public partial class InitialDatabaseSetup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Boreholes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Depth = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    X = table.Column<int>(type: "int", nullable: false),
                    Y = table.Column<int>(type: "int", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    CableType = table.Column<int>(type: "int", nullable: true),
                    CableStrength = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DrillType = table.Column<int>(type: "int", nullable: true),
                    DrillStrength = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Boreholes", x => x.ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Boreholes");
        }
    }
}
