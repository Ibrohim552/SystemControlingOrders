using examm.Models;

namespace examm.Interfaces;

public interface IProduct
{
    Task<bool> CreateProduct(Products product);
    Task<bool> UpdateProduct(Products product);
    Task<bool> DeleteProduct(Guid Id);
    Task<Products> GetProductById(Guid Id);
    Task<IEnumerable<Products>> GetAllProducts();
    Task<IEnumerable<Products>> GetProductThatTotalAmoountIsNull();
    Task<IEnumerable<Products>> GetTopSellingProducts();
    Task<IEnumerable<Products>> GetMonthlySalesStatistics();
    Task<IEnumerable<Products>> GetCustomersWhoDidNotMakeAnyOrdersInLastYear();
    Task<IEnumerable<Products>> GetProductsWithTotalAmount();

}