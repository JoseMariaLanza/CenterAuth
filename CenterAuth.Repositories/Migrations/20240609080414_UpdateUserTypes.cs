using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CenterAuth.Repositories.Migrations
{
    public partial class UpdateUserTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "UserTypes",
                columns: new[] { "Id", "Name", "Type" },
                values: new object[,]
                {
                    { 3, "Management", "/2/1/" },
                    { 4, "SiteAdmin", "/2/1/1/" },
                    { 5, "Director", "/2/1/2/" },
                    { 6, "Manager", "/2/1/3/" },
                    { 7, "OperationsManager", "/2/1/4/" },
                    { 8, "AdministrativeAssistant", "/2/1/5/" },
                    { 9, "HR", "/2/2/" },
                    { 10, "ITSupport", "/2/3/" },
                    { 11, "Finance", "/2/4/" },
                    { 12, "Architect", "/3/" },
                    { 13, "SecuritySpecialist", "/4/" },
                    { 14, "NetworkEngineer", "/5/" },
                    { 15, "SupportEngineer", "/6/" },
                    { 16, "ITAdministrator", "/7/" },
                    { 17, "SME", "/8/" },
                    { 18, "TeamMember", "/9/" },
                    { 19, "ProjectManager", "/9/1/" },
                    { 20, "TeamLead", "/9/2/" },
                    { 21, "Developer", "/9/3/" },
                    { 22, "FrontendDeveloper", "/9/3/1/" },
                    { 23, "BackendDeveloper", "/9/3/2/" },
                    { 24, "QAEngineer", "/9/4/" },
                    { 25, "UXDesigner", "/9/5/" },
                    { 26, "ProductOwner", "/9/6/" },
                    { 27, "DevOpsEngineer", "/9/7/" },
                    { 28, "DataScientist", "/9/8/" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserTypes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "UserTypes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "UserTypes",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "UserTypes",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "UserTypes",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "UserTypes",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "UserTypes",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "UserTypes",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "UserTypes",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "UserTypes",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "UserTypes",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "UserTypes",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "UserTypes",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "UserTypes",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "UserTypes",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "UserTypes",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "UserTypes",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "UserTypes",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "UserTypes",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "UserTypes",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "UserTypes",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "UserTypes",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "UserTypes",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "UserTypes",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "UserTypes",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "UserTypes",
                keyColumn: "Id",
                keyValue: 28);
        }
    }
}
