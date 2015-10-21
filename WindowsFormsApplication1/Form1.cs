using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System.Diagnostics;
namespace WindowsFormsApplication1
{
    public partial class OutlookRegister : Form
    {
        string account;
        string pwd;
        public OutlookRegister()
        {
            InitializeComponent();
             //browser.Navigate("https://signup.live.com//signup");
            browser.Navigate("https://signup.live.com/signup?wa=wsignin1.0&ct=1440858070&rver=6.1.6206.0&sa=1&ntprob=-1&wp=MBI_SSL_SHARED&wreply=https%3a%2f%2fmail.live.com%2f%3fowa%3d1%26owasuffix%3dowa%252f&id=64855&snsc=1&cbcxt=mail&bk=1440858070&uiflavor=web&uaid=aae9ca8192444e03a0a4bc6972fd2c1e&mkt=EN-US&lc=3076&lic=1");
            progresspbar.Minimum = 0;

            string line = null;
            int line_number = 1;
            int line_to_delete = 2;

            using (StreamReader reader = new StreamReader("outlook.csv"))
            {
                //System.IO.StreamWriter writer = new System.IO.StreamWriter("write.txt");
                using (StreamWriter writer = new StreamWriter("~outlook.csv"))
                {


                     System.IO.StreamReader file = new System.IO.StreamReader("outlook.csv");

                    //read line
                     string readline = file.ReadLine();

                    //split by , 
                    string[] words = readline.Split(',');
                    //assign 1st index of array to account 
                    account = words[0];
                    //assign 2nd index of array to password
                    pwd = words[1];

                    file.Close();

                    while ((line = reader.ReadLine()) != null)
                    {

                        line_number++;

                        if (line_number == line_to_delete)
                            continue;

                        writer.WriteLine(line);
                    }
                }
            }

            System.IO.File.Delete("outlook.csv");
            System.IO.File.Move("~outlook.csv", "outlook.csv");
            
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

            Random random = new Random();
            
           // string[] firstname = new string[] { "Zero", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine" };
            string[] number = new string [] { "Zero", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine" };
            // set random name 
            string[] randonName = new string[] { "John", "Tim", "Wendy", "Tom", "Grace", "Sue", "Cheryl", "Ping", "Azure", "Mama",
                                                 "Kobe", "Curry","Emma","Chiang","Der","Roger","Amy","Hebe","Nancy","Kevin","Tobby","Steven"};
            //set all attribute
            string[] attribute =new string[] {
                "FirstName",
                "LastName",
                "MemberName",
                "Password",
                "RetypePassword" ,
                "Country" ,
                "BirthMonth" ,
                "BirthDay" ,
                "BirthYear" ,
                "Gender"  ,
                "PhoneCountry" ,
                "PhoneNumber" };


            HtmlElement fillElement = browser.Document.GetElementById(attribute[0]);
            fillElement.Focus();
           
            //firstname
            SendKeys.SendWait(randonName[random.Next(0, randonName.Length - 1 )]);
            SendKeys.SendWait("{TAB}");



            // lastname
            string accountName = null; 
            string lastnameNumber = Strings.Right(account,2);
            Debug.Print(lastnameNumber);
            char[] lastnameChar = lastnameNumber.ToCharArray();

            for(int index = 0; index <= 1; index ++ )
             accountName += number[ Convert.ToInt32 (new string ( lastnameChar[index], 1))];
           // accountName = "Azure";

            //SendKeys.SendWait(lastname[random.Next(0, lastname.Length - 1 )]);
            SendKeys.SendWait(accountName);
            SendKeys.SendWait("{TAB}");
            accountName = "";

           // fillElement = browser.Document.GetElementById(attribute[3]);
            SendKeys.SendWait(account);



            fillElement = browser.Document.GetElementById(attribute[4]);
            fillElement.Focus();
            SendKeys.SendWait("{TAB}");
            //SendKeys.SendWait("{TAB}");



            //  Thread.Sleep(1000);
            //SendKeys.SendWait("passworddd!");
            // SendKeys.SendWait("{TAB}");
            // SendKeys.SendWait("{TAB}");

            //SendKeys.SendWait("passworddd!");
            // SendKeys.SendWait("{TAB}");

            SendKeys.SendWait("tai");
            SendKeys.SendWait("{TAB}");

            string[] month = new string[] { "j", "f", "mar", "ap", "may", "june", "july", "aug", "se", "oc", "no", "de" };
            SendKeys.SendWait( month[random.Next(0, month.Length - 1 )] );
            SendKeys.SendWait("{TAB}");

            
            SendKeys.SendWait(random.Next(1,12).ToString());
            SendKeys.SendWait("{TAB}");

            SendKeys.SendWait(random.Next(1945, 1997).ToString());
            SendKeys.SendWait("{TAB}");

            SendKeys.SendWait("n");
            SendKeys.SendWait("{TAB}");

            SendKeys.SendWait("tai");
            SendKeys.SendWait("{TAB}");

            SendKeys.SendWait(random.Next(900000000, 999999999).ToString());

            // go to pass code 
            SendKeys.SendWait("{TAB}");
            SendKeys.SendWait("{TAB}");
            SendKeys.SendWait("{TAB}");
            SendKeys.SendWait("{TAB}");



            fillElement = browser.Document.GetElementById(attribute[3]);
            fillElement.Focus();
            fillElement.InnerText = pwd;
            fillElement.RemoveFocus();

           
            fillElement = browser.Document.GetElementById(attribute[4]);
            fillElement.Focus();
            fillElement.InnerText = pwd;
            fillElement.RemoveFocus();
            SendKeys.SendWait("{TAB}");

            fillElement = browser.Document.GetElementById("iAltEmail");
            fillElement.Focus();

            SendKeys.SendWait("{TAB}");
            SendKeys.SendWait("{TAB}");
            SendKeys.SendWait("{TAB}");

          //  fillElement = browser.Document.GetElementById(attribute[0]);
           // fillElement.InnerText = "FirstName";


            //for (int index = 0; index < attribute.Length; index++)
            //{
            //    HtmlElement fillElement = browser.Document.GetElementById(attribute[index]);
            //    fillElement.Focus();

            //    switch (index)
            //    {

            //        case 0:
            //            fillElement.InnerText = "FirstName";
            //            break;
            //        case 1:
            //            fillElement.InnerText = "LastName";
            //            break;
            //        case 2:
            //            fillElement.InnerText = "MemberName19722@outlook.com";
            //            break;

            //        case 3:
            //        case 4:
            //            //fillElement.InnerText = "Password!!ew";
            //            //int milliseconds = 1500;
            //            //Thread.Sleep(milliseconds);
            //            break;
            //        case 5:
            //        case 10:
            //            fillElement.SetAttribute("value", "TW");
            //            break;
            //        case 6:
            //            fillElement.SetAttribute("value", random.Next(1, 12).ToString());
            //            break;
            //        case 7:
            //            fillElement.SetAttribute("value", random.Next(1, 28).ToString());
            //            break;
            //        case 8:
            //            fillElement.SetAttribute("value", random.Next(1940, 2000).ToString());
            //            break;
            //        case 9:
            //            fillElement.SetAttribute("value", "u");
            //            break;
            //        case 11:
            //            fillElement.InnerText = "987456321";
            //            break;

            //    }
            //    fillElement.InvokeMember("onchange");
            //    fillElement.RemoveFocus();
            //}
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

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
