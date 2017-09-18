using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ASF.UI.WbSite.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<ASF.Entities.Category> Categories { get; set; }

        public System.Data.Entity.DbSet<ASF.Entities.Country> Countries { get; set; }

        public System.Data.Entity.DbSet<ASF.Entities.Dealer> Dealers { get; set; }

        public System.Data.Entity.DbSet<ASF.Entities.Client> Clients { get; set; }

        public System.Data.Entity.DbSet<ASF.Entities.Product> Products { get; set; }

        public System.Data.Entity.DbSet<ASF.Entities.Rating> Ratings { get; set; }

        public System.Data.Entity.DbSet<ASF.Entities.OrderDetail> OrderDetails { get; set; }

        public System.Data.Entity.DbSet<ASF.Entities.Order> Orders { get; set; }

        public System.Data.Entity.DbSet<ASF.Entities.Cart> Carts { get; set; }

        public System.Data.Entity.DbSet<ASF.Entities.CartItem> CartItems { get; set; }

        public System.Data.Entity.DbSet<ASF.Entities.OrderNumber> OrderNumbers { get; set; }

        public System.Data.Entity.DbSet<ASF.Entities.Error> Errors { get; set; }

        public System.Data.Entity.DbSet<ASF.Entities.Setting> Settings { get; set; }

        public System.Data.Entity.DbSet<ASF.Entities.Language> Languages { get; set; }

        public System.Data.Entity.DbSet<ASF.Entities.LocaleResourceKey> LocaleResourceKeys { get; set; }

        public System.Data.Entity.DbSet<ASF.Entities.LocaleStringResource> LocaleStringResources { get; set; }
    }
}