namespace examm.SqlCommands;

public class SQLCommands
{
    public const string connectionString = "Server=localhost;Port=5432;Database=Market_DB;User Id=postgres;Password=12345;";
    
    public const string GetOrders = "select * from orders;";
    
    public const string GetOrderById = "select * from orders where id = @id;";
    
    public const string CreateOrder = 
        "insert into orders (id, customerId, totalAmount, orderDate, status, createdAt) " +
        "values (@id, @customerId, @totalAmount, @orderDate, @status, @createdAt);";
    
    public const string UpdateOrder = 
        "update orders set id = @id, customerId = @customerId, totalAmount = @totalAmount, " +
        "orderDate = @orderDate, status = @status, createdAt = @createdAt " +
        "where id = @id;";
    
    public const string DeleteOrder = "delete from orders where id = @id;";
    
    public const string GetCustomers = "select * from customers";
    
    public const string GetCustomerById = "select * from customers where id = @id";

    public const string CreateCustomer =
        "insert into customers(id,fullName,email,phone,createdAt) values (@id,@fullName,@email,@phone,@createdAt)";
    
    public const string UpdateCustomer = "update customers set id = @id,fullName = @fullName,email = @email,phone = @phone,createdAt = @createdAt where id = @id";
    
    public const string DeleteCustomer = "delete from customers where id = @id";
    
    public const string GetOrderItems = "select * from orderItems;";
    
    public const string GetOrderItemById = "select * from orderItems where id = @id;";
    
    public const string CreateOrderItem = 
        "insert into orderItems (id, orderId, productId, quantity, price, createdAt) " +
        "values (@id, @orderId, @productId, @quantity, @price, @createdAt);";
    
    public const string UpdateOrderItem = 
        "update orderItems set id = @id, orderId = @orderId, productId = @productId, " +
        "quantity = @quantity, price = @price, createdAt = @createdAt " +
        "where id = @id;";
    
    public const string DeleteOrderItem = "delete from orderItems where id = @id;";
    
    
    public const string GetProducts = "select * from products";
    
    public const string GetProductById = "select * from products where id = @id";
    
    public const string CreateProduct = "insert into products (id,name, price, stockQuantity,createdAt) values (@id,@name, @price, @stockQuantity,@createdAt)";
    
    public const string UpdateProduct = "update products set id = @id, name = @name, price = @price, stockQuantity = @stockQuantity, createdAt = @createdAt where id = @id";
    
    public const string DeleteProduct = "delete from products where id = @id";
}


