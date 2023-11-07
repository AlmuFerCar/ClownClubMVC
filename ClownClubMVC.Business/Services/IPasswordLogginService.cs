using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClownClubMVC.Models.loggin;

namespace ClownClubMVC.Business.Services
{
    public interface IPasswordLogginService
    {
        Task<bool> Insert(passwordLoggin modelo);
        Task<bool> Update(passwordLoggin modelo);
        Task<bool> Delete(int id);
        Task<passwordLoggin> GetOne(int id);
        Task <passwordLoggin> GetPasswordByUserId(int id);
        Task<IQueryable<passwordLoggin>> GetAll();

        //añadir todas las operaciones que se quiera
    }
}
