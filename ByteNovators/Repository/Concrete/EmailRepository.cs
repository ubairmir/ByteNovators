using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ByteNovators.Repository.Abstract;
using ByteNovators.Models.Requst;
using Microsoft.AspNetCore.Http;
using CRM.HonorTourAndTravels.Utilities;

namespace ByteNovators.Repository.Concrete
{
    public class EmailRepository : IEmailRepository
    {

        
        public string SendEmail(Quotes model)
        {
            Sendmailcs QuoteMial = new Sendmailcs();
           return QuoteMial.SendQuotes(model); 

        }
        public string SendFeedback(Feedback model)
        {
            Sendmailcs feedbackMail = new Sendmailcs();
            return  feedbackMail.SendFeedback(model);

        }
    }
}
