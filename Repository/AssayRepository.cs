using Entities.Models;
using Interfaces;
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


        public Assay GetAssay(Guid laboratoryId, Guid id, bool trackChanges)
        {
            var assay = FindByCondition(a => a.LaboratoryId.Equals(laboratoryId) && a.AssayId == id, trackChanges)
                .SingleOrDefault();

            return assay;
        }

        public IEnumerable<Assay> GetAssays(Guid laboratoryId, bool trackChanges)
        {
            var assays = FindByCondition(a => a.LaboratoryId.Equals(laboratoryId), trackChanges)
                .OrderBy(a => a.NameOfTest)
                .ToList();

            return assays;
        }

        public void CreateAssayForLaboratory(Guid laboratoryId, Assay assay)
        {
            assay.LaboratoryId = laboratoryId;
            Create(assay);
        }
    }
}
