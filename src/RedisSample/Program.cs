using System;
using System.Collections.Generic;
using System.Linq;
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
            var devicesCount = 10;
            for (int i = 1; i <= devicesCount; i++)
            {
                var value = cache.StringGet($"key{i}");
                Console.WriteLine($"key{i} = {value}");
            }
        }

        public void SaveBigData()
        {
            var devicesCount = 10;
            var rnd = new Random();
            var cache = RedisConnectorHelper.Connection.GetDatabase();

            for (int i = 1; i <= devicesCount; i++)
            {
                var value = rnd.Next(0, 10000);
                //var value = i;
                cache.StringSet($"key{i}", value);
            }
        }
    }
}
