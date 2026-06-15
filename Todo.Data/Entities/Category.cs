using System;

namespace Todo.Data.Entities
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
