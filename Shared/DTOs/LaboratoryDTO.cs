using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DTOs
{
    public record LaboratoryDTO
    {
        public Guid Id { get; init; }
        public string? LaboratoryName { get; init; }
        public string? FullAddress { get; init; }
    }
}
