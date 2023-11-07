using ClownClubMVC.Models.loggin;

namespace ClownClub.Bussiness.Services
{
	public interface IUsersLogginService
	{
		Task<bool> Insert(usersLoggin modelo);
		Task<bool> Update(usersLoggin modelo);
		Task<bool> Delete(int id);
		Task<usersLoggin> GetOne(int id);
		Task<usersLoggin> GetOneByName(string name);
		Task<IQueryable<usersLoggin>> GetAll();
		Task<usersLoggin> GetUserByEmail(string email);
        //añadir todas las operaciones que se quiera

    }
}
