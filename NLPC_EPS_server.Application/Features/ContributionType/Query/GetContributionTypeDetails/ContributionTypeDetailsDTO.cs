namespace NLPC_EPS_server.Application.Features.ContributionType.Query.GetContributionTypeDetails
{
    public class ContributionTypeDetailsDTO
    {
        public int Id { get; set; }
        public string Type { get; set; } = string.Empty;
        public string? Description { get; set; }
    }
}
