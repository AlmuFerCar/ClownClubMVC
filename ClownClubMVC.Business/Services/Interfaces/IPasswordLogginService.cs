using ClownClubMVC.Models.loggin;

namespace ClownClubMVC.Business.Services.Interfaces
{
    public interface IPasswordLogginService
    {
        Task<bool> Insert(passwordLoggin modelo);
        Task<bool> Update(passwordLoggin modelo);
        Task<bool> Delete(int id);
        Task<passwordLoggin> GetOne(int id);
        Task<passwordLoggin> GetPasswordByUserId(int id);
        Task<IQueryable<passwordLoggin>> GetAll();
    }
}
