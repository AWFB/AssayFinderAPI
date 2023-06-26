using Entities.Models;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class LaboratoryRepository : RepositoryBase<Laboratory>, ILaboratoryRepository
    {
        public LaboratoryRepository(RepositoryContext repositoryContext) : base(repositoryContext) 
        { 
        }

        // Get all Labs
        public IEnumerable<Laboratory> GetAllLaboratories(bool trackchanges)
        {
            List<Laboratory> Labs = FindAll(trackchanges).OrderBy(l => l.LaboratoryName).ToList();
            return Labs;
        }

        public Laboratory GetLaboratory(Guid laboratoryId, bool trackchanges)
        {
            var lab = FindByCondition(l => l.Id.Equals(laboratoryId), trackchanges).SingleOrDefault();

            return lab;
        }
    }
}
