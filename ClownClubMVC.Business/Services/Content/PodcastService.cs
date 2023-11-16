using ClownClubMVC.Business.Services.Interfaces.Content;
using ClownClubMVC.Data.Repositories;
using ClownClubMVC.Models.content;

namespace ClownClubMVC.Business.Services.Content
{
    public class PodcastService : IPodcastService
    {
        private readonly IGenericRepository<podcast> _podcastRepo;
        public PodcastService(IGenericRepository<podcast> podcastRepo)
        {
            _podcastRepo = podcastRepo;
        }
        public async Task<bool> Insert(podcast modelo)
        {
            return await _podcastRepo.Insert(modelo);
        }
        public async Task<bool> Update(podcast modelo)
        {
            return await _podcastRepo.Update(modelo);
        }
        public async Task<bool> Delete(int id)
        {
            return await _podcastRepo.Delete(id);
        }
        public async Task<podcast> GetOne(int id)
        {
            return await _podcastRepo.GetOne(id);
        }
        public async Task<podcast> GetOneByContentId(int id)
        {
            IQueryable<podcast> queryPodcastSQL = await _podcastRepo.GetAll();
            podcast podcast = queryPodcastSQL.Where(c => c.content_id == id).FirstOrDefault();
            return podcast;
        }
        public async Task<IQueryable<podcast>> GetAll()
        {
            return await _podcastRepo.GetAll();
        }
    }
}
