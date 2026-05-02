using DomainLayer.Entities;
using MassTransit;
using Microsoft.EntityFrameworkCore;

namespace PersistanceLayer
{
    public class Context : DbContext
    {
        public Context(DbContextOptions options) : base(options) { }
        DbSet<Auction> Auctions { get; set; }
        DbSet<Item> Items { get; set; }

        public ModelBuilder ConfigureModel(ModelBuilder modelBuilder)
        {


            modelBuilder.Entity<Auction>()
            .HasOne(a => a.Item)
            .WithOne(i => i.Auction)
            .HasForeignKey<Item>(i => i.AuctionId)
            .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Item>()
                .HasKey(i => i.id);

            modelBuilder.Entity<Auction>()
                .HasKey(a => a.id);

            // Configuración de MassTransit tables para el patron
         

            return modelBuilder;
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.AddInboxStateEntity();
            modelBuilder.AddOutboxMessageEntity();
            modelBuilder.AddOutboxStateEntity();
        }
    }
}
