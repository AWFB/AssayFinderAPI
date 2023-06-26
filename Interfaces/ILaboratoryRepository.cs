using Entities.Models;

namespace Interfaces
{
    public interface ILaboratoryRepository
    {
        IEnumerable<Laboratory> GetAllLaboratories(bool trackchanges);
    }
}
