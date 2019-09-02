using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

namespace DotNetCore_DI_Console
{
    class Program
    {
        //Based on the article by Andrew Lock: https://andrewlock.net/using-dependency-injection-in-a-net-core-console-application/


        static void Main(string[] args)
        {
            //Setup our DI
            var serviceProvider = new ServiceCollection()
                .AddLogging()
                .AddScoped<IFileService, FileService>()
                .BuildServiceProvider()
                ;

            //Configure Console Logging
            serviceProvider
                .GetService<ILoggingBuilder>()
                //.AddConsole()
                ;

            var logger = serviceProvider.GetService<ILoggerFactory>()
                .CreateLogger<Program>();
            logger.LogError("Starting Up!");

            //do the actual work here
            var fileService = serviceProvider.GetService<IFileService>();
            fileService.WriteToFile("ABC", "test.txt");

            logger.LogDebug("All done!");
        }
    }

    interface IFileService
    {
        void WriteToFile(string content, string filename);
    }

    class FileService : IFileService
    {
        public void WriteToFile(string content, string filename)
        {

        }
    }
}
