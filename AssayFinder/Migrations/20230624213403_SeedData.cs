using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AssayFinder.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Comments",
                table: "Assays",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContactName",
                table: "Assays",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Laboratories",
                columns: new[] { "LaboratoryId", "Address", "ContactEmail", "ContactName", "ContactNumber", "LaboratoryName" },
                values: new object[,]
                {
                    { new Guid("a9f068c1-972a-4708-a52f-dd1edaa6abb6"), "1 Hospital Way, Liverpool, LV1 2BZ", "lab@PineWheat.com", "William Riker", "0112 587 326", "PineWheat Trust" },
                    { new Guid("bcc94fb7-df87-447e-a563-41255cf856c4"), "1 Caring Street, Derby, DE1 9BZ", "lab@BirchBarley.com", "Bev Crusher", "01332 222 123", "BirchBarley Trust" }
                });

            migrationBuilder.InsertData(
                table: "Assays",
                columns: new[] { "AssayId", "AccreditationNumber", "AccreditationScheme", "AutoCommentAddedToReports", "Comments", "ContactName", "ContactNumber", "CostOfTest", "CreatedAt", "Discipline", "EmailAddress", "EqaSchemeForTest", "IsAccreditted", "IsPerformanceAcceptable", "LaboratoryId", "LastUpdatedAt", "MeditechCode", "NameOfTest", "NpexAvailable", "PerformanceOutcomesIfNotSatisafactory", "PreAnalyticalAndStorageConditions", "RangesApplicableToPaeds", "ReferenceRange", "SampleType", "SampleVolume", "TransportRequirments", "TurnAroundTime" },
                values: new object[,]
                {
                    { new Guid("432c59c0-9d75-4fb3-880f-03b5ef067780"), "N/A", "N/A", "No Comment", "", "Monty Scott", "01603 287945", "£5", new DateTime(2023, 6, 24, 22, 34, 3, 846, DateTimeKind.Local).AddTicks(5735), "Biochemistry", "a.c@person.com", "DEQAS", false, true, new Guid("a9f068c1-972a-4708-a52f-dd1edaa6abb6"), new DateTime(2023, 6, 24, 22, 34, 3, 846, DateTimeKind.Local).AddTicks(5786), "125VITD", "1,25-dihydroxyvitamin D", true, "", "Fridged", false, "55 - 139 pmol/L", "Serum", "500ul", "First class post", "4 Weeks" },
                    { new Guid("87bf7ac9-0921-4d42-92f9-4a4f38252fba"), "N/A", "N/A", "No Comment", "", "Monty Scott", "01603 287945", "£28.00", new DateTime(2023, 6, 24, 22, 34, 3, 846, DateTimeKind.Local).AddTicks(5793), "Biochemistry", "a.c@person.com", "Sample exchange", false, true, new Guid("a9f068c1-972a-4708-a52f-dd1edaa6abb6"), new DateTime(2023, 6, 24, 22, 34, 3, 846, DateTimeKind.Local).AddTicks(5795), "BONE ALP", "Bone specific ALP", true, "", "Frozen", true, "See report", "Serum", "500ul", "First class post", "6 Weeks" },
                    { new Guid("f5670c49-8193-4d42-9a9d-9deaf81851d8"), "8494", "UKAS", "No Comment", "", "Kev Blue", "0114 271 5552", "", new DateTime(2023, 6, 24, 22, 34, 3, 846, DateTimeKind.Local).AddTicks(5803), "Immunology", "a.c@person.com", "Sample exchange", true, true, new Guid("bcc94fb7-df87-447e-a563-41255cf856c4"), new DateTime(2023, 6, 24, 22, 34, 3, 846, DateTimeKind.Local).AddTicks(5805), "C3NF", "C3 Nephritic Factor (C3NEF)", true, "", "Frozen", false, "Negative", "Serum", "2mL", "DX Address: Protein Reference Unit, PO Box 894, Sheffield, S5 7YT. DX Number: 6261402", "10 working days" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Assays",
                keyColumn: "AssayId",
                keyValue: new Guid("432c59c0-9d75-4fb3-880f-03b5ef067780"));

            migrationBuilder.DeleteData(
                table: "Assays",
                keyColumn: "AssayId",
                keyValue: new Guid("87bf7ac9-0921-4d42-92f9-4a4f38252fba"));

            migrationBuilder.DeleteData(
                table: "Assays",
                keyColumn: "AssayId",
                keyValue: new Guid("f5670c49-8193-4d42-9a9d-9deaf81851d8"));

            migrationBuilder.DeleteData(
                table: "Laboratories",
                keyColumn: "LaboratoryId",
                keyValue: new Guid("a9f068c1-972a-4708-a52f-dd1edaa6abb6"));

            migrationBuilder.DeleteData(
                table: "Laboratories",
                keyColumn: "LaboratoryId",
                keyValue: new Guid("bcc94fb7-df87-447e-a563-41255cf856c4"));

            migrationBuilder.DropColumn(
                name: "Comments",
                table: "Assays");

            migrationBuilder.DropColumn(
                name: "ContactName",
                table: "Assays");
        }
    }
}
