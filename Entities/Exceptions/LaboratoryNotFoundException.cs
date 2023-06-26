namespace Entities.Exceptions
{
    public sealed class LaboratoryNotFoundException : NotFoundException
    {
        public LaboratoryNotFoundException(Guid laboratoryId)
            : base($"The laboratory with the ID: {laboratoryId} was not found.")
        {

        }
    }
}
