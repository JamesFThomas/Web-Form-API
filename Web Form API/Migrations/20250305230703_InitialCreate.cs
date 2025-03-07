using Microsoft.EntityFrameworkCore.Migrations;

namespace Web_Form_API.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Forms",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Message = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Forms", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Forms",
                columns: new[] { "Id", "FirstName", "LastName", "Message" },
                values: new object[,]
                {
                    { 1, "Johhny", "Fives", "This is test data" },
                    { 2, "Emily", "Smith", "Sample message for testing" },
                    { 3, "John", "Doe", "Another test entry" },
                    { 4, "Sophia", "Brown", "Testing data input format" },
                    { 5, "Liam", "Johnson", "Example of a form submission" },
                    { 6, "Olivia", "Miller", "Checking the message field" },
                    { 7, "Noah", "Davis", "Ensuring proper formatting" },
                    { 8, "Ava", "Wilson", "Test message for system validation" },
                    { 9, "James", "Anderson", "FormBase test entry number 9" },
                    { 10, "Emma", "Taylor", "Final test data input" },
                    { 22, "Remove", "Me", "Test the delete endpoint" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Forms");
        }
    }
}
