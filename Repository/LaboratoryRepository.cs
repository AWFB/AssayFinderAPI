﻿using Entities.Models;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class LaboratoryRepository : RepositoryBase<Laboratory>, ILaboratoryRepository
    {
        public LaboratoryRepository(RepositoryContext repositoryContext) : base(repositoryContext) 
        { 
        }
    }
}