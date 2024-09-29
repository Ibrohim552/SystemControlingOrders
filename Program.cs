using examm.Interfaces;
using examm.Models;
using examm.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<ICustomers,CustomerServices > ();
builder.Services.AddTransient<IOrder, OrderServices>();
builder.Services.AddTransient<IOrderItems, OrderItemsServices>();
builder.Services.AddTransient<IProduct,ProductServices>();
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

#region Customers



app.MapPost("/api/customers", (Customers customer, ICustomers CustomerServices) =>
{
    return CustomerServices.CreateCustomers(customer);
});

app.MapGet("/api/customers", (ICustomers CustomerServices) =>
{
    return CustomerServices.GetCustomers();
});

app.MapPut("/api/customers/{id}", ( Customers customer, ICustomers CustomerServices) =>
{
    return CustomerServices.UpdateCustomers(customer);
});

app.MapDelete("/api/customers/{id}", (Guid Id, ICustomers CustomerServices) =>
{
    return CustomerServices.DeleteCustomers(Id);
});

app.MapGet("api/customers/{id}", (Guid Id, ICustomers CustomerServices) =>
{
    return CustomerServices.GetCustomersById(Id);
});
app.MapGet("api/customers/orders", (ICustomers CustomerServices) =>
{
    return CustomerServices.GetClientStatistics();
});
app.MapGet("api/customers/statistics", (ICustomers CustomerServices) =>
{
    return CustomerServices.GetClientStatistics();
});

#endregion


#region Orders


app.MapPost("/api/orders", (Orders order, IOrder OrderServices) =>
{
    return OrderServices.CreateOrder(order);
});

app.MapGet("/api/orders", (IOrder OrderServices) =>
{
    return OrderServices.GetOrders();
});

app.MapPut("/api/orders/{id}", (Orders order, IOrder OrderServices) =>
{
    return OrderServices.UpdateOrder(order);
});

app.MapDelete("/api/orders/{id}", (Guid Id, IOrder OrderServices) =>
{
    return OrderServices.DeleteOrder(Id);
});

app.MapGet("api/orders/{id}", (Guid Id, IOrder OrderServices) =>
{
    return OrderServices.GetOrderById(Id);
});

app.MapGet("api/orders/details", (IOrder OrderServices) =>
{
  return OrderServices.GetOrdersWithClientAndProductInfo();
});
app.MapGet("api/orders?status", (IOrder OrderServices) =>
{
    return OrderServices.GetOrdersByStatusAndDate();
});
app.MapGet("api/orders/products", (IOrder OrderServices) =>
{
    return OrderServices.GetOrdersWithProduct();
});

#endregion

#region OrderItems


app.MapPost("/api/orderitems", (OrderItems orderItems, IOrderItems OrderItemsServices) =>
{
    return OrderItemsServices.CreateOrderItems(orderItems);
});

app.MapGet("/api/orderitems", (IOrderItems OrderItemsServices) =>
{
    return OrderItemsServices.GetOrderItems();
});

app.MapPut("/api/orderitems/{id}", (OrderItems orderItems, IOrderItems OrderItemsServices) =>
{
    return OrderItemsServices.UpdateOrderItems(orderItems);
});

app.MapDelete("/api/orderitems/{id}", (Guid Id, IOrderItems OrderItemsServices) =>
{
    return OrderItemsServices.DeleteOrderItems(Id);
});

app.MapGet("api/orderitems/{id}", (Guid Id, IOrderItems OrderItemsServices) =>
{
    return OrderItemsServices.GetOrderItemsById(Id);
});


#endregion

#region Products


app.MapPost("/api/products", (Products product, IProduct ProductServices) =>
{
    return ProductServices.CreateProduct(product);
});

app.MapGet("/api/products", (IProduct ProductServices) =>
{
    return ProductServices.GetAllProducts();
});

app.MapPut("/api/products/{id}", (Products product, IProduct ProductServices) =>
{
    return ProductServices.UpdateProduct(product);
});

app.MapDelete("/api/products/{id}", (Guid Id, IProduct ProductServices) =>
{
    return ProductServices.DeleteProduct(Id);
});

app.MapGet("api/products/{id}", (Guid Id, IProduct ProductServices) =>
{
    return ProductServices.GetProductById(Id);
});

app.MapGet("api/products/out-of-stock", (IProduct ProductServices) =>
{
    return ProductServices.GetProductThatTotalAmoountIsNull();
});
app.MapGet("api/products/popular", (IProduct ProductServices) =>
{
    return ProductServices.GetTopSellingProducts();
});
app.MapGet("api/products/sales-statistics", (IProduct ProductServices) =>
{
    return ProductServices.GetMonthlySalesStatistics();
});
app.MapGet("api/products/customers", (IProduct ProductServices) =>
{
    return ProductServices.GetCustomersWhoDidNotMakeAnyOrdersInLastYear();
});

app.MapGet("api/orders/products-summary", (IProduct ProductServices) =>
{
    return ProductServices.GetProductsWithTotalAmount();
});

#endregion




app.Run();
