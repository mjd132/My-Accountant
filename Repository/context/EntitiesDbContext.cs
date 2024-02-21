
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using p1.Entities;
using System.Reflection.Emit;

namespace p1.Repository.context
{

    public class EntitiesDbContext : DbContext
    {
        public EntitiesDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Friend> Friends { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<DebtReg> Debts { get; set; }

        //public DbSet<Account> Accounts { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>().HasIndex(u => u.userName).IsUnique();
            builder.Entity<Room>().HasIndex(u => u.code).IsUnique();


            //debt reg relation
            
            
             builder.Entity<DebtReg>()
                .HasOne(d => d.MadarKharj)
                .WithMany(u=>u.MadarKharjis)
                .HasForeignKey(d => d.MadarKharjId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<DebtReg>()
                   .HasMany(d => d.DebtUsers)
                   .WithMany(u => u.Debts)
                   ;

            //account relation
            //builder.Entity<Account>()
            //.HasOne(a => a.CreatorUser)
            //.WithMany(u => u.Accounts)
            //.HasForeignKey(a => a.CreatorUserId);

            //builder.Entity<Account>()
            // .HasOne(a => a.DebtUser)
            // .WithMany()
            // .HasForeignKey(a => a.DebtUserId);

        }

    }
}
