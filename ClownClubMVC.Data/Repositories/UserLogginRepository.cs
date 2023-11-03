using ClownClubMVC.Models.loggin;

namespace ClownClub.Data.Repositories
{
	public class UserLogginRepository : IGenericRepository<usersLoggin>
	{
		private readonly DataDBContext _dbContext;
        public UserLogginRepository(DataDBContext context)
        {
			_dbContext = context;
            
        }
		public async Task<bool> Insert(usersLoggin modelo)
		{
			_dbContext.usersLoggin.Add(modelo);
			await _dbContext.SaveChangesAsync();
			return true;
		}
		public async Task<bool> Update(usersLoggin modelo)
		{
			_dbContext.usersLoggin.Update(modelo);
			await _dbContext.SaveChangesAsync();
			return true;
		}
		public async Task<bool> Delete(int id)
		{
			usersLoggin modelo = _dbContext.usersLoggin.First(c => c.id == id);
			_dbContext.usersLoggin.Remove(modelo);
			await _dbContext.SaveChangesAsync();
			return true;
		}
		public async Task<usersLoggin> GetOne(int id)
		{
			return await _dbContext.usersLoggin.FindAsync(id);
		}

		public async Task<IQueryable<usersLoggin>> GetAll()
		{
			IQueryable<usersLoggin> queryUsersLogginSQL = _dbContext.usersLoggin;
			return queryUsersLogginSQL;
		}






	}
}
