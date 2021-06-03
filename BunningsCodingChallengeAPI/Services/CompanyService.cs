using System.Collections.Generic;
using System.Linq;
using BunningsCodingChallengeAPI.Interfaces;
using BunningsCodingChallengeAPI.Models;

namespace BunningsCodingChallengeAPI.Services
{
    public class CompanyService: ICompanyService
    {
        private readonly ICSVService _csvService;
        public CompanyService(ICSVService csvService)
        {
            _csvService = csvService;
        }

        public CompanyModel GetCompany(string companyLetter = "?")
        {
            var catalog = _csvService.GetCatalogFromCSV($"./InputFiles/catalog{companyLetter}.csv");
            
            var barcodes = _csvService.GetBarcodesFromCSV($"./InputFiles/barcodes{companyLetter}.csv");
            var suppliers = _csvService.GetSuppliersFromCSV($"./InputFiles/suppliers{companyLetter}.csv");
            var company = MapCompanyFromCSVModels(catalog, barcodes, suppliers, companyLetter);
            return company;
        }

        private static CompanyModel MapCompanyFromCSVModels(List<CatalogItemCSVModel> catalogCSV, List<BarcodeModel> barcodes, List<SupplierModel> suppliers, string companyLetter)
        {
            List<CatalogItemModel> catalog = new List<CatalogItemModel>();
            foreach (var item in catalogCSV)
            {
                catalog.Add(new CatalogItemModel
                {
                    CompanyLetter = companyLetter,
                    Description = item.Description,
                    SKU = item.SKU

                });
            };
            return new CompanyModel
            {
                Barcodes = barcodes,
                Catalog = catalog,
                Suppliers = suppliers
            };
        }

        public CompanyModel MergeTwoCompanies(CompanyModel companyModelA, CompanyModel companyModelB)
        {
            var mergedBarcodes = companyModelA.Barcodes.Union(companyModelB.Barcodes);

            var mergedCatalog = GenerateCatalogFromMergedBarcodes(mergedBarcodes, companyModelA.Catalog, companyModelB.Catalog);

            //should clean up barcodes after merge by selecting barcodes related to new Catalog SKUs

            //should clean up suppliers after merge by selecting supliers related to cleaned up barcodes

            return new CompanyModel
            {
                Barcodes = mergedBarcodes.ToList(),
                Catalog = mergedCatalog,
                Suppliers = companyModelA.Suppliers.Union(companyModelB.Suppliers).ToList()
            };
        }

        private static List<CatalogItemModel> GenerateCatalogFromMergedBarcodes(
            IEnumerable<BarcodeModel> mergedBarcodes, List<CatalogItemModel> catalogA,List<CatalogItemModel> catalogB )
        {
            var filterBarcodes = new List<BarcodeModel>();
            var mergedCatalog = catalogA.Union(catalogB);
            foreach (var groupedBarcodes in mergedBarcodes.GroupBy(mb => mb.Barcode))
            {
                var selectedBarcode = mergedBarcodes.Where(mb => mb.Barcode.Equals(groupedBarcodes.Key)).FirstOrDefault();
                filterBarcodes.Add(selectedBarcode);
            }
            var selectedCatalogItems = new List<CatalogItemModel>();
            foreach (var groupedBarcodes in filterBarcodes.GroupBy(mb => mb.SKU))
            {
                var selectedBarcode = filterBarcodes.Where(fb => fb.SKU.Equals(groupedBarcodes.Key)).FirstOrDefault();
                var catalogItem = mergedCatalog.Where(mc => mc.SKU.Equals(selectedBarcode.SKU)).FirstOrDefault();
                selectedCatalogItems.Add(catalogItem);
            }
            return selectedCatalogItems;
        }
    }
}
