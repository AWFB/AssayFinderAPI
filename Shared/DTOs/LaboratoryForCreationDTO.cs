using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DTOs
{
    public record LaboratoryForCreationDTO
    {
        [Required]
        public string? LaboratoryName { get; init; }
        public string? ContactName { get; init; }
        public string? ContactNumber { get; init; }
        public string? ContactEmail { get; init; }
        public string? Address { get; init; }
        public string? City { get; init; }
        public string? Country { get; init; }
        public string? Postcode { get; init; }

        public IEnumerable<AssayForCreationDTO>? Assays { get; init; }

    }
}
