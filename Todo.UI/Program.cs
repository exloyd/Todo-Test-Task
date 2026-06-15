using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Configuration;
using System.Windows.Forms;
using Todo.Data.Connection;
using Todo.Data.Entities;
using Todo.Data.Mappers;
using Todo.Data.Repositories.Categories;
using Todo.Data.Repositories.Tasks;
using Todo.Data.Runner;
using TaskEntity = Todo.Data.Entities.Task;

namespace Todo.UI
{
    internal static class Program
    {
        public static IServiceProvider ServiceProvider { get; private set; }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            ConfigureServices();
            InitializeDatabase();

            var mainForm = ServiceProvider.GetRequiredService<TasksForm>();
            Application.Run(mainForm);
        }

        private static void ConfigureServices()
        {
            var services = new ServiceCollection();

            services.AddLogging(configure =>
            {
                configure.SetMinimumLevel(LogLevel.Debug);
            });

            services.AddSingleton<IDatabaseConnectionFactory>(x =>
            {
                var connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                return new DatabaseConnectionFactory(connectionString);
            });

            services.AddSingleton<MigrationRunner>();

            services.AddSingleton<IDataMapper<TaskEntity>, TasksDataMapper>();
            services.AddSingleton<IDataMapper<Category>, CategoriesDataMapper>();

            services.AddScoped<ITaskRepository, TaskRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();

            services.AddScoped<TasksForm>();
            services.AddScoped<AddOrUpdateTaskForm>();

            services.AddScoped<CategoriesForm>();
            services.AddScoped<AddOrUpdateCategoryForm>();

            ServiceProvider = services.BuildServiceProvider();
        }

        private static void InitializeDatabase()
        {
            using (var scope = ServiceProvider.CreateScope())
            {
                var migrationRunner = scope.ServiceProvider.GetRequiredService<MigrationRunner>();
                migrationRunner.Migrate();
            }
        }
    }
}
