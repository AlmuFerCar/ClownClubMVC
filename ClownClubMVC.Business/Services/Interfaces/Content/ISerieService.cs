using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClownClubMVC.Models.content;

namespace ClownClubMVC.Business.Services.Interfaces.Content
{
    public interface ISerieService
    {
        Task<bool> Insert(serie modelo);
        Task<bool> Update(serie modelo);
        Task<bool> Delete(int id);
        Task<serie> GetOne(int id);
        Task<serie> GetOneByContentId(int id);
        Task<IQueryable<serie>> GetAll();
    }
}
