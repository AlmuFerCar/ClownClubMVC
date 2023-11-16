using ClownClubMVC.Models.content;

namespace ClownClubMVC.Data.Repositories.Content
{
    public class FilmRepository : IGenericRepository<film>
    {
        private readonly DataDBContext _dbContext;
        public FilmRepository(DataDBContext context)
        {
            _dbContext = context;
        }
        public async Task<bool> Insert(film modelo)
        {
            _dbContext.film.Add(modelo);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        public async Task<bool> Update(film modelo)
        {
            _dbContext.film.Update(modelo);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        public async Task<bool> Delete(int id)
        {
            film modelo = _dbContext.film.First(c => c.id == id);
            _dbContext.film.Remove(modelo);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        public async Task<film> GetOne(int id)
        {
            return await _dbContext.film.FindAsync(id);
        }
        public async Task<IQueryable<film>> GetAll()
        {
            IQueryable<film> queryFilmSQL = _dbContext.film;
            return queryFilmSQL;
        }
    }
}
