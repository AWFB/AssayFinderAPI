﻿using Shared.DTOs;

namespace Service.Interfaces
{
    public interface ILaboratoryService
    {
        IEnumerable<LaboratoryDTO> GetAllLaboratories(bool trackChanges);
    }
}
