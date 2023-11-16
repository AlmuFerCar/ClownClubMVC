using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClownClubMVC.Models.content;

namespace ClownClubMVC.Business.Services.Interfaces.Content
{
    public interface IPodcastService
    {
        Task<bool> Insert(podcast modelo);
        Task<bool> Update(podcast modelo);
        Task<bool> Delete(int id);
        Task<podcast> GetOne(int id);
        Task<podcast> GetOneByContentId(int id);
        Task<IQueryable<podcast>> GetAll();
    }
}
