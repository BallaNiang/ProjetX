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
    public class OrderList
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


        public void StartPicking(IDriver driver)
        {
            var testName = MethodBase.GetCurrentMethod().Name;
            // Last execution image
            var curentImage = G.ActiveDir + testName + "-" + DateTime.Now.ToString(TestConstants.Logformat) + G.ImageFormat;
            // Base line image
            var baseImage = G.ActiveDir + testName + "-" + G.ImageFormat;
            try
            {
                driver.GoToUrl(G.TestedSiteUrl);
                Authentication.Login(driver);
                driver.FindElementAndClick(G.StartPicking);

                // Take and Save screenshot file
                driver.SaveScreenshot(baseImage, curentImage, ImageFormat.Jpeg);
                if (G.CompareImage == TestConstants.True)
                {
                    // Validate images hash comparison is fine
                    Assert.IsTrue(Tools.ImageSimilarity(curentImage, baseImage));
                }

                driver.FindLinkAndClick(G.BackButton);
                Authentication.Logout(driver);

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
            catch (Exception e)
            {
                _verificationErrors.Append(testName + e.Message);
                driver.SaveScreenshot(baseImage, curentImage, ImageFormat.Jpeg);
                driver.Quit();
            }
        }


        public void MoveTo_Next_First_LastOrderPage(IDriver driver)
        {
            var testName = MethodBase.GetCurrentMethod().Name;
            // Last execution image
            var curentImage = G.ActiveDir + testName + "-" + DateTime.Now.ToString(TestConstants.Logformat) + G.ImageFormat;
            // Base line image
            var baseImage = G.ActiveDir + testName + "-" + G.ImageFormat;
            try
            {
                driver.GoToUrl(G.TestedSiteUrl);
                Authentication.Login(driver);
                driver.FindLinkAndClick(G.NextButton);
                driver.FindLinkAndClick(G.FirstButton);
                driver.FindLinkAndClick(G.LastButton);

                // Take and Save screenshot file
                driver.SaveScreenshot(baseImage, curentImage, ImageFormat.Jpeg);
                if (G.CompareImage == TestConstants.True)
                {
                    // Validate images hash comparison is fine
                    Assert.IsTrue(Tools.ImageSimilarity(curentImage, baseImage));
                }

                Authentication.Logout(driver);

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
            catch (Exception e)
            {
                _verificationErrors.Append(testName + e.Message);
                driver.SaveScreenshot(baseImage, curentImage, ImageFormat.Jpeg);
                driver.Quit();
            }
        }

    }

}
