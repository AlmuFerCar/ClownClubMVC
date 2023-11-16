using ClownClubMVC.Models.content;

namespace ClownClubMVC.Business.Services.Interfaces.Content
{
    public interface IFilmService
    {
        Task<bool> Insert(film modelo);
        Task<bool> Update(film modelo);
        Task<bool> Delete(int id);
        Task<film> GetOne(int id);
        Task<film> GetOneByContentId(int id);
        Task<IQueryable<film>> GetAll();
    }
}
