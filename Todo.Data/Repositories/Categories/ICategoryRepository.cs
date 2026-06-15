using System.Collections.Generic;
using System.Threading.Tasks;
using Todo.Data.Entities;
using Task = System.Threading.Tasks.Task;

namespace Todo.Data.Repositories.Categories
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetAllAsync();
        Task<Category> GetByIdAsync(int id);
        Task<int> CreateAsync(Category category);
        Task UpdateAsync(int id, Category category);
        Task DeleteAsync(int id);
        Task<bool> ExistsByNameAsync(string name);
    }
}
