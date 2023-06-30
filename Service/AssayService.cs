﻿using AutoMapper;
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

        

        public AssayDTO GetAssay(Guid laboratoryId, Guid id, bool trackChanges)
        {
            var lab = _repository.Laboratory.GetLaboratory(laboratoryId, trackChanges);
            if (lab is null)
            {
                throw new LaboratoryNotFoundException(laboratoryId);
            }

            var assay = _repository.Assay.GetAssay(laboratoryId, id, trackChanges);
            if (assay is null)
            {
                throw new AssayNotFoundException(id);
            }

            var assayDTO = _mapper.Map<AssayDTO>(assay);

            return assayDTO;

        }

        public IEnumerable<AssayDTO> GetAssays(Guid laboratoryId, bool trackChanges)
        {
            var lab = _repository.Laboratory.GetLaboratory(laboratoryId, trackChanges);
            if (lab is null)
            {
                throw new LaboratoryNotFoundException(laboratoryId);
            }

            var assays = _repository.Assay.GetAssays(laboratoryId, trackChanges);
            var assayDTO = _mapper.Map<IEnumerable<AssayDTO>>(assays);

            return assayDTO;

        }

        public AssayDTO CreateAssayForLaboratory(Guid laboratoryId, AssayForCreationDTO assayForCreation, bool trackChanges)
        {
            var lab = _repository.Laboratory.GetLaboratory(laboratoryId, trackChanges);
            if (lab is null)
            {
                throw new LaboratoryNotFoundException(laboratoryId);
            }

            var assay = _mapper.Map<Assay>(assayForCreation);

            _repository.Assay.CreateAssayForLaboratory(laboratoryId, assay);
            _repository.Save();

            var assayToReturn = _mapper.Map<AssayDTO>(assay);

            return assayToReturn;
        }

        public void DeleteAssayForLaboratory(Guid laboratoryId, Guid id, bool trackChanges)
        {
            var lab = _repository.Laboratory.GetLaboratory(laboratoryId, trackChanges);
            if (lab is null)
            {
                throw new LaboratoryNotFoundException(laboratoryId);
            }

            var assayForLab = _repository.Assay.GetAssay(laboratoryId, id, trackChanges);
            if (assayForLab is null)
            {
                throw new AssayNotFoundException(id);
            }

            _repository.Assay.DeleteAssay(assayForLab);
            _repository.Save();
        }

        public void UpdateAssayForLaboratory(Guid laboratoryId, Guid id, AssayForUpdateDTO assayForUpdate, 
            bool labTrackChanges, bool assayTrackChanges)
        {
            var lab = _repository.Laboratory.GetLaboratory(laboratoryId, labTrackChanges);
            if (lab is null)
            {
                throw new LaboratoryNotFoundException(laboratoryId);
            }

            var assay = _repository.Assay.GetAssay(laboratoryId, id, assayTrackChanges);
            if (assay is null)
            {
                throw new AssayNotFoundException(id);
            }

            _mapper.Map(assayForUpdate, assay);
            _repository.Save();
        }

        public (AssayForUpdateDTO assayToPatch, Assay assayEntity) GetAssayForPatch(Guid laboratoryId, Guid id, bool labTrackChanges, bool assayTrackChanges)
        {
            var lab = _repository.Laboratory.GetLaboratory(laboratoryId, labTrackChanges);
            if (lab is null)
            {
                throw new LaboratoryNotFoundException(laboratoryId);
            }

            var assayEntity = _repository.Assay.GetAssay(laboratoryId, id, assayTrackChanges);
            if (assayEntity is null)
            {
                throw new AssayNotFoundException(id);
            }

            var assayToPatch = _mapper.Map<AssayForUpdateDTO>(assayEntity);

            return (assayToPatch: assayToPatch, assayEntity: assayEntity);
        }

        public void SaveChangesForPatch(AssayForUpdateDTO assayToPatch, Assay assay)
        {
            _mapper.Map(assayToPatch, assay);
            _repository.Save();
        }
    }
}
