using DemoAuctrack.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace DemoAuctrack.DAL
{
    public class AuctionContext : DbContext
    {

        public AuctionContext() : base("AuctionContext")
        {
        }

        public DbSet<Item> Items { get; set; }
        public DbSet<ItemGroup> ItemGroups { get; set; }
        public DbSet<Bidder> Bidders { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}