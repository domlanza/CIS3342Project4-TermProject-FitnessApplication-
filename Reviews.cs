using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkoutLibrary
{
    public class Reviews
    {
        private String ReviewMessage;
        private String ReviewTitle;
        private String DatePosted;
        private String Rating;


        public String reviewMessage
        {
            get { return ReviewMessage; }
            set { ReviewMessage = value; }
        }
        public String reviewTitle
        {
            get { return ReviewTitle; }
            set { ReviewTitle = value; }
        }
        public String datePosted
        {
            get { return DatePosted; }
            set { DatePosted = value; }
        }
        public String rating
        {
            get { return Rating; }
            set { Rating = value; }
        }


    }

}
