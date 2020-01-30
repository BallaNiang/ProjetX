using Solution.CareBook.Gui.Test.Control;

using log4net;

namespace Solution.CareBook.Gui.Test.Common
{
    public static class SharedResources
    {
        public static GlobalSettings GlobalSettings { get; set; }
        public static ConfigSettings ConfigSettings { get; set; }

        private static ILog _log;

        public static GlobalSettings GetResource()
        {
            return GlobalSettings ?? (GlobalSettings = new GlobalSettings());
        }
        public static ConfigSettings GetConfig()
        {
            return ConfigSettings ?? (ConfigSettings = new ConfigSettings());
        }
        public static ILog GetLogger()
        {
            if (_log == null)
            {
                _log = LogManager.GetLogger(typeof(IDriver));
                log4net.Config.XmlConfigurator.Configure();
            }
            return _log ;
        }
    }
}
