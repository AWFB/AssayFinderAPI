using AutoMapper;
using Entities.Models;
using Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
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
        private readonly Lazy<IAuthenticationService> _authenticationService;

        public ServiceManager(IRepositoryManager repositoryManager,
                              ILoggerManager logger,
                              IMapper mapper,
                              UserManager<User> userManager,
                              IConfiguration configuration)
        {
            _laboratoryService = new Lazy<ILaboratoryService>(() => new LaboratoryService(repositoryManager, logger, mapper));
            _assayService = new Lazy<IAssayService>(() => new AssayService(repositoryManager, logger, mapper));
            _authenticationService = new Lazy<IAuthenticationService>(() => new AuthenticationService(logger, mapper, userManager, configuration));
        }

        public ILaboratoryService LaboratoryService => _laboratoryService.Value;
        public IAssayService AssayService => _assayService.Value;
        public IAuthenticationService AuthenticationService => _authenticationService.Value;
    }
}
