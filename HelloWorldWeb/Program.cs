// <copyright file="Program.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace HelloWorldWeb
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>

/*        Host.CreateDefaultBuilder(args).ConfigureWebHostDefaults(webBuilder =>
        {
            var port = Environment.GetEnvironmentVariable("PORT");
            webBuilder.UseStartup<Startup>().UseUrls("http://*:" + port);
        });*/
        Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
            webBuilder.UseStartup<Startup>();
        });
    }
}