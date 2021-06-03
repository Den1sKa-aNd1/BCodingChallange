using System;
using System.Collections.Generic;
using System.Linq;
using BunningsCodingChallengeAPI.Interfaces;
using BunningsCodingChallengeAPI.Models;

namespace BunningsCodingChallengeAPI.Services
{
    public class CatalogService: ICatalogService
    {
        private readonly ICSVService _csvService;
        public CatalogService(ICSVService csvService)
        {
            _csvService = csvService;
        }
        public List<CatalogItemModel> GenerateCatalog(CompanyModel company)
        {
            var catalog = company.Catalog.OrderBy(item => item.SKU).ToList();
            _csvService.WriteCatalogToCSV(catalog, $"./OutputFiles/result_output_{DateTime.Now.Ticks}.csv");
            return catalog;
        }
    }
}
