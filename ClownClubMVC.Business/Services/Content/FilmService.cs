using ClownClubMVC.Business.Services.Interfaces.Content;
using ClownClubMVC.Data.Repositories;
using ClownClubMVC.Models.content;

namespace ClownClubMVC.Business.Services.Content
{
    public class FilmService : IFilmService
    {
        private readonly IGenericRepository<film> _filmRepo;
        public FilmService(IGenericRepository<film> filmRepo)
        {
            _filmRepo = filmRepo;
        }
        public async Task<bool> Insert(film modelo)
        {
            return await _filmRepo.Insert(modelo);
        }
        public async Task<bool> Update(film modelo)
        {
            return await _filmRepo.Update(modelo);
        }
        public async Task<bool> Delete(int id)
        {
            return await _filmRepo.Delete(id);
        }
        public async Task<film> GetOne(int id)
        {
            return await _filmRepo.GetOne(id);
        }
        public async Task<film> GetOneByContentId(int id)
        {
            IQueryable<film> queryFilmSQL = await _filmRepo.GetAll();
            film film = queryFilmSQL.Where(c => c.content_id == id).FirstOrDefault();
            return film;
        }
        public async Task<IQueryable<film>> GetAll()
        {
            return await _filmRepo.GetAll();
        }
    }
}