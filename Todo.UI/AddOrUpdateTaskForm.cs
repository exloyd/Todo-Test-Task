using System;
using System.Linq;
using System.Windows.Forms;
using Todo.Data.Entities;
using Todo.Data.Repositories.Categories;
using Todo.Data.Repositories.Tasks;
using Todo.UI.Extensions;
using Task = System.Threading.Tasks.Task;
using TaskEntity = Todo.Data.Entities.Task;

namespace Todo.UI
{
    public partial class AddOrUpdateTaskForm : Form
    {
        public int? TaskId = null;

        private bool IsEditMode => TaskId.HasValue;
        private readonly ITaskRepository _taskRepository;
        private readonly ICategoryRepository _categoryRepository;

        public AddOrUpdateTaskForm(ITaskRepository taskRepository, ICategoryRepository categoryRepository)
        {
            _taskRepository = taskRepository;
            _categoryRepository = categoryRepository;

            InitializeComponent();
            this.Load += async (s, e) => await LoadFormAsync();
        }

        private async Task LoadFormAsync()
        {
            var categories = await _categoryRepository.GetAllAsync();
            var categoriesList = categories.ToList();
            categoriesList.Insert(0, new Category { Id = -1, Name = "Без категории" });

            categoryComboBox.DataSource = categoriesList;
            categoryComboBox.DisplayMember = "Name";
            categoryComboBox.ValueMember = "Id";

            priorityComboBox.DataSource = Enum.GetValues(typeof(TaskPriority))
                .Cast<TaskPriority>()
                .Select(x => new
                {
                    Value = (int)x,
                    Text = x.GetDescription()
                })
                .ToList();
            priorityComboBox.DisplayMember = "Text";
            priorityComboBox.ValueMember = "Value";
            priorityComboBox.SelectedValue = (int)TaskPriority.Low;

            statusComboBox.DataSource = Enum.GetValues(typeof(TaskStatus))
                .Cast<TaskStatus>()
                .Select(x => new
                {
                    Value = (int)x,
                    Text = x.GetDescription()
                })
                .ToList();
            statusComboBox.DisplayMember = "Text";
            statusComboBox.ValueMember = "Value";
            statusComboBox.SelectedValue = (int)TaskStatus.New;

            await LoadTaskAsync();
        }

        private async Task LoadTaskAsync()
        {
            if (!IsEditMode)
                return;

            var task = await _taskRepository.GetByIdAsync(TaskId.Value);
            if (task == null)
                return;

            titleTextBox.Text = task.Title;
            descriptionTextBox.Text = task.Description;
            categoryComboBox.SelectedValue = task.CategoryId ?? 0;
            priorityComboBox.SelectedValue = (int)task.Priority;
            dueDatePicker.Value = task.DueDate;
            statusComboBox.SelectedValue = (int)task.Status;
        }

        private async void OnSaveButtonClick(object sender, EventArgs e)
        {
            var isValid = ValidateForm();
            if (!isValid)
            {
                MessageBox.Show("Заполните все обязательные поля", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var task = new TaskEntity
            {
                Title = titleTextBox.Text.Trim(),
                Description = descriptionTextBox.Text.Trim(),
                CategoryId = categoryComboBox.SelectedIndex == 0 ? null : categoryComboBox.SelectedValue as int?,
                Priority = (TaskPriority)priorityComboBox.SelectedValue,
                DueDate = dueDatePicker.Value,
                Status = (TaskStatus)statusComboBox.SelectedValue
            };

            if (IsEditMode)
                await _taskRepository.UpdateAsync(TaskId.Value, task);
            else
                await _taskRepository.CreateAsync(task);

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private bool ValidateForm()
        {
            return !string.IsNullOrEmpty(titleTextBox.Text.Trim());
        }

        private void OnCancelButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
