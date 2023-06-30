using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DTOs
{
    public abstract record AssayForManipulationDTO
    {
        [Required] public string? NameOfTest { get; init; }
        [Required] public string? Discipline { get; init; }
        [Required] public string? ContactName { get; init; }
        [Required] public string? ContactNumber { get; init; }
        [Required] public string? EmailAddress { get; init; }
        public string? CostOfTest { get; init; }
        [Required] public string? SampleType { get; init; }
        [Required] public string? SampleVolume { get; init; }
        [Required] public string? PreAnalyticalAndStorageConditions { get; init; }
        [Required] public string? TransportRequirments { get; init; }
        public string? ReferenceRange { get; init; }
        public bool? RangesApplicableToPaeds { get; init; }
        public string? AutoCommentAddedToReports { get; init; }
        public bool? NpexAvailable { get; init; }
        public string? TurnAroundTime { get; init; }
        [Required] public bool? IsAccreditted { get; init; }
        [Required] public string? AccreditationScheme { get; init; }
        public string? AccreditationNumber { get; init; }
        [Required] public string? EqaSchemeForTest { get; init; }
        public bool? IsPerformanceAcceptable { get; init; }
        public string? PerformanceOutcomesIfNotSatisafactory { get; init; }
        public string? Comments { get; init; }
        public string? MeditechCode { get; init; }
    }
}
