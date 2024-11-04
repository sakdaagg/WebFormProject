using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace WebFormProject.DAL.DbContexts;

public class WebFormDbContextFactory : IDesignTimeDbContextFactory<WebFormDbContext>
{
    public WebFormDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<WebFormDbContext>();

        // appsettings.json dosyasından bağlantı dizesini okuma
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        var connectionString = configuration.GetConnectionString("DefaultConnection");
        optionsBuilder.UseSqlServer(connectionString);

        return new WebFormDbContext(optionsBuilder.Options);
    }
}
