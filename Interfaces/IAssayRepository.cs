using Entities.Models;
using Shared.RequestFeatures;

namespace Interfaces
{
    public interface IAssayRepository
    {
        Task<PagedList<Assay>> GetAssaysAsync(Guid laboratoryId, AssayParameters assayParameters, bool trackChanges);
        Task<Assay> GetAssayAsync(Guid laboratoryId, Guid id, bool trackChanges);
        void CreateAssayForLaboratory(Guid laboratoryId, Assay assay);
        void DeleteAssay(Assay assay);
    }
}
