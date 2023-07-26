namespace AspNetCoreHero.Boilerplate.Infrastructure.CacheKeys
{
    public static class DriverCacheKeys
    {
        public static string ListKey => "VendorList";

        public static string SelectListKey => "VendorSelectList";

        public static string GetKey(int VendorId) => $"Vendor-{VendorId}";

        public static string GetDetailsKey(int VendorId) => $"VendortDetails-{VendorId}";
    }
}