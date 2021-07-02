// GDC Technical Assessment
// Ryan Carney
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnicalAssessment
{
    class Program
    {
        static void Main(string[] args)
        {
            // Variables
            // List containing all data in the record from the first_name field
            var firstNames = new List<string>();

            // List containing all data in the record from the last_name field
            var lastNames = new List<string>();

            // List containing all data in the record from the email field
            var emails = new List<string>();

            // List containing only valid email addresses
            // Valid Email Addresses contain "@" and end in one of ".com", ".net", ".org", ".gov", ".edu", or ".uk"
            var valEmail = new List<string>();
            
            // List containing only invalid email addresses
            var invEmail = new List<string>();
            

            // Prompt User For a File Name
            Console.WriteLine("Enter a valid filepath:");
            var filename = Console.ReadLine();
            
            // Verify CSV File
            if (File.Exists(@filename))
            {
                Console.WriteLine("Record Found");
            }
            else
            {
                Console.WriteLine("Record Not Found");
                Environment.Exit(0);
            }

            // Read CSV File
            string[] csvraw = System.IO.File.ReadAllLines(@filename);
            
            for (int i = 1; i < csvraw.Length; i++)
            {
                String[] rows = csvraw[i].Split(',');
                firstNames.Add(rows[0]);
                lastNames.Add(rows[1]);
                emails.Add(rows[2]);
            }

            // Check For Valid Email Syntax
            // Valid and Invalid Emails are separated as such and sorted into lists
            for (int i = 1; i < emails.Count; i++)
            {

                // Check .org
                if (emails[i].Contains(".org") && emails[i].Contains("@"))
                {
                    valEmail.Add(emails[i]);
                }

                //Check .com
                else if (emails[i].Contains(".com") && emails[i].Contains("@"))
                {
                    valEmail.Add(emails[i]);
                }

                // Check .gov
                else if (emails[i].Contains(".gov") && emails[i].Contains("@"))
                {
                    valEmail.Add(emails[i]);
                }

                // Check .edu
                else if (emails[i].Contains(".edu") && emails[i].Contains("@"))
                {
                    valEmail.Add(emails[i]);
                }

                // Check .uk
                else if (emails[i].Contains(".uk") && emails[i].Contains("@"))
                {
                    valEmail.Add(emails[i]);
                }

                //Check .net
                else if (emails[i].Contains(".net") && emails[i].Contains("@"))
                {
                    valEmail.Add(emails[i]);
                }
                
                // Invalid Email
                else
                {
                    invEmail.Add(emails[i]);
                }
            }

            // Output List of Valid and Invalid Email Addresses
            Console.WriteLine("List of Valid Email Addresses\n-----------------------------");
            for (int i = 0; i <valEmail.Count; i++)
            {
                Console.WriteLine(valEmail[i]);
            }
            
            Console.WriteLine("List of Invalid Email Addresses\n-------------------------------");
            for (int i = 0; i < invEmail.Count; i++)
            {
                Console.WriteLine(invEmail[i]);
            }
        }
    }
}
