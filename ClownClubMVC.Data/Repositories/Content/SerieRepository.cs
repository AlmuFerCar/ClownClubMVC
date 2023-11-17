using ClownClubMVC.Models.content;

namespace ClownClubMVC.Data.Repositories.Content
{
    public class SerieRepository : IGenericRepository<serie>
    {
        private readonly DataDBContext _dbContext;
        public SerieRepository(DataDBContext context)
        {
            _dbContext = context;
        }
        public async Task<bool> Insert(serie modelo)
        {
            _dbContext.serie.Add(modelo);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        public async Task<bool> Update(serie modelo)
        {
            _dbContext.serie.Update(modelo);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        public async Task<bool> Delete(int id)
        {
            serie modelo = _dbContext.serie.First(c => c.content_id == id);
            _dbContext.serie.Remove(modelo);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        public async Task<serie> GetOne(int id)
        {
            return await _dbContext.serie.FindAsync(id);
        }
        public async Task<IQueryable<serie>> GetAll()
        {
            IQueryable<serie> querySerieSQL = _dbContext.serie;
            return querySerieSQL;
        }
    }
}
