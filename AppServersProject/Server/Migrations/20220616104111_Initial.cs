using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppServersProject.Server.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    League = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Coach = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FootballPlayers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TeamId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FootballPlayers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FootballPlayers_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "Id", "Coach", "League", "Name" },
                values: new object[,]
                {
                    { 1, "Erik ten Hag", "La Liga", "Real Madrid" },
                    { 2, "Julian Nagelsmann", "Bundesliga", "Bayern Munich" },
                    { 3, "Mauricio Pochettino", "Ligue 1", "Paris Saint Germain" },
                    { 4, "Xavi", "La Liga", "FC Barcelona" }
                });

            migrationBuilder.InsertData(
                table: "FootballPlayers",
                columns: new[] { "Id", "Name", "Position", "Surname", "TeamId" },
                values: new object[,]
                {
                    { 1, "Toni", "Midfielder", "Kroos", 1 },
                    { 2, "Karim", "Striker", "Benzema", 1 },
                    { 3, "Robert", "Striker", "Lewandowski", 2 },
                    { 4, "Jordi", "Left-back", "Alves", 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_FootballPlayers_TeamId",
                table: "FootballPlayers",
                column: "TeamId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FootballPlayers");

            migrationBuilder.DropTable(
                name: "Teams");
        }
    }
}
