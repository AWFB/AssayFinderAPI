using Entities.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Configuration
{
    public class AssayConfiguration : IEntityTypeConfiguration<Assay>
    {
        public void Configure(EntityTypeBuilder<Assay> builder)
        {
            builder.HasData
                (
                    new Assay
                    {
                        AssayId = new Guid("432C59C0-9D75-4FB3-880F-03B5EF067780"),
                        NameOfTest = "1,25-dihydroxyvitamin D",
                        Discipline = "Biochemistry",
                        ContactNumber = "01603 287945",
                        EmailAddress = "a.c@person.com",
                        ContactName = "Monty Scott",
                        CostOfTest = "£5",
                        SampleType = "Serum",
                        SampleVolume = "500ul",
                        PreAnalyticalAndStorageConditions = "Fridged",
                        TransportRequirments = "First class post",
                        ReferenceRange = "55 - 139 pmol/L",
                        RangesApplicableToPaeds = false,
                        AutoCommentAddedToReports = "No Comment",
                        NpexAvailable = true,
                        TurnAroundTime = "4 Weeks",
                        IsAccreditted = false,
                        AccreditationScheme = "N/A",
                        AccreditationNumber = "N/A",
                        EqaSchemeForTest = "DEQAS",
                        IsPerformanceAcceptable = true,
                        PerformanceOutcomesIfNotSatisafactory = "",
                        CreatedAt = DateTime.Now,
                        LastUpdatedAt = DateTime.Now,
                        MeditechCode = "125VITD",
                        Comments = "",
                        LaboratoryId = new Guid("A9F068C1-972A-4708-A52F-DD1EDAA6ABB6")
                    },
                    new Assay
                    {
                        AssayId = new Guid("87BF7AC9-0921-4D42-92F9-4A4F38252FBA"),
                        NameOfTest = "Bone specific ALP",
                        Discipline = "Biochemistry",
                        ContactNumber = "01603 287945",
                        EmailAddress = "a.c@person.com",
                        ContactName = "Monty Scott",
                        CostOfTest = "£28.00",
                        SampleType = "Serum",
                        SampleVolume = "500ul",
                        PreAnalyticalAndStorageConditions = "Frozen",
                        TransportRequirments = "First class post",
                        ReferenceRange = "See report",
                        RangesApplicableToPaeds = true,
                        AutoCommentAddedToReports = "No Comment",
                        NpexAvailable = true,
                        TurnAroundTime = "6 Weeks",
                        IsAccreditted = false,
                        AccreditationScheme = "N/A",
                        AccreditationNumber = "N/A",
                        EqaSchemeForTest = "Sample exchange",
                        IsPerformanceAcceptable = true,
                        PerformanceOutcomesIfNotSatisafactory = "",
                        CreatedAt = DateTime.Now,
                        LastUpdatedAt = DateTime.Now,
                        MeditechCode = "BONE ALP",
                        Comments = "",
                        LaboratoryId = new Guid("A9F068C1-972A-4708-A52F-DD1EDAA6ABB6")
                    },
                    new Assay
                    {
                        AssayId = new Guid("F5670C49-8193-4D42-9A9D-9DEAF81851D8"),
                        NameOfTest = "C3 Nephritic Factor (C3NEF)",
                        Discipline = "Immunology",
                        ContactNumber = "0114 271 5552",
                        EmailAddress = "a.c@person.com",
                        ContactName = "Kev Blue",
                        CostOfTest = "",
                        SampleType = "Serum",
                        SampleVolume = "2mL",
                        PreAnalyticalAndStorageConditions = "Frozen",
                        TransportRequirments = "DX Address: Protein Reference Unit, PO Box 894, Sheffield, S5 7YT. DX Number: 6261402",
                        ReferenceRange = "Negative",
                        RangesApplicableToPaeds = false,
                        AutoCommentAddedToReports = "No Comment",
                        NpexAvailable = true,
                        TurnAroundTime = "10 working days",
                        IsAccreditted = true,
                        AccreditationScheme = "UKAS",
                        AccreditationNumber = "8494",
                        EqaSchemeForTest = "Sample exchange",
                        IsPerformanceAcceptable = true,
                        PerformanceOutcomesIfNotSatisafactory = "",
                        CreatedAt = DateTime.Now,
                        LastUpdatedAt = DateTime.Now,
                        MeditechCode = "C3NF",
                        Comments = "",
                        LaboratoryId = new Guid("BCC94FB7-DF87-447E-A563-41255CF856C4")
                    }
                );
        }
    }
}
