using System;
using System.ComponentModel;

namespace Todo.Data.Entities
{
    public class Task : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int? CategoryId { get; set; }
        public TaskPriority Priority { get; set; }
        public DateTime DueDate { get; set; }
        public TaskStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public Category Category { get; set; } = null;
    }

    public enum TaskPriority
    {
        [Description("Низкий")]
        Low = 0,
        [Description("Средний")]
        Medium = 1,
        [Description("Высокий")]
        High = 2
    }

    public enum TaskStatus
    {
        [Description("Новая")]
        New = 0,

        [Description("В работе")]
        InProgress = 1,

        [Description("Выполнена")]
        Done = 2
    }
}
