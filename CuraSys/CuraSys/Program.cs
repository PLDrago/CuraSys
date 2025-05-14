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

            ApplyDatabaseMigrations(context);
            ExecuteSqlScriptWithEF(context, "Init_Users.sql");

            ApplicationConfiguration.Initialize();
            Application.Run(new MainWindow());
        }

        private static void ApplyDatabaseMigrations(CuraSysContext context)
        {
            context.Database.Migrate();
            DbSeeder.Seed(context);
        }

        private static void ExecuteSqlScriptWithEF(CuraSysContext context, string filePath)
        {
            string sql = File.ReadAllText(filePath);

            foreach (string command in sql.Split(';', StringSplitOptions.RemoveEmptyEntries))
            {
                string trimmed = command.Trim();
                if (!string.IsNullOrWhiteSpace(trimmed))
                {
                    context.Database.ExecuteSqlRaw(trimmed);
                }
            }
        }
    }
}