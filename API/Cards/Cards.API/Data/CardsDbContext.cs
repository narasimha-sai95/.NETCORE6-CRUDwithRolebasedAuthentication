using Microsoft.EntityFrameworkCore;
using Cards.API.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace Cards.API.Data
{
    public class CardsDbContext : IdentityDbContext<IdentityUser>
    {
        public CardsDbContext(DbContextOptions<CardsDbContext> options) : base(options)
        {
        }

        //Dbset
        public DbSet<Card> Cards { get; set; }
    }
}
