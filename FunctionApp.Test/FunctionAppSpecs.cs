using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using FunctionApp1.Messages;

namespace FunctionApp.Test
{
    [TestClass]
    public class FunctionAppSpecs
    {
        // This is what I think of the Specifications and Scenarios that should be tested.

        [TestMethod]
        public void CalculateExpectedDate_SubmissionDate_NotNull()
        {
            FormLetter formLetter = new FormLetter();
            DateTime? submissionDate = null;
            Assert.ThrowsException<ArgumentException>(() => formLetter.calculateExpectedDate(submissionDate));
        }

        [TestMethod]
        public void calculateLikelihood_HowMuch_NotOverMaximumAmount()
        {
            FormLetter formLetter = new FormLetter();
            decimal howmuch = 12000m;

            Assert.ThrowsException<ArgumentException>(() => formLetter.calculateLikelihood(howmuch));
        }

        [TestMethod]
        public void calculateExpectedDate_SubmissionDate_LessThanCurrentDay()
        {
            FormLetter formLetter = new FormLetter();
            DateTime? submissionDate = DateTime.Now.AddDays(-1);
            Assert.ThrowsException<ArgumentException>(() => formLetter.calculateExpectedDate(submissionDate));
        }

    }
}
