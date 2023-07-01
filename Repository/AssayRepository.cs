using Entities.Models;
using Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class AssayRepository : RepositoryBase<Assay>, IAssayRepository
    {
        public AssayRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }


        public async Task<Assay> GetAssayAsync(Guid laboratoryId, Guid id, bool trackChanges)
        {
            var assay = await FindByCondition(a => a.LaboratoryId.Equals(laboratoryId) && a.AssayId.Equals(id), trackChanges)
                .SingleOrDefaultAsync();

            return assay;
        }

        public async Task<IEnumerable<Assay>> GetAssaysAsync(Guid laboratoryId, bool trackChanges)
        {
            var assays = await FindByCondition(a => a.LaboratoryId.Equals(laboratoryId), trackChanges)
                .OrderBy(a => a.NameOfTest)
                .ToListAsync();

            return assays;
        }

        public void CreateAssayForLaboratory(Guid laboratoryId, Assay assay)
        {
            assay.LaboratoryId = laboratoryId;
            Create(assay);
        }

        public void DeleteAssay(Assay assay)
        {
            Delete(assay);
        }
    }
}
