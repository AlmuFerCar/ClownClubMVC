using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClownClubMVC.Models.content;
using ClownClubMVC.Models.person;

namespace ClownClubMVC.Business.Services.Interfaces
{
    public interface IContentService
    {
        Task<bool> Insert(content modelo);
        Task<bool> Update(content modelo);
        Task<bool> Delete(int id);
        Task<content> GetOne(int id);
        Task<IQueryable<content>> GetAll();
    }
}
