using DataAccess;
using GTLCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Text;

namespace GTLUnitTest
{
    /// <summary>
    /// Summary description for LoanUnitTest
    /// </summary>
    [TestClass]
    public class LoanUnitTest
    {
        private LoanRepository _loanRepository;
        private Loan _Loan;

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
        public void Inser_Loan_Test()
        {
            Random rng = new Random();
            int member_loan_no = rng.Next(1, 500);

            // Arrange
            var l = new Loan
            {
                start_date = DateTime.Now,
                return_date = (DateTime)SqlDateTime.Null,
                m_ssn = 976914173,
                member_loan_no = member_loan_no
            };

            // Act
            var insertedSurvey = _loanRepository.Insert(l);

            // Assert
            Assert.AreNotEqual(l, insertedSurvey);
        }
        [TestMethod]
        public void Update_Loan_Test()
        {
            Random rng = new Random();
            int member_loan_no = rng.Next(1, 500);

            // Arrange

            _Loan = new Loan();

            _Loan.id = 100032;
            _Loan.start_date = DateTime.Now;
            _Loan.return_date = (DateTime)SqlDateTime.Null;
            _Loan.m_ssn = 976914173;
            _Loan.member_loan_no = member_loan_no;


            bool expectedValue = true;

            // Act
            bool actualValue = _loanRepository.Update(_Loan);

            // Assert
            Assert.AreEqual(expectedValue, actualValue);
        }
        [TestMethod]
        public void Get_All_Loans_Test()
        {
            List<Loan> Expected = new List<Loan>();

            // Act
            Expected = (List<Loan>)_loanRepository.GetAll();

            // Assert
            Assert.IsTrue(RaniMetode(Expected.Count));

        }
        public bool RaniMetode(int count)
        {
            bool result = (count > 0) ? true : false;
            return result;
        }
    }
}
