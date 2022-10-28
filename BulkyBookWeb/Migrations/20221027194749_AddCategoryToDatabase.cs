using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BulkyBookWeb.Migrations
{
    /// <inheritdoc />
    public partial class AddCategoryToDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)   /*2 metoder, en opp og en ned (nederst på siden)*/
        {
            migrationBuilder.CreateTable(   /*I migratiobuilder vi har en metode som heter CreateTable.*/
                name: "Categories",         /*Den lager da en tabell med navnet: "Categories"*/
                columns: table => new       /*Så vil den ha kolonner, som vist under med Id, Name, DisplayOrder, CreatedDateTime*/
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>       /*Så vil den legge til constraints med PK navn og Id kolonne som PK.*/
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
