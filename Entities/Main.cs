using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using Solution.CareBook.Gui.Test.Control;


// Requires reference to WebDriver.Support.dll
using System;
using NUnit.Framework;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Appium.Enums;

namespace Solution.CareBook.Gui.Test.Entities
{


    [TestClass]
    [TestFixture]

    public class Main
    {


        [TestInitialize]
        public virtual void TestInit()
        {
            G.SetupTest();
        }


        [TestMethod]
        [Test]
        public void Sample()
        {
            FirefoxDriverService service = FirefoxDriverService.CreateDefaultService(@"C:\Program Files (x86)\Mozilla Firefox\");
            service.FirefoxBinaryPath = @"C:\Program Files (x86)\Mozilla Firefox\firefox.exe";
            using (IWebDriver driver = new FirefoxDriver(service))
            {
                //Notice navigation is slightly different than the Java version
                //This is because 'get' is a keyword in C#
                driver.Navigate().GoToUrl("http://www.google.com/");

                // Find the text input element by its name
                IWebElement query = driver.FindElement(By.Name("q"));

                // Enter something to search for
                query.SendKeys("Cheese");

                // Now submit the form. WebDriver will find the form for us from the element
                query.Submit();

                // Google's search is rendered dynamically with JavaScript.
                // Wait for the page to load, timeout after 10 seconds
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                wait.Until(d => d.Title.StartsWith("cheese", StringComparison.OrdinalIgnoreCase));

                // Should see: "Cheese - Google Search" (for an English locale)
                Console.WriteLine("Page title is: " + driver.Title);
            }
        }

        [TestMethod]
        [Test]
        public void LocalStartup()
        {
            LocalDriver driver = new LocalDriver(G.FirefoxHome);
            driver.GoToUrl("http://www.dow.com");

        }

        [Test]
        [TestMethod]
        public void RemoteStartup()
        {
            FirefoxOptions options = new FirefoxOptions();
            options.AddArguments("disable-infobars");
            IDriver driver = new Driver(new Uri(G.SeleniumHubUrl), options.ToCapabilities());
            driver.GoToUrl("http://www.youtube.com");
        }


        [Test]
        [TestMethod]
        public void MobileStartup()
        {
            DesiredCapabilities capabilities = new DesiredCapabilities();
            capabilities.SetCapability(MobileCapabilityType.PlatformName, "Android");
            capabilities.SetCapability(MobileCapabilityType.PlatformVersion, "9.0");
            capabilities.SetCapability(MobileCapabilityType.DeviceName, "emulator-5554");
            capabilities.SetCapability(MobileCapabilityType.Udid, "52004a18537135e3");

            //capabilities.SetCapability(MobileCapabilityType.AutomationName, "UIAutomator2");
            //capabilities.SetCapability(MobileCapabilityType.BrowserName, "chrome");
            capabilities.SetCapability(MobileCapabilityType.App, "C:\\Users\\balla.niang\\Downloads\\WikipediaSample.apk");
            capabilities.SetCapability("appActivity", "org.wikipedia.page.PageActivity");
            capabilities.SetCapability("appPackage", "org.wikipedia.alpha");



            MobileDriver driver = new MobileDriver("http://192.168.100.64:4723/wd/hub", capabilities);

           driver.Quit();
        }

        [Test]
        [TestMethod]
        public void Mobiletest()
        {
            DesiredCapabilities capabilities = new DesiredCapabilities();
            capabilities.SetCapability(MobileCapabilityType.PlatformName, "Android");
            capabilities.SetCapability(MobileCapabilityType.PlatformVersion, "10");
            capabilities.SetCapability(MobileCapabilityType.DeviceName, "8B3Y0TC63");
            //capabilities.SetCapability(MobileCapabilityType.Udid, "52004a18537135e3");

            //capabilities.SetCapability(MobileCapabilityType.AutomationName, "UIAutomator2");
            //capabilities.SetCapability(MobileCapabilityType.BrowserName, "chrome");
            //capabilities.SetCapability(MobileCapabilityType.App, "C:\apps\AA.apk");
            capabilities.SetCapability("appActivity", "com.carebook.android.module.entrypoint.EntryPointActivity");
            capabilities.SetCapability("appPackage", "app.letsbewell.android.qa");



            MobileDriver driver = new MobileDriver("http://192.168.100.64:4723/wd/hub", capabilities);

            driver.Quit();
        }


    }
}
