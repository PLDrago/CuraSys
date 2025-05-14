using System;
using System.IO;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using CuraSys.Data;
using CuraSys.GUI;

namespace CuraSys
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplyDatabaseMigrations();

            ApplicationConfiguration.Initialize();
            Application.Run(new MainWindow());
        }

        private static void ApplyDatabaseMigrations()
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<CuraSysContext>();
            optionsBuilder.UseMySql(
                config.GetConnectionString("DefaultConnection"),
                new MySqlServerVersion(new Version(8, 0, 34))
            );
            
            using var context = new CuraSysContext(optionsBuilder.Options);
            DbSeeder.Seed(context);             
        }
    }
}