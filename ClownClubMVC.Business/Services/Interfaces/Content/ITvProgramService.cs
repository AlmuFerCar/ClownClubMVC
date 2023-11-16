using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClownClubMVC.Models.content;

namespace ClownClubMVC.Business.Services.Interfaces.Content
{
    public interface ITvProgramService
    {
        Task<bool> Insert(tvProgram modelo);
        Task<bool> Update(tvProgram modelo);
        Task<bool> Delete(int id);
        Task<tvProgram> GetOne(int id);
        Task<tvProgram> GetOneByContentId(int id);
        Task<IQueryable<tvProgram>> GetAll();
    }
}
