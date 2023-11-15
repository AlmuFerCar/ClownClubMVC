using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClownClubMVC.Models.content;
using ClownClubMVC.Models.loggin;

namespace ClownClubMVC.Data.Repositories
{
    public class ContentRepository : IGenericRepository<content>
    {
        private readonly DataDBContext _dbContext;
        public ContentRepository(DataDBContext context)
        {
            _dbContext = context;
        }
        public async Task<bool> Insert(content modelo)
        {
            _dbContext.content.Add(modelo);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        public async Task<bool> Update(content modelo)
        {
            _dbContext.content.Update(modelo);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        public async Task<bool> Delete(int id)
        {
            content modelo = _dbContext.content.First(c => c.id == id);
            _dbContext.content.Remove(modelo);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        public async Task<content> GetOne(int id)
        {
            return await _dbContext.content.FindAsync(id);
        }
        public async Task<IQueryable<content>> GetAll()
        {
            IQueryable<content> queryContentSQL = _dbContext.content;
            return queryContentSQL;
        }
    }
}
