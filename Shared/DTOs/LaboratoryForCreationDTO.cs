﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DTOs
{
    public record LaboratoryForCreationDTO : LaboratoryForManipulationDTO
    {
        public IEnumerable<AssayForCreationDTO>? Assays { get; init; }
    }
}
