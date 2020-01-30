using System;
using System.Drawing.Imaging;
using System.Reflection;
using System.Text;
using Gallio.Framework.Assertions;
using MbUnit.Framework;
using OpenQA.Selenium;
using Solution.CareBook.Gui.Test.Common;
using Solution.CareBook.Gui.Test.Control;
using Solution.CareBook.Gui.Test.Entities;

namespace Solution.CareBook.Gui.Test.Pages
{
    public class Authentication
    {

        private StringBuilder _verificationErrors;

        public void SetupTest()
        {

            G.SetupTest();
            _verificationErrors = new StringBuilder();

        }
        public void TeardownTest()
        {
            try
            {

            }
            catch (ElementNotVisibleException e)
            {
                // Ignore errors if unable to close the browser
                if (e.Source != null) _verificationErrors.Append(e.Message);
            }
            Assert.AreEqual("", _verificationErrors.ToString());
            _verificationErrors.Clear();
        }

        public void LoginValidPin(IDriver driver)
        {
            var testName = MethodBase.GetCurrentMethod().Name;
            // Last execution image
            var curentImage = G.ActiveDir + testName + "-" + DateTime.Now.ToString(TestConstants.Logformat) + G.ImageFormat;
            // Base line image
            var baseImage = G.ActiveDir + testName + "-" + G.ImageFormat;
            try
            {
                driver.GoToUrl(G.TestedSiteUrl);
                Login(driver);

                // Take and Save screenshot file
                driver.SaveScreenshot(baseImage, curentImage, ImageFormat.Jpeg);
                if (G.CompareImage == TestConstants.True)
                {
                    // Validate images hash comparison is fine
                    Assert.IsTrue(Tools.ImageSimilarity(curentImage, baseImage));
                }

                driver.FindElementAndClick(G.LogoutLink);
                driver.WaitLoadingPage(G.LoginPrompt);

                driver.Dispose();

            }
            catch (ElementNotVisibleException e)
            {
                _verificationErrors.Append(testName + e.Message);
                driver.SaveScreenshot(baseImage, curentImage, ImageFormat.Jpeg);
                driver.Quit();
            }
            catch (AssertionException e)
            {
                _verificationErrors.Append(testName + e.Message);
                driver.SaveScreenshot(baseImage, curentImage, ImageFormat.Jpeg);
                driver.Quit();
            }
            catch (Exception)
            {
                driver.Quit();
            }
        }


        public void Login_Logout(IDriver driver)
        {
            var testName = MethodBase.GetCurrentMethod().Name;
            // Last execution image
            var curentImage = G.ActiveDir + testName + "-" + DateTime.Now.ToString(TestConstants.Logformat) + G.ImageFormat;
            // Base line image
            var baseImage = G.ActiveDir + testName + "-" + G.ImageFormat;
            try
            {
                driver.GoToUrl(G.TestedSiteUrl);
                Login(driver);

                // Take and Save screenshot file
                driver.SaveScreenshot(baseImage, curentImage, ImageFormat.Jpeg);
                if (G.CompareImage == TestConstants.True)
                {
                    // Validate images hash comparison is fine
                    Assert.IsTrue(Tools.ImageSimilarity(curentImage, baseImage));
                }

                driver.FindElementAndClick(G.LogoutLink);
                driver.WaitLoadingPage(G.LoginPrompt);

                driver.Dispose();
            }
            catch (ElementNotVisibleException e)
            {
                _verificationErrors.Append(testName + e.Message);
                driver.SaveScreenshot(baseImage, curentImage, ImageFormat.Jpeg);
                driver.Quit();
            }
            catch (AssertionException e)
            {
                _verificationErrors.Append(testName + e.Message);
                driver.SaveScreenshot(baseImage, curentImage, ImageFormat.Jpeg);
                driver.Quit();
            }
            catch (Exception)
            {
                driver.Quit();
            }
        }

        public static void Login(IDriver driver)
        {
            driver.WaitLoadingPage(G.LoginPrompt);
            if (driver.IsElementVisible(G.StoreScopeField))
            {
                driver.Login(G.LoginPin, G.StoreScope, G.LoginPinField, G.StoreScopeField);
            }
            else
            {
                driver.FindElementAndClick(G.LoginLangField);
                driver.Pinin(G.LoginPin, G.LoginPinField);                
            }
            driver.WaitLoadingPage(G.LogoutLink);
        }

        public static void Logout(IDriver driver)
        {
            driver.GoToUrl(G.TestedSiteUrl);
            driver.FindElementAndClick(G.LogoutLink);
        }
    }
}
