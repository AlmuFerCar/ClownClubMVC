using ClownClubMVC.Business.Services.Interfaces;
using ClownClubMVC.Data.Repositories;
using ClownClubMVC.Models.content;

namespace ClownClubMVC.Business.Services
{
    public class ContentService: IContentService
    {
        private readonly IGenericRepository<content> _contentRepo;
        public ContentService(IGenericRepository<content> contentRepo)
        {
            _contentRepo = contentRepo;
        }
        public async Task<bool> Insert(content modelo)
        {
            return await _contentRepo.Insert(modelo);
        }
        public async Task<bool> Update(content modelo)
        {
            return await _contentRepo.Update(modelo);
        }
        public async Task<bool> Delete(int id)
        {
            return await _contentRepo.Delete(id);
        }
        public async Task<content> GetOne(int id)
        {
            return await _contentRepo.GetOne(id);
        }
        public async Task<IQueryable<content>> GetAll()
        {
            return await _contentRepo.GetAll();
        }
    }
}
