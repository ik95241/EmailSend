using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace EmailManager
{
    public class Student
    {
         public int Id { get; set; }
        public string Name { get; set; }

        public DateTime DOB { get; set; }

        public string Email { get; set; }

        public int Mobile { get; set; }
    }
  
    internal class Program
    {
        static void Main(string[] args)
    {
            List<Student> students = new List<Student>()
            {
                new Student{ Id=1, Name="ABC", DOB=new DateTime(11022000), Email="abc@gmil.com", Mobile=1234567890},
                 new Student{Id=2, Name="pqr", DOB=new DateTime(11022000), Email="pqr@gmil.com", Mobile=1234567890},
                  new Student{Id=3, Name="zyz", DOB=new DateTime(11022000), Email="zyz@gmil.com", Mobile=1234567890},
                   new Student{Id=4, Name="apa", DOB=new DateTime(11022000), Email="apa@gmil.com", Mobile=1234567890},
                   new Student{ Id=1, Name="ABC", DOB=new DateTime(11022000), Email="abc@gmil.com", Mobile=1234567890},
                 new Student{Id=2, Name="pqr", DOB=new DateTime(11022000), Email="pqr@gmil.com", Mobile=1234567890},
                  new Student{Id=3, Name="zyz", DOB=new DateTime(11022000), Email="zyz@gmil.com", Mobile=1234567890},
                   new Student{Id=4, Name="apa", DOB=new DateTime(11022000), Email="apa@gmil.com", Mobile=1234567890},
                   new Student{ Id=1, Name="ABC", DOB=new DateTime(11022000), Email="abc@gmil.com", Mobile=1234567890},
                 new Student{Id=2, Name="pqr", DOB=new DateTime(11022000), Email="pqr@gmil.com", Mobile=1234567890},
                  new Student{Id=3, Name="zyz", DOB=new DateTime(11022000), Email="zyz@gmil.com", Mobile=1234567890},
                   new Student{Id=4, Name="apa", DOB=new DateTime(11022000), Email="apa@gmil.com", Mobile=1234567890},
                   new Student{ Id=1, Name="ABC", DOB=new DateTime(11022000), Email="abc@gmil.com", Mobile=1234567890},
                 new Student{Id=2, Name="pqr", DOB=new DateTime(11022000), Email="pqr@gmil.com", Mobile=1234567890},
                  new Student{Id=3, Name="zyz", DOB=new DateTime(11022000), Email="zyz@gmil.com", Mobile=1234567890},
                   new Student{Id=4, Name="apa", DOB=new DateTime(11022000), Email="apa@gmil.com", Mobile=1234567890},
                   new Student{ Id=1, Name="ABC", DOB=new DateTime(11022000), Email="abc@gmil.com", Mobile=1234567890},
                 new Student{Id=2, Name="pqr", DOB=new DateTime(11022000), Email="pqr@gmil.com", Mobile=1234567890},
                  new Student{Id=3, Name="zyz", DOB=new DateTime(11022000), Email="zyz@gmil.com", Mobile=1234567890},
                   new Student{Id=4, Name="apa", DOB=new DateTime(11022000), Email="apa@gmil.com", Mobile=1234567890}

            };
        string htmlString = getHtml(students); //here you will be getting an html string  
        SendEmail(htmlString); //Pass html string to Email function. 
    }

        public static void Readtextfile()
        {
            string line;
          //  List listOfPersons = new List();

            // Read the file and display it line by line.
            System.IO.StreamReader file =
                new System.IO.StreamReader(@"c:\yourFile.txt");
            while ((line = file.ReadLine()) != null)
            {
                string[] words = line.Split(',');
              //  listOfPersons.Add(new Person(words[0], words[1], words[2]));
            }

            file.Close();
        }
        public static string getHtml(List<Student> grid)
        {
            try
            {
                string messageBody = "<font>The following are the records: </font><br><br>";
                if (grid.Count == 0) return messageBody;
                string htmlTableStart = "<table style=\"border-collapse:collapse; text-align:center;\" >";
                string htmlTableEnd = "</table>";
                string htmlHeaderRowStart = "<tr style=\"background-color:#6FA1D2; color:#ffffff;\">";
                string htmlHeaderRowEnd = "</tr>";
                string htmlTrStart = "<tr style=\"color:#555555;\">";
                string htmlTrEnd = "</tr>";
                string htmlTdStart = "<td style=\" border-color:#5c87b2; border-style:solid; border-width:thin; padding: 5px;\">";
                string htmlTdEnd = "</td>";
                messageBody += htmlTableStart;
                messageBody += htmlHeaderRowStart;
                messageBody += htmlTdStart + "Id" + htmlTdEnd;
                messageBody += htmlTdStart + "Student Name" + htmlTdEnd;
                messageBody += htmlTdStart + "DOB" + htmlTdEnd;
                messageBody += htmlTdStart + "Email" + htmlTdEnd;
                messageBody += htmlTdStart + "Mobile" + htmlTdEnd;
                messageBody += htmlHeaderRowEnd;
                //Loop all the rows from grid vew and added to html td  
                for (int i = 0; i <= grid.Count - 1; i++)
                {
                    messageBody = messageBody + htmlTrStart;
                    messageBody = messageBody + htmlTdStart + grid[i].Id.ToString() + htmlTdEnd; //adding student name
                    messageBody = messageBody + htmlTdStart + grid[i].Name.ToString() + htmlTdEnd; //adding student name  
                    messageBody = messageBody + htmlTdStart + grid[i].DOB.ToString() + htmlTdEnd; //adding DOB  
                    messageBody = messageBody + htmlTdStart + grid[i].Email.ToString() + htmlTdEnd; //adding Email  
                    messageBody = messageBody + htmlTdStart + grid[i].Mobile.ToString() + htmlTdEnd; //adding Mobile  
                    messageBody = messageBody + htmlTrEnd;
                }
                messageBody = messageBody + htmlTableEnd;
                return messageBody; // return HTML Table as string from this function  
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public static void SendEmail(string htmlString)
        {
            try
            {
                MailMessage message = new MailMessage();
                SmtpClient smtp = new SmtpClient();


                message.From = new MailAddress(System.Configuration.ConfigurationManager.AppSettings.Get("From").ToString());
                string addresses_to = System.Configuration.ConfigurationManager.AppSettings.Get("To").ToString();
                foreach (var address in addresses_to.Split(new[] { ";" }, StringSplitOptions.RemoveEmptyEntries))
                {
                    // message.To.Add(new MailAddress(address));
                    message.To.Add(address);
                }

                message.Subject = "Test";
                message.IsBodyHtml = true; //to make message body as html  
                message.Body = htmlString;
                smtp.Port = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings.Get("SMTPPort"));
                smtp.Host = System.Configuration.ConfigurationManager.AppSettings.Get("SMTPHost").ToString();// "smtp.gmail.com"; //for gmail host  
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential(System.Configuration.ConfigurationManager.AppSettings.Get("From").ToString(), System.Configuration.ConfigurationManager.AppSettings.Get("FromEmailPassword").ToString());
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                //smtp.Send(message);
            }
            catch (Exception ex)
            {
            }
        }

    }
}
