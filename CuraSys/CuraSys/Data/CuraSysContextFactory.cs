using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace CuraSys.Data
{
    public class CuraSysContextFactory : IDesignTimeDbContextFactory<CuraSysContext>
    {
        public CuraSysContext CreateDbContext(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false)
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<CuraSysContext>();
            optionsBuilder.UseMySql(
                config.GetConnectionString("DefaultConnection"),
                new MySqlServerVersion(new Version(8, 0, 34))
            );

            return new CuraSysContext(optionsBuilder.Options);
        }
    }
}