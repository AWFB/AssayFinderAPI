using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AssayFinder.Migrations
{
    /// <inheritdoc />
    public partial class DatabaseCreation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Laboratories",
                columns: table => new
                {
                    LaboratoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LaboratoryName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Laboratories", x => x.LaboratoryId);
                });

            migrationBuilder.CreateTable(
                name: "Assays",
                columns: table => new
                {
                    AssayId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NameOfTest = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Discipline = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CostOfTest = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SampleType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SampleVolume = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PreAnalyticalAndStorageConditions = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TransportRequirments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReferenceRange = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RangesApplicableToPaeds = table.Column<bool>(type: "bit", nullable: true),
                    AutoCommentAddedToReports = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NpexAvailable = table.Column<bool>(type: "bit", nullable: true),
                    TurnAroundTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsAccreditted = table.Column<bool>(type: "bit", nullable: true),
                    AccreditationScheme = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccreditationNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EqaSchemeForTest = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsPerformanceAcceptable = table.Column<bool>(type: "bit", nullable: true),
                    PerformanceOutcomesIfNotSatisafactory = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MeditechCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LaboratoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assays", x => x.AssayId);
                    table.ForeignKey(
                        name: "FK_Assays_Laboratories_LaboratoryId",
                        column: x => x.LaboratoryId,
                        principalTable: "Laboratories",
                        principalColumn: "LaboratoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Assays_LaboratoryId",
                table: "Assays",
                column: "LaboratoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Assays");

            migrationBuilder.DropTable(
                name: "Laboratories");
        }
    }
}
