using Npgsql;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Todo.Data.Connection;
using Todo.Data.Entities;
using Todo.Data.Mappers;

namespace Todo.Data.Repositories
{
    public abstract class BaseRepository<T> where T : BaseEntity
    {
        protected readonly IDatabaseConnectionFactory _connectionFactory;
        protected readonly IDataMapper<T> _dataMapper;

        protected BaseRepository(IDatabaseConnectionFactory connectionFactory, IDataMapper<T> dataMapper)
        {
            _connectionFactory = connectionFactory;
            _dataMapper = dataMapper;
        }

        protected async Task<IEnumerable<T>> QueryAsync(string sql, Dictionary<string, object> parameters = null)
        {
            using (var connection = _connectionFactory.GetConnection())
            {
                using (var command = new NpgsqlCommand(sql, connection))
                {
                    if (parameters != null)
                    {
                        foreach (var param in parameters)
                        {
                            command.Parameters.AddWithValue(param.Key, param.Value ?? DBNull.Value);
                        }
                    }

                    var result = new List<T>();
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            result.Add(_dataMapper.Map(reader));
                        }
                    }

                    return result;
                }
            }
        }

        protected async Task<T> QuerySingleOrDefaultAsync(string sql, Dictionary<string, object> parameters = null)
        {
            using (var connection = _connectionFactory.GetConnection())
            {
                using (var command = new NpgsqlCommand(sql, connection))
                {
                    if (parameters != null)
                    {
                        foreach (var param in parameters)
                        {
                            command.Parameters.AddWithValue(param.Key, param.Value ?? DBNull.Value);
                        }
                    }

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var result = _dataMapper.Map(reader);
                            return result;
                        }
                    }
                }
            }

            return default;
        }

        protected async Task<int> ExecuteAsync(string sql, Dictionary<string, object> parameters = null)
        {
            using (var connection = _connectionFactory.GetConnection())
            {
                using (var command = new NpgsqlCommand(sql, connection))
                {
                    if (parameters != null)
                    {
                        foreach (var param in parameters)
                        {
                            command.Parameters.AddWithValue(param.Key, param.Value ?? DBNull.Value);
                        }
                    }

                    return await command.ExecuteNonQueryAsync();
                }
            }
        }

        protected async Task<int> ExecuteScalarAsync(string sql, Dictionary<string, object> parameters = null)
        {
            using (var connection = _connectionFactory.GetConnection())
            {
                using (var command = new NpgsqlCommand(sql, connection))
                {
                    if (parameters != null)
                    {
                        foreach (var param in parameters)
                        {
                            command.Parameters.AddWithValue(param.Key, param.Value ?? DBNull.Value);
                        }
                    }

                    var result = await command.ExecuteScalarAsync();
                    return Convert.ToInt32(result);
                }
            }
        }
    }
}
