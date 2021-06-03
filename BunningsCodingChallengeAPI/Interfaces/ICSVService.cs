using System.Collections.Generic;
using BunningsCodingChallengeAPI.Models;

namespace BunningsCodingChallengeAPI.Interfaces
{
    public interface ICSVService
    {
        List<CatalogItemCSVModel> GetCatalogFromCSV(string csvFilePath);
        List<BarcodeModel> GetBarcodesFromCSV(string csvFilePath);
        List<SupplierModel> GetSuppliersFromCSV(string csvFilePath);

        void WriteCatalogToCSV(List<CatalogItemModel> catalog, string csvFilePath);
    }
}
