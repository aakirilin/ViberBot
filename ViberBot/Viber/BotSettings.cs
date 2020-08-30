using Microsoft.Extensions.Configuration;
using System.IO;

namespace ViberBot.Viber
{
    public class BotSettings
    {
        public static string Name => GetConfiguration.GetSection("BotSettings").GetSection("Name").Value;
        public static string Uri => GetConfiguration.GetSection("BotSettings").GetSection("Uri").Value;
        public static string Token => GetConfiguration.GetSection("BotSettings").GetSection("Token").Value; 
        public static string Avatar => null;
        public static string WebHookUrl => GetConfiguration.GetSection("BotSettings").GetSection("WebHookUrl").Value; 

        public static string AdminLogin => GetConfiguration.GetSection("Admin").GetSection("Login").Value;
        public static string AdminPassword => GetConfiguration.GetSection("Admin").GetSection("Password").Value;
        public static string AdminHashPassword => GetConfiguration.GetSection("Admin").GetSection("HashPassword").Value;



        private static IConfigurationRoot configuration { get; set; }

        private static object locker = new object();

        private static IConfigurationRoot GetConfiguration
        {
            get
            {
                lock (locker)
                {
                    if(configuration == null)
                    {
                        var builder = new ConfigurationBuilder();
                        builder.SetBasePath(Directory.GetCurrentDirectory());
                        builder.AddJsonFile("appsettings.json");
                        var config = builder.Build();
                        return config;
                    }
                }
                return configuration;
            }
        }
    }
}
