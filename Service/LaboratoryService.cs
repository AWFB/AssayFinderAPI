using AutoMapper;
using Interfaces;
using Service.Interfaces;
using Shared.DTOs;

namespace Service
{
    internal sealed class LaboratoryService : ILaboratoryService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public LaboratoryService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        public IEnumerable<LaboratoryDTO> GetAllLaboratories(bool trackChanges)
        {
            var labs = _repository.Laboratory.GetAllLaboratories(trackChanges);
            var labsDto = _mapper.Map<IEnumerable<LaboratoryDTO>>(labs);

            return labsDto;
        }
    }
}
