namespace NLPC_EPS_server.Application.Features.BenefitProcess.Query.GetBenefitProcessDetails
{
    public class BenefitProcessDetailsDTO
    {
        public int Id { get; set; }
        public string ProcessCode { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
