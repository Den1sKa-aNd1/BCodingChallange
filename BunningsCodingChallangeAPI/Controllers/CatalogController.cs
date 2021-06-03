using BunningsCodingChallengeAPI.Interfaces;
using BunningsCodingChallengeAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace BunningsCodingChallengeAPI.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CatalogController: ControllerBase
    {
        private readonly ICompanyService _companyService;
        private readonly ICatalogService _catalogService;
        public CatalogController(ICompanyService companyService, ICatalogService catalogService)
        {
            _companyService = companyService;
            _catalogService = catalogService;
        }

        [HttpPost("MergeCatalogs")]
        public IActionResult MergeCatalogs([FromBody]MergeCatalogsRequest request)
        {
            var companyA = _companyService.GetCompany(request.CompanyNameA);
            var companyB = _companyService.GetCompany(request.CompanyNameB);
            var mergedCompany = _companyService.MergeTwoCompanies(companyA, companyB);
            var mergedCatalog = _catalogService.GenerateCatalog(mergedCompany);
            return Ok(mergedCatalog);
        }
    }
}
