using System;
using System.Text;

using MbUnit.Framework;

using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using Solution.CareBook.Gui.Test.Control;
using Solution.CareBook.Gui.Test.Pages;

namespace Solution.CareBook.Gui.Test.Entities
{
    [Parallelizable]
    [TestFixture]
    public class Smoke
    {

        private StringBuilder _verificationErrors;
        private Authentication _auth;
        private PickingList _pick;
        private PickingDetail _pickD;
        private OrderList _orderL;
        private OrderDetail _orderD;
        private FirefoxOptions options = new FirefoxOptions();


        [SetUp]
        public void SetupTest()
        {

            G.SetupTest();
            _verificationErrors = new StringBuilder();
            _auth = new Authentication();
            _pick = new PickingList();
            _pickD = new PickingDetail();
            _orderL = new OrderList();
            _orderD = new OrderDetail();

        }
        [TearDown]
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

        /*************************** Authentication ***************************/

        [Parallelizable]
        [Test]
        [Category("Firefox"), Category("GE"), Category("Sobeys")]
        [Repeat(1)]
        public void Login_Logout()
        {
            IDriver driver = new Driver(new Uri(G.SeleniumHubUrl), options.ToCapabilities());
            _auth.Login_Logout(driver);
        }

        /*************************** OrderList ***************************/

        [Parallelizable]
        [Test]
        [Category("Firefox"), Category("GE"), Category("Sobeys")]
        [Repeat(1)]
        public void OrderList_StartPicking()
        {
            IDriver driver = new Driver(new Uri(G.SeleniumHubUrl), options.ToCapabilities());
            _orderL.StartPicking(driver);
        }


        [Parallelizable]
        [Category("Firefox"), Category("GE"), Category("Sobeys")]
        [Repeat(1)]
        public void MoveTo_Next_First_LastOrderPage()
        {
            IDriver driver = new Driver(new Uri(G.SeleniumHubUrl), options.ToCapabilities());
            _orderL.MoveTo_Next_First_LastOrderPage(driver);
        }

        /*************************** PickingList ***************************/

        [Parallelizable]
        [Test]
        [Category("Firefox"), Category("GE"), Category("Sobeys")]
        [Repeat(1)]
        public void Scan_ProductType0()
        {
            IDriver driver = new Driver(new Uri(G.SeleniumHubUrl), options.ToCapabilities());
            _pick.Scan(driver, "0062368211200");
        }

        [Parallelizable]
        [Test]
        [Category("Firefox"), Category("GE"), Category("Sobeys")]
        [Repeat(1)]
        public void Scan_ProductType1()
        {
            IDriver driver = new Driver(new Uri(G.SeleniumHubUrl), options.ToCapabilities());
            _pick.Scan(driver, "0022703700000");
        }

        [Parallelizable]
        [Test]
        [Category("Firefox"), Category("GE"), Category("Sobeys")]
        [Repeat(1)]
        public void Scan_ProductType2()
        {
            IDriver driver = new Driver(new Uri(G.SeleniumHubUrl), options.ToCapabilities());
            _pick.Scan(driver, "4036");
        }

        /*************************** AddToPickingList @OrderDetail ***************************/

        [Parallelizable]
        [Test]
        [Category("Firefox"), Category("GE"), Category("Sobeys")]
        [Repeat(1)]
        public void Add_Cancel_OrderToPickingList()
        {
            IDriver driver = new Driver(new Uri(G.SeleniumHubUrl), options.ToCapabilities());
            _orderD.AddToPickList(driver);
        }


        /*************************** On Hold @OrderDetail ***************************/

        [Parallelizable]
        [Test]
        [Category("Firefox"), Category("GE"), Category("Sobeys")]
        [Repeat(1)]
        public void OnHold_Resume_OrderPicking()
        {
            IDriver driver = new Driver(new Uri(G.SeleniumHubUrl), options.ToCapabilities());
            _orderD.OnHold_Resume_OrderPicking(driver);
        }


        /*************************** AddNotExistinProduct @OrderDetail ***************************/

        [Parallelizable]
        [Test]
        [Category("Firefox"), Category("GE")]
        [Repeat(1)]
        public void AddNotExistingProduct()
        {
            IDriver driver = new Driver(new Uri(G.SeleniumHubUrl), options.ToCapabilities());
            _orderD.AddProduct(driver, "1234");
        }


        /*************************** AddExistingProduct @OrderDetail ***************************/

        [Parallelizable]
        [Test]
        [Category("Firefox"), Category("GE"), Category("Sobeys")]
        [Repeat(1)]
        public void Add_ExistingProductType0()
        {
            IDriver driver = new Driver(new Uri(G.SeleniumHubUrl), options.ToCapabilities());
            _orderD.AddProduct(driver, "87180200223");
        }

        [Parallelizable]
        [Test]
        [Category("Firefox"), Category("GE"), Category("Sobeys")]
        [Repeat(1)]
        public void Add_ExistingProductType1()
        {
            IDriver driver = new Driver(new Uri(G.SeleniumHubUrl), options.ToCapabilities());
            _orderD.AddProduct(driver, "22620200000");
        }

        [Parallelizable]
        [Test]
        [Category("Firefox"), Category("GE"), Category("Sobeys")]
        [Repeat(1)]
        public void Add_ExistingProductType2()
        {
            IDriver driver = new Driver(new Uri(G.SeleniumHubUrl), options.ToCapabilities());
            _orderD.AddProduct(driver, "4011");
        }


        /*************************** Product Not Available @PickingDetail ***************************/

        [Parallelizable]
        [Test]
        [Category("Firefox"), Category("GE"), Category("Sobeys")]
        [Repeat(1)]
        public void ProductNotAvailable_Reactivate()
        {
            IDriver driver = new Driver(new Uri(G.SeleniumHubUrl), options.ToCapabilities());
            _pickD.ProductNotAvailable_Reactivate(driver);
        }


        /*************************** Substitute @PickingDetail ***************************/

        [Parallelizable]
        [Test]
        [Category("Firefox"), Category("GE"), Category("Sobeys")]
        [Repeat(1)]
        public void Substitute_Type2To2()
        {
            IDriver driver = new Driver(new Uri(G.SeleniumHubUrl), options.ToCapabilities());
            _pickD.Substitute(driver, G.ProductType2Page, "4011");
        }

        [Parallelizable]
        [Test]
        [Category("Firefox"), Category("GE"), Category("Sobeys")]
        [Repeat(1)]
        public void Substitute_Type2To1()
        {
            IDriver driver = new Driver(new Uri(G.SeleniumHubUrl), options.ToCapabilities());
            _pickD.Substitute(driver, G.ProductType2Page, "0022703700000");
        }

        [Parallelizable]
        [Test]
        [Category("Firefox"), Category("GE"), Category("Sobeys")]
        [Repeat(1)]
        public void Substitute_Type2To0()
        {
            IDriver driver = new Driver(new Uri(G.SeleniumHubUrl), options.ToCapabilities());
            _pickD.Substitute(driver, G.ProductType2Page, "87180200223");
        }

        [Parallelizable]
        [Test]
        [Category("Firefox"), Category("GE"), Category("Sobeys")]
        [Repeat(1)]
        public void Substitute_Type1To0()
        {
            IDriver driver = new Driver(new Uri(G.SeleniumHubUrl), options.ToCapabilities());
            _pickD.Substitute(driver, G.ProductType1Page, "87180200223");
        }

        [Parallelizable]
        [Test]
        [Category("Firefox"), Category("GE"), Category("Sobeys")]
        [Repeat(1)]
        public void Substitute_Type1To1()
        {
            IDriver driver = new Driver(new Uri(G.SeleniumHubUrl), options.ToCapabilities());
            _pickD.Substitute(driver, G.ProductType1Page, "0022703700000");
        }

        [Parallelizable]
        [Test]
        [Category("Firefox"), Category("GE"), Category("Sobeys")]
        [Repeat(1)]
        public void Substitute_Type1To2()
        {
            IDriver driver = new Driver(new Uri(G.SeleniumHubUrl), options.ToCapabilities());
            _pickD.Substitute(driver, G.ProductType1Page, "4011");
        }

        [Parallelizable]
        [Test]
        [Category("Firefox"), Category("GE"), Category("Sobeys")]
        [Repeat(1)]
        public void Substitute_Type0To0()
        {
            IDriver driver = new Driver(new Uri(G.SeleniumHubUrl), options.ToCapabilities());
            _pickD.Substitute(driver, G.ProductType0Page, "87180200223");
        }

        [Parallelizable]
        [Test]
        [Category("Firefox"), Category("GE"), Category("Sobeys")]
        [Repeat(1)]
        public void Substitute_Type0To1()
        {
            IDriver driver = new Driver(new Uri(G.SeleniumHubUrl), options.ToCapabilities());
            _pickD.Substitute(driver, G.ProductType0Page, "0022703700000");
        }

        [Parallelizable]
        [Test]
        [Category("Firefox"), Category("GE"), Category("Sobeys")]
        [Repeat(1)]
        public void Substitute_Type0To2()
        {
            IDriver driver = new Driver(new Uri(G.SeleniumHubUrl), options.ToCapabilities());
            _pickD.Substitute(driver, G.ProductType0Page, "4011");
        }

        /*************************** PickedNotScanned @PickingDetail ***************************/

        [Parallelizable]
        [Test]
        [Category("Firefox"), Category("GE"), Category("Sobeys")]
        [Repeat(1)]
        public void PickedNotScanned_Reactivate()
        {
            IDriver driver = new Driver(new Uri(G.SeleniumHubUrl), options.ToCapabilities());
            _pickD.PickedNotScanned_Reactivate(driver);
        }


    }
}
