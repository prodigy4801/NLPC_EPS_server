using Microsoft.EntityFrameworkCore;
using NLPC_EPS_server.Application.Contracts.Persistence;
using NLPC_EPS_server.Application.Exceptions;
using NLPC_EPS_server.DAL;
using NLPC_EPS_server.Persistence.DataAccess;
using NLPC_EPS_server.Persistence.Repository;

namespace NLPC_EPS_server.Persistence.Repositories
{
    public class MemberProfileRepository : GenericRepository<MemberProfile>, IMemberProfileRepository
    {
        public MemberProfileRepository(EPSDatabaseContext context) : base(context)
        {
        }

        public async Task<bool> DeactivateMember(int Id)
        {
            var getMember = await _context.MemberProfiles.AsNoTracking().Where(x => x.Id == Id).SingleOrDefaultAsync();
            if(getMember == null)
            {
                throw new BadRequestExceptions("Failed to retrieve Member Profile.");
            }
            if(getMember.DeleteStatus)
            {
                throw new BadRequestExceptions("Member Profile has been Deactivated Previously.");
            }
            getMember.DeleteStatus = true;
            getMember.DateDeleted = DateTime.UtcNow;
            getMember.DateModified = DateTime.UtcNow;

            _context.Entry(getMember).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Exist(int Id)
        {
            return await _context.MemberProfiles.AnyAsync(x => x.Id == Id);
        }

        public async Task<bool> ExistByEmail(string email)
        {
            return await _context.MemberProfiles.AnyAsync(x => x.Email == email);
        }

        public async Task<List<MemberProfile>> GetActive()
        {
            return await _context.Set<MemberProfile>().AsNoTracking().Where(x => x.DeleteStatus == false).ToListAsync();
        }

        public async Task<MemberProfile> GetActiveById(int Id)
        {
            return await _context.Set<MemberProfile>()
                .AsNoTracking()
                .SingleOrDefaultAsync(q => q.Id == Id && q.DeleteStatus == false);
        }
    }
}
