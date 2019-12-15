using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using TripTrackerLive.BackService.Models;

namespace TripTrackerLive.BackService.Data
{
    public class TripContext : DbContext
    {
        public TripContext(DbContextOptions<TripContext> options):
            base(options)
        {

        }

        //public TripContext()
        //{
        //    /*this.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;*///stop tracking change tracker
        //}

        public DbSet<Trip> Trips { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.Entry<Trip>().HasKey()
        //}

        public static void SeedData(IServiceProvider serviceProvider)
        {

            using (var serviceScope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<TripContext>();

                context.Database.EnsureCreated();


                context.Trips.AddRange(new Trip[]
                {
                new Trip
            {
                Id=1,
                Name = "MVP Summit",
                StartDate = new DateTime(2018,3,5),
                EndDate = new DateTime(2018,3,8)
            },
            new Trip
            {
                Id=2,
                Name="DevIntersection Orlando 2018",
                StartDate = new DateTime(2018,3,25),
                EndDate = new DateTime(2018,3,27)
            },
            new Trip
            {
                Id=3,
                Name="Build 2018",
                StartDate = new DateTime(2019,5,5),
                EndDate = new DateTime(2019,6,6)
            }
                });

               context.SaveChanges();
            }
        }
    }
}
