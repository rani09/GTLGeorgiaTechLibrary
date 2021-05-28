using DataAccess;
using GTLCore;
using InfrastructureLayer.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace GTLUnitTest
{
    [TestClass]
    public class MemberUnitTest
    {
        private MemberRepository _memberRepository;
        private Member _member;

        [TestInitialize]
        public void TestInitialize()
        {
            _memberRepository = new MemberRepository();

        }
        [TestCleanup]
        public void TestCleanup()
        {
            _memberRepository = null;
        }

        [TestMethod]
        public void Add_Member_Test()
        {
            Random random = new Random();
            int ssn = random.Next(100000000, 999999999);
            // Arrange
            var m = new Member
            {
                ssn = ssn,
                campus_address = "Allborg vej 12",
                is_professor = true,
                person = 1
            };
            // Act
            var insertedSurvey = _memberRepository.Insert(m);
            // Assert

            Assert.AreNotEqual(m, insertedSurvey);

            //Logger
            StaticLogger.LogInfo(this.GetType(), "Member created!");
        }

        [TestMethod]
        public void Update_Member_Test()
        {
            // Arrange
            _member = new Member();
            _member.ssn = 123456789;
            _member.campus_address = "vodskovvej 134";
            _member.is_professor = true;
            _member.person = 1;

            bool expectedValue = true;

            // Act
            bool actualValue = _memberRepository.Update(_member);

            // Assert
            Assert.AreEqual(expectedValue, actualValue);
        }
        [TestMethod]
        public void Get_All_Members_Test()
        {
            List<Member> Expected = new List<Member>();

            // Act
            Expected = (List<Member>)_memberRepository.GetAll();

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
