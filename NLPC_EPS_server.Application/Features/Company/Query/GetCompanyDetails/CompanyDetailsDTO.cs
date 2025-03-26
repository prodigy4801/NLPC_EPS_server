namespace NLPC_EPS_server.Application.Features.Company.Query.GetCompanyDetails
{
    public class CompanyDetailsDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public int CountryId { get; set; }
        public string StateId { get; set; } = string.Empty;
    }
}
