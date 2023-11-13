using ClownClubMVC.Data.Repositories;
using ClownClubMVC.Models.loggin;
using ClownClubMVC.Models.person;

namespace ClownClubMVC.Business.Services
{
    public class PersonService : IPersonService
    {
        private readonly IGenericRepository<person> _personRepo;
        public PersonService(IGenericRepository<person> personRepo)
        {
            _personRepo = personRepo;
        }
        public async Task<bool> Insert(person modelo)
        {
            return await _personRepo.Insert(modelo);
        }
        public async Task<bool> Update(person modelo)
        {
            return await _personRepo.Update(modelo);
        }
        public async Task<bool> Delete(int id)
        {
            return await _personRepo.Delete(id);
        }
        public async Task<person> GetOne(int id)
        {
            return await _personRepo.GetOne(id);
        }
        public async Task<IQueryable<person>> GetAll()
        {
            return await _personRepo.GetAll();
        }
        public async Task<person> GetUserByIdLogin(int id)
        {
            IQueryable<person> queryPersonSQL = await _personRepo.GetAll();
            person personRole = queryPersonSQL.Where(c => c.userLoggin_id == id).FirstOrDefault();
            return personRole;
        }
    }
}
