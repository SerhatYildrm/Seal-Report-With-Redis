using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;


namespace Seal.Model
{

    public class Redis
    {
        string RedisHost { set; get; }
        private RedisClient redisClient = null;

        public void Connect(string Host) => redisClient = new RedisClient(Host);
        public void Close()=> redisClient.Dispose();
        public long HasKey(String key) => redisClient.Exists(key);

        public List<JObject> GetData(String key)
        {
            List<JObject> redisData = new List<JObject>();

            var datas = redisClient.LRange(key, 0, 10);
            foreach (var data in datas)
            {
                string d = Encoding.UTF8.GetString(data, 0, data.Length);
                redisData.Add(JObject.Parse(d));
            }
            return redisData;
        }

    }
}
