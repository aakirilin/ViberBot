using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace ViberBot.Data
{
    public class DatabaseContextFactory
    {
        private static string connectionString = null;

        public static object locker = new object();

        public static string getConnectionString
        {
            get
            {
                lock (locker)
                {
                    if (connectionString == null)
                    {
                        var builder = new ConfigurationBuilder();
                        builder.SetBasePath(Directory.GetCurrentDirectory());
                        builder.AddJsonFile("appsettings.json");
                        var config = builder.Build();
                        connectionString = config.GetConnectionString("DatabaseContext");
                    }
                }
                return connectionString;
            }
        }

        public static DatabaseContext getContext
        {
            get
            {
                var option = new DbContextOptionsBuilder<DatabaseContext>();
                option.UseSqlServer(getConnectionString);
                var contextDB = new DatabaseContext(option.Options);
                return contextDB;
            }
        }
    }
}
