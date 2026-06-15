using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Windows.Forms;
using Todo.Data.Repositories.Tasks;
using Todo.UI.Extensions;
using Task = System.Threading.Tasks.Task;
using TaskStatus = Todo.Data.Entities.TaskStatus;

namespace Todo.UI
{
    public partial class TasksForm : Form
    {
        private readonly ITaskRepository _taskRepository;

        public TasksForm(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;

            InitializeComponent();

            this.Load += async (s, e) => await GetTasksAsync();
        }

        private async Task GetTasksAsync(string search = null)
        {
            var tasks = await _taskRepository.GetAllAsync(search); 

            var tasksDataSource = tasks.Select(t => new
            {
                t.Id,
                t.Title,
                t.Description,
                Category = t.Category?.Name,
                Priority = t.Priority.GetDescription(),
                t.DueDate,
                Status = t.Status.GetDescription(),
                t.CreatedAt,
                t.UpdatedAt
            }).ToList();

            tasksGridView.AutoGenerateColumns = false;
            tasksGridView.DataSource = null;
            tasksGridView.DataSource = tasksDataSource;

            statusLabel.Text = $"Всего: {tasksDataSource.Count} | " +
                         $"Выполнено: {tasksDataSource.Count(t => t.Status == TaskStatus.Done.GetDescription())} | " +
                         $"В работе: {tasksDataSource.Count(t => t.Status == TaskStatus.InProgress.GetDescription())} | " +
                         $"Новых: {tasksDataSource.Count(t => t.Status == TaskStatus.New.GetDescription())}";
        }

        private async void OnSearchButtonClick(object sender, EventArgs e)
        {
            await GetTasksAsync(searchTextBox.Text.Trim());
        }

        private async void OnCategoriesClick(object sender, EventArgs e)
        {
            using (var scope = Program.ServiceProvider.CreateScope())
            {
                var form = scope.ServiceProvider.GetRequiredService<CategoriesForm>();
                if (form.ShowDialog() == DialogResult.OK)
                {
                    await GetTasksAsync();
                }
            }
        }

        private async void OnAddTaskClick(object sender, EventArgs e)
        {
            using (var scope = Program.ServiceProvider.CreateScope())
            {
                var form = scope.ServiceProvider.GetRequiredService<AddOrUpdateTaskForm>();
                if (form.ShowDialog() == DialogResult.OK)
                {
                    await GetTasksAsync();
                }
            }
        }

        private async void OnTaskDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                using (var scope = Program.ServiceProvider.CreateScope())
                {
                    var taskId = Convert.ToInt32(tasksGridView.Rows[e.RowIndex].Cells["Id"].Value);
                    var form = scope.ServiceProvider.GetRequiredService<AddOrUpdateTaskForm>();
                    form.TaskId = taskId;

                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        await GetTasksAsync();
                    }
                }
            }
        }

        private async void OnTaskDeleteClick(object sender, EventArgs e)
        {
            if (tasksGridView.CurrentRow == null)
            {
                MessageBox.Show("Выберите задачу для удаления", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var row = tasksGridView.CurrentRow;
            var taskId = Convert.ToInt32(row.Cells["Id"].Value);
            var taskTitle = row.Cells["Title"].Value?.ToString();

            var result = MessageBox.Show(
                $"Удалить задачу \"{taskTitle}\"?",
                "Подтверждение удаления",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result != DialogResult.Yes) 
                return;

            await _taskRepository.DeleteAsync(taskId);
            await GetTasksAsync();
        }
    }
}
