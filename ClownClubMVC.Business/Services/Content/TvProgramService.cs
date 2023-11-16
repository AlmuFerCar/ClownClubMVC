using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClownClubMVC.Business.Services.Interfaces.Content;
using ClownClubMVC.Data.Repositories;
using ClownClubMVC.Models.content;

namespace ClownClubMVC.Business.Services.Content
{
    public class TvProgramService : ITvProgramService
    {
        private readonly IGenericRepository<tvProgram> _tvProgramRepo;
        public TvProgramService(IGenericRepository<tvProgram> tvProgramRepo)
        {
            _tvProgramRepo = tvProgramRepo;
        }
        public async Task<bool> Insert(tvProgram modelo)
        {
            return await _tvProgramRepo.Insert(modelo);
        }
        public async Task<bool> Update(tvProgram modelo)
        {
            return await _tvProgramRepo.Update(modelo);
        }
        public async Task<bool> Delete(int id)
        {
            return await _tvProgramRepo.Delete(id);
        }
        public async Task<tvProgram> GetOne(int id)
        {
            return await _tvProgramRepo.GetOne(id);
        }
        public async Task<tvProgram> GetOneByContentId(int id)
        {
            IQueryable<tvProgram> queryTvProgramSQL = await _tvProgramRepo.GetAll();
            tvProgram tvProgram = queryTvProgramSQL.Where(c => c.content_id == id).FirstOrDefault();
            return tvProgram;
        }
        public async Task<IQueryable<tvProgram>> GetAll()
        {
            return await _tvProgramRepo.GetAll();
        }
    }
}
