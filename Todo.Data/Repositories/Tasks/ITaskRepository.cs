using System.Collections.Generic;
using System.Threading.Tasks;
using TaskEntity = Todo.Data.Entities.Task;

namespace Todo.Data.Repositories.Tasks
{
    public interface ITaskRepository
    {
        Task<IEnumerable<TaskEntity>> GetAllAsync(string search);
        Task<TaskEntity> GetByIdAsync(int id);
        Task<int> CreateAsync(TaskEntity task);
        Task UpdateAsync(int id, TaskEntity task);
        Task DeleteAsync(int id);
    }
}
