using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MuseumData.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Museums",
                columns: table => new
                {
                    Adress = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Countofemployees = table.Column<int>(name: "Count_of_employees", type: "int", nullable: false),
                    Countofexhibit = table.Column<int>(name: "Count_of_exhibit", type: "int", nullable: false),
                    Countofhall = table.Column<int>(name: "Count_of_hall", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Museums", x => x.Adress);
                    table.UniqueConstraint("AK_Museums_Name", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "Halls",
                columns: table => new
                {
                    HallID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adressofmuseum = table.Column<string>(name: "Adress_of_museum", type: "nvarchar(450)", nullable: false),
                    Typeofhall = table.Column<string>(name: "Type_of_hall", type: "nvarchar(max)", nullable: false),
                    Countofexhibit = table.Column<int>(name: "Count_of_exhibit", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Halls", x => x.HallID);
                    table.ForeignKey(
                        name: "FK_Halls_Museums_Adress_of_museum",
                        column: x => x.Adressofmuseum,
                        principalTable: "Museums",
                        principalColumn: "Adress",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mobilenumber = table.Column<string>(name: "Mobile_number", type: "nvarchar(max)", nullable: true),
                    Adressofmuseum = table.Column<string>(name: "Adress_of_museum", type: "nvarchar(450)", nullable: true),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: true, defaultValue: "Staff"),
                    Salary = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.ID);
                    table.CheckConstraint("CH_Salary", "Salary > 14999");
                    table.ForeignKey(
                        name: "FK_Persons_Museums_Adress_of_museum",
                        column: x => x.Adressofmuseum,
                        principalTable: "Museums",
                        principalColumn: "Adress",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Exhibits",
                columns: table => new
                {
                    ExhibitID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HallID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Storageconditions = table.Column<string>(name: "Storage_conditions", type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exhibits", x => x.ExhibitID);
                    table.ForeignKey(
                        name: "FK_Exhibits_Halls_HallID",
                        column: x => x.HallID,
                        principalTable: "Halls",
                        principalColumn: "HallID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tickects",
                columns: table => new
                {
                    TicketID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientID = table.Column<int>(type: "int", nullable: false),
                    Adressofmuseum = table.Column<string>(name: "Adress_of_museum", type: "nvarchar(450)", nullable: false),
                    WorkerID = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Cost = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickects", x => x.TicketID);
                    table.ForeignKey(
                        name: "FK_Tickects_Museums_Adress_of_museum",
                        column: x => x.Adressofmuseum,
                        principalTable: "Museums",
                        principalColumn: "Adress",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tickects_Persons_ClientID",
                        column: x => x.ClientID,
                        principalTable: "Persons",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tickects_Persons_WorkerID",
                        column: x => x.WorkerID,
                        principalTable: "Persons",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Exhibits_HallID",
                table: "Exhibits",
                column: "HallID");

            migrationBuilder.CreateIndex(
                name: "IX_Halls_Adress_of_museum",
                table: "Halls",
                column: "Adress_of_museum");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_Adress_of_museum",
                table: "Persons",
                column: "Adress_of_museum");

            migrationBuilder.CreateIndex(
                name: "IX_Tickects_Adress_of_museum",
                table: "Tickects",
                column: "Adress_of_museum");

            migrationBuilder.CreateIndex(
                name: "IX_Tickects_ClientID",
                table: "Tickects",
                column: "ClientID");

            migrationBuilder.CreateIndex(
                name: "IX_Tickects_WorkerID",
                table: "Tickects",
                column: "WorkerID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Exhibits");

            migrationBuilder.DropTable(
                name: "Tickects");

            migrationBuilder.DropTable(
                name: "Halls");

            migrationBuilder.DropTable(
                name: "Persons");

            migrationBuilder.DropTable(
                name: "Museums");
        }
    }
}
