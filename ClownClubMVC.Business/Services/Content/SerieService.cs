using ClownClubMVC.Business.Services.Interfaces.Content;
using ClownClubMVC.Data.Repositories;
using ClownClubMVC.Models.content;

namespace ClownClubMVC.Business.Services.Content
{
    public class SerieService : ISerieService
    {
        private readonly IGenericRepository<serie> _serieRepo;
        public SerieService(IGenericRepository<serie> serieRepo)
        {
            _serieRepo = serieRepo;
        }
        public async Task<bool> Insert(serie modelo)
        {
            return await _serieRepo.Insert(modelo);
        }
        public async Task<bool> Update(serie modelo)
        {
            return await _serieRepo.Update(modelo);
        }
        public async Task<bool> Delete(int id)
        {
            return await _serieRepo.Delete(id);
        }
        public async Task<serie> GetOne(int id)
        {
            return await _serieRepo.GetOne(id);
        }
        public async Task<serie> GetOneByContentId(int id)
        {
            IQueryable<serie> querySerieSQL = await _serieRepo.GetAll();
            serie serie = querySerieSQL.Where(c => c.content_id == id).FirstOrDefault();
            return serie;
        }
        public async Task<IQueryable<serie>> GetAll()
        {
            return await _serieRepo.GetAll();
        }
    }
}
