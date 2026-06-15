using System;
using System.Windows.Forms;
using Todo.Data.Entities;
using Todo.Data.Repositories.Categories;
using Task = System.Threading.Tasks.Task;

namespace Todo.UI
{
    public partial class AddOrUpdateCategoryForm : Form
    {
        public int? CategoryId = null;

        private bool IsEditMode => CategoryId.HasValue;
        private readonly ICategoryRepository _categoryRepository;

        public AddOrUpdateCategoryForm(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;

            InitializeComponent();
            this.Load += async (s, e) => await LoadCategoryAsync();
        }

        private async Task LoadCategoryAsync()
        {
            if (!IsEditMode)
                return;

            var category = await _categoryRepository.GetByIdAsync(CategoryId.Value);
            if (category == null)
                return;

            nameTextBox.Text = category.Name;
        }

        private async void OnSaveButtonClick(object sender, EventArgs e)
        {
            var isValid = ValidateForm();
            if (!isValid)
            {
                MessageBox.Show("Для добавления необходимо заполнить наименование", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var category = new Category()
            {
                Name = nameTextBox.Text.Trim()
            };

            var hasDuplicateCategory = await _categoryRepository.ExistsByNameAsync(category.Name);
            if (hasDuplicateCategory)
            {
                MessageBox.Show("Выбранная категория уже существует", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (IsEditMode)
                await _categoryRepository.UpdateAsync(CategoryId.Value, category);
            else
                await _categoryRepository.CreateAsync(category);

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private bool ValidateForm()
        {
            return !string.IsNullOrEmpty(nameTextBox.Text.Trim());
        }

        private void OnCancelButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
