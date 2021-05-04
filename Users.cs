using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkoutLibrary
{   [Serializable]
    public class Users
    {
        //   private String userName;
        private String firstName;
        private String lastName;
        private String emailAddress;
        private String password;
        private String securityQuestion1;
        private String securityAnswer1;
        private String securityQuestion2;
        private String securityAnswer2;
        private String securityQuestion3;
        private String securityAnswer3;
        private String experience;
        private String type;
        private String userImage;
        private String userName;
        private String billingAddress;
        private String dateCreated;
        private int UserWeight;
        private int UserAge;
        private String AmountOfDays;
        private String UserTrainingType;
        private String userGoals;
        private String ProgramName;
        private String binaryPassword;
        private String binaryAddress;

        public String BinaryAddress
        {
            get { return binaryAddress; }
            set { binaryAddress = value; }
        }

        public String BinaryPassword
        {
            get { return binaryPassword; }
            set { binaryPassword = value; }
        }


        public String programName
        {
            get { return ProgramName; }
            set { ProgramName = value; }
        }

        public String UserGoals
        {
            get { return userGoals; }
            set { userGoals = value; }
        }


        public int userWeight
        {
            get { return UserWeight; }
            set { UserWeight = value; }
        }



        public int userAge
        {
            get { return UserAge; }
            set { UserAge = value; }
        }
        public String amountOfDays
        {
            get { return AmountOfDays; }
            set { AmountOfDays = value; }
        }

        public String userTrainingType
        {
            get { return UserTrainingType; }
            set { UserTrainingType = value; }
        }


        public String DateCreated
        {
            get { return dateCreated; }
            set { dateCreated = value; }
        }

        public String BillingAddress
        {
            get { return billingAddress; }
            set { billingAddress = value; }
        }

        public String UserName
        {
            get { return userName; }
            set { userName = value; }
        }
        public String FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        public String LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        public String EmailAddress
        {
            get { return emailAddress; }
            set { emailAddress = value; }
        }

        public String Password
        {
            get { return password; }
            set { password = value; }
        }

        public String SecurityQuestion1
        {
            get { return securityQuestion1; }
            set { securityQuestion1 = value; }
        }


        public String SecurityAnswer1
        {
            get { return securityAnswer1; }
            set { securityAnswer1 = value; }
        }


        public String SecurityQuestion2
        {
            get { return securityQuestion2; }
            set { securityQuestion2 = value; }
        }


        public String SecurityAnswer2
        {
            get { return securityAnswer2; }
            set { securityAnswer2 = value; }
        }

        public String SecurityQuestion3
        {
            get { return securityQuestion3; }
            set { securityQuestion3 = value; }
        }


        public String SecurityAnswer3
        {
            get { return securityAnswer3; }
            set { securityAnswer3 = value; }
        }


        public String Experience
        {
            get { return experience; }
            set { experience = value; }
        }

        public String Type
        {
            get { return type; }
            set { type = value; }
        }

        public String UserImage
        {
            get { return userImage; }
            set { userImage = value; }
        }
    }
}

