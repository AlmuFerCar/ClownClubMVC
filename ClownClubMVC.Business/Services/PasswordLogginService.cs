using ClownClubMVC.Business.Services.Interfaces;
using ClownClubMVC.Data.Repositories;
using ClownClubMVC.Models.loggin;

namespace ClownClubMVC.Business.Services
{
    public class PasswordLogginService : IPasswordLogginService
    {
        private readonly IGenericRepository<passwordLoggin> _passLogRepo;
        public PasswordLogginService(IGenericRepository<passwordLoggin> passLogRepo)
        {
            _passLogRepo = passLogRepo;
        }
        public async Task<bool> Insert(passwordLoggin modelo)
        {
            return await _passLogRepo.Insert(modelo);
        }
        public async Task<bool> Update(passwordLoggin modelo)
        {
            return await _passLogRepo.Update(modelo);
        }
        public async Task<bool> Delete(int id)
        {
            return await _passLogRepo.Delete(id);
        }
        public async Task<passwordLoggin> GetOne(int id)
        {
            return await _passLogRepo.GetOne(id);
        }
        public async Task<passwordLoggin> GetPasswordByUserId(int id)
        {
            IQueryable<passwordLoggin> queryPasswordLogginSQL = await _passLogRepo.GetAll();
            passwordLoggin passwordLoggin = queryPasswordLogginSQL.Where(c => c.userLoggin_id == id).FirstOrDefault();
            return passwordLoggin;
        }
        public async Task<IQueryable<passwordLoggin>> GetAll()
        {
            return await _passLogRepo.GetAll();
        }
    }
}
