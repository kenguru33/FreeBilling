using FreeBilling.Data;
using FreeBilling.Data.Entities;
using Microsoft.AspNetCore.Mvc;

[Route("/api/[controller]")]
public class CustomersController : ControllerBase
{
    private readonly IBillingRepository _repository;

    public CustomersController(IBillingRepository repository)
    {
        
        _repository = repository;
    }
    
    [HttpGet("")]
    public async Task<IEnumerable<Customer>> Get()
    {
        Console.WriteLine("Hitting controller...");
        return await _repository.GetCustomer();
    }
    
    [HttpGet("{id:int}")]
    public async Task<Customer?> GetOne(int id)
    {
        return await _repository.GetCustomer(id);
    }
}