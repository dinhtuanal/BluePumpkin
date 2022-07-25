using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class seedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8D04DCE2-969A-435D-BBA4-DF3F325983DC", "364d2d34-2a45-4346-b927-325f016101cc", "admin", "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "BirtthDay", "ConcurrencyStamp", "Country", "Email", "EmailConfirmed", "FirstName", "Gender", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "47ACE1B1-5476-41AA-A41D-0CE223F5A45C", 0, new DateTime(1991, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "828d8456-3b39-4679-8f06-d8a7b2212d23", "Dak Lak, Viet Nam", "hoangvanviet@gmail.com", true, "Hoang Van", 1, "Viet", false, null, "hoangvanviet@gmail.com", "hoangvanviet", "AQAAAAEAACcQAAAAEC9/ATJc78VVNWnOIPoAVslM7x9+qzigKKHsYkG71DlGYVYcex8S50h8I0Jus+eeqQ==", "0888444777", false, "", false, "hoangvanviet" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "BirtthDay", "ConcurrencyStamp", "Country", "Email", "EmailConfirmed", "FirstName", "Gender", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "69BD714F-9576-45BA-B5B7-F00649BE00DE", 0, new DateTime(2001, 6, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "63d06b4c-3d81-4e76-8cfe-8b9f7430a788", "Quang Tri, Viet Nam", "dinhtuanal@gmail.com", true, "Le Dinh", 1, "Tuan", false, null, "dinhtuanal@gmail.com", "dinhtuanal", "AQAAAAEAACcQAAAAEMOoGA4WBDhN3Sguia3IDdv074JYtvIEYuxHcTN2oa8f/j7iypZg4S2zegVENhowiw==", "0999686888", false, "", false, "dinhtuanal" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "8D04DCE2-969A-435D-BBA4-DF3F325983DC", "47ACE1B1-5476-41AA-A41D-0CE223F5A45C" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "8D04DCE2-969A-435D-BBA4-DF3F325983DC", "69BD714F-9576-45BA-B5B7-F00649BE00DE" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "8D04DCE2-969A-435D-BBA4-DF3F325983DC", "47ACE1B1-5476-41AA-A41D-0CE223F5A45C" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "8D04DCE2-969A-435D-BBA4-DF3F325983DC", "69BD714F-9576-45BA-B5B7-F00649BE00DE" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8D04DCE2-969A-435D-BBA4-DF3F325983DC");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "47ACE1B1-5476-41AA-A41D-0CE223F5A45C");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "69BD714F-9576-45BA-B5B7-F00649BE00DE");
        }
    }
}
