﻿using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using StolovkaWebAPI.Data;
using System.Threading.Tasks;

namespace StolovkaWebAPI
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = CreateWebHostBuilder(args).Build();

            using (var serviceScope = host.Services.CreateScope())
            {
                var dbContext = serviceScope.ServiceProvider.GetRequiredService<StolovkaDbContext>();

                await dbContext.Database.MigrateAsync();

                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                //if (!await roleManager.RoleExistsAsync("Admin"))
                //{
                //    var adminRole = new IdentityRole("Admin");
                //    await roleManager.CreateAsync(adminRole);
                //}

                //if (!await roleManager.RoleExistsAsync("Poster"))
                //{
                //    var posterRole = new IdentityRole("Poster");
                //    await roleManager.CreateAsync(posterRole);
                //}
            }

            await host.RunAsync();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
