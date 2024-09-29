using Dapper;
using examm.Interfaces;
using examm.Models;
using examm.SqlCommands;
using Npgsql;

namespace examm.Services;

public class CustomerServices:ICustomers
{
    public async Task<bool> CreateCustomers(Customers customers)
    {
        using (NpgsqlConnection connection = new NpgsqlConnection(SqlCommands.SQLCommands.connectionString))
        {
            await connection.OpenAsync();
            return await connection.ExecuteAsync(SQLCommands.CreateCustomer, customers) > 0;
        }
    }

    public async Task<bool> UpdateCustomers(Customers customers)
    {
        using (NpgsqlConnection connection = new NpgsqlConnection(SqlCommands.SQLCommands.connectionString))
        {
            await connection.OpenAsync();
            return await connection.ExecuteAsync(SQLCommands.UpdateCustomer, customers) > 0;
        }
    }

    public async Task<bool> DeleteCustomers(Guid Id)
    {
        using (NpgsqlConnection connection = new NpgsqlConnection(SqlCommands.SQLCommands.connectionString))
        {
            await connection.OpenAsync();
            return await connection.ExecuteAsync(SQLCommands.DeleteCustomer, new { Id }) > 0;
        }
    }

    public async Task<Customers> GetCustomersById(Guid Id)
    {
        using (NpgsqlConnection connection = new NpgsqlConnection(SqlCommands.SQLCommands.connectionString))
        {
            await connection.OpenAsync();
            return await connection.QuerySingleAsync<Customers>(SQLCommands.GetCustomerById, new { Id });
        }
    }

    public async Task<IEnumerable<Customers>> GetCustomers()
    {
        using (NpgsqlConnection connection = new NpgsqlConnection(SqlCommands.SQLCommands.connectionString))
        {
            await connection.OpenAsync();
            return await connection.QueryAsync<Customers>(SQLCommands.GetCustomers);
        }
    }

    public async Task<IEnumerable<Customers>> GetAllCustomersORDCreatedInPeriod()
    {
        using (NpgsqlConnection connection = new NpgsqlConnection(SqlCommands.SQLCommands.connectionString))
        {
            connection.OpenAsync();
            return await connection.QueryAsync<Customers>(Requests.GetAllCustomersORDCreatedInPeriod);
        }
    }

    public async Task<IEnumerable<Customers>> GetClientStatistics()
    {
        using (NpgsqlConnection connection = new NpgsqlConnection(SqlCommands.SQLCommands.connectionString))
        {
            connection.OpenAsync();
            return await connection.QueryAsync<Customers>(Requests.GetClientStatistics);
        }
    }
}