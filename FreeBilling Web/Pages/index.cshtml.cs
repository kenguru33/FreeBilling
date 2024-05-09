using FreeBilling.Data;
using FreeBilling.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace FreeBilling.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IBillingRepository _repository;
        public IEnumerable<Customer> Customers { get; set; } 
        
        public IndexModel(IBillingRepository repository)
        {
            _repository = repository;
        }
        
        public async Task OnGetAsync()
        {
            Customers = await _repository.GetCustomer();
        }
    }
}
