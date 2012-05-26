using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using CalabashMedia.EmiEurope.DataAccess;
using CalabashMedia.EmiEurope.Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CalabashMedia.EmiEurope.MvcApplication.Tests.Repository
{
    /// <summary>
    /// Summary description for UnitTest3
    /// </summary>
    [TestClass]
    public class VacancyRepositoryUnitTests
    {
        private VacancyRepository vacancyRepository;
        private TestContext testContextInstance;  
        
        public VacancyRepositoryUnitTests()
        {
            vacancyRepository = new VacancyRepository();
        }

        [TestMethod]
        public void GetVacanciesTestMethod()
        {
           


            //Arrange
            
            //Act
            var vacanciesList = vacancyRepository.GetVacancies();

            //Assert
            Assert.AreNotEqual(vacanciesList,0);
        }



      

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

       
    }
}
