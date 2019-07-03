using System;
using System.Collections.Generic;
using System.Text;

namespace Hex.Event.Core.Domain.DomainEvents.Messages
{
   public  class RegisterCompleted
    {
        private const string EMAIL_SUBJECT = "Course subscribed success!";
        private const string EMAIL_BODY = "Congratulations {0}, your application has been accepted.";

        public RegisterCompleted(string studentName, string email, string course)
        {
            StudentName = studentName;
            Email = email;
            Course = course;
        }

        public string StudentName { get; private set; }
        public string Email { get; private set; }
        public string Course { get; private set; }
        public string Subject => EMAIL_SUBJECT;
        public string Body => string.Format(EMAIL_BODY, this.StudentName);
    }
}
