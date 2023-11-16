using ClownClubMVC.Models.loggin;

namespace ClownClubMVC.Data.Repositories.Login
{
    public class PasswordLogginRepository : IGenericRepository<passwordLoggin>
    {
        private readonly DataDBContext _dbContext;
        public PasswordLogginRepository(DataDBContext context)
        {
            _dbContext = context;

        }
        public async Task<bool> Insert(passwordLoggin modelo)
        {
            _dbContext.passwordLoggin.Add(modelo);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        public async Task<bool> Update(passwordLoggin modelo)
        {
            _dbContext.passwordLoggin.Update(modelo);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        public async Task<bool> Delete(int id)
        {
            passwordLoggin modelo = _dbContext.passwordLoggin.First(c => c.id == id);
            _dbContext.passwordLoggin.Remove(modelo);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        public async Task<passwordLoggin> GetOne(int id)
        {
            return await _dbContext.passwordLoggin.FindAsync(id);
        }

        public async Task<IQueryable<passwordLoggin>> GetAll()
        {
            IQueryable<passwordLoggin> queryPasswordLogginSQL = _dbContext.passwordLoggin;
            return queryPasswordLogginSQL;
        }
    }
}
