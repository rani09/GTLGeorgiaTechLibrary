using Autofac.Extras.Moq;
using DataAccess;
using GTLCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;

namespace GTLUnitTest
{
    [TestClass]
    public class MaterialUnitTest
    {
        private MaterialRepository _materialRepository;
        private Material _material;

        [TestInitialize]
        public void TestInitialize()
        {
            _materialRepository = new MaterialRepository();

        }
        [TestCleanup]
        public void TestCleanup()
        {
            _materialRepository = null;
        }

        [TestMethod]
        public void Add_Material_Test()
        {
            Random rng = new Random();
            int isbn = rng.Next(1, 1000000000);
            int no_of_copies = rng.Next(1, 50);
            int total_loans = rng.Next(1, 100);
            int loanable_acquire = rng.Next(1, 5);

            // Arrange
            var m = new Material
            {
                isbn = isbn,
                language = "Dansk",
                title = "Bogen fra himlen",
                subject_area = "Du kommer en anden verden",
                description = "Du er sindsyg",
                no_of_copies = no_of_copies,
                total_loans = total_loans,
                loanable_acquire = loanable_acquire

            };
            // Act
            var insertedSurvey = _materialRepository.Insert(m);
            // Assert

            Assert.AreNotEqual(m, insertedSurvey);
        }


        [TestMethod]
        public void Update_Material_Test()
        {
            Random rng = new Random();
            int isbn = rng.Next(1, 1000000000);
            int no_of_copies = rng.Next(1, 2);
            int total_loans = rng.Next(1, 3);
            int loanable_acquire = rng.Next(1, 1);
            // Arrange

            _material = new Material();
            _material.id = 100029;
            _material.isbn = isbn;
            _material.language = "Dansk nu her";
            _material.title = "Bogen fra himlen nu her";
            _material.subject_area = "Du kommer en anden verden nu her";
            _material.description = "Du er sindsyg nu her";
            _material.no_of_copies = no_of_copies;
            _material.total_loans = total_loans;
            _material.loanable_acquire = loanable_acquire;

            bool expectedValue = true;

            // Act
            bool actualValue = _materialRepository.Update(_material);

            // Assert
            Assert.AreEqual(expectedValue, actualValue);
        }

        [TestMethod]
        public void Get_All_Materials_Test()
        {
            List<Material> Expected = new List<Material>();

            // Act
            Expected = (List<Material>)_materialRepository.GetAll();

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
