using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using BunningsCodingChallengeAPI.Models;
using BunningsCodingChallengeAPI.Tests.Fixtures;
using BunningsCodingChallengeAPI.Tests.Infrastructure;
using FluentAssertions;
using Newtonsoft.Json;
using Xunit;

namespace BunningsCodingChallengeAPI.Tests.Controllers
{
    [Collection(TestConstants.TestCollection)]
    public class CatalogControllerTests
    {
        private readonly BunningsCodingChallengeFixture _fixture;
        public CatalogControllerTests(BunningsCodingChallengeFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public async Task When_Barcodes_Not_Overlaping_Completely_Should_Take_SKUs_From_Both_Companies()
        {
            var request = new MergeCatalogsRequest
            {
                CompanyNameA = "ADifferentBarcodes",
                CompanyNameB = "BDifferentBarcodes"
            };

            var expectedResponse = new List<CatalogItemModel>
            {
                new CatalogItemModel{CompanyLetter = "ADifferentBarcodes", Description = "Description A1", SKU = "A1"},
                new CatalogItemModel{CompanyLetter = "ADifferentBarcodes", Description = "Description A2", SKU = "A2"},
                new CatalogItemModel{CompanyLetter = "BDifferentBarcodes", Description = "Description B2", SKU = "B2"},
                new CatalogItemModel{CompanyLetter = "ADifferentBarcodes", Description = "Description A3", SKU = "A3"},
                new CatalogItemModel{CompanyLetter = "ADifferentBarcodes", Description = "Description A4", SKU = "A4"},
                new CatalogItemModel{CompanyLetter = "BDifferentBarcodes", Description = "Description B4", SKU = "B4"},
                new CatalogItemModel{CompanyLetter = "ADifferentBarcodes", Description = "Description A5", SKU = "A5"},

            }.OrderBy(item => item.SKU);
            var response = await _fixture.Client.PostAsync("/api/v1/catalog/MergeCatalogs",
                new StringContent(JsonConvert.SerializeObject(request), System.Text.Encoding.UTF8, "application/json"));
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<List<CatalogItemModel>>(content);
            result.Should().BeEquivalentTo(expectedResponse);
        }

        [Fact]
        public async Task When_Barcodes_In_A_Company_Cover_All_Barcode_In_B_Should_Take_Data_Only_From_A()
        {
            var request = new MergeCatalogsRequest
            {
                CompanyNameA = "ASameBarcodes",
                CompanyNameB = "BSameBarcodes"
            };

            var expectedResponse = new List<CatalogItemModel>
            {
                new CatalogItemModel{CompanyLetter = "ASameBarcodes", Description = "Description A1", SKU = "A1"},
                new CatalogItemModel{CompanyLetter = "ASameBarcodes", Description = "Description A2", SKU = "A2"},
                new CatalogItemModel{CompanyLetter = "ASameBarcodes", Description = "Description A3", SKU = "A3"},
                new CatalogItemModel{CompanyLetter = "ASameBarcodes", Description = "Description A4", SKU = "A4"},
                new CatalogItemModel{CompanyLetter = "ASameBarcodes", Description = "Description A5", SKU = "A5"},

            }.OrderBy(item => item.SKU);
            var response = await _fixture.Client.PostAsync("/api/v1/catalog/MergeCatalogs",
                new StringContent(JsonConvert.SerializeObject(request), System.Text.Encoding.UTF8, "application/json"));
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<List<CatalogItemModel>>(content);
            result.Should().BeEquivalentTo(expectedResponse);
        }

        [Fact]
        public async Task When_Products_Do_Not_Overlap_Should_Take_From_Both_Companies()
        {
            var request = new MergeCatalogsRequest
            {
                CompanyNameA = "AProductsNotOverlaping",
                CompanyNameB = "BProductsNotOverlaping"
            };

            var expectedResponse = new List<CatalogItemModel>
            {
                new CatalogItemModel{CompanyLetter = "AProductsNotOverlaping", Description = "Description A1", SKU = "A1"},
                new CatalogItemModel{CompanyLetter = "AProductsNotOverlaping", Description = "Description A2", SKU = "A2"},
                new CatalogItemModel{CompanyLetter = "AProductsNotOverlaping", Description = "Description A3", SKU = "A3"},
                new CatalogItemModel{CompanyLetter = "BProductsNotOverlaping", Description = "Description B4", SKU = "B4"},
                new CatalogItemModel{CompanyLetter = "BProductsNotOverlaping", Description = "Description B5", SKU = "B5"},

            }.OrderBy(item => item.SKU);
            var response = await _fixture.Client.PostAsync("/api/v1/catalog/MergeCatalogs",
                new StringContent(JsonConvert.SerializeObject(request), System.Text.Encoding.UTF8, "application/json"));
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<List<CatalogItemModel>>(content);
            result.Should().BeEquivalentTo(expectedResponse);
        }
    }
}
