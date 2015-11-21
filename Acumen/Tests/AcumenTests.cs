using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Input;
using System.Windows.Forms;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UITest.Extension;
using Keyboard = Microsoft.VisualStudio.TestTools.UITesting.Keyboard;
using Acumen.Tests;
using System.Diagnostics;


namespace Acumen
{
    /// <summary>
    /// Test class implementing Test Cases for the "Contact Us" page
    /// </summary>
    [CodedUITest]
    public class AcumenTests : BaseTestClass
    {
        /// <summary>
        /// Method to setup the Test Suite. This is called once before any of the Test Methods in this class are executed.
        /// Use to get the system into a state to execute tests e.g. start Maestro, setup data etc.
        /// </summary>
        /// <param name="testContext"></param>
        [ClassInitialize]
        new public static void ClassInitialize(TestContext testContext)
        {
            BaseTestClass.ClassInitialize(testContext);
            Debug.WriteLine("ClassInitialize");
        }

        /// <summary>
        /// Method to cleanup the Test Suite. This is called once after all of the Test Methods in this class have been executed.
        /// Use to get the system into a state to execute tests.
        /// </summary>
        [ClassCleanup]
        new public static void ClassCleanup()
        {
            BaseTestClass.ClassCleanup();
            Debug.WriteLine("ClassCleanup");
        }

        /// <summary>
        /// Method to setup before the Test Method. This is called before every Test Method is executed.
        /// </summary>
        [TestInitialize]
        new public void TestInitialize()
        {
            base.TestInitialize();
            Debug.WriteLine("TestInitialize");
        }

        /// <summary>
        /// Method to cleanup after the Test Method. This is called after every Test Method is executed.
        /// </summary>
        [TestCleanup]
        new public void TestCleanup()
        {
            base.TestCleanup();
            Debug.WriteLine("TestCleanup");
        }

        /// <summary>
        /// Test method that executes the Accurate Address scenario with several added verification steps for phone bumbers and e-mail addresses.
        /// </summary>
        [TestMethod]
        public void AccurateAddressTestCase()
        {
            //Go to "Contact Us" page
            UIMapRoot.UIMapMenu.ClickContactUs();
            //Verify that the post code is correct
            UIMapRoot.UIMapContactUs.AssertPostCode("TW9 1HY");
            //Verify that the client enquiries phone number is correct
            UIMapRoot.UIMapContactUs.AssertClientEnquiriesPhone("+44 (0)20 8334 0420");
            //Verify that the client enquiries e-mail address is correct
            UIMapRoot.UIMapContactUs.AssertClientEnquiriesEmail("info@acumenci.com");
            //Verify that the support enquiries phone number is correct
            UIMapRoot.UIMapContactUs.AssertSupportEnquiriesPhone("+44 (0)20 8334 0430");
            //Verify that the support enquiries e-mail address is correct
            UIMapRoot.UIMapContactUs.AssertSupportEnquiriesEmail("support@acumenci.com");
        }

        /// <summary>
        /// Test method that executes the Submission Validation scenario.
        /// </summary>
        [TestMethod]
        public void SubmissionValidationTestCase()
        {
            //Enter valid e-mail address (contains @ symbol)
            UIMapRoot.UIMapContactUs.EnterEmail("john.doe@gmail.com");
            //Enter message text
            UIMapRoot.UIMapContactUs.EnterMessage("I don't know who I am!");
            //Press "Send" button
            UIMapRoot.UIMapContactUs.ClickSend();
            //Verify that the error message regarding the missing "Name" required field is shown.
            UIMapRoot.UIMapContactUs.AssertNameErrorMessage();
            //Verify that the error message regarding the missing "Company" required field is shown.
            UIMapRoot.UIMapContactUs.AssertCompanyErrorMessage();
            //Verify that the error message regarding the missing "Location" required field is shown.
            UIMapRoot.UIMapContactUs.AssertLocationErrorMessage();

        }

        /// <summary>
        /// Test method that executes the Submission Invalid Email scenario.
        /// </summary>
        [TestMethod]
        public void SubmissionInvalidEmailTestCase()
        {
            //Enter invalid e-mail address (does't contain @ symbol)
            UIMapRoot.UIMapContactUs.EnterEmail("john.doegmail.com");
            //Press "Send" button
            UIMapRoot.UIMapContactUs.ClickSend();
            //Verify that the error message regarding the invalid "E-mail" entered is shown.
            UIMapRoot.UIMapContactUs.AssertEmailErrorMessage();
        }

        /// <summary>
        /// Test method that executes the Submission Valid Phone scenario.
        /// </summary>
        [TestMethod]
        public void SubmissionValidPhoneTestCase()
        {
            //Enter valid phone number (contains only digits and special symbols)
            UIMapRoot.UIMapContactUs.EnterPhone("+44 (0)20 8334 0420");
            //Verify that the entered phone number is valid, i.e. contains only digits and special symbols
            UIMapRoot.UIMapContactUs.AssertValidPhone();
        }
    }
}
