using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DTOs
{
    public abstract record LaboratoryForManipulationDTO
    {
        [Required]
        public string? LaboratoryName { get; init; }
        [Required]
        public string? ContactName { get; init; }
        [Required]
        public string? ContactNumber { get; init; }
        [Required]
        public string? ContactEmail { get; init; }
        [Required]
        public string? Address { get; init; }
        [Required]
        public string? City { get; init; }
        [Required]
        public string? Country { get; init; }
        [Required]
        public string? Postcode { get; init; }
    }
}
