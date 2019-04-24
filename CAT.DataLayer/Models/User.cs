using CAT.DataLayer.Models.Enums;
using Microsoft.AspNetCore.Identity;

namespace CAT.DataLayer.Models
{
    public class User : IdentityUser
    {
        public UserAvailabilityStatus AvailabilityStatus { get; set; }

        public string FirstName { get; set; }

        public string SecondName { get; set; }
    }
}
