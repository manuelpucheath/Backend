using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Project.Migrations
{
    /// <inheritdoc />
    public partial class PersonsAndUsersCreated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IdentificationTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(320)", maxLength: 320, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentificationTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(320)", maxLength: 320, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IdentificationTypeId = table.Column<int>(type: "int", nullable: false),
                    IdentificationNumber = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ConcatenatedIdentification = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Persons_IdentificationTypes_IdentificationTypeId",
                        column: x => x.IdentificationTypeId,
                        principalTable: "IdentificationTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "IdentificationTypes",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 4, 10, 20, 27, 0, 690, DateTimeKind.Local).AddTicks(8497), null, "Cedula de ciudadania", new DateTime(2024, 4, 10, 20, 27, 0, 690, DateTimeKind.Local).AddTicks(8507) },
                    { 2, new DateTime(2024, 4, 10, 20, 27, 0, 690, DateTimeKind.Local).AddTicks(8510), null, "Tarjeta de identidad", new DateTime(2024, 4, 10, 20, 27, 0, 690, DateTimeKind.Local).AddTicks(8510) },
                    { 3, new DateTime(2024, 4, 10, 20, 27, 0, 690, DateTimeKind.Local).AddTicks(8511), null, "Registro Civil", new DateTime(2024, 4, 10, 20, 27, 0, 690, DateTimeKind.Local).AddTicks(8512) },
                    { 4, new DateTime(2024, 4, 10, 20, 27, 0, 690, DateTimeKind.Local).AddTicks(8512), null, "Cedula de Extranjeria", new DateTime(2024, 4, 10, 20, 27, 0, 690, DateTimeKind.Local).AddTicks(8513) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Persons_IdentificationTypeId",
                table: "Persons",
                column: "IdentificationTypeId");
            
            migrationBuilder.Sql(@"
                CREATE PROCEDURE [dbo].[GetAllPersons]
                AS
                BEGIN
                    SELECT * FROM [dbo].[Persons]
                END
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Persons");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "IdentificationTypes");
            
            migrationBuilder.Sql("DROP PROCEDURE [dbo].[GetAllPersons]");
        }
    }
}
