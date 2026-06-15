using System;
using System.Data.Common;
using Todo.Data.Entities;
using TaskEntity = Todo.Data.Entities.Task;

namespace Todo.Data.Mappers
{
    public class TasksDataMapper : IDataMapper<TaskEntity>
    {
        public TaskEntity Map(DbDataReader reader)
        {
            return new TaskEntity
            {
                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                Title = reader.GetString(reader.GetOrdinal("Title")),
                Description = reader.IsDBNull(reader.GetOrdinal("Description"))
                    ? null
                    : reader.GetString(reader.GetOrdinal("Description")),
                CategoryId = reader.IsDBNull(reader.GetOrdinal("CategoryId")) 
                    ? (int?)null 
                    : reader.GetInt32(reader.GetOrdinal("CategoryId")),
                Priority = (TaskPriority) reader.GetInt32(reader.GetOrdinal("Priority")),
                DueDate = reader.GetDateTime(reader.GetOrdinal("DueDate")),
                Status = (TaskStatus) reader.GetInt32(reader.GetOrdinal("Status")),
                CreatedAt = reader.GetDateTime(reader.GetOrdinal("CreatedAt")),
                UpdatedAt = reader.GetDateTime(reader.GetOrdinal("UpdatedAt")),

                Category = reader.IsDBNull(reader.GetOrdinal("CategoryId"))
                    ? null
                    : new Category
                    {
                        Id = reader.GetInt32(reader.GetOrdinal("CategoryId")),
                        Name = reader.IsDBNull(reader.GetOrdinal("CategoryName"))
                            ? null
                            : reader.GetString(reader.GetOrdinal("CategoryName")),
                        CreatedAt = reader.GetDateTime(reader.GetOrdinal("CreatedAt")),
                    }
            };
        }
    }
}
