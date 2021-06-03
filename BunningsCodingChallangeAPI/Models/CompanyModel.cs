using System.Collections.Generic;

namespace BunningsCodingChallengeAPI.Models
{
    public class CompanyModel
    {
        public List<CatalogItemModel> Catalog { get; set; }
        public List<BarcodeModel> Barcodes { get; set; }
        public List<SupplierModel> Suppliers { get; set; }
    }
}
