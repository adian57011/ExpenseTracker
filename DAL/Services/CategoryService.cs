using DAL.Model;
using DAL.Repository;

namespace DAL.Services
{
    public class CategoryService
    {
        private readonly IRepository<Category> _category;

        public CategoryService(IRepository<Category> category)
        {
            _category = category;
        }

        public async Task<IList<Category>> GetCategory()
        {
            try
            {
                return await _category.Get();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Category> GetCategory(int id)
        {
            try
            {
                return await _category.Get(id);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> SaveCategory(Category c)
        {
            try
            {
                return await _category.Create(c);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> UpdateCaetegory(Category c)
        {
            try
            {
                return await _category.Update(c);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> Delete(int c)
        {
            try
            {
                return await _category.Delete(c);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
