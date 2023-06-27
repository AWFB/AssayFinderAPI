using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        [Required(ErrorMessage = "Laboratory Name is required")]
        public string? LaboratoryName { get; set; }

        [Required(ErrorMessage = "Contact Name is required")]
        public string? ContactName { get; set; }

        [Required(ErrorMessage = "Contact Number is required")]
        public string? ContactNumber { get; set; }

        [Required(ErrorMessage = "Contact Email is required")]
        public string? ContactEmail { get; set; }

        [Required(ErrorMessage = "First Line of address is required")]
        public string? Address { get; set; }

        [Required(ErrorMessage = "City is required")]
        public string? City { get; set; }

        [Required(ErrorMessage = "Country is required")]
        public string? Country { get; set; }

        [Required(ErrorMessage = "Postcode is required")]
        public string? Postcode { get; set; }

        public ICollection<Assay>? Assays { get; set; }

    }
}
