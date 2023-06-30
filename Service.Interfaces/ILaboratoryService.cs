using Shared.DTOs;

namespace Service.Interfaces
{
    public interface ILaboratoryService
    {
        IEnumerable<LaboratoryDTO> GetAllLaboratories(bool trackChanges);
        LaboratoryDTO GetLaboratory(Guid laboratoryId, bool trackChanges);
        LaboratoryDTO CreateLaboratory(LaboratoryForCreationDTO laboratory);
        void UpdateLaboratory(Guid laboratoryId, LaboratoryForUpdateDTO laboratoryForUpdate, bool trackChanges);
        void DeleteLaboratory(Guid laboratoryId, bool trackChanges);
    }
}
