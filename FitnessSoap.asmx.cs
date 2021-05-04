using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using Utilities;
using WorkoutLibrary;

namespace SoapWebService
{
    /// <summary>
    /// Summary description for FitnessSoap
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class FitnessSoap : System.Web.Services.WebService
    {
        DBConnect db = new DBConnect();

        [WebMethod]
        public WorkoutSoap Test(string m)
        {
            WorkoutSoap s = new WorkoutSoap();
            s.Name = m;
            return s;
        }

        [WebMethod]
        public Boolean AddUser(User newUsers)
        {
            SqlCommand sqlCommand = new SqlCommand();

            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.CommandText = "TP_InsertUser";

            SqlParameter UserName = new SqlParameter("@UserName", newUsers.UserName);
            UserName.Direction = ParameterDirection.Input;
            sqlCommand.Parameters.Add(UserName);

            SqlParameter Avatar = new SqlParameter("@FirstName", newUsers.FirstName);
            Avatar.Direction = ParameterDirection.Input;
            sqlCommand.Parameters.Add(Avatar);

            SqlParameter Address = new SqlParameter("@LastName", newUsers.LastName);
            Address.Direction = ParameterDirection.Input;
            sqlCommand.Parameters.Add(Address);

            SqlParameter PhoneNumber = new SqlParameter("@EmailAddress", newUsers.EmailAddress);
            PhoneNumber.Direction = ParameterDirection.Input;
            sqlCommand.Parameters.Add(PhoneNumber);

            SqlParameter NewEmail = new SqlParameter("@BillingAddress", newUsers.BillingAddress);
            NewEmail.Direction = ParameterDirection.Input;
            sqlCommand.Parameters.Add(NewEmail);

            SqlParameter SecurityEmail = new SqlParameter("@Image", "Images2/" + newUsers.UserImage + ".png");
            SecurityEmail.Direction = ParameterDirection.Input;
            sqlCommand.Parameters.Add(SecurityEmail);

            SqlParameter SecurityAnswer1 = new SqlParameter("@SecurityAnswer1", newUsers.SecurityAnswer1);
            SecurityAnswer1.Direction = ParameterDirection.Input;
            sqlCommand.Parameters.Add(SecurityAnswer1);


            SqlParameter SecurityAnswer2 = new SqlParameter("@SecurityAnswer2", newUsers.SecurityAnswer2);
            SecurityAnswer2.Direction = ParameterDirection.Input;
            sqlCommand.Parameters.Add(SecurityAnswer2);


            SqlParameter SecurityAnswer3 = new SqlParameter("@SecurityAnswer3", newUsers.SecurityAnswer3);
            SecurityAnswer3.Direction = ParameterDirection.Input;
            sqlCommand.Parameters.Add(SecurityAnswer3);


            SqlParameter SecurityQuestion1 = new SqlParameter("@SecurityQuestion1", newUsers.SecurityQuestion1);
            SecurityQuestion1.Direction = ParameterDirection.Input;
            sqlCommand.Parameters.Add(SecurityQuestion1);


            SqlParameter SecurityQuestion2 = new SqlParameter("@SecurityQuestion2", newUsers.SecurityQuestion2);
            SecurityQuestion2.Direction = ParameterDirection.Input;
            sqlCommand.Parameters.Add(SecurityQuestion2);


            SqlParameter SecurityQuestion3 = new SqlParameter("@SecurityQuestion3", newUsers.SecurityQuestion3);
            SecurityQuestion3.Direction = ParameterDirection.Input;
            sqlCommand.Parameters.Add(SecurityQuestion3);

            SqlParameter Password = new SqlParameter("@Password", newUsers.Password);
            Password.Direction = ParameterDirection.Input;
            sqlCommand.Parameters.Add(Password);

            SqlParameter Type = new SqlParameter("@Type", newUsers.Type);
            Type.Direction = ParameterDirection.Input;
            sqlCommand.Parameters.Add(Type);

            SqlParameter DateCreated = new SqlParameter("@DateCreated", newUsers.DateCreated);
            DateCreated.Direction = ParameterDirection.Input;
            sqlCommand.Parameters.Add(DateCreated);

            SqlParameter Experience = new SqlParameter("@Experience", newUsers.Experience);
            Experience.Direction = ParameterDirection.Input;
            sqlCommand.Parameters.Add(Experience);

            SqlParameter Verified = new SqlParameter("@Verified", "No");
            Verified.Direction = ParameterDirection.Input;
            sqlCommand.Parameters.Add(Verified);

            SqlParameter VerifiedNumber = new SqlParameter("@VerifiedNumber", newUsers.Code);
            VerifiedNumber.Direction = ParameterDirection.Input;
            sqlCommand.Parameters.Add(VerifiedNumber);

            SqlParameter age = new SqlParameter("@Age", newUsers.userAge);
            age.Direction = ParameterDirection.Input;
            sqlCommand.Parameters.Add(age);

            SqlParameter weight = new SqlParameter("@Weight", newUsers.userWeight);
            weight.Direction = ParameterDirection.Input;
            sqlCommand.Parameters.Add(weight);

            SqlParameter date = new SqlParameter("@DayWorkoutSelected", newUsers.DateCreated);
            date.Direction = ParameterDirection.Input;
            sqlCommand.Parameters.Add(date);


            int ret = db.DoUpdateUsingCmdObj(sqlCommand);

            if (ret > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        [WebMethod]
        public User GetAllUsers(DataSet myData, int i)
        {
            User users = new User();
            int ID = Convert.ToInt32(myData.Tables[0].Rows[i]["ProgramID"]);
            string ProgramName;

            SqlCommand sqlCommand = new SqlCommand();

            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.CommandText = "TP_SelectProgramName";

            SqlParameter programName = new SqlParameter("@ID", ID);
            programName.Direction = ParameterDirection.Input;
            sqlCommand.Parameters.Add(programName);
            DataSet ds = db.GetDataSetUsingCmdObj(sqlCommand);
            ProgramName = ds.Tables[0].Rows[0]["ProgramName"].ToString();



            users.FirstName = myData.Tables[0].Rows[i]["FirstName"].ToString();
            users.LastName = myData.Tables[0].Rows[i]["LastName"].ToString();
            users.EmailAddress = myData.Tables[0].Rows[i]["EmailAddress"].ToString();
            users.UserName = myData.Tables[0].Rows[i]["UserName"].ToString();
            users.DateCreated = myData.Tables[0].Rows[i]["DateCreated"].ToString();
            users.userWeight = Convert.ToInt32(myData.Tables[0].Rows[i]["UserWeight"]);
            users.userAge = Convert.ToInt32(myData.Tables[0].Rows[i]["UserAge"]);
            users.UserGoals = myData.Tables[0].Rows[i]["UserGoals"].ToString();
            users.userTrainingType = myData.Tables[0].Rows[i]["UserTraining"].ToString();
            users.Experience = myData.Tables[0].Rows[i]["Experience"].ToString();
            users.amountOfDays = myData.Tables[0].Rows[i]["UserDays"].ToString();
            users.UserImage = myData.Tables[0].Rows[i]["UserImage"].ToString();
            users.programName = ProgramName;

            return users;
        }

        [WebMethod]
        public Program GetAllProgram(DataSet myData, int i)
        {
            Program program = new Program();

            program.ProgramID = Convert.ToInt32(myData.Tables[0].Rows[i]["ProgramID"]);

            program.programName = myData.Tables[0].Rows[i]["ProgramName"].ToString();
            program.dateAdded = myData.Tables[0].Rows[i]["DateAdded"].ToString();
            program.description = myData.Tables[0].Rows[i]["Description"].ToString();
            program.programType = myData.Tables[0].Rows[i]["ProgramType"].ToString();
            program.programExperience = myData.Tables[0].Rows[i]["ProgramExperience"].ToString();
            program.Days = Convert.ToInt32(myData.Tables[0].Rows[i]["AmountOfDays"]);
            program.Image = myData.Tables[0].Rows[i]["ProgramImage"].ToString();
            program.LengthOfProgram = Convert.ToInt32(myData.Tables[0].Rows[i]["LengthOfProgram"]);

            return program;

        }
        //FitnessService
    }
}
