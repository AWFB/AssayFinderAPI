﻿using Entities.Models;

namespace Interfaces
{
    public interface ILaboratoryRepository
    {
        IEnumerable<Laboratory> GetAllLaboratories(bool trackchanges);
        Laboratory GetLaboratory(Guid Id, bool trackchanges);
        void CreateLaboratory(Laboratory laboratory);
        void DeleteLaboratory(Laboratory laboratory);
    }
}
