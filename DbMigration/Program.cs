using System.Reflection;
using DbUp;
using Microsoft.Extensions.Configuration;

namespace DbMigration
{
    class Program
    {
        static int Main(string[] args)
        {
            // Build configuration
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            var connectionString = configuration.GetConnectionString("MainDb");
            if (string.IsNullOrEmpty(connectionString))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Connection string 'MainDb' not found.");
                Console.ResetColor();
                return -1;
            }

            EnsureDatabase.For.SqlDatabase(connectionString);
            
            var upgrader =
                DeployChanges.To
                    .SqlDatabase(connectionString)
                    .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly())
                    .LogToConsole()
                    .Build();

            var result = upgrader.PerformUpgrade();

            if (!result.Successful)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(result.Error);
                Console.ResetColor();
#if DEBUG
                Console.ReadLine();
#endif
                return -1;
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Success!");
            Console.ResetColor();
            return 0;
        }
    }
}
