using DataAccess;
using GTLCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace GTLUnitTest
{
    [TestClass]
    public class PersonUnitTest
    {
        private PersonRepository _personRepository;
        private Person _person;

        [TestInitialize]
        public void TestInitialize()
        {
            _personRepository = new PersonRepository();

        }
        [TestCleanup]
        public void TestCleanup()
        {
            _personRepository = null;
        }


        [TestMethod]
        public void Add_Person_Test()
        {
            // Arrange
            var p = new Person
            {
                first_name = "Anne",
                last_name = "Maria",
                middle_name = "Rasmusen"
            };
            // Act
            var insertedSurvey = _personRepository.Insert(p);
            // Assert

            Assert.AreNotEqual(p, insertedSurvey);
        }

        [TestMethod]
        public void Update_Person_Test()
        {
            // Arrange
            _person = new Person();
            _person.id = 100005;
            _person.first_name = "Ida";
            _person.middle_name = "Bo";
            _person.last_name = "Jensen";

            bool expectedValue = true;

            // Act
            bool actualValue = _personRepository.Update(_person);

            // Assert
            Assert.AreEqual(expectedValue, actualValue);
        }
        [TestMethod]
        public void Get_All_Persons_Test()
        {
            List<Person> Expected = new List<Person>();

            // Act
            Expected = (List<Person>)_personRepository.GetAll();

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
