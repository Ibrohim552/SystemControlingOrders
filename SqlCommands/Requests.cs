namespace examm.SqlCommands;

public class Requests
{
    //
    public const string GetAllCustomersORDCreatedInPeriod = "SELECT c.FullName,c.Email" +
                                                            "o.Id,o.status.o.CreatedAt" +
                                                            "from Customers c join" +
                                                            "Orders o on o.CustomerId = c.Id" +
                                                            "where o.CreatedAt between '2023-01-01 and 2024-10-14' ";
//
    public const string GetProductThatTotalAmoountIsNull = "select  p.Name, p.Price , p.StockQuantity" +
                                                           "from Products p " +
                                                           "where p.StockQuantity = 0";

    //
        public const string GetClientStatistics = "SELECT c.FullName, COUNT(o.Id) as TotalOrders, SUM(o.TotalAmount) as TotalSpentAmount" +
                                                "FROM Customers c JOIN Orders o ON c.Id = o.CustomerId" +
                                                "GROUP BY c.FullName";
        
//
        public const string GetOrdersWithClientAndProductInfo = "SELECT o.Id, c.FullName, p.Name, p.Price, o.TotalAmount" +
                                                            "FROM Orders o JOIN Customers c ON o.CustomerId = c.Id" +
                                                            "JOIN OrderItems oi ON o.Id = oi.OrderId" +
                                                            "JOIN Products p ON oi.ProductId = p.Id";
        
//
        public const string GetOrdersByStatusAndDate = "SELECT Id, FullName, Email, CreatedAt, Status" +
                                                        "FROM Customers c JOIN Orders o ON c.Id = o.CustomerId" +
                                                        "WHERE o.Starus ='Complited' and o.OrderDate between '2023-01-01 and 2024-10-14' ";
        
        public const string GetTopSellingProducts = "SELECT p.Name, SUM(oi.Quantity) as TotalSoldQuantity" +
                                                  "FROM Products p JOIN OrderItems oi ON p.Id = oi.ProductId" +
                                                  "GROUP BY p.Name" +
                                                  "ORDER BY TotalSoldQuantity DESC" +
                                                  "Limit 1";
        
   //     
        
    public const string GetMonthlySalesStatistics = "SELECT EXTRACT(MONTH FROM o.CreatedAt) as Month, EXTRACT(YEAR FROM o.CreatedAt) as Year, SUM(o.TotalAmount) as TotalSalesAmount" +
                                                 "FROM Orders o" +
                                                 "WHERE EXTRACT(MONTH FROM o.CreatedAt) = '10' AND EXTRACT(YEAR FROM o.CreatedAt) = '2024'" +
                                                 "GROUP BY Month, Year";
    //
    public const string GetCustomersWhoDidNotMakeAnyOrdersInLastYear = "SELECT c.FullName, c.Email" +
                                                                   "FROM Customers c LEFT JOIN Orders o ON c.Id = o.CustomerId" +
                                                                   "WHERE o.Id IS NULL AND o.CreatedAt < DATE_SUB(NOW(), INTERVAL 1 YEAR)";
    //
    public const string GetOrdersWithProduct = "SELECT o.Id, c.FullName, p.Name, p.Price, o.TotalAmount" +
                                            "FROM Orders o JOIN Customers c ON o.CustomerId = c.Id" +
                                            "JOIN OrderItems oi ON o.Id = oi.OrderId" +
                                            "JOIN Products p ON oi.ProductId = p.Id" +
                                            "WHERE p.Name = 'Apple 16 pro max' ";
    
    public const string GetProductsWithTotalAmount = "SELECT p.Name, SUM(oi.Quantity * p.Price) as TotalAmount" +
                                                 "FROM Products p JOIN OrderItems oi ON p.Id = oi.ProductId" +
                                                 "GROUP BY p.Name";
}


