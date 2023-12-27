using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntreprisesContacts.Server.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contact",
                columns: table => new
                {
                    ContactID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Lastname = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    Firstname = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    Entreprise = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    Phone = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contact", x => x.ContactID);
                });

            migrationBuilder.CreateTable(
                name: "Entreprise",
                columns: table => new
                {
                    EntrepriseID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    Description = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    FirstAdress = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    SecondAdress = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    Zip = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    City = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    Country = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    Phone = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    thumbnail = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entreprise", x => x.EntrepriseID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contact");

            migrationBuilder.DropTable(
                name: "Entreprise");
        }
    }
}
