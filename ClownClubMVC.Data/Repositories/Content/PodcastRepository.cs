using ClownClubMVC.Models.content;

namespace ClownClubMVC.Data.Repositories.Content
{
    public class PodcastRepository : IGenericRepository<podcast>
    {
        private readonly DataDBContext _dbContext;
        public PodcastRepository(DataDBContext context)
        {
            _dbContext = context;
        }
        public async Task<bool> Insert(podcast modelo)
        {
            _dbContext.podcast.Add(modelo);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        public async Task<bool> Update(podcast modelo)
        {
            _dbContext.podcast.Update(modelo);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        public async Task<bool> Delete(int id)
        {
            podcast modelo = _dbContext.podcast.First(c => c.content_id == id);
            _dbContext.podcast.Remove(modelo);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        public async Task<podcast> GetOne(int id)
        {
            return await _dbContext.podcast.FindAsync(id);
        }
        public async Task<IQueryable<podcast>> GetAll()
        {
            IQueryable<podcast> queryPodcastSQL = _dbContext.podcast;
            return queryPodcastSQL;
        }
    }
}
