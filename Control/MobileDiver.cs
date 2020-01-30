using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.Reflection;
using System.Threading;

using MbUnit.Framework;


using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

using Solution.CareBook.Gui.Test.Common;

using log4net;
using System;
using OpenQA.Selenium.Appium.Service;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Remote;

namespace Solution.CareBook.Gui.Test.Control
{
    public class MobileDriver
    {
        private static AndroidDriver<AppiumWebElement> _driver;
        private static readonly ILog Log = SharedResources.GetLogger();

        public MobileDriver(String appiumLocalService, DesiredCapabilities capabilities)
        {
            _driver = new AndroidDriver<AppiumWebElement>(new Uri(appiumLocalService), capabilities, TimeSpan.FromMinutes(10));
        }

        public void Quit()
        {
            _driver.Quit();
        }

        public void Dispose()
        {
            _driver.Dispose();
        }

        public bool TitleContains(string value)
        {
            Thread.Sleep(TestConstants.Delay);
            return _driver.Title.Contains(value);
        }

        public bool PageSourceContains(string value)
        {
            var duration = new Stopwatch();
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(TestConstants.Wait));

            try
            {
                Thread.Sleep(TestConstants.PageLoadTime);
                duration.Start();
                var result = wait.Until(d => d.PageSource.Contains(value));
                duration.Stop();
                if (result)
                {
                    Log.Info(MethodBase.GetCurrentMethod().Name + "(" + value + ")" + TestConstants.Sp + duration.ElapsedMilliseconds + TestConstants.Ms);
                    return true;
                }
                Log.Error(TestConstants.ElementNotFound + value);
                return false;
            }
            catch (Exception e)
            {
                Log.Error(e);
                return false;
            }
        }

        public bool PageSourceNotContains(string value)
        {
            Thread.Sleep(TestConstants.PageLoadTime);
            try
            {
                var result = _driver.PageSource.Contains(value);
                if (result)
                {
                    Log.Info(MethodBase.GetCurrentMethod().Name + "(" + value + ")" + TestConstants.Sp + TestConstants.Ms);
                    return false;
                }
                Log.Error(TestConstants.ElementNotFound + value);
                return true;
            }
            catch (Exception)
            {
                Log.Error(TestConstants.ElementNotFound + value);
                return true;
            }
        }

        public bool PageContains(string value)
        {
            var duration = new Stopwatch();
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(TestConstants.Wait));

            try
            {
                duration.Start();
                var result = wait.Until(d => d.FindElement(By.XPath(value)));
                duration.Stop();
                if (result != null && result.Enabled)
                {
                    Log.Info(MethodBase.GetCurrentMethod().Name + "(" + value + ")" + TestConstants.Sp + duration.ElapsedMilliseconds + TestConstants.Ms);
                    return true;
                }
                Log.Error(TestConstants.ElementNotFound + value);
                return false;
            }
            catch (Exception e)
            {
                Log.Error(e);
                return  false;
            }
        }


        

        public bool IsElementEnabled(string element)
        {
            var duration = new Stopwatch();
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(TestConstants.Wait));

            try
            {
                duration.Start();
                var result = wait.Until(d => d.FindElement(By.XPath(element)));
                duration.Stop();
                if (result != null && result.Enabled)
                {
                    Log.Info(MethodBase.GetCurrentMethod().Name + "(" + element + ")" + TestConstants.Sp + duration.ElapsedMilliseconds + TestConstants.Ms);
                    return true;
                }
                Log.Error(TestConstants.ElementNotFound + element);
                return false;
            }
            catch (Exception e)
            {
                Log.Error(e);
                return false;
            }
        }

        public bool IsElementVisible(string element)
        {
            var duration = new Stopwatch();
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(TestConstants.Wait));

            try
            {
                duration.Start();
                var result = wait.Until(d => d.FindElement(By.XPath(element)));
                duration.Stop();
                if (result != null && result.Displayed)
                {
                    Log.Info(MethodBase.GetCurrentMethod().Name + "(" + element + ")" + TestConstants.Sp + duration.ElapsedMilliseconds + TestConstants.Ms);
                    return true;
                }
                Log.Error(TestConstants.ElementNotFound + element);
                return false;
            }
            catch (Exception e)
            {
                Log.Error(e);
                return false;
            }
        }

        public void GoToUrl(string url)
        {
            var duration = new Stopwatch();
            duration.Start();
            try
            {
            _driver.Navigate().GoToUrl(url);
            _driver.Manage().Window.Maximize();
            _driver.Manage().Cookies.DeleteAllCookies();
            duration.Stop();
            Log.Info(MethodBase.GetCurrentMethod().Name + TestConstants.Sp + duration.ElapsedMilliseconds + TestConstants.Ms);
            }
            catch (Exception e)
            {

                Log.Error(e);
                throw new ElementNotVisibleException();
            }
        }

        public object ExecuteScript(string script)
        {
            return _driver.ExecuteScript(script);
        }

        public void Login(string uservalue, string passvalue, string userid, string passid)
        {
            var duration = new Stopwatch();
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(TestConstants.Wait));

            try
            {
                duration.Start();
                wait.Until(
                        x =>
                        x.FindElement(
                            By.XPath(passid)));

                var element = _driver.FindElement(By.XPath(userid));
                element.Click();
                Thread.Sleep(TestConstants.Delay);
                element.SendKeys(uservalue);
                Thread.Sleep(TestConstants.Delay);
                var element2 = _driver.FindElement(By.XPath(passid));
                Thread.Sleep(TestConstants.Delay);
                element2.SendKeys(passvalue);
                Thread.Sleep(TestConstants.Delay);
                element.SendKeys(Keys.Return);
                duration.Stop();
                Log.Info(MethodBase.GetCurrentMethod().Name + TestConstants.Sp + duration.ElapsedMilliseconds + TestConstants.Ms);
            }
            catch (Exception e)
            {
                Log.Error(e);
                throw new ElementNotVisibleException();
            }
        }

        public void Pinin(string uservalue, string userid)
        {
            var duration = new Stopwatch();
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(TestConstants.Wait));

            try
            {
                duration.Start();
                wait.Until(
                        x =>
                        x.FindElement(
                            By.XPath(userid)));

                var element = _driver.FindElement(By.XPath(userid));
                element.Click();
                Thread.Sleep(TestConstants.Delay);
                element.SendKeys(uservalue);
                Thread.Sleep(TestConstants.Delay);
                element.SendKeys(Keys.Return);
                duration.Stop();
                Log.Info(MethodBase.GetCurrentMethod().Name + TestConstants.Sp + duration.ElapsedMilliseconds + TestConstants.Ms);
            }
            catch (Exception e)
            {
                Log.Error(e);
                throw new ElementNotVisibleException();
            }
        }

        public IList<object> FindElements(string element)
        {
            var duration = new Stopwatch();
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(TestConstants.Wait));
            try
            {
                Thread.Sleep(TestConstants.PageLoadTime);
                duration.Start();
                IList<IWebElement> result = wait.Until(d => d.FindElements(By.XPath(element)));
                duration.Stop();
                if (result == null || result.Count <= 0)
                {
                    return null;
                }
                Log.Info(MethodBase.GetCurrentMethod().Name + "(" + element + ")" + TestConstants.Sp + duration.ElapsedMilliseconds + TestConstants.Ms);
                return new List<object>(result);

            }
            catch (Exception e)
            {
                Log.Error(e);
                return null;
            }
        }


        public void FindElementById(string element)
        {
            var duration = new Stopwatch();
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(TestConstants.Wait));

            try
            {
                Thread.Sleep(TestConstants.PageLoadTime);
                duration.Start();
                var result = wait.Until(d => _driver.FindElementByAccessibilityId(element));
                if (result != null && result.Enabled)
                {
                    result.Click();
                    Assert.IsNotNull(result);
                }
                else
                {
                    Log.Error(TestConstants.ElementNotFound + element);
                }
                duration.Stop();
                Log.Info(MethodBase.GetCurrentMethod().Name + "(" + element + ")" + TestConstants.Sp + duration.ElapsedMilliseconds + TestConstants.Ms);
            }
            catch (Exception e)
            {
                Log.Error(TestConstants.ElementNotFound + element + e);
                throw new ElementNotVisibleException(TestConstants.ElementNotFound + element + e);
            }
        }

        public void FindElementByAccessibilityId(string element)
        {
            var duration = new Stopwatch();
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(TestConstants.Wait));

            try
            {
                Thread.Sleep(TestConstants.PageLoadTime);
                duration.Start();
                var result = wait.Until(d => _driver.FindElementByAccessibilityId(element));
                if (result != null && result.Enabled)
                {
                    result.Click();
                    Assert.IsNotNull(result);
                }
                else
                {
                    Log.Error(TestConstants.ElementNotFound + element);
                }
                duration.Stop();
                Log.Info(MethodBase.GetCurrentMethod().Name + "(" + element + ")" + TestConstants.Sp + duration.ElapsedMilliseconds + TestConstants.Ms);
            }
            catch (Exception e)
            {
                Log.Error(TestConstants.ElementNotFound + element + e);
                throw new ElementNotVisibleException(TestConstants.ElementNotFound + element + e);
            }
        }

        public void FindElementByIdClickPos(string element)
        {
            var duration = new Stopwatch();
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(TestConstants.Wait));
            //Find and get location of the element and click at the end   

            try
            {
                Thread.Sleep(TestConstants.PageLoadTime);
                duration.Start();
                var result = wait.Until(d => _driver.FindElementById(element));
                if (result != null && result.Enabled)
                {
                    int xloc = result.Location.X;
                    int yloc = result.Location.Y;
                    //Get the size of the element ex : "Already have a Be Well account? Sign in" 
                    int width = result.Size.Width;
                    int newXloc = xloc + width - 1;

                    //Clicking element
                    _driver.Tap(1, newXloc, yloc, 1);
                    Assert.IsNotNull(result);
                }
                else
                {
                    Log.Error(TestConstants.ElementNotFound + element);
                }
                duration.Stop();
                Log.Info(MethodBase.GetCurrentMethod().Name + "(" + element + ")" + TestConstants.Sp + duration.ElapsedMilliseconds + TestConstants.Ms);
            }
            catch (Exception e)
            {
                Log.Error(TestConstants.ElementNotFound + element + e);
                throw new ElementNotVisibleException(TestConstants.ElementNotFound + element + e);
            }
        }

        public void FindElementByByClassName(string element)
        {
            var duration = new Stopwatch();
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(TestConstants.Wait));

            try
            {
                Thread.Sleep(TestConstants.PageLoadTime);
                duration.Start();
                var result = wait.Until(d => _driver.FindElementByClassName(element));
                if (result != null && result.Enabled)
                {
                    result.Click();
                    Assert.IsNotNull(result);
                }
                else
                {
                    Log.Error(TestConstants.ElementNotFound + element);
                }
                duration.Stop();
                Log.Info(MethodBase.GetCurrentMethod().Name + "(" + element + ")" + TestConstants.Sp + duration.ElapsedMilliseconds + TestConstants.Ms);
            }
            catch (Exception e)
            {
                Log.Error(TestConstants.ElementNotFound + element + e);
                throw new ElementNotVisibleException(TestConstants.ElementNotFound + element + e);
            }
        }

        public void FindElementAndClick(string element)
        {
            var duration = new Stopwatch();
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(TestConstants.Wait));

            try
            {
                Thread.Sleep(TestConstants.PageLoadTime);
                duration.Start();
                var result = wait.Until(d => d.FindElement(By.XPath(element)));
                if (result != null && result.Enabled)
                {
                    result.Click();
                    Assert.IsNotNull(result);
                }
                else
                {
                    Log.Error(TestConstants.ElementNotFound + element);
                }
                duration.Stop();
                Log.Info(MethodBase.GetCurrentMethod().Name + "(" + element + ")" + TestConstants.Sp + duration.ElapsedMilliseconds + TestConstants.Ms);
            }
            catch (Exception e)
            {
                Log.Error(TestConstants.ElementNotFound + element + e);
                throw new ElementNotVisibleException(TestConstants.ElementNotFound + element + e);
            }
        }

        public void FindListAndSelectElement(string list, string element)
        {
            var duration = new Stopwatch();
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(TestConstants.Wait));

            try
            {
                Thread.Sleep(TestConstants.PageLoadTime);
                duration.Start();
                var result = wait.Until(d => d.FindElement(By.XPath(list)));
                if (result != null && result.Enabled)
                {
                    var selector = new SelectElement(result);
                    selector.SelectByText(element);
                    Assert.IsNotNull(result);
                }
                else
                {
                    Log.Error(TestConstants.ElementNotFound + list);
                }
                duration.Stop();
                Log.Info(MethodBase.GetCurrentMethod().Name + "(" + list + ")" + TestConstants.Sp + duration.ElapsedMilliseconds + TestConstants.Ms);
            }
            catch (Exception e)
            {
                Log.Error(TestConstants.ElementNotFound + list + e);
                throw new ElementNotVisibleException(TestConstants.ElementNotFound + list + e);
            }
        }

        public void FindElementAndType(string element, string text)
        {
            var duration = new Stopwatch();
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(TestConstants.Wait));

            try
            {
                Thread.Sleep(TestConstants.PageLoadTime);
                duration.Start();
                var result = wait.Until(d => d.FindElement(By.XPath(element)));
                if (result != null && result.Enabled)
                {
                    result.SendKeys(text);
                    Thread.Sleep(TestConstants.Delay);
                    result.SendKeys(Keys.Return);
                    Assert.IsNotNull(result);
                }
                else
                {
                    Log.Error(TestConstants.ElementNotFound + element);
                }
                duration.Stop();
                Log.Info(MethodBase.GetCurrentMethod().Name + "(" + element + ")" + TestConstants.Sp + duration.ElapsedMilliseconds + TestConstants.Ms);
            }
            catch (Exception e)
            {
                Log.Error(TestConstants.ElementNotFound + element + e);
                throw new ElementNotVisibleException(TestConstants.ElementNotFound + element + e);
            }
        }

        public string FindElementAndGetText(string element)
        {
            var duration = new Stopwatch();
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(TestConstants.Wait));

            try
            {
                Thread.Sleep(TestConstants.PageLoadTime);
                duration.Start();
                var result = wait.Until(d => d.FindElement(By.XPath(element))).Text;
                if (result != null)
                {
                    Assert.IsNotNull(result);
                }
                else
                {
                    Log.Error(TestConstants.ElementNotFound + element);
                }
                duration.Stop();
                Log.Info(MethodBase.GetCurrentMethod().Name + "(" + element + ")" + TestConstants.Sp + duration.ElapsedMilliseconds + TestConstants.Ms);
                return result;
            }
            catch (Exception e)
            {
                Log.Error(TestConstants.ElementNotFound + element + e);
                throw new ElementNotVisibleException(TestConstants.ElementNotFound + element + e);
            }
        }


        public void FindElementAndCheck(string element)
        {
            var duration = new Stopwatch();
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(TestConstants.Wait));

            try
            {
                Thread.Sleep(TestConstants.PageLoadTime);
                duration.Start();
                var result = wait.Until(d => d.FindElement(By.XPath(element)));
                if (result != null && result.Enabled)
                {
                    Thread.Sleep(TestConstants.Delay);
                    // result.SendKeys(Keys.Space);
                    result.Click();
                    Assert.IsNotNull(result);
                }
                else
                {
                    Log.Error(TestConstants.ElementNotFound + element);
                }
                duration.Stop();
                Log.Info(MethodBase.GetCurrentMethod().Name + "(" + element + ")" + TestConstants.Sp + duration.ElapsedMilliseconds + TestConstants.Ms);
            }
            catch (Exception e)
            {
                Log.Error(TestConstants.ElementNotFound + element + e);
                throw new ElementNotVisibleException(TestConstants.ElementNotFound + element + e);
            }
        }

        public void FindFieldAndInput(string element, string text)
        {
            var duration = new Stopwatch();
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(TestConstants.Wait));

            try
            {
                Thread.Sleep(TestConstants.PageLoadTime);
                duration.Start();
                var result = wait.Until(d => d.FindElement(By.XPath(element)));
                if (result != null && result.Enabled)
                {
//                    result.Click();
                    result.Clear();
                    Thread.Sleep(TestConstants.Delay);
                    result.SendKeys(text);
                    Assert.IsNotNull(result);
                }
                else
                {
                    Log.Error(TestConstants.ElementNotFound + element);
                }
                duration.Stop();
                Log.Info(MethodBase.GetCurrentMethod().Name + "(" + element + ")" + TestConstants.Sp + duration.ElapsedMilliseconds + TestConstants.Ms);
            }
            catch (Exception e)
            {
                Log.Error(TestConstants.ElementNotFound + element + e);
                throw new ElementNotVisibleException(TestConstants.ElementNotFound + element + e);
            }
        }

        public void FindLinkAndClick(string link)
        {
            var duration = new Stopwatch();
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(TestConstants.Wait));

            try
            {
                Thread.Sleep(TestConstants.PageLoadTime);
                duration.Start();
                var result = wait.Until(d => d.FindElement(By.PartialLinkText(link)));
                if (result != null && result.Enabled && result.Displayed)
                {
                    Assert.IsNotNull(result);
                    result.Click();
                    Thread.Sleep(TestConstants.Delay);
                }
                else
                {
                    Log.Error(TestConstants.ElementNotFound + link);
                    Assert.Fail();
                }
                duration.Stop();
                Log.Info(MethodBase.GetCurrentMethod().Name + "(" + link + ")" + TestConstants.Sp + duration.ElapsedMilliseconds + TestConstants.Ms);
            }
            catch (Exception e)
            {
                Log.Error(TestConstants.ElementNotFound + link + e);
                throw new ElementNotVisibleException(TestConstants.ElementNotFound + link + e);
            }
        }

        public void DoubleClickAndWait(string link)
        {
            var duration = new Stopwatch();
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(TestConstants.Wait));
            var act = new Actions(_driver);
            try
            {
                Thread.Sleep(TestConstants.PageLoadTime);
                duration.Start();
                var element = wait.Until(d => d.FindElement(By.PartialLinkText(link)));
                if (element != null && element.Enabled && element.Displayed)
                {
                    Assert.IsTrue(element.Displayed);
                    act.DoubleClick(element).Build().Perform();
                    Thread.Sleep(TestConstants.Delay);
                }
                else
                {
                    Log.Error(TestConstants.ElementNotFound + link);
                    Assert.Fail();
                }
                duration.Stop();
                Log.Info(MethodBase.GetCurrentMethod().Name + "(" +link+ ")"+ TestConstants.Sp + duration.ElapsedMilliseconds + TestConstants.Ms);
            }
            catch (Exception e)
            {
                Log.Error(TestConstants.ElementNotFound + link + e);
                throw new ElementNotVisibleException(TestConstants.ElementNotFound + link + e);
            }
        }

        public void SaveScreenshot(string baseImage, string currentImage, ImageFormat format)
        {
            var duration = new Stopwatch();
           // WaitCallback 5 seconds before shot
            Thread.Sleep(TestConstants.ScreenShotDelay);
            duration.Start();
            _driver.GetScreenshot().SaveAsFile(currentImage);
            if (!Tools.CheckImageExist(baseImage))
            {
                // Save base line screenshot file
                _driver.GetScreenshot().SaveAsFile(baseImage);
            }
            Log.Info(MethodBase.GetCurrentMethod().Name + TestConstants.Sp + duration.ElapsedMilliseconds + TestConstants.Ms);
            duration.Stop();
        }

        public void WaitLoadingPage(string pageContent)
        {
            var duration = new Stopwatch();
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(TestConstants.Wait));

            try
            {
                Thread.Sleep(TestConstants.PageLoadTime);
                duration.Start();
                wait.Until(d => d.FindElement(By.XPath(pageContent)));
                duration.Stop();
                Assert.IsNotNull(pageContent);
                Log.Info(MethodBase.GetCurrentMethod().Name +"(" + pageContent + ")" + TestConstants.Sp + duration.ElapsedMilliseconds + TestConstants.Ms);
            }
            catch (Exception e)
            {
                Log.Error(TestConstants.ElementNotFound + pageContent + e);
                throw new ElementNotVisibleException(TestConstants.ElementNotFound + pageContent + e);
            }
        }

        public bool IsElementPresent(string element)
        {
            var duration = new Stopwatch();
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(TestConstants.Mn));
            try
            {
                Thread.Sleep(TestConstants.PageLoadTime);
                duration.Start();
                wait.Until(d => d.FindElement(By.XPath(element)));
                duration.Stop();
                Log.Info(MethodBase.GetCurrentMethod().Name + TestConstants.Sp + duration.ElapsedMilliseconds + TestConstants.Ms);
                return true;
            }
            catch (NoSuchElementException e)
            {
                Log.Error(e);
                return false;
            }
            catch (Exception e)
            {
                Log.Error(e);
                return false;
            }
        }

        public bool IsElementPresent(By by)
        {
            var duration = new Stopwatch();
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(TestConstants.Wait));
            try
            {
                Thread.Sleep(TestConstants.PageLoadTime);
                duration.Start();
                wait.Until(d => d.FindElement(@by));
                duration.Stop();
                Log.Info(MethodBase.GetCurrentMethod().Name + TestConstants.Sp + duration.ElapsedMilliseconds + TestConstants.Ms);
                return true;
            }
            catch (NoSuchElementException e)
            {
                Log.Error(e);
                return false;
            }
        }

        public void FindElementAndClick(By by)
        {
            var duration = new Stopwatch();
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(TestConstants.Wait));

            try
            {
                Thread.Sleep(TestConstants.PageLoadTime);
                duration.Start();
                var element = wait.Until(d => d.FindElement(@by));
                if (element != null && element.Enabled)
                {
                    element.Click();
                    Assert.IsNotNull(element);
                }
                else
                {
                    Log.Error(TestConstants.ElementNotFound + @by);
                }
                duration.Stop();
                Log.Info(MethodBase.GetCurrentMethod().Name + TestConstants.Sp + duration.ElapsedMilliseconds + TestConstants.Ms);
            }
            catch (Exception e)
            {
                Log.Error(TestConstants.ElementNotFound + by + e);
                throw new ElementNotVisibleException(TestConstants.ElementNotFound + by + e);
            }
        }

        public IWebElement FindElementExpliciteWait(By by, double waitTime)
        {
            var duration = new Stopwatch();
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(waitTime));

            try
            {
                Thread.Sleep(TestConstants.PageLoadTime);
                duration.Start();
                var element = wait.Until(d => d.FindElement(@by));
                duration.Stop();
                Log.Info(MethodBase.GetCurrentMethod().Name + TestConstants.Sp + duration.ElapsedMilliseconds + TestConstants.Ms);
                return element;
            }
            catch (Exception e)
            {
                Log.Error(e);
                return null;
            }
        }

        public IWebElement FindElementImpliciteWait(By by)
        {
            var duration = new Stopwatch();
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(TestConstants.Wait));

            try
            {
                Thread.Sleep(TestConstants.PageLoadTime);
                duration.Start();
                var element = wait.Until(d => d.FindElement(@by));
                duration.Stop();
                Log.Info(MethodBase.GetCurrentMethod().Name + TestConstants.Sp + duration.ElapsedMilliseconds + TestConstants.Ms);
                return element;
            }
            catch (Exception e)
            {
                Log.Error(e);
                return null;
            }
        }

        public string GetElementValue(By by, string attributeName)
        {
            return _driver.FindElement(by).GetAttribute(attributeName);
        }

        public void MoveToElementAndClick(By by)
        {
            var act = new Actions(_driver);
            var element = _driver.FindElement(by);

            act.MoveToElement(element).Click();
        }

        public void MoveToElementAndClick(string element)
        {
            var act = new Actions(_driver);
            var duration = new Stopwatch();
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(TestConstants.Delay));
            try
            {
                Thread.Sleep(TestConstants.PageLoadTime);
                duration.Start();
                var result = wait.Until(d => d.FindElement(By.XPath(element)));
                if (result != null && result.Enabled)
                {
                    act.MoveToElement(result).Build().Perform();
                    act.MoveToElement(result).Click();
                    Assert.IsTrue(result.Displayed);
                }
                else
                {
                    Log.Error(TestConstants.ElementNotFound + element);
                }
                duration.Stop();
                Log.Info(MethodBase.GetCurrentMethod().Name + TestConstants.Sp + duration.ElapsedMilliseconds + TestConstants.Ms);
            }
            catch (Exception e)
            {
                Log.Error(TestConstants.ElementNotFound + element + e);
                throw new ElementNotVisibleException(TestConstants.ElementNotFound + element + e);
            }

        }
    }
}
