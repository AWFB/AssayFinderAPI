using Interfaces;
using Service.Interfaces;

namespace Service
{
    internal sealed class LaboratoryService : ILaboratoryService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;

        public LaboratoryService(IRepositoryManager repository, ILoggerManager logger)
        {
            _repository = repository;
            _logger = logger;
        }
    }
}
