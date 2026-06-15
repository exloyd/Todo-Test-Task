using System.Data.Common;
using Todo.Data.Entities;

namespace Todo.Data.Mappers
{
    public class CategoriesDataMapper : IDataMapper<Category>
    {
        public Category Map(DbDataReader reader)
        {
            return new Category
            {
                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                Name = reader.GetString(reader.GetOrdinal("Name")),
                CreatedAt = reader.GetDateTime(reader.GetOrdinal("CreatedAt")),
                UpdatedAt = reader.GetDateTime(reader.GetOrdinal("UpdatedAt")),
            };
        }
    }
}
