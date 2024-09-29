namespace examm.Models;

public class Products
{
    public Guid Id { get; set; }
    public string  Name { get; set; }
    public int Price { get; set; }
    public int StockQuantity { get; set; }
    public DateTime CreatedAt { get; set; }
    
}
