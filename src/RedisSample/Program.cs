using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RedisSample
{
    class Program
    {
        static void Main(string[] args)
        {
            var program = new Program();

            Console.WriteLine("Saving random data in cache");
            program.SaveBigData();

            Console.WriteLine("Reading data from cache");
            program.ReadData();

            Console.ReadLine();
        }

        public void ReadData()
        {
            var cache = RedisConnectorHelper.Connection.GetDatabase();
            var devicesCount = 1;
            for (int i = 1; i <= devicesCount; i++)
            {
                var value = cache.StringGet($"key{i}");
                Console.WriteLine($"key{i} = {value}");
            }
        }

        public  void SaveBigData()
        {
            var devicesCount = 1;
            var rnd = new Random();
            var cache = RedisConnectorHelper.Connection.GetDatabase();

            for (int i = 1; i <= devicesCount; i++)
            {
                var value = File.ReadAllText("E:\\PRACTICE\\PERFORMANCE\\DistributedCachingUsingRedis\\src\\RedisSample\\data.txt");
                //var value = rnd.Next(0, 10000);
                //var value = i;
                cache.StringSet($"key{i}", value);
            }
        }
    }
}
