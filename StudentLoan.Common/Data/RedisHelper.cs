using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ServiceStack.Redis;


namespace StudentLoan.Common
{
    public class RedisHelper
    {
        public static RedisClient InitRedisClient()
        {
            string host = ConfigHelper.AppSettings<string>("RedisHost");
            int port = ConfigHelper.AppSettings<int>("RedisPort");
            long db = ConfigHelper.AppSettings<long>("RedisDB");

            return new RedisClient(host, port, null, db);
        }

    }
}
