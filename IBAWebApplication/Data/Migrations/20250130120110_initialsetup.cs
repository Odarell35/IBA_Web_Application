using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IBAWebApplication.Data.Migrations
{
    /// <inheritdoc />
    public partial class initialsetup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IBA_Trainee",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AssignedProducts = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrainingProgram = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IBA_Trainee", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IBA_Trainee");
        }
    }
}
