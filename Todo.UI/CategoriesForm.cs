using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Windows.Forms;
using Todo.Data.Repositories.Categories;
using Task = System.Threading.Tasks.Task;

namespace Todo.UI
{
    public partial class CategoriesForm : Form
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoriesForm(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;

            InitializeComponent();

            this.FormClosing += (s, e) =>
            {
                if (e.CloseReason == CloseReason.UserClosing)
                    this.DialogResult = DialogResult.OK;
            };

            this.Load += async (s, e) => await GetCategoriesAsync();
        }

        private async Task GetCategoriesAsync()
        {
            var categories = await _categoryRepository.GetAllAsync();

            var categoriesDataSource = categories.Select(t => new
            {
                t.Id,
                NameColumn = t.Name,
                t.CreatedAt,
                t.UpdatedAt
            }).ToList();

            categoriesGridView.AutoGenerateColumns = false;
            categoriesGridView.DataSource = null;
            categoriesGridView.DataSource = categoriesDataSource;

            statusLabel.Text = $"Всего: {categoriesDataSource.Count}";
        }

        private async void OnCategoryDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                using (var scope = Program.ServiceProvider.CreateScope())
                {
                    var categoryId = Convert.ToInt32(categoriesGridView.Rows[e.RowIndex].Cells["Id"].Value);
                    var form = scope.ServiceProvider.GetRequiredService<AddOrUpdateCategoryForm>();
                    form.CategoryId = categoryId;

                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        await GetCategoriesAsync();
                    }
                }
            }
        }

        private async void OnCategoryDeleteClick(object sender, EventArgs e)
        {
            if (categoriesGridView.CurrentRow == null)
            {
                MessageBox.Show("Выберите категорию для удаления", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var row = categoriesGridView.CurrentRow;
            var categoryId = Convert.ToInt32(row.Cells["Id"].Value);
            var categoryTitle = row.Cells["NameColumn"].Value?.ToString();

            var result = MessageBox.Show(
                $"Удалить категорию \"{categoryTitle}\"?",
                "Подтверждение удаления",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
                return;

            await _categoryRepository.DeleteAsync(categoryId);
            await GetCategoriesAsync();
        }

        private async void OnAddCategoryClick(object sender, EventArgs e)
        {
            using (var scope = Program.ServiceProvider.CreateScope())
            {
                var form = scope.ServiceProvider.GetRequiredService<AddOrUpdateCategoryForm>();
                if (form.ShowDialog() == DialogResult.OK)
                {
                    await GetCategoriesAsync();
                }
            }
        }
    }
}
