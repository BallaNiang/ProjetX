using OpenQA.Selenium;
using Solution.CareBook.Gui.Test.Common;

namespace Solution.CareBook.Gui.Test.Entities
{
    class G
    {
        public static string TestedSiteUrl;
        public static string SeleniumHubUrl;
        public static string ImageFormat;
        public static string CompareImage;
        public static string ActiveDir;
        public static string LoginPin;
        public static string StoreScope;
        public static string FirefoxHome;

        public static string UpcType0;
        public static string UpcType1;
        public static string UpcType2;

        public static string LoginPrompt;
        public static string LogoutLink;
        public static string LoginPinField;
        public static string LoginLangField;
        public static string StoreScopeField;
        public static string StartPicking;
        public static string BackButton;
        public static string FirstButton;
        public static string NextButton;
        public static string LastButton;
        public static string ScanSkuField;
        public static string ScanButton;
        public static string ScanConfirmButton;
        public static string ScanContinueButton;
        public static string OrderDetailPage;
        public static string OrderToAddOnPickingPage;
        public static string OrderDescSection;
        public static string AddToPicklistButton;
        public static string AddProductButton;
        public static string OnHoldPickingButton;
        public static string ResumePickingButton;
        public static string CancelPickingButton;
        public static string CaptureFormatList;
        public static string CaptureField;
        public static string ProductType0Page;
        public static string ProductType1Page;
        public static string ProductType2Page;
        public static string CompletedTap;
        public static string CompletedItem;
        public static string ProductNotAvaiButton;
        public static string ReactivateToPickButton;
        public static string DropScannedItemButton;
        public static string SubstituteButton;
        public static string PickedNotScanButton;
        public static string FixAisleButton;


        public static void SetupTest()
        {
            log4net.Config.XmlConfigurator.Configure();

            // Global settings
            SeleniumHubUrl = SharedResources.GetResource().SeleniumHub;
            TestedSiteUrl = SharedResources.GetResource().TestedSite;
            ImageFormat = SharedResources.GetResource().ImageFormat;
            CompareImage = SharedResources.GetResource().CompareImage;
            ActiveDir = SharedResources.GetResource().ActiveDir;
            LoginPin = SharedResources.GetResource().LoginPin;
            StoreScope = SharedResources.GetResource().StoreScope;
            FirefoxHome = SharedResources.GetResource().FirefoxHome;

            // Data settings
            UpcType0 = SharedResources.GetConfig().Results["UpcType0"];
            UpcType1 = SharedResources.GetConfig().Results["UpcType1"];
            UpcType2 = SharedResources.GetConfig().Results["UpcType2"];

            // Test settings
            LogoutLink = SharedResources.GetConfig().Results["LogoutLink"];
            LoginPrompt = SharedResources.GetConfig().Results["LoginPrompt"];
            LoginPinField = SharedResources.GetConfig().Results["LoginPinField"];
            LoginLangField = SharedResources.GetConfig().Results["LoginLangField"];
            StoreScopeField = SharedResources.GetConfig().Results["StoreScopeField"];
            StartPicking = SharedResources.GetConfig().Results["StartPicking"];
            BackButton = SharedResources.GetConfig().Results["BackButton"];
            FirstButton = SharedResources.GetConfig().Results["FirstButton"];
            NextButton = SharedResources.GetConfig().Results["NextButton"];
            LastButton = SharedResources.GetConfig().Results["LastButton"];
            ScanSkuField = SharedResources.GetConfig().Results["ScanSkuField"];
            ScanButton = SharedResources.GetConfig().Results["ScanButton"];
            ScanConfirmButton = SharedResources.GetConfig().Results["ScanConfirmButton"];
            ScanContinueButton = SharedResources.GetConfig().Results["ScanContinueButton"];
            OrderDetailPage = SharedResources.GetConfig().Results["OrderDetailPage"];
            OrderToAddOnPickingPage = SharedResources.GetConfig().Results["OrderToAddOnPickingPage"];
            OrderDescSection = SharedResources.GetConfig().Results["OrderDescSection"];
            AddToPicklistButton = SharedResources.GetConfig().Results["AddToPicklistButton"];
            AddProductButton = SharedResources.GetConfig().Results["AddProductButton"];
            OnHoldPickingButton = SharedResources.GetConfig().Results["OnHoldPickingButton"];
            ResumePickingButton = SharedResources.GetConfig().Results["ResumePickingButton"];
            CancelPickingButton = SharedResources.GetConfig().Results["CancelPickingButton"];
            CaptureFormatList = SharedResources.GetConfig().Results["CaptureFormatList"];
            CaptureField = SharedResources.GetConfig().Results["CaptureField"];
            ProductType0Page = SharedResources.GetConfig().Results["ProductType0Page"];
            ProductType1Page = SharedResources.GetConfig().Results["ProductType1Page"];
            ProductType2Page = SharedResources.GetConfig().Results["ProductType2Page"];
            CompletedTap = SharedResources.GetConfig().Results["CompletedTap"];
            CompletedItem = SharedResources.GetConfig().Results["CompletedItem"];
            ProductNotAvaiButton = SharedResources.GetConfig().Results["ProductNotAvaiButton"];
            ReactivateToPickButton = SharedResources.GetConfig().Results["ReactivateToPickButton"];
            DropScannedItemButton = SharedResources.GetConfig().Results["DropScannedItemButton"];
            SubstituteButton = SharedResources.GetConfig().Results["SubstituteButton"];
            PickedNotScanButton = SharedResources.GetConfig().Results["PickedNotScanButton"];
            FixAisleButton = SharedResources.GetConfig().Results["FixAisleButton"];

        }
        public static void TeardownTest()
        {
            try
            {

            }
            catch (ElementNotVisibleException)
            {
 
            }
        }
    }
}
