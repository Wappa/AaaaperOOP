using System;
using System.Linq;
using DublinBikes.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DublinBikes.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new Context(
                serviceProvider.GetRequiredService<
                DbContextOptions<Context>>()))
            {
                if (context.BikeStation.Any())
                {
                    return;
                }

                context.BikeStation.AddRange(
                    new BikeStation
                    {
                        ContractName = "Dublin",
                        Name = "Dublin 1",
                        adress = "mayor street",
                        latitude = 12,
                        longitude = 32,
                        banking = true,
                        AvailableBikes = 12,
                        AvailableStands = 8,
                        Capacity = 20,
                        Status = "open",
                        paymentAtTheTerminal = true
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
