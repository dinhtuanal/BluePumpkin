using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class addPropertiesAvataUrlUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AvataUrl",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8D04DCE2-969A-435D-BBA4-DF3F325983DC",
                column: "ConcurrencyStamp",
                value: "b32dc7bb-9e0a-47ce-bd09-263d9c1dc18d");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "47ACE1B1-5476-41AA-A41D-0CE223F5A45C",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "1c05abd3-5dd4-4638-828f-c3a94bbe5929", "AQAAAAEAACcQAAAAEBXewDHDw7aE/BOSNe+Xj2uC/jc1+jyPcExvR5Y2VQv6b/eqyZzNcxcw52lEPS9ozg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "69BD714F-9576-45BA-B5B7-F00649BE00DE",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "ed8073f0-10e5-4628-a73d-a0304ca00037", "AQAAAAEAACcQAAAAEMKgGXQtJWvmH6oZG7Q6tzI1UylVZZSSYMGe0YJfxDU2l/Ofgyq36jP0Gz1B6tiUAg==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AvataUrl",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8D04DCE2-969A-435D-BBA4-DF3F325983DC",
                column: "ConcurrencyStamp",
                value: "364d2d34-2a45-4346-b927-325f016101cc");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "47ACE1B1-5476-41AA-A41D-0CE223F5A45C",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "828d8456-3b39-4679-8f06-d8a7b2212d23", "AQAAAAEAACcQAAAAEC9/ATJc78VVNWnOIPoAVslM7x9+qzigKKHsYkG71DlGYVYcex8S50h8I0Jus+eeqQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "69BD714F-9576-45BA-B5B7-F00649BE00DE",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "63d06b4c-3d81-4e76-8cfe-8b9f7430a788", "AQAAAAEAACcQAAAAEMOoGA4WBDhN3Sguia3IDdv074JYtvIEYuxHcTN2oa8f/j7iypZg4S2zegVENhowiw==" });
        }
    }
}
