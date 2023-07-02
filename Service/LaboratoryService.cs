using AutoMapper;
using Entities.Exceptions;
using Entities.Models;
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

        // Get all Laboratories
        public async Task<IEnumerable<LaboratoryDTO>> GetAllLaboratoriesAsync(bool trackChanges)
        {
            var labs = await _repository.Laboratory.GetAllLaboratoriesAsync(trackChanges);
            var labsDto = _mapper.Map<IEnumerable<LaboratoryDTO>>(labs);

            return labsDto;
        }

        // Get single laboratory by ID
        public async Task<LaboratoryDTO> GetLaboratoryAsync(Guid id, bool trackChanges)
        {
            var lab = await GetLabAndCheckItExists(id, trackChanges);

            var laboratoryDto = _mapper.Map<LaboratoryDTO>(lab);
            
            return laboratoryDto;
        }

        // Create a laboratory
        public async Task<LaboratoryDTO> CreateLaboratoryAsync(LaboratoryForCreationDTO laboratory)
        {
            var lab = _mapper.Map<Laboratory>(laboratory);

            _repository.Laboratory.CreateLaboratory(lab);
            await _repository.SaveAsync();

            var labToReturn = _mapper.Map<LaboratoryDTO>(lab);

            return labToReturn;
        }

        public async Task DeleteLaboratoryAsync(Guid laboratoryId, bool trackChanges)
        {
            var lab = await GetLabAndCheckItExists(laboratoryId, trackChanges);

            _repository.Laboratory.DeleteLaboratory(lab);
            await _repository.SaveAsync();
        }

        public async Task UpdateLaboratoryAsync(Guid laboratoryId, LaboratoryForUpdateDTO laboratoryForUpdate, bool trackChanges)
        {
            var lab = await GetLabAndCheckItExists(laboratoryId, trackChanges);

            _mapper.Map(laboratoryForUpdate, lab);
            await _repository.SaveAsync();
        }



        private async Task<Laboratory> GetLabAndCheckItExists(Guid id, bool trackChanges)
        {
            var lab = await _repository.Laboratory.GetLaboratoryAsync(id, trackChanges);
            if (lab is null)
            {
                throw new LaboratoryNotFoundException(id);
            }
            return lab;

        }
    }
}
