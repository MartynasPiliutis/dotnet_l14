using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using IAC;
using IAC.BL.Repositories;


namespace Lesson11_01.IAC.test
{
    [TestClass]
    public class ReportGeneratorTests
    {
        [TestMethod]
        public void GenerateReportAircraftInEuropeShouldReturnListWithReportItems()
        {
            // Assign
            ReportGenerator reportGenerator = new ReportGenerator(new AircraftRepository(), new CompanyRepository(), new CountryRepository(), new AircraftModelRepository());

            // Act
            var report = reportGenerator.GenerateReportAircraftInEurope();

            // Assert
            Assert.IsNotNull(report);
        }
    }
}

