using NLPC_EPS_server.DAL;

namespace NLPC_EPS_server.Application.Contracts.Persistence
{
    public interface ICompanyRepository : IGenericRepository<Company>
    {
        Task<bool> Exist(int id);
        Task<bool> ExistByName(string name);
    }
}
