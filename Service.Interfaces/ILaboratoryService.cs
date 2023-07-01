using Shared.DTOs;

namespace Service.Interfaces
{
    public interface ILaboratoryService
    {
        Task<IEnumerable<LaboratoryDTO>> GetAllLaboratoriesAsync(bool trackChanges);
        Task<LaboratoryDTO> GetLaboratoryAsync(Guid laboratoryId, bool trackChanges);
        Task<LaboratoryDTO> CreateLaboratoryAsync(LaboratoryForCreationDTO laboratory);
        Task UpdateLaboratoryAsync(Guid laboratoryId, LaboratoryForUpdateDTO laboratoryForUpdate, bool trackChanges);
        Task DeleteLaboratoryAsync(Guid laboratoryId, bool trackChanges);
    }
}
