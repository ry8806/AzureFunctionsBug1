using Microsoft.AspNetCore.Identity;

namespace EfLibrary
{
    public class ApplicationUser : IdentityUser
    {
        public string otherName { get; set; }
    }
}
