using GraphQl_solution.Database;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQl_solution
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            using (IServiceScope scope = host.Services.CreateScope())
            {
                ApplicationDbContext context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

                var authorDbEntry = context.Authors.Add(
                    new Author
                    {
                        Name = "First Author",
                    }
                    );
                context.SaveChanges();

                context.Books.AddRange(
                    new Book
                    {
                        Name = "First Book",
                        Published = true,
                        AuthorId = authorDbEntry.Entity.Id,
                        Genre = "Action",
                    },
                    new Book
                    {
                        Name = "Second Book",
                        Published = false,
                        AuthorId = authorDbEntry.Entity.Id,
                        Genre = "Crime"
                    }
                    );

            }
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
