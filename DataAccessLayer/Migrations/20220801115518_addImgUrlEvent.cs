using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class addImgUrlEvent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImgUrl",
                table: "Events",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8D04DCE2-969A-435D-BBA4-DF3F325983DC",
                column: "ConcurrencyStamp",
                value: "e94c4146-98b5-41f3-a48c-94d65b7fc254");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "47ACE1B1-5476-41AA-A41D-0CE223F5A45C",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "b7fa72b2-bd8a-4569-afe8-c67c384cb68b", "AQAAAAEAACcQAAAAEC1d0PbD/QQYPA8ePf5nNP9GGkvpH2krWJR7YET29JPZqRVfCN1mWVLVcUD0YrEDIA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "69BD714F-9576-45BA-B5B7-F00649BE00DE",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "01937190-fae1-4493-8c48-e68ab6182d25", "AQAAAAEAACcQAAAAEI3d2Mn7af/kiRyb3AuBbw41M07JyQ8jalFU9QX//VxpigafKm6GOg6fT3lupTS6mQ==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImgUrl",
                table: "Events");

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
    }
}
