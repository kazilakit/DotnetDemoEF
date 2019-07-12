using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using NLog.Web;

namespace DemoCrud.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var logger = NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();
            try
            {
                logger.Debug("Engine Innited");
                CreateWebHostBuilder(args).Build().Run();
            }
            catch (Exception ex)
            {

                logger.Error(ex, "Error occured");
            }
            finally
            {
                NLog.LogManager.Shutdown();
            }
            
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
            .ConfigureLogging(log=> 
            {
                log.ClearProviders();
                log.SetMinimumLevel(LogLevel.Information);
                //log.AddConsole();
                //log.AddDebug();
                //log.AddEventSourceLogger();

            }).UseNLog();
    }
}
