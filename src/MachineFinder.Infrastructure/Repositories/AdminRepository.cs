using MachineFinder.Application.Contracts.Persistence;
using MachineFinder.Domain;
using MachineFinder.Infrastructure.Persistence.Data;

namespace MachineFinder.Infrastructure.Repositories
{
    public class AdminRepository : RepositoryBase, IAdminRepository
    {
        public AdminRepository(AppDBContext context, SessionStorage? sessionStorage) : base(context, sessionStorage)
        {
        }
    }
}
