using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class addStaffRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8D04DCE2-969A-435D-BBA4-DF3F325983DC",
                column: "ConcurrencyStamp",
                value: "dace8c00-3c94-4c12-aa6f-39d9301606d4");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1E0B4271-BDC6-4DFD-8190-9F992926EE72", "a1d7d2b8-ff1d-4e09-921d-c3c2a6d30b96", "staff", "staff" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "47ACE1B1-5476-41AA-A41D-0CE223F5A45C",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "55d2f21d-8d53-41f6-8a30-efbd08dc7868", "AQAAAAEAACcQAAAAEK13/7FuOjFtPfC2odR5bWuPsll0XSNoloKTI/ii2kqBZQ2yU6/eOKSP7re7qjut0A==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "69BD714F-9576-45BA-B5B7-F00649BE00DE",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e93bc328-4d9e-4d29-b985-49397f6375eb", "AQAAAAEAACcQAAAAEPCQEjV2c8h2An56ykdTm6IZxLqeiOUb/qrGrAUVvWSA4eXb0e77y/YpocRAF/QF3g==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1E0B4271-BDC6-4DFD-8190-9F992926EE72");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8D04DCE2-969A-435D-BBA4-DF3F325983DC",
                column: "ConcurrencyStamp",
                value: "45710eee-a5f3-4119-ba04-66e1a151c53b");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "47ACE1B1-5476-41AA-A41D-0CE223F5A45C",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "c671f869-94f0-4ffb-b0e3-8890e1e2a996", "AQAAAAEAACcQAAAAEMAVanxpM+3drkVFbaeZ7G5HwJWLECNGW+XSHrkVplUma00G1Ot+BlDupontT2dR5A==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "69BD714F-9576-45BA-B5B7-F00649BE00DE",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "0405263b-7ef8-4ea8-98e8-218ae86585ee", "AQAAAAEAACcQAAAAEBU2r18xZLQ8yhYt2N2QTsB3AAfhCD/jUkd+73c1gVD1FkAypoQk3AHDX++6LjMxHw==" });
        }
    }
}
