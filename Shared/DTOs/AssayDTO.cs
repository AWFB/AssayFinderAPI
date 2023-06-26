namespace Shared.DTOs
{
    public record AssayDTO
    {
        public Guid AssayId { get; init; }
        public string? NameOfTest { get; init; }
        public string? SampleType { get; init; }
        public string? EmailAddress { get; init; }
    }
}
