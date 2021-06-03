using BunningsCodingChallengeAPI.Models;

namespace BunningsCodingChallengeAPI.Interfaces
{
    public interface ICompanyService
    {
        CompanyModel MergeTwoCompanies(CompanyModel companyModelA, CompanyModel companyModelB);
        CompanyModel GetCompany(string companyName);
    }
}
