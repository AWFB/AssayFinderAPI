using AutoMapper;
using Entities.Exceptions;
using Entities.Models;
using Interfaces;
using Service.Interfaces;
using Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Service
{
    internal sealed class AssayService : IAssayService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public AssayService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        

        public async Task<AssayDTO> GetAssayAsync(Guid laboratoryId, Guid id, bool trackChanges)
        {
            await CheckLabExists(laboratoryId, trackChanges);

            var assay = await GetAssayForLabAndCheckExists(laboratoryId, id, trackChanges);

            var assayDTO = _mapper.Map<AssayDTO>(assay);

            return assayDTO;

        }

        public async Task<IEnumerable<AssayDTO>> GetAssaysAsync(Guid laboratoryId, bool trackChanges)
        {
            await CheckLabExists(laboratoryId, trackChanges);

            var assays = await _repository.Assay.GetAssaysAsync(laboratoryId, trackChanges);
            var assayDTO = _mapper.Map<IEnumerable<AssayDTO>>(assays);

            return assayDTO;

        }

        public async Task<AssayDTO> CreateAssayForLaboratoryAsync(Guid laboratoryId, AssayForCreationDTO assayForCreation, bool trackChanges)
        {
            await CheckLabExists(laboratoryId, trackChanges);

            var assay = _mapper.Map<Assay>(assayForCreation);

            _repository.Assay.CreateAssayForLaboratory(laboratoryId, assay);
            
            await _repository.SaveAsync();

            var assayToReturn = _mapper.Map<AssayDTO>(assay);

            return assayToReturn;
        }

        public async Task DeleteAssayForLaboratoryAsync(Guid laboratoryId, Guid id, bool trackChanges)
        {
            await CheckLabExists(laboratoryId, trackChanges);

            var assayForDelete = await GetAssayForLabAndCheckExists(laboratoryId, id, trackChanges);

            _repository.Assay.DeleteAssay(assayForDelete);
            await _repository.SaveAsync();
        }

        public async Task UpdateAssayForLaboratoryAsync(Guid laboratoryId, Guid id, AssayForUpdateDTO assayForUpdate, 
            bool labTrackChanges, bool assayTrackChanges)
        {
            await CheckLabExists(laboratoryId, labTrackChanges);

            var assay = await GetAssayForLabAndCheckExists(laboratoryId, id, assayTrackChanges);

            _mapper.Map(assayForUpdate, assay);
            await _repository.SaveAsync();
        }

        public async Task<(AssayForUpdateDTO assayToPatch, Assay assayEntity)> GetAssayForPatchAsync(Guid laboratoryId, Guid id, 
            bool labTrackChanges, bool assayTrackChanges)
        {
            await CheckLabExists(laboratoryId, labTrackChanges);

            var assay = await GetAssayForLabAndCheckExists(laboratoryId, id, assayTrackChanges);

            var assayToPatch = _mapper.Map<AssayForUpdateDTO>(assay);

            return (assayToPatch: assayToPatch, assayEntity: assay);
        }

        public async Task SaveChangesForPatchAsync(AssayForUpdateDTO assayToPatch, Assay assay)
        {
            _mapper.Map(assayToPatch, assay);
            await _repository.SaveAsync();
        }

        private async Task CheckLabExists(Guid laboratoryId, bool trackChanges)
        {
            var lab = await _repository.Laboratory.GetLaboratoryAsync(laboratoryId, trackChanges);
            if (lab is null)
            {
                throw new LaboratoryNotFoundException(laboratoryId);
            }
        }

        private async Task<Assay> GetAssayForLabAndCheckExists(Guid laboratoryId, Guid id, bool trackChanges)
        {
            var assay = await _repository.Assay.GetAssayAsync(laboratoryId, id, trackChanges);
            if (assay is null)
            {
                throw new AssayNotFoundException(id);
            }

            return assay;
        }
    }
}
