using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            browser.Navigate("https://signup.live.com/signup");
            progresspbar.Minimum = 0;
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            browser.Document.GetElementById("FirstName").InnerText = "rewrwr";
            browser.Document.GetElementById("LastName").InnerText = "dgsrgre";

            browser.Document.GetElementById("MemberName").InnerText = "gggtttt";
            browser.Document.GetElementById("Password").InnerText = "eeeeerrrrrffffff";
            browser.Document.GetElementById("RetypePassword").InnerText = "eeeeerrrrrffffff";

          //browser.Document.GetElementById("Country").SetAttribute("value", "Taiwan");


          HtmlElement reportDropDown = browser.Document.GetElementById("Country");
          reportDropDown.Focus();
          reportDropDown.SetAttribute("value", "Taiwan");  //The value of the desired selection
          reportDropDown.InvokeMember("onchange");
          reportDropDown.RemoveFocus();
           //  browser.Document.GetElementById("LastName").InnerText = "321";
            

        }


        private void browser_ProgressChanged(object sender, WebBrowserProgressChangedEventArgs e)
        {
            progresspbar.Minimum = 0;
            progresspbar.Maximum = (int)e.MaximumProgress;
            Console.WriteLine(e.CurrentProgress);
            if (e.CurrentProgress > 0)
            {
                progresspbar.Value = (int)e.CurrentProgress;
            }
        }

    }
}
