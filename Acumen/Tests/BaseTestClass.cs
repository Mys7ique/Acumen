using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Input;
using Acumen.Maps;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.WinControls;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Acumen.Tests
{
    [CodedUITest]    
    public class BaseTestClass
    {
        static private String urlAcumenHome = "http://www.acumenci.com/";
        static private String urlAcumenContactUs = "http://www.acumenci.com/contact-us/";
        static BrowserWindow browser = null;

        #region Properties

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
        private TestContext testContextInstance;

        /// <summary>
        /// Property to get the RootMap which gives contains all the other UI Maps.
        /// </summary>
        public UIMapRoot UIMapRoot
        {
            get
            {
                return UIMapRoot.GetInstance();
            }
        }
        #endregion

        #region Life Cycle
        /// <summary>
        /// Default constructor.
        /// Resets the UIMap forcing controls to be found again for each test.
        /// </summary>
        public BaseTestClass()
        {
            UIMapRoot.ResetUIMap();
        }
        #endregion

        #region Methods

        public static void ClassInitialize(TestContext testContext)
        {
            Debug.WriteLine("BaseClassInitialize");            
        }

        public static void ClassCleanup()
        {
            Debug.WriteLine("BaseClassCleanup");
        }

        [TestInitialize]
        public void TestInitialize()
        {
            switch (TestContext.TestName)
            {
                case "AccurateAddressTestCase":
                    this.InitializeHomePage();                   
                    break;
                case "SubmissionValidationTestCase":
                    this.InitializeContactUsPage();
                    break;
                case "SubmissionInvalidEmailTestCase":
                    this.InitializeContactUsPage();
                    break;
                case "SubmissionValidPhoneTestCase":
                    this.InitializeContactUsPage();
                    break;
            }
        }

        [TestCleanup]
        public void TestCleanup()
        {
            Debug.WriteLine("BaseTestCleanup");
            browser.Close();
        }

        public void InitializeHomePage()
        {
            Debug.WriteLine("BaseTestInitialize");

            browser = BrowserWindow.Launch(new System.Uri(urlAcumenHome));
            browser.CloseOnPlaybackCleanup = false;            
        }

        public void InitializeContactUsPage()
        {
            Debug.WriteLine("BaseTestInitialize");

            browser = BrowserWindow.Launch(new System.Uri(urlAcumenContactUs));
            browser.CloseOnPlaybackCleanup = false;
        }

       

      #endregion

    }
}
