using Microsoft.AspNetCore.Mvc.Rendering;

namespace AspNetCoreHero.Boilerplate.Web.Areas.Catalog.Models
{
    public class VendorViewModel
    {
        public int Id { get; set; }
        public string MobileNumber { get; set; }
        public string Name { get; set; }
        public SelectList Gander { get; set; }
        public string Age { get; set; }
        public string CompanyName { get; set; }
        public int Pincode { get; set; }
        public string Address { get; set; }
    }
}
