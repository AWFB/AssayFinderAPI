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
        IEnumerable<AssayDTO> GetAssays(Guid laboratoryId, bool trackChanges);
        AssayDTO GetAssay(Guid laboratoryId, Guid id, bool trackChanges);
        AssayDTO CreateAssayForLaboratory(Guid laboratoryId, AssayForCreationDTO assayForCreation, bool trackChanges);
        void DeleteAssayForLaboratory(Guid laboratoryId, Guid id, bool trackChanges);
        void UpdateAssayForLaboratory(Guid laboratoryId, Guid id, AssayForUpdateDTO assayForUpdate, 
            bool labTrackChanges, bool assayTrackChanges);
    }
}
