using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _repositoryContext;
        private readonly Lazy<ILaboratoryRepository> _laboratoryRepository;
        private readonly Lazy<IAssayRepository> _assayRepository;
        
        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
            _laboratoryRepository = new Lazy<ILaboratoryRepository>(() => new LaboratoryRepository(repositoryContext));
            _assayRepository = new Lazy<IAssayRepository>(() => new AssayRepository(repositoryContext));
        }

        public ILaboratoryRepository Laboratory => _laboratoryRepository.Value;
        public IAssayRepository Assay => _assayRepository.Value;
        public async Task SaveAsync() => await _repositoryContext.SaveChangesAsync();
    }
}
