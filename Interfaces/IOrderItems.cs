using examm.Models;

namespace examm.Interfaces;

public interface IOrderItems
{
    Task<bool> CreateOrderItems(OrderItems orderItems);
    Task<bool> UpdateOrderItems(OrderItems orderItems);
    Task<bool> DeleteOrderItems(Guid Id);
    Task<OrderItems> GetOrderItemsById(Guid Id);
    Task<IEnumerable<OrderItems>> GetOrderItems();
}