using Entities.Models;

namespace Interfaces
{
    public interface ILaboratoryRepository
    {
        Task<IEnumerable<Laboratory>> GetAllLaboratoriesAsync(bool trackchanges);
        Task<Laboratory> GetLaboratoryAsync(Guid Id, bool trackchanges);
        void CreateLaboratory(Laboratory laboratory);
        void DeleteLaboratory(Laboratory laboratory);
    }
}
