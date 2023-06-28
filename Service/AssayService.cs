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
    }
}
