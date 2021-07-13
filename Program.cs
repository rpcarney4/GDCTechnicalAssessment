using System;
using System.Text;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks; 
using System.Collections;

namespace emailApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var emails = new List<string>();
            emailList eList = new emailList("Valid Emails", "Invalid Emails", new List<Email>(), new List<Email>());
            Console.WriteLine("Please enter a valid filepath.");
            var filename = Console.ReadLine();

            try
            {
                string[] csvraw = System.IO.File.ReadAllLines(@filename);
                for (int i = 1; i < csvraw.Length; i++)
                {
                    String[] rows = csvraw[i].Split(',');
                    emails.Add(rows[2]);
                }
                for (int j = 0; j < emails.Count; j++)
                {
                    Email e = new Email(emails[j]);
                    eList.addEmail(e);
                }
                Console.WriteLine(eList.getFirstList() + "\n----------------------");
                Console.WriteLine(eList.getValList());
                Console.WriteLine(eList.getSecondList() + "\n----------------------");
                Console.WriteLine(eList.getInvList());
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("The file " + filename + " does not exist");
            }            
        }
    }
}
    
    public class emailList
    {
        // List of email objects that meet the criteria of a valid email address
        List<Email> validList = new List<Email>();

        // List of email objects that meet the criteria of a valid email address
        List<Email> invalidList = new List<Email>();

        // String value naming the first (valid) list of emails
        private String valids;

        // String value naminng the second (invalid) list of emails in the emailList constructor
        private String invalids;


        ////////////////////////////////////////////////
        // Constructor for emailList objects          //
        // @param listv corresponds to valids         //
        // @param listi corresponds to invalids       //
        // @param vallist corresponds to validList    //
        // @param invallist corresponds to invalidList//
        ////////////////////////////////////////////////
        public emailList(String listv, String listi, List<Email> vallist, List<Email> invallist)
        {
            valids = listv;
            invalids = listi;
            invalidList = invallist;
            validList = vallist;
        }

        /////////////////////////////////////////////////////////////////////
        // Returns the name of the first list                              //
        // for all intensive purposes the second list contains valid emails//
        /////////////////////////////////////////////////////////////////////
        public String getFirstList()
        {
            return valids;
        }

        ///////////////////////////////////////////////////////////////////////
        // Returns the name of the second list                               //
        // for all intensive purposes the second list contains invalid emails//
        ///////////////////////////////////////////////////////////////////////
        public String getSecondList()
        {
            return invalids;
        }

        ////////////////////////////////////////////////////////////////////////////////////////
        // Method used to return the valid List<Email> object from within the emailList object//
        ////////////////////////////////////////////////////////////////////////////////////////
        public String getValList()
        {
            String output = "";
            foreach (Email e in validList)
            {
                output += e.getEmail() + "\n";
            }
            return output;
        }

        //////////////////////////////////////////////////////////////////////////////////////////
        // Method used to return the invalid List<Email> object from within the emailList object//
        //////////////////////////////////////////////////////////////////////////////////////////
        public String getInvList()
        {
            String output = "";
            foreach (Email e in invalidList)
            {
                output += e.getEmail() + "\n";
            }
            return output;
        }

        /////////////////////////////////////////////////////////////////////////////
        // Method used to add valid and invalid emails to their corresponding lists//
        // Uses isValid() method from Email class                                  //
        // @param e references the email object to be added to the List<Email>     //
        /////////////////////////////////////////////////////////////////////////////
        public void addEmail(Email e)
        {
            if (e.isValid())
            {
                validList.Add(e);
            }
            else
            {
                invalidList.Add(e);
            }

        }

    }

    // Email Class
    // Creates Email Objects for use in emailList Class
    public class Email
    {
        // The string value held in the Email object
        private String email;

        //////////////////////////////////////////////
        // Email Constructor                        //
        // @param emailIn corresponds to email field//
        //////////////////////////////////////////////
        public Email(String emailIn)
        {
            email = emailIn;
        }

        //////////////////////////////////////////////////////////////////////////////////
        // Method Checks criteria for proper email and returns true or false accordingly//
        // Used primarily to add emails to a List<Email> of valid or invalid emails     // 
        //////////////////////////////////////////////////////////////////////////////////
        public bool isValid()
        {
            if (email.Contains('@') && email.Contains('.'))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        ////////////////////////////////////////////////////////////////////////////
        // Method used to return the string value of the email object in reference//
        ////////////////////////////////////////////////////////////////////////////
        public String getEmail()
        {
            return email;
        }

        /////////////////////////////////////////////////////////////////////////
        // Method used to set the string value of the email object in reference//
        /////////////////////////////////////////////////////////////////////////
        public void setEmail(String emailSet)
        {
            email = emailSet;
        }
    }