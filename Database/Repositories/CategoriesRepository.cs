using Microsoft.EntityFrameworkCore;
using PFM_project.Database.Entities;
using PFM_project.Models;

namespace PFM_project.Database.Repositories
{
    public class CategoriesRepository : ICategoriesRepository
    {
        private readonly TranasactionsDBContext _context;
        public CategoriesRepository(TranasactionsDBContext context)
        {
            _context=context;
        }

        public async Task<CategoryEntity> Create(CategoryEntity entity)
        {
           CategoryEntity old_entity=await Get(entity.code); 
           if(old_entity==null)
           { 
           _context.Categories.Add(entity);
           await _context.SaveChangesAsync();
           return entity;
           }
           else
           {
            _context.Categories.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
           }
        }
        public async Task<CategoryEntity> Get(string code)
        {
            return await _context.Categories.FirstOrDefaultAsync(p => p.code == code);
        }

        public async Task<List<CategoryEntity>> GetCategories(string parent_id)
        {
           if(parent_id=="")
           { 
                var query= _context.Categories.Where(p=>p.code!="").AsQueryable();
                return await query.ToListAsync();
           }
           else
           {
                var query= _context.Categories.Where(p=>p.code!=parent_id).AsQueryable();
                return await query.ToListAsync();
           }
        }
    }

}