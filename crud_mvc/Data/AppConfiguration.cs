using Microsoft.Extensions.Configuration;
using System.IO;

namespace crud_mvc.Data
{
    public static class AppConfigurationManager
    {
        // Get connectionString from appsettings.json in Net Core
        // https://stackoverflow.com/questions/64029917/net-core-3-console-not-able-to-get-connectionstring-from-appsettings
        public static string GetConnectionString(string connectionString)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(Path.Combine(Directory.GetCurrentDirectory()))
                    .AddJsonFile("appsettings.json", optional: false)
                    .Build();

            return configuration.GetConnectionString(connectionString);
        }
    }
}
