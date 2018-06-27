using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace HiddleWindow.Model
{
    [Serializable]
    class Configuration
    {
        public int time_out;           // 多少毫秒内无动作则隐藏
        public bool enable;            // 是否启用

        private static string CONFIG_PATH = "config.json";
        private static int defaultTime = 60000;   // 默认是60秒

        public static Configuration Load()
        {
            try
            {
                string configContent = File.ReadAllText(CONFIG_PATH);
                Configuration config = JsonConvert.DeserializeObject<Configuration>(configContent);

                if (config.time_out <= 0)
                    config.time_out = defaultTime;
                
                return config;
            }
            catch (FileNotFoundException e)
            {
                Configuration config = new Configuration { time_out=defaultTime, enable=true};
                Save(config);
                return config;
            }
        }

        public static void Save(Configuration config)
        {
            string configContent = JsonConvert.SerializeObject(config, Formatting.Indented);

            File.WriteAllText(CONFIG_PATH, configContent);
        }
    }
}
