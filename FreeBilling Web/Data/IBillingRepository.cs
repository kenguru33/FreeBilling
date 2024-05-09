using FreeBilling.Data.Entities;

namespace FreeBilling.Data;

public interface IBillingRepository
{
    Task<IEnumerable<Employee>> GetEmployees();
    Task<IEnumerable<Customer>> GetCustomer();
    Task<Customer?> GetCustomer(int id);
    Task<bool> SaveChanges();
}