using System.Net.Mail;
using ByteNovators.Models.Requst;
using ByteNovators.Repository;
using ByteNovators.Repository.Resources;

namespace CRM.HonorTourAndTravels.Utilities
{
    public class Sendmailcs
    {
        public string SendQuotes(Quotes model)
        {
            string mailresponse = "";
            string resp = "";
            try
            {


                if (string.IsNullOrEmpty(model.Name))
                {
                    return "false:Missing Name";
                }
                if (string.IsNullOrEmpty(model.Mobile))
                {
                    return "false:Missing Mobile";
                }
                else if (!API.Utility.IsValid.IndianMobileNo(model.Mobile))
                {
                    return "false:Invalid Mobile Number";
                }
                if (string.IsNullOrEmpty(model.Email))
                {
                    return "false:Missing Email";
                }
                else if (!API.Utility.IsValid.Email(model.Email))
                {
                    return "false:Invalid Email";
                }

                if (string.IsNullOrEmpty(model.Address))
                {
                    return "false:Missing Address.";
                }


                // sending mail now 
                string body = "";
                MailMessage msg = new MailMessage();
                msg.From = new MailAddress("enquiry@bytenovators.com");
                msg.To.Add("info@bytenovators.com");
                msg.Subject = "Booking lead from " + model.Email;


                body = EmailTemplate.RequestDemo;
               
                body = body.Replace("{name}", model.Name);
                body = body.Replace("{mobile}", model.Mobile);
                body = body.Replace("{email}", model.Email);
                body = body.Replace("{address}", model.Address);
                msg.Body = body;
                msg.IsBodyHtml = true;
                // MailMessage instance to a specified SMTP server
                SmtpClient smtp = new SmtpClient("199.79.62.161",587);
                smtp.Credentials = new System.Net.NetworkCredential("enquiry@bytenovators.com", "Easy@Password#1234");

                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;

                // Sending the email
                try
                {
                    smtp.Send(msg);
                }
                catch (Exception mex)
                {
                    resp =mex.ToString();

                }

                if (!string.IsNullOrEmpty(resp))
                {
                    mailresponse = resp;
                }
                else
                {
                    mailresponse = "Your querry has being submitted , we will get back to you soon!";
                }
                msg.Dispose();
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }

            return mailresponse;
        }

        public string SendFeedback(Feedback model)
        {
            string mailresponse = "";
            string resp = "";
            try
            {



                if (string.IsNullOrEmpty(model.Name))
                {
                    return "false:Missing Name";
                }
                if (string.IsNullOrEmpty(model.Email))
                {
                    return "false:Missing Email";
                }
                else if (!API.Utility.IsValid.Email(model.Email))
                {
                    return "false:Invalid Email";
                }
                if (string.IsNullOrEmpty(model.Message))
                {
                    return "false:Missing Message";
                }


                string body = "";
                MailMessage msg = new MailMessage();
                msg.From = new MailAddress("feedback@bytenovators.com");
                msg.To.Add("info@bytenovators.com");
                msg.Subject = "Contact from " + model.Email;


                body = EmailTemplate.Feedback;
                //body=body.Replace("{HotelName}", hotelname);
                body = body.Replace("{name}", model.Name);
                body = body.Replace("{email}", model.Email);
                body = body.Replace("{message}", model.Message);
               

                msg.Body = body;
                msg.IsBodyHtml= true;
                // MailMessage instance to a specified SMTP server
                SmtpClient smtp = new SmtpClient("bytenovators.com", 25);
                smtp.Credentials = new System.Net.NetworkCredential("feedback@bytenovators.com", "Easy@Password#1234");

                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;

                // Sending the email
                try
                {
                    smtp.Send(msg);
                }
                catch (Exception mex)
                {
                    resp = mex.ToString();
                }

                if (!string.IsNullOrEmpty(resp))
                {
                    mailresponse = resp; //"false:Reservation faild to submit, please try again  after some time or call us +91 9103000019";
                }
                else
                {
                    mailresponse = "Your Feedback has being submitted , we will get back to you soon!";
                }
                msg.Dispose();
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }

            return mailresponse;
        }
    } 
}
