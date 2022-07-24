using PFM_project.Database.Entities;
using PFM_project.Models;

namespace PFM_project.Database.Repositories
{
    public interface ICategoriesRepository
    {
        Task<CategoryEntity> Create(CategoryEntity entity); 
        Task<CategoryEntity> Get(string code);
        Task<List<CategoryEntity>> GetCategories(string parent_id);
    }
}