using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;

namespace Dojodachi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
    public static class SessionExtensions
        {
            public static void SetObjectAsJson(this ISession session, string key, object value){
                session.SetString(key, JsonConvert.SerializeObject(value));
            }
    public static T GetObjectFromJson<T>(this ISession session, string key){
            string value = session.GetString(key);
            return value == null? default(T) : JsonConvert.DeserializeObject<T>(value);
    }
        }
}
