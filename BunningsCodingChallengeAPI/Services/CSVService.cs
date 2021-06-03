using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using BunningsCodingChallengeAPI.Interfaces;
using BunningsCodingChallengeAPI.Models;
using CsvHelper;

namespace BunningsCodingChallengeAPI.Services
{
    public class CSVService: ICSVService
    {
        public List<BarcodeModel> GetBarcodesFromCSV(string csvFilePath)
        {
            using (var reader = new StreamReader(csvFilePath))
            {
                using (var csvReader = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    return csvReader.GetRecords<BarcodeModel>().ToList();
                }
            }
        }

        public List<CatalogItemCSVModel> GetCatalogFromCSV(string csvFilePath)
        {
            using (var reader = new StreamReader(csvFilePath))
            {
                using (var csvReader = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    return csvReader.GetRecords<CatalogItemCSVModel>().ToList();
                }
            }
        }

        public List<SupplierModel> GetSuppliersFromCSV(string csvFilePath)
        {
            using (var reader = new StreamReader(csvFilePath))
            {
                using (var csvReader = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    return csvReader.GetRecords<SupplierModel>().ToList();
                }
            }
        }

        public void WriteCatalogToCSV(List<CatalogItemModel> catalog, string csvFilePath)
        {
            using (var writer = new StreamWriter(csvFilePath))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(MapCatalogItemToCatalogItemCSVOutput(catalog));
            }
        }

        private IEnumerable<CatalogItemCSVOutputModel> MapCatalogItemToCatalogItemCSVOutput(List<CatalogItemModel> catalog)
        {
            var outputModel = new List<CatalogItemCSVOutputModel>();
            foreach(var item in catalog)
            {
                outputModel.Add(new CatalogItemCSVOutputModel { Description = item.Description, SKU = item.SKU, Source = item.CompanyLetter});
            }
            return outputModel;
        }
    }
}
