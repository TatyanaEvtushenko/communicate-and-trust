using Microsoft.AspNetCore.Http;

namespace CAT.BusinessLayer.Models.Account.ViewModels
{
    public class RegisterAccountViewModel
    {
        public string Email { get; set; }

        public string UserName { get; set; }
        
        public string Password { get; set; }

        public string FirstName { get; set; }

        public string SecondName { get; set; }

        public IFormFile File { get; set; }
    }
}