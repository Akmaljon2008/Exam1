using Dapper;
using Npgsql;
namespace Infrastracture.Datacontext;

public class DapperContext
{
    private readonly string _connectionString =
        "Host = localhost;Port = 5432; Database = examdb;user id = postgres;Password = akmaljon2008";

    public NpgsqlConnection Connection()
    {
        return new NpgsqlConnection(_connectionString);
    }
}