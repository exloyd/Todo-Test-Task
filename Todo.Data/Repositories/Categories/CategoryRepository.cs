using System.Collections.Generic;
using System.Threading.Tasks;
using Todo.Data.Connection;
using Todo.Data.Entities;
using Todo.Data.Mappers;
using Task = System.Threading.Tasks.Task;

namespace Todo.Data.Repositories.Categories
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(IDatabaseConnectionFactory connectionFactory, IDataMapper<Category> dataMapper)
            : base(connectionFactory, dataMapper)
        {
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            const string sql = @"select * from Categories order by CreatedAt DESC, Name ASC";
            return await QueryAsync(sql);
        }

        public async Task<Category> GetByIdAsync(int id)
        {
            const string sql = @"
                SELECT * FROM Categories
                WHERE Id = @Id
                LIMIT 1";

            return await QuerySingleOrDefaultAsync(sql, new Dictionary<string, object>
            {
                { "@Id", id }
            });
        }

        public async Task<int> CreateAsync(Category category)
        {
            const string sql = @"
                INSERT INTO Categories (Name) 
                VALUES (@Name)
                RETURNING Id";

            return await ExecuteScalarAsync(sql, new Dictionary<string, object>
            {
                { "@Name", category.Name },
            });
        }

        public async Task UpdateAsync(int id, Category category)
        {
            const string sql = @"
                UPDATE Categories 
                SET Name = @Name,
                    UpdatedAt = CURRENT_TIMESTAMP
                WHERE Id = @Id";

            await ExecuteAsync(sql, new Dictionary<string, object>
            {
                { "@Id", id },
                { "@Name", category.Name },
            });
        }

        public async Task DeleteAsync(int id)
        {
            const string sql = "DELETE FROM Categories WHERE Id = @Id";

            await ExecuteAsync(sql, new Dictionary<string, object>
            {
                { "@Id", id }
            });
        }

        public async Task<bool> ExistsByNameAsync(string name)
        {
            const string sql = "SELECT COUNT(1) FROM Categories WHERE LOWER(Name) = LOWER(@Name)";

            var count = await ExecuteScalarAsync(sql, new Dictionary<string, object>
            {
                { "@Name", name }
            });

            return count > 0;
        }
    }
}
