using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ByteNovators.Repository.Abstract;
using ByteNovators.Models.Requst;
using Microsoft.AspNetCore.Http;
using ByteNovators.Utility;

namespace ByteNovators.Repository.Concrete
{
    public class EmailRepository : IEmailRepository
    {

        
        public string SendEmail(Quotes model)
        {
            mail QuoteMial = new mail();
           return QuoteMial.SendQuotes(model); 

        }
        public string SendFeedback(Feedback model)
        {
            mail feedbackMail = new mail();
            return  feedbackMail.SendFeedback(model);

        }
    }
}
