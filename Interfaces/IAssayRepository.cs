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
        IEnumerable<Assay> GetAssays(Guid laboratoryId, bool trackChanges);
        Assay GetAssay(Guid laboratoryId, Guid id, bool trackChanges);
        void CreateAssayForLaboratory(Guid laboratoryId, Assay assay);
    }
}
