using AzureRedisCachePractice.Configuration;
using AzureRedisCachePractice.Models;
using Microsoft.AspNet.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.OptionsModel;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AzureRedisCachePractice.Controllers
{
    public class HomeController : Controller
    {
        public EnvironmentVariables EnvironmentVariables { get; set; }

        public IDatabase Cache { get; set; }

        public HomeController(IOptions<EnvironmentVariables> configuration)
        {
            this.EnvironmentVariables = configuration.Value;

            var connectionString = this.EnvironmentVariables.AZURE_REDIS_CONNECTION_STRING;

            ConnectionMultiplexer connection = ConnectionMultiplexer.Connect(connectionString);
            IDatabase cache = connection.GetDatabase();

            this.Cache = cache;
        }

        public IActionResult Index()
        {

            this.Cache.StringSet("key1", "Hello World from Azure Redis Cache!");
            this.Cache.StringSet("key2", "Goodbye World from Azure Redis Cache!");

            return View();
        }

        public IActionResult Page2()
        {
            return View(new HomeViewModel { Message1 = this.Cache.StringGet("key1"), Message2 = this.Cache.StringGet("key2") });
        }
    }
}
