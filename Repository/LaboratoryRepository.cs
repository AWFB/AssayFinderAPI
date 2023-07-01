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
    public class LaboratoryRepository : RepositoryBase<Laboratory>, ILaboratoryRepository
    {
        public LaboratoryRepository(RepositoryContext repositoryContext) : base(repositoryContext) 
        { 
        }


        // Get all Labs
        public async Task<IEnumerable<Laboratory>> GetAllLaboratoriesAsync(bool trackchanges)
        {
            List<Laboratory> Labs = await FindAll(trackchanges)
                .OrderBy(l => l.LaboratoryName)
                .ToListAsync();
            return Labs;
        }

        // Get a specific laboratory
        public async Task<Laboratory> GetLaboratoryAsync(Guid laboratoryId, bool trackchanges)
        {
            var lab = await FindByCondition(l => l.Id.Equals(laboratoryId), trackchanges).SingleOrDefaultAsync();

            return lab;
        }

        // Create a laboratory
        public void CreateLaboratory(Laboratory laboratory)
        {
            Create(laboratory);
        }

        public void DeleteLaboratory(Laboratory laboratory)
        {
            Delete(laboratory);
        }
    }
}
