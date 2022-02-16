using Bad.Core.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TourTheWorld.Models;

namespace TourTheWorld.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }

        public DbSet<TourModel> Tours { get; set; }
        public DbSet<MultimediaModel> Multimedia { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<MultimediaModel>().HasData(
                        new MultimediaModel()
                        {
                            Id = -1,
                            Url = "https://thumbs.dreamstime.com/b/sunrise-over-beach-cancun-beautiful-mexico-40065727.jpg",
                            Title = "Beach",
                            Description = "Dance with the waves"
                        },
                        new MultimediaModel()
                        {
                            Id = -2,
                            Url = "https://miro.medium.com/max/1400/1*IC7_pdLtDMqwoqLkTib4JQ.jpeg",
                            Title = "Forest",
                            Description = "Get lost in nature"
                        });

            modelBuilder.Entity<TourModel>().HasData(
                    new TourModel
                    {
                        Id = -1,
                        Title = "Pangasinan Day Tour",
                        DateCreated = new DateTime(2022, 2, 14, 15, 28, 39, 282, DateTimeKind.Local).AddTicks(7149),
                        Description = "Whole day trip around Pangasinan",
                        Price = 2500.00M,
                        PrimaryMediaId = -1
                    },
                    new TourModel
                    {
                        Id = -2,
                        Title = "La Union Day Tour",
                        DateCreated = new DateTime(2022, 2, 14, 15, 28, 39, 282, DateTimeKind.Local).AddTicks(7149),
                        Description = "Whole day trip around La Union",
                        Price = 2200.00M,
                        PrimaryMediaId = -2
                    }
            );
        }
    }
}
