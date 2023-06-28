using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DTOs
{
    public record AssayForUpdateDTO
    {
        public string? NameOfTest { get; init; }
        public string? Discipline { get; init; }
        public string? ContactName { get; init; }
        public string? ContactNumber { get; init; }
        public string? EmailAddress { get; init; }
        public string? CostOfTest { get; init; }
        public string? SampleType { get; init; }
        public string? SampleVolume { get; init; }
        public string? PreAnalyticalAndStorageConditions { get; init; }
        public string? TransportRequirments { get; init; }
        public string? ReferenceRange { get; init; }
        public bool? RangesApplicableToPaeds { get; init; }
        public string? AutoCommentAddedToReports { get; init; }
        public bool? NpexAvailable { get; init; }
        public string? TurnAroundTime { get; init; }
        public bool? IsAccreditted { get; init; }
        public string? AccreditationScheme { get; init; }
        public string? AccreditationNumber { get; init; }
        public string? EqaSchemeForTest { get; init; }
        public bool? IsPerformanceAcceptable { get; init; }
        public string? PerformanceOutcomesIfNotSatisafactory { get; init; }
        public string? Comments { get; init; }
        public string? MeditechCode { get; init; }
    }
}
