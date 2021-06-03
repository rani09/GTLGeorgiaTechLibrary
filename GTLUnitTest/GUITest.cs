using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Support.UI;
using System.Windows;

namespace GTLUnitTest
{
    [TestClass]
    public class GUITest
    {
        protected const string WindowsApplicationDriverUrl = "http://127.0.0.1:4723/";
        private const string WpfAppId = @"C:\Users\bruger\source\repos\GTL\GTLGeorgiaTechLibrary\bin\Debug\GTLGeorgiaTechLibrary.exe";

        protected static WindowsDriver<WindowsElement> session;


        [ClassInitialize]
        public static void Setup(TestContext context)
        {
            if (session == null)
            {
                var appiumOptions = new AppiumOptions();
                appiumOptions.AddAdditionalCapability("app", WpfAppId);
                appiumOptions.AddAdditionalCapability("deviceName", "WindowsPC");
                session = new WindowsDriver<WindowsElement>(new Uri(WindowsApplicationDriverUrl), appiumOptions);

            }
        }
        [TestMethod]
        [Obsolete]
        public void Add_Loan_To_List_After_To_Database()
        {
            var txtLoanSsn = session.FindElementByAccessibilityId("txtLoanSsn");
            var txtLoanmaterialId = session.FindElementByAccessibilityId("txtLoanmaterialId");

            txtLoanSsn.SendKeys("1973336968");
            txtLoanmaterialId.SendKeys("91322");


            session.FindElementByAccessibilityId("addToLoanList").Click();
            var bindingSourceMaterial = session.FindElementByAccessibilityId("bindingSourceMaterial");
            Assert.AreNotEqual(bindingSourceMaterial.Text, $"{txtLoanmaterialId.Text}, {txtLoanSsn.Text}");

            session.FindElementByAccessibilityId("SaveLoans").Click();

            IWebElement webElementYes = session.FindElement(By.Name("Ja"));
            webElementYes.Click();

            IWebElement webElementOK = session.FindElement(By.Name("OK"));
            webElementOK.Click();

        }

        //[TestMethod]
        //public void Add_Material()
        //{
        //    session.FindElementByAccessibilityId("addMaterial").Click();

        //    var txtIsb = session.FindElementByAccessibilityId("txtIsbn");
        //    var txtLang = session.FindElementByAccessibilityId("txtLanguage");
        //    var txtTitle = session.FindElementByAccessibilityId("txtMaterialTitle");
        //    var txtSubj = session.FindElementByAccessibilityId("txtSubject");
        //    var txtDescrip = session.FindElementByAccessibilityId("txtDescription");
        //    var txtNoOfCop = session.FindElementByAccessibilityId("txtNoOfCopies");
        //    var txtMaterialTo = session.FindElementByAccessibilityId("txtMaterialTotal");
        //    var txtLoanab = session.FindElementByAccessibilityId("txtLoanable");


        //    txtIsb.SendKeys("654783291");
        //    txtLang.SendKeys("Dansk");
        //    txtTitle.SendKeys("Dansk Mad");
        //    txtSubj.SendKeys("Mad på bordet");
        //    txtDescrip.SendKeys("Nu skal vi alle spise fra denne mad");
        //    txtNoOfCop.SendKeys("25");
        //    txtMaterialTo.SendKeys("110");
        //    txtLoanab.SendKeys("4");

        //    session.FindElementByAccessibilityId("saveMaterial").Click();
        //}
        //[TestMethod]
        //public void Add_Member()
        //{
        //    session.FindElementByAccessibilityId("AddMember").Click();

        //    var metroCheckBoxIsProfessor = session.FindElementByAccessibilityId("metroCheckBoxIsProfessor");
        //    var txtCampusAddress = session.FindElementByAccessibilityId("txtCampusAddress");
        //    var menberPersonId = session.FindElementByAccessibilityId("menberPersonId");

        //    metroCheckBoxIsProfessor.Click();
        //    txtCampusAddress.SendKeys("Århusvej 12");
        //    menberPersonId.SendKeys("6916");

        //    session.FindElementByAccessibilityId("saveMember").Click();
        //}
    }
}
