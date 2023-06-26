using AutoMapper;
using Interfaces;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public sealed class ServiceManager : IServiceManager
    {
        private readonly Lazy<ILaboratoryService> _laboratoryService;
        private readonly Lazy<IAssayService> _assayService;

        public ServiceManager(IRepositoryManager repositoryManager, ILoggerManager logger, IMapper mapper)
        {
            _laboratoryService = new Lazy<ILaboratoryService>(() => new LaboratoryService(repositoryManager, logger, mapper));
            _assayService = new Lazy<IAssayService>(() => new AssayService(repositoryManager, logger, mapper));
        }

        public ILaboratoryService LaboratoryService => _laboratoryService.Value;
        public IAssayService AssayService => _assayService.Value;
    }
}
