using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Laboratory
    {
        [Column("LaboratoryId")]
        public Guid Id { get; set; }
        public string? LaboratoryName { get; set; }
        public string? ContactName { get; set; }
        public string? ContactNumber { get; set; }
        public string? ContactEmail { get; set; }
        public string? Address { get; set; }

        public ICollection<Assay>? Assays { get; set; }

    }
}
