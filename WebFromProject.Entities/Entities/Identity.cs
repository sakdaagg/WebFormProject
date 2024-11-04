using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace WebFromProject.Entities.Entities
{
    public class AspNetUser : IdentityUser<Guid>
    {
        [MaxLength(100)]
        public string FirstName { get; set; }
        [MaxLength(100)]
        public string LastName { get; set; }
    }
    public class AspNetRole : IdentityRole<Guid>
    {
        public string Description { get; set; }
    }
    public class AspNetUserRole : IdentityUserRole<Guid>
    {
    }
    public class AspNetUserClaim : IdentityUserClaim<Guid>
    {
    }
    public class AspNetUserLogin : IdentityUserLogin<Guid>
    {
    }
    public class AspNetUserToken : IdentityUserToken<Guid>
    {
    }
    public class AspNetRoleClaim : IdentityRoleClaim<Guid>
    {
    }
}
