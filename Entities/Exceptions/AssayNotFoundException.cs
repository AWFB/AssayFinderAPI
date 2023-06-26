namespace Entities.Exceptions
{
    public class AssayNotFoundException : NotFoundException
    {
        public AssayNotFoundException(Guid assayId) 
            : base($"The assay with Id: {assayId} can not be found.")
        {

        }
    }
}
