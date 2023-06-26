using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration
{
    public class LaboratoryConfiguration : IEntityTypeConfiguration<Laboratory>
    {
        public void Configure(EntityTypeBuilder<Laboratory> builder)
        {
            builder.HasData
                (
                    new Laboratory
                    {
                        Id = new Guid("A9F068C1-972A-4708-A52F-DD1EDAA6ABB6"),
                        LaboratoryName = "PineWheat Trust",
                        Address = "1 Hospital Way",
                        City = "Liverpool",
                        Country = "England",
                        Postcode = "LV1 2BZ",
                        ContactEmail = "lab@PineWheat.com",
                        ContactName = "William Riker",
                        ContactNumber = "0112 587 326"
                    },
                    new Laboratory
                    {
                        Id = new Guid("BCC94FB7-DF87-447E-A563-41255CF856C4"),
                        LaboratoryName = "BirchBarley Trust",
                        Address = "1 Caring Street",
                        City = "Derby",
                        Country = "England",
                        Postcode = "DE1 9BZ",
                        ContactEmail = "lab@BirchBarley.com",
                        ContactName = "Bev Crusher",
                        ContactNumber = "01332 222 123"
                    }
                );
        }
    }
}
