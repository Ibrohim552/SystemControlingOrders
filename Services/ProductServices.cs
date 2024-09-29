using Dapper;
using examm.Interfaces;
using examm.Models;
using examm.SqlCommands;
using Npgsql;

namespace examm.Services;

public class ProductServices:IProduct
{
    public async Task<bool> CreateProduct(Products product)
    {
        using (NpgsqlConnection connection=new NpgsqlConnection(SQLCommands.connectionString))
        {
            await connection.OpenAsync();
            return await connection.ExecuteAsync(SQLCommands.CreateProduct, product) > 0;
        }
    }

    public async Task<bool> UpdateProduct(Products product)
    {
        using (NpgsqlConnection connection=new NpgsqlConnection(SQLCommands.connectionString))
        {
            await connection.OpenAsync();
            return await connection.ExecuteAsync(SQLCommands.UpdateProduct, product) > 0;
        }
    }

    public async Task<bool> DeleteProduct(Guid Id)
    {
        using (NpgsqlConnection connection=new NpgsqlConnection(SQLCommands.connectionString))
        {
            await connection.OpenAsync();
            return await connection.ExecuteAsync(SQLCommands.DeleteProduct, new { Id }) > 0;
        }
    }

    public async Task<Products> GetProductById(Guid Id)
    {
        using (NpgsqlConnection connection=new NpgsqlConnection(SQLCommands.connectionString))
        {
            await connection.OpenAsync();
            return await connection.QuerySingleAsync<Products>(SQLCommands.GetProductById, new { Id });
        }
    }

    public async Task<IEnumerable<Products>> GetAllProducts()
    {
        using (NpgsqlConnection connection=new NpgsqlConnection(SQLCommands.connectionString))
        {
            await connection.OpenAsync();
            return await connection.QueryAsync<Products>(SQLCommands.GetProducts);
        }
    }

    public async Task<IEnumerable<Products>> GetProductThatTotalAmoountIsNull()
    {
        using (NpgsqlConnection connection=new NpgsqlConnection(SQLCommands.connectionString))
        {
            connection.OpenAsync();
            return await connection.QueryAsync<Products>(Requests.GetProductThatTotalAmoountIsNull);
        }
    }

    public async Task<IEnumerable<Products>> GetTopSellingProducts()
    {
        using (NpgsqlConnection connection=new NpgsqlConnection(SQLCommands.connectionString))
        {
            connection.OpenAsync();
            return await connection.QueryAsync<Products>(Requests.GetTopSellingProducts);
        }
    }

    public async Task<IEnumerable<Products>> GetMonthlySalesStatistics()
    {
        using (NpgsqlConnection connection=new NpgsqlConnection(SQLCommands.connectionString))
        {
            connection.OpenAsync();
            return await connection.QueryAsync<Products>(Requests.GetMonthlySalesStatistics);
        }
    }

    public async Task<IEnumerable<Products>> GetCustomersWhoDidNotMakeAnyOrdersInLastYear()
    {
        using (NpgsqlConnection connection=new NpgsqlConnection(SQLCommands.connectionString))
        {
            connection.OpenAsync();
            return await connection.QueryAsync<Products>(Requests.GetCustomersWhoDidNotMakeAnyOrdersInLastYear);
        }
    }

    public async Task<IEnumerable<Products>> GetProductsWithTotalAmount()
    {
        using (NpgsqlConnection connection=new NpgsqlConnection(SQLCommands.connectionString))
        {
            connection.OpenAsync();
            return await connection.QueryAsync<Products>(Requests.GetProductsWithTotalAmount);
        }
    }
}