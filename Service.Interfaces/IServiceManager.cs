﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IServiceManager
    {
        ILaboratoryService LaboratoryService { get; }
        IAssayService AssayService { get; }
        IAuthenticationService AuthenticationService { get; }
    }
}
