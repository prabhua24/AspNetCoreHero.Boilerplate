using AspNetCoreHero.Abstractions.Domain;
namespace AspNetCoreHero.Boilerplate.Domain.Entities.Catalog
{
    public class Driver : AuditableEntity
    {

        public string Name { get; set; }
        public string Age { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public decimal Pincode { get; set; }
       
    }
}