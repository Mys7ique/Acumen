using System;
using System.Collections.Generic;
using System.CodeDom.Compiler;
using Microsoft.VisualStudio.TestTools.UITest.Extension;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Keyboard = Microsoft.VisualStudio.TestTools.UITesting.Keyboard;
using Mouse = Microsoft.VisualStudio.TestTools.UITesting.Mouse;
using MouseButtons = System.Windows.Forms.MouseButtons;
using System.Drawing;
using System.Windows.Input;
using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;

namespace Acumen.Maps.UIMapContactUsClasses
{
    public partial class UIMapContactUs
    {
        #region Methods

        public void EnterEmail(string email)
        {
            HtmlEdit uiEmail = this.UIContactUsAcumenWindow.UIContactUsAcumen.UIEmailEdit;
            uiEmail.Text = email;
        }

        public void EnterPhone(string phone)
        {
            HtmlEdit uiPhone = this.UIContactUsAcumenWindow.UIContactUsAcumen.UIPhoneEdit;
            uiPhone.Text = phone;
        }

        public void EnterMessage(string message)
        {
            HtmlTextArea uiMessage = this.UIContactUsAcumenWindow.UIContactUsAcumen.UIMessageEdit;
            uiMessage.Text = message;
        }

        public void ClickSend()
        {
            HtmlInputButton uiSend = this.UIContactUsAcumenWindow.UIContactUsAcumen.UIMissing.UISendButton;
            Mouse.Click(uiSend);
        }

        public void AssertPostCode(string postCode)
        {
            HtmlControl uiAddress = this.UIContactUsAcumenWindow.UIContactUsAcumen.UIContent.UIAcumenContactAddress;
            Assert.IsTrue(uiAddress.InnerText.Contains(postCode), "The provided address contains incorrect post code.");
        }

        public void AssertNameErrorMessage()
        {
            HtmlControl uiNameMessage = this.UIContactUsAcumenWindow.UIContactUsAcumen.UIInvalid.UIMissingName;
            Assert.IsTrue(uiNameMessage.Enabled, "Error messege doesn't appear.");
            Assert.IsTrue(uiNameMessage.InnerText == "Please fill the required field.", "Error message is not displayed or displayed incorrectly.");
        }

        public void AssertCompanyErrorMessage()
        {
            HtmlControl uiCompanyMessage = this.UIContactUsAcumenWindow.UIContactUsAcumen.UIInvalid.UIMissingCompany;
            Assert.IsTrue(uiCompanyMessage.Enabled, "Error messege doesn't appear.");
            Assert.IsTrue(uiCompanyMessage.InnerText == "Please fill the required field.", "Error message is not displayed or displayed incorrectly.");
        }

        public void AssertLocationErrorMessage()
        {
            HtmlControl uiLocationMessage = this.UIContactUsAcumenWindow.UIContactUsAcumen.UIInvalid.UIMissingLocation;
            Assert.IsTrue(uiLocationMessage.Enabled, "Error messege doesn't appear.");
            Assert.IsTrue(uiLocationMessage.InnerText == "Please fill the required field.", "Error message is not displayed or displayed incorrectly.");
        }

        public void AssertEmailErrorMessage()
        {
            HtmlControl uiEmailMissingMessage = this.UIContactUsAcumenWindow.UIContactUsAcumen.UIInvalid.UIMissingEmail;
            HtmlControl uiEmailInvalidMessage = this.UIContactUsAcumenWindow.UIContactUsAcumen.UIInvalid.UIInvalidMessageEmail;
            HtmlEdit uiEmail = this.UIContactUsAcumenWindow.UIContactUsAcumen.UIEmailEdit;
                        
            if (uiEmail.Text!="")
            {
                if (!uiEmail.Text.Contains("@"))
                {
                    Assert.IsTrue(uiEmailInvalidMessage.Enabled, "Error messege doesn't appear.");
                    Assert.IsTrue(uiEmailInvalidMessage.InnerText == "Email address seems invalid.", "Error message is not displayed or displayed incorrectly.");
                }
            }
            else Assert.IsTrue(uiEmailMissingMessage.InnerText == "Please fill the required field.", "Error message is not displayed or displayed incorrectly.");
            
            
        }

        public void AssertClientEnquiriesEmail(string clientEmail)
        {
            HtmlHyperlink uiClientEnquiriesEmail = this.UIContactUsAcumenWindow.UIContactUsAcumen.UIContent.UIClientEmailHyperlink;
            Assert.IsTrue(uiClientEnquiriesEmail.InnerText == clientEmail, "Client enquiries e-mail address is incorrect.");
        }

        public void AssertSupportEnquiriesEmail(string supportEmail)
        {
            HtmlHyperlink uiSupportEnquiriesEmail = this.UIContactUsAcumenWindow.UIContactUsAcumen.UIContent.UISupportEmailHyperlink;
            Assert.IsTrue(uiSupportEnquiriesEmail.InnerText == supportEmail, "Support enquiries e-mail address is incorrect.");
        }

        public void AssertClientEnquiriesPhone(string clientPhone)
        {
            HtmlControl uiClientEnquiriesPhone = this.UIContactUsAcumenWindow.UIContactUsAcumen.UIContent.UIAcumentPhoneEmail;
            Assert.IsTrue(uiClientEnquiriesPhone.InnerText.Contains(clientPhone), "The provided phone number for client inquires is not correct.");
        }

        public void AssertSupportEnquiriesPhone(string supportPhone)
        {
            HtmlControl uiClientEnquiriesPhone = this.UIContactUsAcumenWindow.UIContactUsAcumen.UIContent.UIAcumentPhoneEmail;
            Assert.IsTrue(uiClientEnquiriesPhone.InnerText.Contains(supportPhone), "The provided phone number for client inquires is not correct.");
        }


        public void AssertValidEmail()
        {
            HtmlEdit uiEmail = this.UIContactUsAcumenWindow.UIContactUsAcumen.UIEmailEdit;
            Assert.IsTrue(uiEmail.Text.Contains("@"), "Entered e-mail address is invalid.");
        }

        public void AssertValidPhone()
        {
            bool validPhone=true;
            string allowedCharacters = "+-() ";
            HtmlEdit uiPhone = this.UIContactUsAcumenWindow.UIContactUsAcumen.UIPhoneEdit;
            foreach (char c in uiPhone.Text)
            {
                if ((c < '0' || c > '9')&&(!allowedCharacters.Contains(c.ToString()))) validPhone = false;
            }
            Assert.IsTrue(validPhone, "The provided phone number is invalid, it contains characters or symbols other than digits.");
        }

        #endregion
    }
}
