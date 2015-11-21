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

namespace Acumen.Maps.UIMapMenuClasses
{  
    public partial class UIMapMenu
    {
        #region Methods

        public void ClickContactUs()
        {
            HtmlHyperlink uiContactUs = this.UIAcumenWindow.UIAcumen.UIContactUs.UIContactUsHyperlink;
            Mouse.Click(uiContactUs);
        }

        #endregion

    }
}
