using System.Collections.Generic;
using System.Configuration;

using Newtonsoft.Json;
using System.IO;


namespace Solution.CareBook.Gui.Test.Common
{
    public class ConfigSettings
    {
        private readonly Dictionary<string, string> _results;

        public Dictionary<string, string> Results
        {
            get { return _results; }
        }

        public ConfigSettings()
        {

            var configJsonFilePath = string.Format(@".\{0}", ConfigurationManager.AppSettings["ConfigJsonFileName"]);
            var json = File.ReadAllText(configJsonFilePath);

            _results = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
        }
    }
}
