using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AzureRedisCachePractice.Configuration
{
    public class EnvironmentVariables
    {
        // Create an environment variable with key of AZURE_REDIS_CONNECTION_STRING and a value of your azure redis cache connection string
        public string AZURE_REDIS_CONNECTION_STRING { get; set; }
    }
}
