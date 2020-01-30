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
    public class PickingDetail
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


        public void ProductNotAvailable_Reactivate(IDriver driver)
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
                driver.FindElementAndClick(G.ProductType2Page);
                if (driver.IsElementPresent(G.ProductNotAvaiButton))
                {
                    driver.FindElementAndClick(G.ProductNotAvaiButton);
                }

                // Take and Save screenshot file
                driver.SaveScreenshot(baseImage, curentImage, ImageFormat.Jpeg);
                if (G.CompareImage == TestConstants.True)
                {
                    // Validate images hash comparison is fine
                    Assert.IsTrue(Tools.ImageSimilarity(curentImage, baseImage));
                }
                driver.FindLinkAndClick(G.BackButton);
                driver.FindElementAndClick(G.ReactivateToPickButton);
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


        public void Substitute(IDriver driver, String productType, String productSku)
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
                driver.FindElementAndClick(productType);
                driver.FindElementAndClick(G.SubstituteButton);
                driver.FindElementAndType(G.ScanSkuField, productSku);
/*                if (driver.IsElementPresent(G.ScanContinueButton))
                {
                    driver.FindElementAndClick(G.ScanContinueButton);
                    driver.FindElementAndType(G.CaptureFormatList, "Units");
                }

                driver.FindElementAndType(G.CaptureField, "11");
 */
                driver.FindElementAndClick(G.ScanConfirmButton);

                // Take and Save screenshot file
                driver.SaveScreenshot(baseImage, curentImage, ImageFormat.Jpeg);
                if (G.CompareImage == TestConstants.True)
                {
                    // Validate images hash comparison is fine
                    Assert.IsTrue(Tools.ImageSimilarity(curentImage, baseImage));
                }

                driver.FindElementAndClick(G.CompletedTap);
                driver.FindElementAndClick(G.CompletedItem);
                driver.FindElementAndClick(G.ReactivateToPickButton);
                driver.FindElementAndClick(G.DropScannedItemButton);
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


        public void PickedNotScanned_Reactivate(IDriver driver)
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
                driver.FindElementAndClick(G.ProductType2Page);
                driver.FindElementAndClick(G.PickedNotScanButton);
                if (driver.IsElementPresent(G.CaptureField))
                {
                    driver.FindElementAndType(G.CaptureField, "11");
                    driver.FindElementAndClick(G.ScanConfirmButton);            
                    driver.FindElementAndClick(G.ScanContinueButton);
                }

                // Take and Save screenshot file
                driver.SaveScreenshot(baseImage, curentImage, ImageFormat.Jpeg);
                if (G.CompareImage == TestConstants.True)
                {
                    // Validate images hash comparison is fine
                    Assert.IsTrue(Tools.ImageSimilarity(curentImage, baseImage));
                }

                driver.FindElementAndClick(G.CompletedTap);
                driver.FindElementAndClick(G.CompletedItem);
                driver.FindElementAndClick(G.ReactivateToPickButton);
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

        public void FixAisle(IDriver driver)
        {
            var testName = MethodBase.GetCurrentMethod().Name;
            // Last execution image
            var curentImage = G.ActiveDir + testName + "-" + DateTime.Now.ToString(TestConstants.Logformat) + G.ImageFormat;
            // Base line image
            var baseImage = G.ActiveDir + testName + "-" + G.ImageFormat;
            try
            {

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
