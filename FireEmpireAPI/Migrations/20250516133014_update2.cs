using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FireEmpireAPI.Migrations
{
    /// <inheritdoc />
    public partial class update2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "VideoUrl",
                table: "Products",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    MobilePhone = table.Column<string>(type: "text", nullable: false),
                    JobTitle = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    BirthDay = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    isDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "Id", "BirthDay", "CreatedAt", "JobTitle", "MobilePhone", "Name", "UpdatedAt", "isDeleted" },
                values: new object[,]
                {
                    { new Guid("0cdcb109-02f8-4abc-aeaa-6bdfa5d01718"), new DateTime(1995, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 16, 13, 30, 13, 381, DateTimeKind.Utc).AddTicks(5877), "Разработчик", "+375293334455", "Ольга Смирнова", null, false },
                    { new Guid("288af5ab-9841-4e82-b55b-1e034e6b0cc4"), new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 16, 13, 30, 13, 381, DateTimeKind.Utc).AddTicks(4164), "Менеджер", "+375291112233", "Иван Иванов", null, false },
                    { new Guid("b8b669e3-618c-40fc-9f62-d8fd4b0064f8"), new DateTime(1992, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 16, 13, 30, 13, 381, DateTimeKind.Utc).AddTicks(5882), "Тестировщик", "+375297778899", "Петр Сидоров", null, false }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropColumn(
                name: "VideoUrl",
                table: "Products");
        }
    }
}
