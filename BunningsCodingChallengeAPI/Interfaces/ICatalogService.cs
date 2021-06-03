using System.Collections.Generic;
using BunningsCodingChallengeAPI.Models;

namespace BunningsCodingChallengeAPI.Interfaces
{
    public interface ICatalogService
    {
        List<CatalogItemModel> GenerateCatalog(CompanyModel company);
    }
}
