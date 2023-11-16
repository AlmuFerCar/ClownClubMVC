using ClownClubMVC.Models.person;

namespace ClownClubMVC.Business.Services.Interfaces.Person
{
    public interface IPersonService
    {
        Task<bool> Insert(person modelo);
        Task<bool> Update(person modelo);
        Task<bool> Delete(int id);
        Task<person> GetOne(int id);
        Task<IQueryable<person>> GetAll();
        Task<person> GetUserByIdLogin(int id);
    }
}
