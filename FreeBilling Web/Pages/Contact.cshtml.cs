using FreeBilling_Web.Pages.Models;
using FreeBilling.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FreeBilling.Pages
{
    public class ContactModel : PageModel
    {
        private readonly IEmailService _emailService;

        public string Title { get; set; } = "Contact Me!";
        public string Message { get; set; } = "";

        public ContactModel(IEmailService emailService)
        {
            _emailService = emailService;
        }

        [BindProperty]
        public ContactViewModel Contact { get; set; } = new ContactViewModel() { Name = "Bernt Anker" };

        public void OnGet()
        {
        }

        public void OnPost()
        {
           if (ModelState.IsValid)
           {
               _emailService.SendMail("bernt.anker@rs.no", Contact.Email ,Contact.Subject, Contact.Body);
               Contact = new ContactViewModel();
               ModelState.Clear();
               Message = "Sent...";
           }
           else
           {
               Message = "Please fix the errors";
           }
        }
    }
}
