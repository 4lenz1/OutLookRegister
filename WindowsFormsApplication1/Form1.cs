﻿using System;
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
                    /*  Format
                    Index | Account | Password | Applicant
                    */ 
                     string readline = file.ReadLine();

                    //split by , 
                    string[] words = readline.Split(',');
                    //assign 1st index of array to account 
                    //spilit @outlook.com


                    // SCV file Header
                    if (words[0].Equals("Index"))
                    {
                        readNextRow(line, line_number, line_to_delete, reader, file, writer);

                        Application.Restart();
                    }
                    else
                    {
                        /* 
                          Raw data in CSV : Account_Name@outlook.com\
                          1. spilit by '@'  
                          2. auto named by account 
                          3. add @outlook.com back 
                        */
                        string[] accountArray = words[1].Split('@');
                        //assign account  to fill in only 
                        account = accountArray[0];
                        //assign 2nd index of array to password
                        pwd = words[2];

                        readNextRow(line, line_number, line_to_delete, reader, file, writer);
                    }
                }
            }

            System.IO.File.Delete("outlook.csv");
            System.IO.File.Move("~outlook.csv", "outlook.csv");
            
        }


        public void SetComboItem(string id, string value)
        {
            HtmlElement ee = browser.Document.GetElementById(id);
            foreach (HtmlElement item in ee.Children)
            {
                if (item.OuterHtml.ToLower().IndexOf(value.ToLower()) >= 0)
                {
                    item.SetAttribute("selected", "selected");
                    item.InvokeMember("onChange");
                }
                else
                {
                    item.SetAttribute("selected", "");
                }
            }

            ee = this.browser.Document.GetElementById(id + "-input");
            ee.InnerText = value;
        }
        private void readNextRow(string line , int line_number,int line_to_delete, StreamReader reader, System.IO.StreamReader file, StreamWriter writer)
        {
            file.Close();

            while ((line = reader.ReadLine()) != null)
            {

                line_number++;

                if (line_number == line_to_delete)
                    continue;

                writer.WriteLine(line);
            }
        }


        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

            string currentUrl = browser.Url.ToString();
            string[] pageUrl = currentUrl.Split('/');
            Debug.WriteLine("current url : " + currentUrl);
            Debug.WriteLine("pageUrl[3] : " + pageUrl[3]);
            //if (pageUrl[2].Equals("account.microsoft.com"))
            //{
            //    Application.Exit();
            //    System.Environment.Exit(1);
            //}
            if (pageUrl[2].Equals("login.live.com"))
            {
                if (pageUrl[3].Equals("ppsecure"))
                {
                    Debug.WriteLine("exit");
                    Application.Restart();
                    //Application.Exit();
                    //System.Environment.Exit(1);
                    
                }
            }


            if (pageUrl[2].Equals("signup.live.com"))
            {
                Random random = new Random();

                // string[] firstname = new string[] { "Zero", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine" };
                string[] number = new string[] { "Zero", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine" };
                // set random name 
                string[] randonName = new string[] { "John", "Tim", "Wendy", "Tom", "Grace", "Sue", "Cheryl", "Ping", "Azure", "Mama",
                                                 "Kobe", "Curry","Emma","Chiang","Der","Roger","Amy","Hebe","Nancy","Kevin","Tobby",
                                                "Steven","David","Andy","Simon","Jessie","Gina","Lebron","Linus","Sam"};
                //set all attribute
                string[] attribute = new string[] {
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


                HtmlElement fillElement= browser.Document.GetElementById(attribute[0]);
                fillElement.Focus();

                //firstname
                //fillText(attribute[0], randonName[random.Next(0, randonName.Length - 1)]);
                SendKeys.SendWait(randonName[random.Next(0, randonName.Length - 1)]);
                SendKeys.SendWait("{TAB}");
               



                // lastname
                string accountName = null;
                string lastnameNumber = Strings.Right(account, 2);
                Debug.Print(lastnameNumber);
                char[] lastnameChar = lastnameNumber.ToCharArray();

                for (int index = 0; index <= 1; index++)
                    accountName += number[Convert.ToInt32(new string(lastnameChar[index], 1))];
                // accountName = "Azure";

                //SendKeys.SendWait(lastname[random.Next(0, lastname.Length - 1 )]);
                SendKeys.SendWait(accountName);
                SendKeys.SendWait("{TAB}");
                accountName = "";

                // fillElement = browser.Document.GetElementById(attribute[3]);

                //fill account 
             //   SendKeys.SendWait(account + "@outlook.com");
                SendKeys.SendWait(account);


                fillElement = browser.Document.GetElementById(attribute[4]);
                fillElement.Focus();
                SendKeys.SendWait("{TAB}");

                txtAccount.Text = account;
                //SendKeys.SendWait("{TAB}");

                //fill country name
                fillcombox(attribute[5], "TW");
                
                SendKeys.SendWait("{TAB}");


                fillElement = browser.Document.GetElementById(attribute[6]);
                fillElement.Focus();
                string[] month = new string[] { "j", "f", "mar", "ap", "may", "june", "july", "aug", "se", "oc", "no", "de" };
               // SetComboItem(attribute[6],"1");


              //fillElement.SetAttribute("value", random.Next(1, 12).ToString());
              // browser.Document.GetElementById("MySite.condition_s").selectedIndex = 1;
                //fillElement.SetAttribute("value", "2");
             SendKeys.SendWait(month[random.Next(0, month.Length - 1)]);
                
                SendKeys.SendWait("{TAB}");
//
               //fillElement = browser.Document.GetElementById(attribute[7]);
               // fillElement.Focus();
               // fillElement.SetAttribute("value", "1");

                SendKeys.SendWait(random.Next(1, 12).ToString());
               SendKeys.SendWait("{TAB}");



            //    fillElement = browser.Document.GetElementById(attribute[8]);
             //   fillElement.Focus();
             SendKeys.SendWait(random.Next(1945, 1997).ToString());
             SendKeys.SendWait("{TAB}");

                // doesn't work when focus on gender 

                //fillcombox(attribute[9], "u");

                SendKeys.SendWait("n");
                SendKeys.SendWait("{TAB}");

                // fill country name
                fillcombox(attribute[10]  , "TW");

                //fill phone number 
                string phone = random.Next(900000000, 999999999).ToString();
                fillText(attribute[11], phone);

                // go to pass code 
                tab(4);

                //fill 1st password 
                fillText(attribute[3], pwd);

                //fill 2nd password  
                fillText(attribute[4], pwd);
                SendKeys.SendWait("{TAB}");


                fillElement = browser.Document.GetElementById("iAltEmail");
                fillElement.Focus();

                tab(2);
            }
            
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
        private void tab(int times)
        {
            for (int index = 0; index <= times; index++)
            {
                SendKeys.SendWait("{TAB}");
            }
        }

        private void fillText(string attribute, string value)
        {
            HtmlElement fillElement;
            fillElement = browser.Document.GetElementById(attribute);
            fillElement.Focus();
            fillElement.InnerText = value;
            fillElement.RemoveFocus();
        }
        private void fillcombox( string attribute , string value)
        {
            HtmlElement fillElement;
            fillElement = browser.Document.GetElementById(attribute);
            fillElement.Focus();
            fillElement.SetAttribute("value", value);
            fillElement.RemoveFocus();
        }
    }
}
