using AutoMapper;
using PFM_project.Commands;
using PFM_project.Database.Entities;
using PFM_project.Database.Repositories;
using PFM_project.Models;

namespace PFM_project.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoriesRepository _repository;
        private readonly IMapper _mapper;
        public CategoryService(IMapper mapper, ICategoriesRepository repository)
        {
            _mapper=mapper;
            _repository=repository;
        }
      

        public async Task<Category> Create(CategoryCsv categoryCsv)
        {
            var entity = _mapper.Map<CategoryEntity>(categoryCsv);

            var existingProduct = await _repository.Get(categoryCsv.code);
            if (existingProduct != null)
            {
                return null;
            }
            var result = await _repository.Create(entity);

            return _mapper.Map<Category>(result);
        }

        public async Task<Category> Get(string id)
        {
            var result=await _repository.Get(id);
            return _mapper.Map<Category>(result);
        }

        public async Task<List<Category>> GetCategories(string parent_id)
        {
            List<CategoryEntity> lista=await _repository.GetCategories(parent_id);
            List<Category> result=new List<Category>();
            foreach(CategoryEntity elem in lista)
            {
               result.Add(_mapper.Map<Category>(elem));
            }
            return result;
        }

       
    }
}