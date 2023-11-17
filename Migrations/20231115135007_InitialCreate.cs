using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DirectoryViewer.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Directories",
                columns: table => new
                {
                    DirectoryId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    ParentId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Directories", x => x.DirectoryId);
                    table.ForeignKey(
                        name: "FK_Directories_Directories_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Directories",
                        principalColumn: "DirectoryId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Directories_ParentId",
                table: "Directories",
                column: "ParentId");

            migrationBuilder.InsertData(
            table: "Directories",
            columns: new[] { "Name", "ParentId" },
            values: new object[,]
            {
                { "Creating Digital Images", null },
                { "Resources", 1 },
                { "Evidence", 1 },
                { "Graphic Product", 1 },
                { "Primary Sources", 2 },
                { "Secondary Sources", 2 },
                { "Process", 4 },
                { "Final Product", 4 },
            });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Directories");
        }
    }
}
