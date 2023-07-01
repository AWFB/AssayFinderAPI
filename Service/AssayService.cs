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
            var lab = await _repository.Laboratory.GetLaboratoryAsync(laboratoryId, trackChanges);
            if (lab is null)
            {
                throw new LaboratoryNotFoundException(laboratoryId);
            }

            var assay = await _repository.Assay.GetAssayAsync(laboratoryId, id, trackChanges);
            if (assay is null)
            {
                throw new AssayNotFoundException(id);
            }

            var assayDTO = _mapper.Map<AssayDTO>(assay);

            return assayDTO;

        }

        public async Task<IEnumerable<AssayDTO>> GetAssaysAsync(Guid laboratoryId, bool trackChanges)
        {
            var lab = await _repository.Laboratory.GetLaboratoryAsync(laboratoryId, trackChanges);
            if (lab is null)
            {
                throw new LaboratoryNotFoundException(laboratoryId);
            }

            var assays = await _repository.Assay.GetAssaysAsync(laboratoryId, trackChanges);
            var assayDTO = _mapper.Map<IEnumerable<AssayDTO>>(assays);

            return assayDTO;

        }

        public async Task<AssayDTO> CreateAssayForLaboratoryAsync(Guid laboratoryId, AssayForCreationDTO assayForCreation, bool trackChanges)
        {
            var lab = await _repository.Laboratory.GetLaboratoryAsync(laboratoryId, trackChanges);
            if (lab is null)
            {
                throw new LaboratoryNotFoundException(laboratoryId);
            }

            var assay = _mapper.Map<Assay>(assayForCreation);

            _repository.Assay.CreateAssayForLaboratory(laboratoryId, assay);
            await _repository.SaveAsync();

            var assayToReturn = _mapper.Map<AssayDTO>(assay);

            return assayToReturn;
        }

        public async Task DeleteAssayForLaboratoryAsync(Guid laboratoryId, Guid id, bool trackChanges)
        {
            var lab = await _repository.Laboratory.GetLaboratoryAsync(laboratoryId, trackChanges);
            if (lab is null)
            {
                throw new LaboratoryNotFoundException(laboratoryId);
            }

            var assayForLab = await _repository.Assay.GetAssayAsync(laboratoryId, id, trackChanges);
            if (assayForLab is null)
            {
                throw new AssayNotFoundException(id);
            }

            _repository.Assay.DeleteAssay(assayForLab);
            await _repository.SaveAsync();
        }

        public async Task UpdateAssayForLaboratoryAsync(Guid laboratoryId, Guid id, AssayForUpdateDTO assayForUpdate, 
            bool labTrackChanges, bool assayTrackChanges)
        {
            var lab = await _repository.Laboratory.GetLaboratoryAsync(laboratoryId, labTrackChanges);
            if (lab is null)
            {
                throw new LaboratoryNotFoundException(laboratoryId);
            }

            var assay = await _repository.Assay.GetAssayAsync(laboratoryId, id, assayTrackChanges);
            if (assay is null)
            {
                throw new AssayNotFoundException(id);
            }

            _mapper.Map(assayForUpdate, assay);
            await _repository.SaveAsync();
        }

        public async Task<(AssayForUpdateDTO assayToPatch, Assay assayEntity)> GetAssayForPatchAsync(Guid laboratoryId, Guid id, 
            bool labTrackChanges, bool assayTrackChanges)
        {
            var lab = await _repository.Laboratory.GetLaboratoryAsync(laboratoryId, labTrackChanges);
            if (lab is null)
            {
                throw new LaboratoryNotFoundException(laboratoryId);
            }

            var assayEntity = await _repository.Assay.GetAssayAsync(laboratoryId, id, assayTrackChanges);
            if (assayEntity is null)
            {
                throw new AssayNotFoundException(id);
            }

            var assayToPatch = _mapper.Map<AssayForUpdateDTO>(assayEntity);

            return (assayToPatch: assayToPatch, assayEntity: assayEntity);
        }

        public async Task SaveChangesForPatchAsync(AssayForUpdateDTO assayToPatch, Assay assay)
        {
            _mapper.Map(assayToPatch, assay);
            await _repository.SaveAsync();
        }
    }
}
