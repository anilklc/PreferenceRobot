using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreferenceRobot.Persistence
{
    static class Configuration
    {
        static public string ConfiguraionString
        {
            get
            {
                ConfigurationManager configurationManager = new();
                configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../../Presentation/PreferenceRobot.API"));
                configurationManager.AddJsonFile("appsettings.json");

                return configurationManager.GetConnectionString("sqlConnection");
            }
        }
    }
}
