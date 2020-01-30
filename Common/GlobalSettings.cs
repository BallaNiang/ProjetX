
using System.Configuration;

namespace Solution.CareBook.Gui.Test.Common
{
    /// <summary>
    /// This class wraps a Global settings defined in file App.config.
    /// </summary>
    public class GlobalSettings
    {
        private const string LoginPinKey = "LoginPin";
        private const string StoreScopeKey = "StoreScope";
        private const string ImageFormatKey = "ImageFormat";
        private const string CompareImageKey = "CompareImage";
        private const string ActiveDirKey = "ActiveDir";
        private const string TestedSiteKey = "TestedSite";
        private const string SeleniumHubKey = "SeleniumHub";
        private const string ImgSimilarityRateKey = "ImgSimilarityRate";
        private const string FirefoxHomeKey = "FirefoxHome";


        private readonly string _loginPin;
        private readonly string _storeScope;
        private readonly string _imageFormat;
        private readonly string _compareImage;
        private readonly string _activeDir;
        private readonly string _testedSite;
        private readonly string _seleniumHub;
        private readonly string _imgSimilarityRate;
        private readonly string _firefoxHome;


        public string LoginPin
        {
            get { return _loginPin; }
        }

        public string StoreScope
        {
            get { return _storeScope; }
        }

        public string ImageFormat
        {
            get { return _imageFormat; }
        }

        public string CompareImage
        {
            get { return _compareImage; }
        }

        public string ActiveDir
        {
            get { return _activeDir; }
        }

        public string TestedSite
        {
            get { return _testedSite; }
        }

        public string SeleniumHub
        {
            get { return _seleniumHub; }
        }

        public string ImgSimilarityRate
        {
            get { return _imgSimilarityRate; }
        }

        public string FirefoxHome
        {
            get { return _firefoxHome; }
        }

        public GlobalSettings()
        {
            _loginPin = ConfigurationManager.AppSettings[LoginPinKey];
            _storeScope = ConfigurationManager.AppSettings[StoreScopeKey];
            _imageFormat = ConfigurationManager.AppSettings[ImageFormatKey];
            _compareImage = ConfigurationManager.AppSettings[CompareImageKey];
            _activeDir = ConfigurationManager.AppSettings[ActiveDirKey];
            _testedSite = ConfigurationManager.AppSettings[TestedSiteKey];
            _seleniumHub = ConfigurationManager.AppSettings[SeleniumHubKey];
            _imgSimilarityRate = ConfigurationManager.AppSettings[ImgSimilarityRateKey];
            _firefoxHome = ConfigurationManager.AppSettings[FirefoxHomeKey];
        }
    }
}
