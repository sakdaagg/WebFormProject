using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebFromProject.Entities.Entities;

namespace WebFormProject.DAL.DbContexts;

public class WebFormDbContext : IdentityDbContext<AspNetUser, AspNetRole, Guid, AspNetUserClaim,
                                               AspNetUserRole, AspNetUserLogin,
                                               AspNetRoleClaim, AspNetUserToken>
{
    public WebFormDbContext(DbContextOptions<WebFormDbContext> options) : base(options)
    {
    }
    public DbSet<AspNetUser> User { get; set; }
    public DbSet<AspNetRole> Role { get; set; }
    public DbSet<AspNetUserRole> UserRole { get; set; }
    public DbSet<AspNetUserClaim> UserClaim { get; set; }
    public DbSet<AspNetUserLogin> UserLogin { get; set; }
    public DbSet<AspNetUserToken> UserToken { get; set; }
    public DbSet<AspNetRoleClaim> RoleClaim { get; set; }
}
