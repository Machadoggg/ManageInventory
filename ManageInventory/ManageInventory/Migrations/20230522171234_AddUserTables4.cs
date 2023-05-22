using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ManageInventory.API.Migrations
{
    /// <inheritdoc />
    public partial class AddUserTables4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    IdAuthor = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(45)", unicode: false, maxLength: 45, nullable: false),
                    LastName = table.Column<string>(type: "varchar(45)", unicode: false, maxLength: 45, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.IdAuthor);
                });

            migrationBuilder.CreateTable(
                name: "Authors_Has_Books",
                columns: table => new
                {
                    IdAuthor = table.Column<int>(type: "int", nullable: false),
                    ISBN = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors_Has_Books", x => new { x.IdAuthor, x.ISBN });
                });

            migrationBuilder.CreateTable(
                name: "Editorials",
                columns: table => new
                {
                    IdEditorial = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(45)", unicode: false, maxLength: 45, nullable: true),
                    Headquarters = table.Column<string>(type: "varchar(45)", unicode: false, maxLength: 45, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Editorials", x => x.IdEditorial);
                });

            migrationBuilder.CreateTable(
                name: "UserProfiles",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProfiles", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    ISBN = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    IdEditorial = table.Column<int>(type: "int", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    Sinopsis = table.Column<string>(type: "text", nullable: true),
                    NumberPages = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books_1", x => x.ISBN);
                    table.ForeignKey(
                        name: "FK_Books_Editorials",
                        column: x => x.IdEditorial,
                        principalTable: "Editorials",
                        principalColumn: "IdEditorial");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_IdEditorial",
                table: "Books",
                column: "IdEditorial");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "Authors_Has_Books");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "UserProfiles");

            migrationBuilder.DropTable(
                name: "Editorials");
        }
    }
}
