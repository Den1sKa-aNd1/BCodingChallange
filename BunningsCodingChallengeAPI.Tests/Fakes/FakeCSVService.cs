using System.Collections.Generic;
using BunningsCodingChallengeAPI.Interfaces;
using BunningsCodingChallengeAPI.Models;

namespace BunningsCodingChallengeAPI.Tests.Fakes
{
    public class FakeCSVService: ICSVService
    {
        public List<BarcodeModel> GetBarcodesFromCSV(string csvFilePath)
        {
            if (csvFilePath.Contains("barcodesADifferentBarcodes"))
            {
                return new List<BarcodeModel>
                {
                    new BarcodeModel{ Barcode = "barcodeA1.1", SKU = "A1", SupplierID = 1},
                    new BarcodeModel{ Barcode = "barcodeA1.2", SKU = "A1", SupplierID = 1},
                    new BarcodeModel{ Barcode = "barcodeA2.1", SKU = "A2", SupplierID = 1},
                    new BarcodeModel{ Barcode = "barcodeA2.2", SKU = "A2", SupplierID = 1},
                    new BarcodeModel{ Barcode = "barcodeA3.1", SKU = "A3", SupplierID = 1},
                    new BarcodeModel{ Barcode = "barcodeA3.2", SKU = "A3", SupplierID = 1},
                    new BarcodeModel{ Barcode = "barcodeA4.1", SKU = "A4", SupplierID = 1},
                    new BarcodeModel{ Barcode = "barcodeA4.2", SKU = "A4", SupplierID = 1},
                    new BarcodeModel{ Barcode = "barcodeA5.1", SKU = "A5", SupplierID = 1},
                    new BarcodeModel{ Barcode = "barcodeA5.2", SKU = "A5", SupplierID = 1},
                };
            }
            if (csvFilePath.Contains("barcodesBDifferentBarcodes"))
            {
                return new List<BarcodeModel>
                {
                    new BarcodeModel{ Barcode = "barcodeA1.1", SKU = "B1", SupplierID = 1},
                    new BarcodeModel{ Barcode = "barcodeA1.2", SKU = "B1", SupplierID = 1},
                    new BarcodeModel{ Barcode = "barcodeA2.1", SKU = "B2", SupplierID = 1},
                    new BarcodeModel{ Barcode = "barcodeB2.2", SKU = "B2", SupplierID = 1},
                    new BarcodeModel{ Barcode = "barcodeA3.1", SKU = "B3", SupplierID = 1},
                    new BarcodeModel{ Barcode = "barcodeA3.2", SKU = "B3", SupplierID = 1},
                    new BarcodeModel{ Barcode = "barcodeA4.1", SKU = "B4", SupplierID = 1},
                    new BarcodeModel{ Barcode = "barcodeB4.2", SKU = "B4", SupplierID = 1},
                    new BarcodeModel{ Barcode = "barcodeA5.1", SKU = "B5", SupplierID = 1},
                    new BarcodeModel{ Barcode = "barcodeA5.2", SKU = "B5", SupplierID = 1},
                };
            }

            if (csvFilePath.Contains("barcodesASameBarcodes"))
            {
                return new List<BarcodeModel>
                {
                    new BarcodeModel{ Barcode = "barcodeA1.1", SKU = "A1", SupplierID = 1},
                    new BarcodeModel{ Barcode = "barcodeA1.2", SKU = "A1", SupplierID = 1},
                    new BarcodeModel{ Barcode = "barcodeA2.1", SKU = "A2", SupplierID = 1},
                    new BarcodeModel{ Barcode = "barcodeA2.2", SKU = "A2", SupplierID = 1},
                    new BarcodeModel{ Barcode = "barcodeA3.1", SKU = "A3", SupplierID = 1},
                    new BarcodeModel{ Barcode = "barcodeA3.2", SKU = "A3", SupplierID = 1},
                    new BarcodeModel{ Barcode = "barcodeA4.1", SKU = "A4", SupplierID = 1},
                    new BarcodeModel{ Barcode = "barcodeA4.2", SKU = "A4", SupplierID = 1},
                    new BarcodeModel{ Barcode = "barcodeA5.1", SKU = "A5", SupplierID = 1},
                    new BarcodeModel{ Barcode = "barcodeA5.2", SKU = "A5", SupplierID = 1},
                };
            }
            if (csvFilePath.Contains("barcodesBSameBarcodes"))
            {
                return new List<BarcodeModel>
                {
                    new BarcodeModel{ Barcode = "barcodeA1.1", SKU = "B1", SupplierID = 1},
                    new BarcodeModel{ Barcode = "barcodeA1.2", SKU = "B1", SupplierID = 1},
                    new BarcodeModel{ Barcode = "barcodeA2.1", SKU = "B2", SupplierID = 1},
                    new BarcodeModel{ Barcode = "barcodeA2.2", SKU = "B2", SupplierID = 1},
                    new BarcodeModel{ Barcode = "barcodeA3.1", SKU = "B3", SupplierID = 1},
                    new BarcodeModel{ Barcode = "barcodeA3.2", SKU = "B3", SupplierID = 1},
                    new BarcodeModel{ Barcode = "barcodeA4.1", SKU = "B4", SupplierID = 1},
                    new BarcodeModel{ Barcode = "barcodeA4.2", SKU = "B4", SupplierID = 1},
                    new BarcodeModel{ Barcode = "barcodeA5.1", SKU = "B5", SupplierID = 1},
                    new BarcodeModel{ Barcode = "barcodeA5.2", SKU = "B5", SupplierID = 1},
                };
            }

            if (csvFilePath.Contains("barcodesAProductsNotOverlaping"))
            {
                return new List<BarcodeModel>
                {
                    new BarcodeModel{ Barcode = "barcodeA1.1", SKU = "A1", SupplierID = 1},
                    new BarcodeModel{ Barcode = "barcodeA1.2", SKU = "A1", SupplierID = 1},
                    new BarcodeModel{ Barcode = "barcodeA2.1", SKU = "A2", SupplierID = 1},
                    new BarcodeModel{ Barcode = "barcodeA2.2", SKU = "A2", SupplierID = 1},
                    new BarcodeModel{ Barcode = "barcodeA3.1", SKU = "A3", SupplierID = 1},
                    new BarcodeModel{ Barcode = "barcodeA3.2", SKU = "A3", SupplierID = 1},
                };
            }
            if (csvFilePath.Contains("barcodesBProductsNotOverlaping"))
            {
                return new List<BarcodeModel>
                {
                    new BarcodeModel{ Barcode = "barcodeA4.1", SKU = "B4", SupplierID = 1},
                    new BarcodeModel{ Barcode = "barcodeA4.2", SKU = "B4", SupplierID = 1},
                    new BarcodeModel{ Barcode = "barcodeA5.1", SKU = "B5", SupplierID = 1},
                    new BarcodeModel{ Barcode = "barcodeA5.2", SKU = "B5", SupplierID = 1},
                };
            }
            return new List<BarcodeModel>();
        }

        public List<CatalogItemCSVModel> GetCatalogFromCSV(string csvFilePath)
        {
            if (csvFilePath.Contains("catalogA"))
            {
                return new List<CatalogItemCSVModel>()
                {
                    new CatalogItemCSVModel{ Description = "Description A1", SKU = "A1"},
                    new CatalogItemCSVModel{ Description = "Description A2", SKU = "A2"},
                    new CatalogItemCSVModel{ Description = "Description A3", SKU = "A3"},
                    new CatalogItemCSVModel{ Description = "Description A4", SKU = "A4"},
                    new CatalogItemCSVModel{ Description = "Description A5", SKU = "A5"},
                };
            }
            else 
            {
                return new List<CatalogItemCSVModel>()
                {
                    new CatalogItemCSVModel{ Description = "Description B1", SKU = "B1"},
                    new CatalogItemCSVModel{ Description = "Description B2", SKU = "B2"},
                    new CatalogItemCSVModel{ Description = "Description A3", SKU = "A3"},
                    new CatalogItemCSVModel{ Description = "Description B4", SKU = "B4"},
                    new CatalogItemCSVModel{ Description = "Description B5", SKU = "B5"},

                };
            }
        }

        public List<SupplierModel> GetSuppliersFromCSV(string csvFilePath)
        {
            return new List<SupplierModel>();
        }

        public void WriteCatalogToCSV(List<CatalogItemModel> catalog, string csvFilePath)
        {
            //not writing anything for the tests so should just return
            return;
        }
    }
}
