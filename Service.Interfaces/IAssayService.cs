using Entities.Models;
using Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IAssayService
    {
        Task<IEnumerable<AssayDTO>> GetAssaysAsync(Guid laboratoryId, bool trackChanges);
        Task<AssayDTO> GetAssayAsync(Guid laboratoryId, Guid id, bool trackChanges);
        Task<AssayDTO> CreateAssayForLaboratoryAsync(Guid laboratoryId, AssayForCreationDTO assayForCreation, bool trackChanges);
        Task DeleteAssayForLaboratoryAsync(Guid laboratoryId, Guid id, bool trackChanges);
        Task UpdateAssayForLaboratoryAsync(Guid laboratoryId, Guid id, AssayForUpdateDTO assayForUpdate, 
            bool labTrackChanges, bool assayTrackChanges);

        Task<(AssayForUpdateDTO assayToPatch, Assay assayEntity)> GetAssayForPatchAsync(Guid laboratoryId, Guid id, 
            bool labTrackChanges, bool assayTrackChanges);

        Task SaveChangesForPatchAsync(AssayForUpdateDTO assayToPatch, Assay assay);
    }
}
