
using System.Collections.Generic;
using System.Drawing.Imaging;

namespace Solution.CareBook.Gui.Test.Control
{
    public interface IDriver
    {
         void Quit();

         void Dispose();

         void GoToUrl(string url);

         bool TitleContains(string value);

         bool PageSourceContains(string value);

         bool PageSourceNotContains(string value);

         bool PageContains(string value);

         bool IsElementEnabled(string element);

         IList<object> FindElements(string link); 
        
         void FindLinkAndClick(string link);

         void FindElementAndClick(string element);

         void FindListAndSelectElement(string list, string element);

         void FindElementAndType(string element, string text);

         string FindElementAndGetText(string element);

         void FindElementAndCheck(string element);

         void FindFieldAndInput(string element, string text);

         void WaitLoadingPage(string pageContent);

         void Login(string uservalue, string passvalue, string userid, string passid);

         void Pinin(string uservalue, string userid);

         void SaveScreenshot(string baseImage, string currentImage, ImageFormat format);

         bool IsElementPresent(string element);

         bool IsElementVisible(string element);

         object ExecuteScript(string script);

         void DoubleClickAndWait(string element);

         void MoveToElementAndClick(string element);
    }
}
