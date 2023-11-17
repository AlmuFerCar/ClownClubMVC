using ClownClubMVC.Models.content;

namespace ClownClubMVC.Data.Repositories.Content
{
    public class TvProgramRepository : IGenericRepository<tvProgram>
    {
        private readonly DataDBContext _dbContext;
        public TvProgramRepository(DataDBContext context)
        {
            _dbContext = context;
        }
        public async Task<bool> Insert(tvProgram modelo)
        {
            _dbContext.tvProgram.Add(modelo);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        public async Task<bool> Update(tvProgram modelo)
        {
            _dbContext.tvProgram.Update(modelo);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        public async Task<bool> Delete(int id)
        {
            tvProgram modelo = _dbContext.tvProgram.First(c => c.content_id == id);
            _dbContext.tvProgram.Remove(modelo);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        public async Task<tvProgram> GetOne(int id)
        {
            return await _dbContext.tvProgram.FindAsync(id);
        }
        public async Task<IQueryable<tvProgram>> GetAll()
        {
            IQueryable<tvProgram> queryTvProgramSQL = _dbContext.tvProgram;
            return queryTvProgramSQL;
        }
    }
}
