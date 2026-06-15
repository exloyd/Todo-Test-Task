using Npgsql;

namespace Todo.Data.Connection
{
    public interface IDatabaseConnectionFactory
    {
        NpgsqlConnection GetConnection();
    }
}
