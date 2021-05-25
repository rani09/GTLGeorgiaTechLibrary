using DataAccess;
using FlaUI.Core;
using FlaUI.UIA3;
using GTLCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Text;

namespace GTLUnitTest
{
    /// <summary>
    /// Summary description for CodedUITest
    /// </summary>
    [TestClass]
    public class CodedUITest
    {
        private LoanRepository _loanRepository;
        private Loan _loan;

        [TestInitialize]
        public void TestInitialize()
        {
            _loanRepository = new LoanRepository();

        }
        [TestCleanup]
        public void TestCleanup()
        {
            _loanRepository = null;
        }
        [TestMethod]
        public void CodedUI()
        {
            //var msApplication = Application.Launch(@"C:\Users\bruger\source\repos\GTLGeorgiaTechLibrary\GTLGeorgiaTechLibrary\Form1.cs");
            //var automation = new UIA3Automation();
            //var mainWindow = msApplication.GetMainWindow(automation);
        }
    }
}
