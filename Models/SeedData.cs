using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using MvcMovie.Data;
using MvcMovie.Models;

namespace MvcMovie.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDBContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<ApplicationDBContext>>()))
            {
                // Look for any movies.
                if (context.Product.Any())
                {
                    return;   // DB has been seeded
                }

                context.Product.AddRange(
                    new Product
                    {
                        ProductID = "000001",
                        ProductName = "Nguyễn Quang Hiển ",
                        UnitPrice = "abc",
                        Quantity = 123,
                    },

                    new Product
                    {
                        ProductID = "000002",
                        ProductName = "alo",
                        UnitPrice = "CBA",
                        Quantity = 1234,
                    },

                    new Product
                    {
                        ProductID = "000003",
                        ProductName = "blo",
                        UnitPrice = "À Lố",
                        Quantity = 01234,
                    },

                    new Product
                    {
                        ProductID = "000004",
                        ProductName = "clo",
                        UnitPrice = "Bề lố",
                        Quantity = 12311345,
                    }
                );
                context.SaveChanges();
            }
        }
    }
}