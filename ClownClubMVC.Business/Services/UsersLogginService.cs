using ClownClubMVC.Data.Repositories;
using ClownClubMVC.Models.loggin;

namespace ClownClubMVC.Business.Services
{
	public class UsersLogginService : IUsersLogginService
	{
		private readonly IGenericRepository<usersLoggin> _usersLogRepo;
		public UsersLogginService(IGenericRepository<usersLoggin> usersLogRepo)
        {
            _usersLogRepo = usersLogRepo;
        }
        public async Task<bool> Insert(usersLoggin modelo)
		{
			return await _usersLogRepo.Insert(modelo);
		}
		public async Task<bool> Update(usersLoggin modelo)
		{
			return await _usersLogRepo.Update(modelo);
		}
		public async Task<bool> Delete(int id)
		{
			return await _usersLogRepo.Delete(id);
		}
		public async Task<usersLoggin> GetOne(int id)
		{
			return await _usersLogRepo.GetOne(id);
		}
		public async Task<usersLoggin> GetOneByName(string name)
		{
			IQueryable<usersLoggin> queryUsersLogginSQL = await _usersLogRepo.GetAll();
			usersLoggin usersLoggin = queryUsersLogginSQL.Where(c=> c.name == name).FirstOrDefault();
			return usersLoggin;
		}
		public async Task<IQueryable<usersLoggin>> GetAll()
		{
			return await _usersLogRepo.GetAll();
		}
        public async Task<usersLoggin> GetUserByEmail(string email)
        {
            IQueryable<usersLoggin> queryUsersLogginSQL = await _usersLogRepo.GetAll();
            usersLoggin usersLoggin = queryUsersLogginSQL.Where(c => c.email == email).FirstOrDefault();
            return usersLoggin;
        }
    }
}
