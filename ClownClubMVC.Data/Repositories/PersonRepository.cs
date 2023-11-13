using ClownClubMVC.Models.loggin;
using ClownClubMVC.Models.person;

namespace ClownClubMVC.Data.Repositories
{
    public class PersonRepository : IGenericRepository<person>
    {
        private readonly DataDBContext _dbContext;
        public PersonRepository(DataDBContext context)
        {
            _dbContext = context;

        }
        public async Task<bool> Insert(person modelo)
        {
            _dbContext.person.Add(modelo);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        public async Task<bool> Update(person modelo)
        {
            _dbContext.person.Update(modelo);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        public async Task<bool> Delete(int id)
        {
            person modelo = _dbContext.person.First(c => c.id == id);
            _dbContext.person.Remove(modelo);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        public async Task<person> GetOne(int id)
        {
            return await _dbContext.person.FindAsync(id);
        }

        public async Task<IQueryable<person>> GetAll()
        {
            IQueryable<person> queryUsersLogginSQL = _dbContext.person;
            return queryUsersLogginSQL;
        }
    }
}
