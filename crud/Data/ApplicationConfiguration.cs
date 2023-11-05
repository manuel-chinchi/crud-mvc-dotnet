using Microsoft.Extensions.Configuration;
using System.IO;

namespace crud.Data
{
    public static class ApplicationConfiguration
    {
        // Get connectionString from appsettings.json in Net Core
        // https://stackoverflow.com/questions/64029917/net-core-3-console-not-able-to-get-connectionstring-from-appsettings
        // https://learn.microsoft.com/en-us/ef/core/miscellaneous/connection-strings
        // Read '|DataDirectory|' in connectionString
        // https://stackoverflow.com/questions/37058684/how-to-set-the-right-attachdbfilename-relative-path-in-asp-net-core
        public static string GetConnectionString(string nameConnectionString)
        {
            // Get connection string
            IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(Path.Combine(Directory.GetCurrentDirectory()))
                    .AddJsonFile("appsettings.json", optional: false)
                    .Build();

            string connectionString = configuration.GetConnectionString(nameConnectionString);

            // Read |DataDirectory|
            if (connectionString.Contains("|DataDirectory|"))
            {
                connectionString = connectionString.Replace("|DataDirectory|", Directory.GetCurrentDirectory());
            }

            return connectionString;
        }
    }
}
