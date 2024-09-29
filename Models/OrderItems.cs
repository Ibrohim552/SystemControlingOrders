namespace examm.Models;

public class OrderItems
{
    public Guid Id { get; set; }
    public int OrderId { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    public int Price { get; set; }
    public DateTime CreatedAt { get; set; }
}