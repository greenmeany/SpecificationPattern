using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SpecificationPattern.Tests
{
    /// <summary>
    /// Unit tests for <see cref="Specification"/>
    /// </summary>
    [TestClass]
    public class SpecificationTests
    {
        /// <summary>
        /// Ensure simple usage of the scenario can be met easily
        /// </summary>
        [TestMethod]
        public void SimpleUsageScenario_Test()
        {
            var lessThanTenSpecifcation = new Specification<int>(i=>i<=10);
            Assert.IsTrue(lessThanTenSpecifcation.IsSatisfiedBy(9));
        }

        /// <summary>
        /// Simple test to ensure And functionality for Specification works
        /// </summary>
        [TestMethod]
        public void SimpleAndUsageScenario_Test()
        {
            var stringLengthTen =  new Specification<string>(s => s.Length == 10);
            var stringLengthTenAndBeginsWithS = stringLengthTen.And(s => s[0] == 'S');

            var testStringOne = "SteakTasty";
            var testStringTwo = "CigsRNasty";

            Assert.IsTrue(stringLengthTenAndBeginsWithS.IsSatisfiedBy(testStringOne));
            Assert.IsFalse(stringLengthTenAndBeginsWithS.IsSatisfiedBy(testStringTwo));
        }

        /// <summary>
        /// Simple test to ensure Or functionality for Specification works
        /// </summary>
        [TestMethod]
        public void SimpleOrUsageScenario_Test()
        {
            var stringLengthTen = new Specification<string>(s => s.Length == 10);
            var stringLengthTenOrBeginsWithS = stringLengthTen.Or(s => s[0] == 'S');

            var testStringOne = "SteakTasty";
            var testStringTwo = "CigsRNasty";
            var testStringThree = "S";
            var testStringFour = "C";

            Assert.IsTrue(stringLengthTenOrBeginsWithS.IsSatisfiedBy(testStringOne));
            Assert.IsTrue(stringLengthTenOrBeginsWithS.IsSatisfiedBy(testStringTwo));
            Assert.IsTrue(stringLengthTenOrBeginsWithS.IsSatisfiedBy(testStringThree));
            Assert.IsFalse(stringLengthTenOrBeginsWithS.IsSatisfiedBy(testStringFour));
        }


    }
}
