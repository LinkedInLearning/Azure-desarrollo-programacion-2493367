﻿using Microsoft.EntityFrameworkCore;

namespace Wpm.Web.Dal;

public static class WpmDbContextExtensions
{
    public static void AddWpmDb(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<WpmDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("Wpm"));
        });
    }
    public static void EnsureWpmDbIsCreated(this IServiceProvider serviceProvider)
    {
        var scope = serviceProvider.CreateScope();
        var db = scope.ServiceProvider.GetService<WpmDbContext>()!;
        db.Database.EnsureCreated();
        db.Dispose();
    }
}