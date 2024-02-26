using System.Collections.Generic;
using System.Threading.Tasks;
using ByteNovators.Models.Requst;

namespace ByteNovators.Repository.Abstract
{
    public interface IEmailRepository
    {
        string SendEmail(Quotes quote);
        string SendFeedback(Feedback feedback);
    }
}
