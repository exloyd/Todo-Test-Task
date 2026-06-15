using Npgsql;
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using Todo.Data.Connection;

namespace Todo.Data.Runner
{
    public class MigrationRunner : IMigrationRunner
    {
        private readonly IDatabaseConnectionFactory _connectionFactory;

        public MigrationRunner(IDatabaseConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public void Migrate()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resourcePath = $"{assembly.GetName().Name}.Migrations";

            var migrationFiles = assembly.GetManifestResourceNames()
                .Where(r => r.StartsWith(resourcePath) && r.EndsWith(".sql"))
                .OrderBy(r => r)
                .ToList();

            if (!migrationFiles.Any())
                return;

            using (var connection = _connectionFactory.GetConnection())
            {
                foreach (var file in migrationFiles)
                {
                    var fileName = Path.GetFileName(file);

                    try
                    {
                        using (var stream = assembly.GetManifestResourceStream(file))
                        {
                            using (var reader = new StreamReader(stream))
                            {
                                var sql = reader.ReadToEnd();

                                using (var command = new NpgsqlCommand(sql, connection))
                                {
                                    command.ExecuteNonQuery();
                                }
                            }
                        }
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }
        }
    }
}
