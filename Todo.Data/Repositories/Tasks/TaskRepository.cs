using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Todo.Data.Connection;
using Todo.Data.Mappers;
using TaskEntity = Todo.Data.Entities.Task;

namespace Todo.Data.Repositories.Tasks
{
    public class TaskRepository : BaseRepository<TaskEntity>, ITaskRepository
    {
        public TaskRepository(IDatabaseConnectionFactory connectionFactory, IDataMapper<TaskEntity> dataMapper) 
            : base(connectionFactory, dataMapper)
        {
        }

        public async Task<IEnumerable<TaskEntity>> GetAllAsync(string search)
        {
            const string sql = @"
                    SELECT 
                    t.Id,
                    t.Title,
                    t.Description,
                    t.CategoryId,
                    t.Priority,
                    t.DueDate,
                    t.Status,
                    t.CreatedAt,
                    t.UpdatedAt,
                    c.Name AS CategoryName
                FROM Tasks t
                LEFT JOIN Categories c ON t.CategoryId = c.Id";

            const string orderSql = @"
                ORDER BY t.Priority DESC, t.Status ASC, t.CreatedAt DESC, t.Title ASC";

            if (string.IsNullOrEmpty(search))
                return await QueryAsync($"{sql} {orderSql}");

            const string whereSql = @"
                WHERE LOWER(t.Title) LIKE @Search 
                OR LOWER(t.Description) LIKE @Search";

            return await QueryAsync($"{sql} {whereSql} {orderSql}", new Dictionary<string, object>
            {
                { "@Search", $"%{search.ToLower()}%" }
            });
        }

        public async Task<TaskEntity> GetByIdAsync(int id)
        {
            const string sql = @"
                SELECT 
                    t.Id, t.Title, t.Description, t.CategoryId,
                    t.Priority, t.DueDate, t.Status,
                    t.CreatedAt, t.UpdatedAt,
                    c.Name AS CategoryName
                FROM Tasks t
                LEFT JOIN Categories c ON t.CategoryId = c.Id
                WHERE t.Id = @Id
                LIMIT 1"; 

            return await QuerySingleOrDefaultAsync(sql, new Dictionary<string, object>
            {
                { "@Id", id }
            });
        }

        public async Task<int> CreateAsync(TaskEntity task)
        {
            const string sql = @"
                INSERT INTO Tasks (Title, Description, CategoryId, Priority, DueDate, Status) 
                VALUES (@Title, @Description, @CategoryId, @Priority, @DueDate, @Status)
                RETURNING Id";

            return await ExecuteScalarAsync(sql, new Dictionary<string, object>
            {
                { "@Title", task.Title },
                { "@Description", (object)task.Description ?? DBNull.Value },
                { "@CategoryId", (object)task.CategoryId ?? DBNull.Value },
                { "@Priority", (int)task.Priority },
                { "@DueDate", task.DueDate },
                { "@Status", (int)task.Status }
            });
        }

        public async Task UpdateAsync(int id, TaskEntity task)
        {
            const string sql = @"
                UPDATE Tasks 
                SET Title = @Title, 
                    Description = @Description, 
                    CategoryId = @CategoryId, 
                    Priority = @Priority, 
                    DueDate = @DueDate, 
                    Status = @Status,
                    UpdatedAt = CURRENT_TIMESTAMP
                WHERE Id = @Id";

            await ExecuteAsync(sql, new Dictionary<string, object>
            {
                { "@Id", id },
                { "@Title", task.Title },
                { "@Description", (object)task.Description ?? DBNull.Value },
                { "@CategoryId", (object)task.CategoryId ?? DBNull.Value },
                { "@Priority", (int)task.Priority },
                { "@DueDate", task.DueDate },
                { "@Status", (int)task.Status }
            });
        }

        public async Task DeleteAsync(int id)
        {
            const string sql = "DELETE FROM Tasks WHERE Id = @Id";

            await ExecuteAsync(sql, new Dictionary<string, object>
            {
                { "@Id", id }
            });
        }
    }
}
