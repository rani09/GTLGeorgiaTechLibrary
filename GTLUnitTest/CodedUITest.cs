using DataAccess;
using GTLCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GTLUnitTest
{
    /// <summary>
    /// Summary description for CodedUITest
    /// </summary>
    [TestClass]
    public class CodedUITest
    {
        private LoanRepository _loanRepository;
        //private Loan _loan;

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
