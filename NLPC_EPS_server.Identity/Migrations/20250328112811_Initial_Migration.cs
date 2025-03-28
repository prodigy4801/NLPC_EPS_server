using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NLPC_EPS_server.Identity.Migrations
{
    /// <inheritdoc />
    public partial class Initial_Migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(550)", maxLength: 550, nullable: false),
                    ActiveStatus = table.Column<bool>(type: "bit", nullable: false),
                    DeleteStatus = table.Column<bool>(type: "bit", nullable: false),
                    DateDeleted = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "CompanyId", "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { 1, "2ba58874-322c-4ddb-b632-515a27771846", "AQAAAAIAAYagAAAAEL6kPvlIXAbyblHRLKKYyIo7fP9+mHr9dnLQMDf9oJ5j4DZPYB2mfTLHP73XT5NP9g==", "a06296c7-979f-4fbf-8a49-65aec8986c2c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9e224968-33e4-4652-b7b7-8574d048cdb9",
                columns: new[] { "CompanyId", "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { 1, "0aec8f8b-9ad2-408e-9d89-f4f7ef924dda", "AQAAAAIAAYagAAAAEDuSSgkRDdNi8WlLj0L1+K3jQPkUGGZNfmvoZ2KAzXXmVvovnnl/OyFhuf8+oqcnqA==", "f1c947bf-6039-40fb-8208-2a8d4c867b62" });

            migrationBuilder.InsertData(
                table: "Company",
                columns: new[] { "Id", "ActiveStatus", "Address", "DateDeleted", "DeleteStatus", "Name" },
                values: new object[] { 1, true, "312 Ikorodu Rd, Anthony, Lagos 105102, Lagos.", null, false, "NLPC Pension Fund Administrators Limited" });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_CompanyId",
                table: "AspNetUsers",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Company_CompanyId",
                table: "AspNetUsers",
                column: "CompanyId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Company_CompanyId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Company");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_CompanyId",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "CompanyId", "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { 0, "f569756c-b043-4f9a-8f88-7d9080a32b7b", "AQAAAAIAAYagAAAAEN8hVuwriSDJxmpFCWSB5NAu9xyI1HbV5cfhyxDTiAqSc+oKqiZPbicKhT8tPyNcPw==", "abf89280-8bfb-4587-a494-822d85934f65" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9e224968-33e4-4652-b7b7-8574d048cdb9",
                columns: new[] { "CompanyId", "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { 0, "b5c529df-b131-4d56-becf-5b19c6a30370", "AQAAAAIAAYagAAAAEBND/ScOOJAiuFfdQEJYOpaR5NqAkgBrpbzjyvW8gRjIPX0fAA1c80JmGKyehniygQ==", "c8442872-f3db-4691-8e22-23b4f43db57d" });
        }
    }
}
