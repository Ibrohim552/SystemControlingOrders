using examm.Models;

namespace examm.Interfaces;

public interface IOrder
{
    Task<bool> CreateOrder(Orders orders);
    Task<Orders> GetOrderById(Guid Id);
    Task<IEnumerable<Orders>> GetOrders();
    Task<bool> DeleteOrder(Guid Id);
    Task<bool> UpdateOrder(Orders orders);
    Task<IEnumerable<Orders>> GetOrdersWithClientAndProductInfo();
    Task<IEnumerable<Orders>> GetOrdersByStatusAndDate();
    Task<IEnumerable<Orders>> GetOrdersWithProduct();
    
}