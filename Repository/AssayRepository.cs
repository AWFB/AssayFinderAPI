using Entities.Models;
using Interfaces;
using Microsoft.EntityFrameworkCore;
using Shared.RequestFeatures;
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

        public async Task<PagedList<Assay>> GetAssaysAsync(Guid laboratoryId, AssayParameters assayParameters, bool trackChanges)
        {
            var assays = await FindByCondition(a => a.LaboratoryId.Equals(laboratoryId), trackChanges)
                .OrderBy(a => a.NameOfTest)
                .ToListAsync();

            return PagedList<Assay>.ToPagedList(assays, assayParameters.PageNumber, assayParameters.PageSize);
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
