using Infrastructure.Models;
using Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;

namespace dapper_ddd_repo
{
    class Program
    {
        // Use example for GenericRepository       
        public static async Task Main(string[] args)
        {
            // Build configuration
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            var connectionString = configuration.GetConnectionString("MainDb");
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new InvalidOperationException("Connection string 'MainDb' not found.");
            }

            // create new Repository for table Users
            var userRepository = new UserRepository("Users", connectionString);
            Console.WriteLine(" Save into table users ");
            var guid = Guid.NewGuid();
            await userRepository.InsertAsync(new User()
            {
                FirstName = "Test2",
                Id = guid,
                LastName = "LastName2"
            });


            await userRepository.UpdateAsync(new User()
            {
                FirstName = "Test3",
                Id = guid,
                LastName = "LastName3"
            });


            var user = await userRepository.GetAsync(guid);
            Console.WriteLine($"Fetched User {user.FirstName}");
            Console.ReadLine();
        }
    }
}
