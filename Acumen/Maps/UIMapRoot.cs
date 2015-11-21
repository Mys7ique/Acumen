using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Acumen.Maps.UIMapMenuClasses;
using Acumen.Maps.UIMapContactUsClasses;


namespace Acumen.Maps
{
    public class UIMapRoot
    {
        private UIMapRoot()
        {

        }

        public static UIMapRoot GetInstance()
        {
            if (instance == null)
            {
                instance = new UIMapRoot();
            }

            return instance;
        }

        public static void ResetUIMap()
        {
            instance = new UIMapRoot();
        }

        private static UIMapRoot instance;

        public UIMapMenu UIMapMenu
        {
            get
            {
                if ((this.uiMapMenu == null))
                {
                    this.uiMapMenu = new UIMapMenu();
                }
                return this.uiMapMenu;
            }
        }
        private UIMapMenu uiMapMenu;

        public UIMapContactUs UIMapContactUs
        {
            get
            {
                if ((this.uiMapContactUs==null))
                {
                    this.uiMapContactUs = new UIMapContactUs();
                }
                return this.uiMapContactUs;
            }
        }
        private UIMapContactUs uiMapContactUs;

     }
}