using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Assay
    {
        [Column("AssayId")]
        public Guid AssayId { get; set; }
        [Required]
        public string? NameOfTest { get; set; }
        [Required]
        public string? Discipline { get; set; }
        [Required]
        public string? ContactName { get; set; }
        [Required]
        public  string? ContactNumber { get; set; }

        [Required]
        [EmailAddress]
        public string? EmailAddress { get; set; }
        public string? CostOfTest { get; set; }
        [Required]
        public string? SampleType { get; set; }
        [Required]
        public string? SampleVolume { get; set; }
        [Required]
        public string? PreAnalyticalAndStorageConditions { get; set; }
        [Required]
        public string? TransportRequirments { get; set; }
        public string? ReferenceRange { get; set; }
        public bool? RangesApplicableToPaeds { get; set; }
        public string? AutoCommentAddedToReports { get; set; }
        public bool? NpexAvailable { get; set; }
        public string? TurnAroundTime { get; set; }
        [Required]
        public bool? IsAccreditted { get; set; }
        public string? AccreditationScheme { get; set; }
        public string? AccreditationNumber { get; set; }
        [Required]
        public string? EqaSchemeForTest { get; set; }
        public bool? IsPerformanceAcceptable { get; set; }
        public string? PerformanceOutcomesIfNotSatisafactory { get; set; }
        public string? Comments { get; set; }
        public string? MeditechCode { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime LastUpdatedAt { get; set;} = DateTime.UtcNow;
        

        // navigation properties
        [ForeignKey(nameof(Laboratory))]
        public Guid LaboratoryId { get; set; }
        public Laboratory? Laboratory { get; set; }
    }
}
