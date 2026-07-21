using Microsoft.EntityFrameworkCore;

namespace Discount.Grpc.Data;

public static class Extentions
{
    public static IApplicationBuilder UseMigration(this IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();
        using var dbContext = scope.ServiceProvider.GetRequiredService<DiscountContext>();
        var dbpath = dbContext.Database.GetConnectionString();
        Console.WriteLine($"Databse path: {dbpath}");

        dbContext.Database.Migrate();
        Console.WriteLine($"Databse migrate successfully");


        var count =dbContext.Coupons.Count();
        Console.WriteLine($"Total coupouns :{count}");


        return app;
    }
}
