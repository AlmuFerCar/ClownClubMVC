using ClownClubMVC.Models.content;


namespace ClownClubMVC.Business.Services.Interfaces.Content
{
    public interface IContentService
    {
        Task<bool> Insert(content modelo);
        Task<bool> Update(content modelo);
        Task<bool> Delete(int id);
        Task<content> GetOne(int id);
        Task<IQueryable<content>> GetAll();
        Task<content> GetOneByTitle(string title);
    }
}
