namespace examm.Models;

public class Orders
{
    public Guid Id { get; set; }
    public int CustomerId { get; set; }
    public int TotalAmount { get; set; }
    public DateTime OrderDate { get; set; }
    public string Status { get; set; }
    public DateTime CreatedAt { get; set; }
    
}
