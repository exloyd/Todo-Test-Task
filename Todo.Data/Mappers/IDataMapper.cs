using System.Data.Common;

namespace Todo.Data.Mappers
{
    public interface IDataMapper<T>
    {
        T Map(DbDataReader reader);
    }
}
