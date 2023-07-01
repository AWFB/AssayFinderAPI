using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IAssayRepository
    {
        Task<IEnumerable<Assay>> GetAssaysAsync(Guid laboratoryId, bool trackChanges);
        Task<Assay> GetAssayAsync(Guid laboratoryId, Guid id, bool trackChanges);
        void CreateAssayForLaboratory(Guid laboratoryId, Assay assay);
        void DeleteAssay(Assay assay);
    }
}
