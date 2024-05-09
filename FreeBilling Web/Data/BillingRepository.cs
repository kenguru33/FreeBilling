using FreeBilling.Data;
using FreeBilling.Data.Entities;
using Microsoft.EntityFrameworkCore;

public class BillingRepository : IBillingRepository
{
    private readonly BillingContext _context;
    private readonly ILogger<BillingRepository> _logger;

    public BillingRepository(BillingContext context, ILogger<BillingRepository> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<IEnumerable<Employee>> GetEmployees()
    {
        try
        {
            return await _context.Employees.OrderBy(e => e.Name).ToListAsync();
        }
        catch (Exception e)
        {
            _logger.LogError($"Could not get Customers: {e.Message}");
            throw;
        }
    }

    public async Task<IEnumerable<Customer>> GetCustomer()
    {
        try
        {
            return await _context.Customers.OrderBy(c => c.CompanyName).ToListAsync();
        }
        catch (Exception e)
        {
            _logger.LogError($"Could not get empleyees: {e.Message}");
            throw;
        }
    }

    public async Task<Customer?> GetCustomer(int id)
    {
        try
        {
            return await _context.Customers.Where(c => c.Id == id).FirstOrDefaultAsync();
        }
        catch (Exception e)
        {
            _logger.LogError($"Could no retrieve customer with {id}");
            throw;
        }
    }

    public async Task<bool> SaveChanges()
    {
        try
        {
            return await _context.SaveChangesAsync() > 0;
        }
        catch (Exception e)
        {
            _logger.LogError($"Could not save to database: {e.Message}");
            throw;
        }
    }
}