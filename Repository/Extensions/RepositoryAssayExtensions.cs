using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Extensions
{
    public static class RepositoryAssayExtensions
    {
        public static IQueryable<Assay> Search(this IQueryable<Assay> assays, string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                return assays;
            }

            var lowerCaseSearch = searchTerm.ToLower();

            return assays.Where(a => a.NameOfTest.ToLower().Contains(lowerCaseSearch));
        }
    }
}
