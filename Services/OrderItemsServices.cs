using Dapper;
using examm.Interfaces;
using examm.Models;
using examm.SqlCommands;
using Npgsql;

namespace examm.Services;

public class OrderItemsServices:IOrderItems
{
    public async Task<bool> CreateOrderItems(OrderItems orderItems)
    {
        using (NpgsqlConnection connection=new NpgsqlConnection(SQLCommands.connectionString))
        {
            await connection.OpenAsync();
            return await connection.ExecuteAsync(SQLCommands.CreateOrderItem, orderItems) > 0;
        }
    }

    public async Task<bool> UpdateOrderItems(OrderItems orderItems)
    {
        using (NpgsqlConnection connection=new NpgsqlConnection(SQLCommands.connectionString))
        {
            await connection.OpenAsync();
            return await connection.ExecuteAsync(SQLCommands.UpdateOrderItem, orderItems) > 0;
        }
    }

    public async Task<bool> DeleteOrderItems(Guid Id)
    {
        using (NpgsqlConnection connection=new NpgsqlConnection(SQLCommands.connectionString))
        {
            await connection.OpenAsync();
            return await connection.ExecuteAsync(SQLCommands.DeleteOrderItem, new { Id }) > 0;
        }
    }

    public async Task<OrderItems> GetOrderItemsById(Guid Id)
    {
        using (NpgsqlConnection connection=new NpgsqlConnection(SQLCommands.connectionString))
        {
            await connection.OpenAsync();
            return await connection.QuerySingleAsync<OrderItems>(SQLCommands.GetOrderItemById, new { Id });
        }
    }

    public async Task<IEnumerable<OrderItems>> GetOrderItems()
    {
        using (NpgsqlConnection connection=new NpgsqlConnection(SQLCommands.connectionString))
        {
            await connection.OpenAsync();
            return await connection.QueryAsync<OrderItems>(SQLCommands.GetOrderItems);
        }
    }
}