using PFM_project.Commands;
using PFM_project.Database.Entities;
using PFM_project.Models;

namespace PFM_project.Services
{

    public interface ICategoryService
    {
        Task<List<Category>> GetCategories(string parent_id);
        Task<Category> Create(CategoryCsv categoryCsv);
        Task<Category> Get(string id);

    }
}