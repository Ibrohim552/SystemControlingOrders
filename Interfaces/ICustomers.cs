using examm.Models;

namespace examm.Interfaces;

public interface ICustomers
{
    Task<bool> CreateCustomers(Customers customers);
    Task<bool> UpdateCustomers(Customers customers);
    Task<bool> DeleteCustomers(Guid Id);
    Task<Customers> GetCustomersById(Guid Id);
    Task<IEnumerable<Customers>> GetCustomers();
    Task<IEnumerable<Customers>> GetAllCustomersORDCreatedInPeriod();
    Task<IEnumerable<Customers>> GetClientStatistics();
}