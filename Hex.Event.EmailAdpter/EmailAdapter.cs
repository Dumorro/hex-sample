using Hex.Event.Core.Domain.Adapters;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Hex.Event.EmailAdpter
{
    public class EmailAdapter : IEmailAdapter
    {
        public async Task SendEmail(string from, string to, string subject, string body)
        {
            //TODO: implement send email;
            
        }
    }
}
