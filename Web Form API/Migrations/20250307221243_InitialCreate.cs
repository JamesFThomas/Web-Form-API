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
                    Message = table.Column<string>(nullable: true),
                    Completed = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Forms", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Forms",
                columns: new[] { "Id", "Completed", "FirstName", "LastName", "Message" },
                values: new object[,]
                {
                    { 1, false, "Johhny", "Fives", "This is test data" },
                    { 2, false, "Emily", "Smith", "Sample message for testing" },
                    { 3, false, "John", "Doe", "Another test entry" },
                    { 4, false, "Sophia", "Brown", "Testing data input format" },
                    { 5, false, "Liam", "Johnson", "Example of a form submission" },
                    { 6, false, "Olivia", "Miller", "Checking the message field" },
                    { 7, false, "Noah", "Davis", "Ensuring proper formatting" },
                    { 8, false, "Ava", "Wilson", "Test message for system validation" },
                    { 9, false, "James", "Anderson", "FormBase test entry number 9" },
                    { 10, false, "Emma", "Taylor", "Final test data input" },
                    { 22, false, "Remove", "Me", "Test the delete endpoint" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Forms");
        }
    }
}
