using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClownClubMVC.Models.loggin;
using ClownClubMVC.Models.person;

namespace ClownClubMVC.Business.Services.Interfaces
{
    public interface IPersonService
    {
        Task<bool> Insert(person modelo);
        Task<bool> Update(person modelo);
        Task<bool> Delete(int id);
        Task<person> GetOne(int id);
        Task<IQueryable<person>> GetAll();
        Task<person> GetUserByIdLogin(int id);

        //añadir todas las operaciones que se quiera
    }
}
