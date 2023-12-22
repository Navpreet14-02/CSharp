using BloodGuardianAPI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BloodGuardianAPI.Data
{
    public class AppDbContext : IdentityDbContext
    {

        public DbSet<BloodRequest> BloodRequests { get; set; }
        public DbSet<BloodBank> BloodBanks { get; set; }
        public DbSet<UserDetails> UserDetails { get; set; }
        public DbSet<BloodDonationCamp> BloodDonationCamps { get; set; }
        public DbSet<BloodTransferReceipt> BloodTransferReceipts { get; set; }

        public DbSet<BankBloodGroupMapping> BankBloodMapping { get; set; }
        public DbSet<BloodGroup> BloodGroups { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);




            modelBuilder.Entity<BloodGroup>().HasData(
                    new BloodGroup() { Id=1, Name = "A+" },
                    new BloodGroup() { Id=2, Name = "A-" },
                    new BloodGroup() { Id=3, Name = "B+" },
                    new BloodGroup() { Id=4, Name = "B-" },
                    new BloodGroup() { Id=5, Name = "O+" },
                    new BloodGroup() { Id=6, Name = "O-" },
                    new BloodGroup() { Id=7, Name = "AB+" },
                    new BloodGroup() { Id = 8, Name = "AB-" }

                );


            modelBuilder.Entity<IdentityRole>().HasData(
                    new IdentityRole() { Id= "1", Name = "Donor", NormalizedName = "Donor" },
                    new IdentityRole() { Id = "2", Name = "BloodBankManager", NormalizedName = "BloodBankManager" },
                    new IdentityRole() { Id = "3", Name = "Admin", NormalizedName = "Admin" }

                );


            modelBuilder.Entity<BloodBank>()
                .HasMany(e => e.BloodUnits)
                .WithOne(e => e.BloodBank)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<BloodBank>()
                .HasOne(e=>e.User)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);
                
            modelBuilder.Entity<BloodBank>()
                .HasMany(e => e.BloodTransferReceipts)
                .WithOne(e => e.BloodBank)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<BloodBank>()
                .HasMany(e => e.BloodDonationCamps)
                .WithOne(e => e.BloodBank)
                .OnDelete(DeleteBehavior.Cascade);


            //modelBuilder.Entity<BankBloodGroupMapping>()
            //    .HasOne(map => map.BloodBank)
            //    .WithMany()
            //    .WillCa


            modelBuilder.Entity<BloodGroup>()
                .HasMany(e => e.BankBloodGroupMapping)
                .WithOne(e => e.BloodGroup)
                .OnDelete(DeleteBehavior.NoAction);
        }

    }
}
