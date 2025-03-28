using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NLPC_EPS_server.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Initial_Migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BenefitProcesses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProcessCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(550)", maxLength: 550, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BenefitProcesses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContributionTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(550)", maxLength: 550, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContributionTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MemberProfiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(550)", maxLength: 550, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(550)", maxLength: 550, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(550)", maxLength: 550, nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(550)", maxLength: 550, nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    StateId = table.Column<int>(type: "int", nullable: true),
                    ActiveStatus = table.Column<bool>(type: "bit", nullable: false),
                    DeleteStatus = table.Column<bool>(type: "bit", nullable: false),
                    DateDeleted = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(550)", maxLength: 550, nullable: true),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(550)", maxLength: 550, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemberProfiles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BenefitRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MemberProfileId = table.Column<int>(type: "int", nullable: false),
                    BenefitProcessId = table.Column<int>(type: "int", nullable: false),
                    RequestDescription = table.Column<string>(type: "nvarchar(550)", maxLength: 550, nullable: false),
                    RequestedAmount = table.Column<decimal>(type: "decimal(16,2)", nullable: false),
                    DispatchedAmount = table.Column<decimal>(type: "decimal(16,2)", nullable: true),
                    EmployeeComment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateDispatched = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(550)", maxLength: 550, nullable: true),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(550)", maxLength: 550, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BenefitRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BenefitRequests_BenefitProcesses_BenefitProcessId",
                        column: x => x.BenefitProcessId,
                        principalTable: "BenefitProcesses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BenefitRequests_MemberProfiles_MemberProfileId",
                        column: x => x.MemberProfileId,
                        principalTable: "MemberProfiles",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MemberContributions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MemberProfileId = table.Column<int>(type: "int", nullable: false),
                    ContributionTypeId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(550)", maxLength: 550, nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(16,2)", nullable: false),
                    ContributionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(550)", maxLength: 550, nullable: true),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(550)", maxLength: 550, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemberContributions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MemberContributions_ContributionTypes_ContributionTypeId",
                        column: x => x.ContributionTypeId,
                        principalTable: "ContributionTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MemberContributions_MemberProfiles_MemberProfileId",
                        column: x => x.MemberProfileId,
                        principalTable: "MemberProfiles",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "BenefitProcesses",
                columns: new[] { "Id", "Description", "ProcessCode" },
                values: new object[,]
                {
                    { 1, "Benefit Request is just initiated", "PENDING" },
                    { 2, "Benefit Request is on the Verification Stage", "VERIFICATION" },
                    { 3, "Benefit Request has been denied", "DENIED" },
                    { 4, "Benefit Request has been confirmed", "CONFIRMED" },
                    { 5, "Requested Benefit has been sent to Member's Account.", "DISBURSED" }
                });

            migrationBuilder.InsertData(
                table: "ContributionTypes",
                columns: new[] { "Id", "Description", "Type" },
                values: new object[,]
                {
                    { 1, "Contribution done monthly through a well organised system or organization.", "Monthly Contribution" },
                    { 2, "Contribution made by the Member and its done at any given time.", "Voluntary Contribution" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BenefitRequests_BenefitProcessId",
                table: "BenefitRequests",
                column: "BenefitProcessId");

            migrationBuilder.CreateIndex(
                name: "IX_BenefitRequests_MemberProfileId",
                table: "BenefitRequests",
                column: "MemberProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_MemberContributions_ContributionTypeId",
                table: "MemberContributions",
                column: "ContributionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_MemberContributions_MemberProfileId",
                table: "MemberContributions",
                column: "MemberProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_MemberProfiles_Email",
                table: "MemberProfiles",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BenefitRequests");

            migrationBuilder.DropTable(
                name: "MemberContributions");

            migrationBuilder.DropTable(
                name: "BenefitProcesses");

            migrationBuilder.DropTable(
                name: "ContributionTypes");

            migrationBuilder.DropTable(
                name: "MemberProfiles");
        }
    }
}
