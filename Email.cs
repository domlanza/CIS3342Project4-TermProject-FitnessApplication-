using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkoutLibrary
{
    public class Email
    {
        private String EmailSubject;
        private String EmailBody;
        private String Sender;
        private String Receiever;
        private String Time;

        public String time
        {
            get { return Time; }
            set { Time = value; }
        }

        public String emailSubject
        {
            get { return EmailSubject; }
            set { EmailSubject = value; }
        }

        public String emailBody
        {
            get { return EmailBody; }
            set { EmailBody = value; }
        }

        public String sender
        {
            get { return Sender; }
            set { Sender = value; }
        }

        public String receiver
        {
            get { return Receiever; }
            set { Receiever = value; }
        }
    }
}
