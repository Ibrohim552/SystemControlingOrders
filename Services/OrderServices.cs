using Dapper;
using examm.Interfaces;
using examm.Models;
using examm.SqlCommands;
using Npgsql;

namespace examm.Services;

public class OrderServices:IOrder
{
    public async Task<bool> CreateOrder(Orders orders)
    {
        using (NpgsqlConnection connection = new NpgsqlConnection(SQLCommands.connectionString))
        {
            await connection.OpenAsync();
            return await connection.ExecuteAsync(SQLCommands.CreateOrder, orders) > 0;
        }
    }

    public async Task<Orders> GetOrderById(Guid Id)
    {
        using (NpgsqlConnection connection = new NpgsqlConnection(SQLCommands.connectionString))
        {
            await connection.OpenAsync();
            return await connection.QuerySingleAsync<Orders>(SQLCommands.GetOrderById, new { Id });
        }
    }

    public async Task<IEnumerable<Orders>> GetOrders()
    {
        using (NpgsqlConnection connection = new NpgsqlConnection(SQLCommands.connectionString))
        {
            await connection.OpenAsync();
            return await connection.QueryAsync<Orders>(SQLCommands.GetOrders);
        }
    }

    public async Task<bool> DeleteOrder(Guid Id)
    {
        using (NpgsqlConnection connection = new NpgsqlConnection(SQLCommands.connectionString))
        {
            await connection.OpenAsync();
            return await connection.ExecuteAsync(SQLCommands.DeleteOrder, new { Id }) > 0;
        }
    }

    public async Task<bool> UpdateOrder(Orders orders)
    {
        using (NpgsqlConnection connection = new NpgsqlConnection(SQLCommands.connectionString))
        {
            await connection.OpenAsync();
            return await connection.ExecuteAsync(SQLCommands.UpdateOrder, orders) > 0;
        }
    }

    public async Task<IEnumerable<Orders>> GetOrdersWithClientAndProductInfo()
    {
        using (NpgsqlConnection connection =new NpgsqlConnection(SQLCommands.connectionString))
        {
            connection.OpenAsync();
            return await connection.QueryAsync<Orders>(Requests.GetOrdersWithClientAndProductInfo);
        }
    }

    public async Task<IEnumerable<Orders>> GetOrdersByStatusAndDate()
    {
        using (NpgsqlConnection connection = new NpgsqlConnection(SQLCommands.connectionString))
        {
            connection.OpenAsync();
            return await connection.QueryAsync<Orders>(Requests.GetOrdersByStatusAndDate);
        }
    }

    public async Task<IEnumerable<Orders>> GetOrdersWithProduct()
    {
        using (NpgsqlConnection connection = new NpgsqlConnection(SQLCommands.connectionString))
        {
            connection.OpenAsync();
            return await connection.QueryAsync<Orders>(Requests.GetOrdersWithProduct);
        }
    }
}