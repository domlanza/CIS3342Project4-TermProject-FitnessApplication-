using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilities;
using WorkoutLibrary;
using System.Net;
using System.Net.Mail;
using WorkoutLibraryClass;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Term_Project
{
    public partial class SignUp : System.Web.UI.Page
    {

        DBConnect db = new DBConnect();
         FitnessService.FitnessSoap pxy = new FitnessService.FitnessSoap();


        protected void Page_Load(object sender, EventArgs e)
        {
 
        }

        protected void btnCreate_Click1(object sender, EventArgs e)
        {
            //Add values to variables
            List<String> CheckList = new List<String>();
            string pass = txtPassword.Text;
            string pass2 = txtPasswordReenter.Text;
            string userName = txtUserName.Text;
            string address = txtAddress.Text;
            string emailAddress = txtNewEmail.Text;
            string firstName = txtFirstName.Text;
            string lastName = txtLastName.Text;
            string billingAddress = txtBillingAddress.Text;
            string phoneNumber = txtPhoneNumber.Text;
            string securityAnswer1 = txtSQ1Answer.Text;
            string securityAnswer2 = txtSQ2Answer.Text;
            string securityAnswer3 = txtSQ3Answer.Text;
            string securityQuestion1 = ddlSQ1.SelectedValue;
            string securityQuestion2 = ddlSQ2.SelectedValue;
            string securityQuestion3 = ddlSQ3.SelectedValue;
            string Weighttxt = txtWeight.Text;
            string Agetxt = txtAge.Text;
            string SQ1 = ddlSQ1.SelectedValue;
            string SQ2 = ddlSQ2.SelectedValue;
            string SQ3 = ddlSQ3.SelectedValue;


            //Verification checks
            int check = 0;
            CheckList.Add(userName);
            CheckList.Add(address);
            CheckList.Add(emailAddress);
            CheckList.Add(firstName);
            CheckList.Add(lastName);
            CheckList.Add(billingAddress);
            CheckList.Add(phoneNumber);
            CheckList.Add(securityAnswer1);
            CheckList.Add(securityAnswer2);
            CheckList.Add(securityAnswer3);
            CheckList.Add(securityQuestion1);
            CheckList.Add(securityQuestion2);
            CheckList.Add(securityQuestion3);
            CheckList.Add(pass);
            CheckList.Add(pass2);
            CheckList.Add(Weighttxt);
            CheckList.Add(Agetxt);

            for (int i = 0; i < CheckList.Count; i++)
            {
                if (CheckList[i] != "")
                {
                    check = check + 1;
                }

            }

            //If checks pass, if passwords are equal, if the security questions selected aren't equal
            if (check == 17)
            {
                if (pass == pass2)
                {
                    if (SQ1 != SQ2 && SQ1 != SQ3 && SQ2 != SQ3)
                    {
                        lblPassError.Visible = false;
                        lblPassError1.Visible = false;
                        lblPassword.Visible = true;
                        lblPassword1.Visible = true;

                        //Stored procedure to check if account exists
                        SqlCommand sqlCommand3 = new SqlCommand();

                        sqlCommand3.CommandType = CommandType.StoredProcedure;
                        sqlCommand3.CommandText = "TP_SelectUserIDEmailCreateUser";

                        SqlParameter EmailAddress = new SqlParameter("@Email", txtNewEmail.Text);
                        EmailAddress.Direction = ParameterDirection.Input;
                        sqlCommand3.Parameters.Add(EmailAddress);

                        DataSet ds = db.GetDataSetUsingCmdObj(sqlCommand3);

                        int size = ds.Tables[0].Rows.Count;

                        //If account doesn't exist
                        if (size == 0)
                        {
                            FitnessService.User newUsers = new FitnessService.User();
                            ArrayList binaryArray = new ArrayList();
                            Users user = new Users();

                            var rand = new Random();
                            int num = rand.Next(1000, 10000);
                            //Assigns values to class object
                            String password = txtPassword.Text;
                            newUsers.FirstName = firstName;
                            newUsers.LastName = lastName;
                            newUsers.EmailAddress = emailAddress;
                            newUsers.UserName = userName;
                            newUsers.BillingAddress = billingAddress;
                            newUsers.SecurityQuestion1 = securityQuestion1;
                            newUsers.SecurityQuestion2 = securityQuestion2;
                            newUsers.SecurityQuestion3 = securityQuestion3;
                            newUsers.SecurityAnswer1 = securityAnswer1;
                            newUsers.SecurityAnswer2 = securityAnswer2;
                            newUsers.SecurityAnswer3 = securityAnswer3;
                            newUsers.Password = pass;
                            newUsers.Type = "User";
                            newUsers.Experience = ddlImage.SelectedValue;
                            newUsers.UserImage = ddlImage.SelectedValue;
                            newUsers.DateCreated = DateTime.Now.ToString();
                            newUsers.userWeight = Convert.ToInt32(txtWeight.Text);
                            newUsers.userAge = Convert.ToInt32(txtAge.Text);
                            user.BinaryPassword = txtPassword.Text;
                            user.BinaryAddress = txtBillingAddress.Text;
                            newUsers.Code = num;
                            //Executes soap, creates user
                            Boolean test = pxy.AddUser(newUsers);


                            //Gets UserID from newest account
                            SqlCommand sqlCommand3B = new SqlCommand();

                            sqlCommand3B.CommandType = CommandType.StoredProcedure;
                            sqlCommand3B.CommandText = "TP_SelectUserIDEmailCreateUser";

                            SqlParameter EmailAddress1 = new SqlParameter("@Email", txtNewEmail.Text);
                            EmailAddress1.Direction = ParameterDirection.Input;
                            sqlCommand3B.Parameters.Add(EmailAddress1);

                            DataSet ds2 = db.GetDataSetUsingCmdObj(sqlCommand3B);

                            int userId = Convert.ToInt32(ds2.Tables[0].Rows[0]["UserID"]);

                            //Serializes an object 
                            BinaryFormatter serializer = new BinaryFormatter();
                            MemoryStream memStream = new MemoryStream();
                            Byte[] byteArray;

                            serializer.Serialize(memStream, user);
                            byteArray = memStream.ToArray();

                            //Adds serialized object to database
                            SqlCommand sqlCommand3A = new SqlCommand();

                            sqlCommand3A.CommandType = CommandType.StoredProcedure;
                            sqlCommand3A.CommandText = "TP_UpdateUsersCreateBinary";

                            SqlParameter ID = new SqlParameter("@ID", userId);
                            ID.Direction = ParameterDirection.Input;
                            sqlCommand3A.Parameters.Add(ID);

                            SqlParameter objectBinary = new SqlParameter("@BinaryObject", byteArray);
                            objectBinary.Direction = ParameterDirection.Input;
                            sqlCommand3A.Parameters.Add(objectBinary);

                            int ret = db.DoUpdateUsingCmdObj(sqlCommand3A);


                            //Creates Inbox tag for user
                            SqlCommand sqlCommand4A = new SqlCommand();

                            sqlCommand4A.CommandType = CommandType.StoredProcedure;
                            sqlCommand4A.CommandText = "TP_InsertIntoTags";

                            SqlParameter UserID2 = new SqlParameter("@ID", userId);
                            UserID2.Direction = ParameterDirection.Input;
                            sqlCommand4A.Parameters.Add(UserID2);

                            SqlParameter TagName = new SqlParameter("@TagName", "Inbox");
                            TagName.Direction = ParameterDirection.Input;
                            sqlCommand4A.Parameters.Add(TagName);

                            db.DoUpdateUsingCmdObj(sqlCommand4A);

                            //Creates Sent tag for user
                            SqlCommand sqlCommand5A = new SqlCommand();

                            sqlCommand5A.CommandType = CommandType.StoredProcedure;
                            sqlCommand5A.CommandText = "TP_InsertIntoTags";

                            SqlParameter UserID3 = new SqlParameter("@ID", userId);
                            UserID3.Direction = ParameterDirection.Input;
                            sqlCommand5A.Parameters.Add(UserID3);

                            SqlParameter Sent = new SqlParameter("@TagName", "Sent");
                            Sent.Direction = ParameterDirection.Input;
                            sqlCommand5A.Parameters.Add(Sent);

                            db.DoUpdateUsingCmdObj(sqlCommand5A);

                            //If soap passes, if users answers yes to question
                            if (test == true)
                            {

                                if (rbAnswer.Text == "Yes")
                                {
                              
                                        //Adds values to class object
                                        newUsers.UserGoals = ddlGoals.SelectedValue;
                                        newUsers.amountOfDays = ddlDays.SelectedValue;
                                        newUsers.userTrainingType = ddlTraining.SelectedValue;


                                        //Gets most recent userID
                                        SqlCommand sqlCommand4 = new SqlCommand();


                                        sqlCommand4.CommandType = CommandType.StoredProcedure;
                                        sqlCommand4.CommandText = "TP_UserIdFromUsersCreateAccountPage";

                                        SqlParameter email = new SqlParameter("@EmailAddress", newUsers.EmailAddress);
                                        email.Direction = ParameterDirection.Input;
                                        sqlCommand4.Parameters.Add(email);


                                        DataSet ds3 = db.GetDataSetUsingCmdObj(sqlCommand4);

                                        int userID = Convert.ToInt32(ds3.Tables[0].Rows[0]["UserID"]);

                                        //Adds questions to user
                                        SqlCommand sqlCommand2 = new SqlCommand();


                                        sqlCommand2.CommandType = CommandType.StoredProcedure;
                                        sqlCommand2.CommandText = "TP_UpdateUsersQuestions";

                                        SqlParameter Training = new SqlParameter("@Training", newUsers.userTrainingType);
                                        Training.Direction = ParameterDirection.Input;
                                        sqlCommand2.Parameters.Add(Training);


                                        SqlParameter Goals = new SqlParameter("@Goals", newUsers.UserGoals);
                                        Goals.Direction = ParameterDirection.Input;
                                        sqlCommand2.Parameters.Add(Goals);

                                        SqlParameter DaysOfWeek = new SqlParameter("@DaysOfWeek", newUsers.amountOfDays);
                                        DaysOfWeek.Direction = ParameterDirection.Input;
                                        sqlCommand2.Parameters.Add(DaysOfWeek);


                                        SqlParameter UserID = new SqlParameter("@UserID", userID);
                                        UserID.Direction = ParameterDirection.Input;
                                        sqlCommand2.Parameters.Add(UserID);

                                        //Adds questions to user
                                        int ret3 = db.DoUpdateUsingCmdObj(sqlCommand2);

                                    SqlCommand sqlCommand9 = new SqlCommand();


                                    sqlCommand9.CommandType = CommandType.StoredProcedure;
                                    sqlCommand9.CommandText = "TP_UpdateUserAssistance";

                                    SqlParameter Yes = new SqlParameter("@Answer", "Yes");
                                    Yes.Direction = ParameterDirection.Input;
                                    sqlCommand9.Parameters.Add(Yes);

                                    SqlParameter UserID7 = new SqlParameter("@ID", userID);
                                    UserID7.Direction = ParameterDirection.Input;
                                    sqlCommand9.Parameters.Add(UserID7);

                                  int ret2 =  db.DoUpdateUsingCmdObj(sqlCommand9);

                                    sendMessage(newUsers.EmailAddress, newUsers.Code);

                                    Response.Redirect("LogIn.aspx");

                                    
                                }
                                else
                                {
                                    //Gets most recent userID
                                    SqlCommand sqlCommand4 = new SqlCommand();


                                    sqlCommand4.CommandType = CommandType.StoredProcedure;
                                    sqlCommand4.CommandText = "TP_UserIdFromUsersCreateAccountPage";

                                    SqlParameter email = new SqlParameter("@EmailAddress", newUsers.EmailAddress);
                                    email.Direction = ParameterDirection.Input;
                                    sqlCommand4.Parameters.Add(email);


                                    DataSet ds3 = db.GetDataSetUsingCmdObj(sqlCommand4);

                                    int userID = Convert.ToInt32(ds3.Tables[0].Rows[0]["UserID"]);

                                    SqlCommand sqlCommand9A = new SqlCommand();


                                    sqlCommand9A.CommandType = CommandType.StoredProcedure;
                                    sqlCommand9A.CommandText = "TP_UpdateUserAssistance";

                                    SqlParameter No = new SqlParameter("@Answer", "No");
                                    No.Direction = ParameterDirection.Input;
                                    sqlCommand9A.Parameters.Add(No);

                                    SqlParameter UserID7 = new SqlParameter("@ID", userID);
                                    UserID7.Direction = ParameterDirection.Input;
                                    sqlCommand9A.Parameters.Add(UserID7);


                                    db.DoUpdateUsingCmdObj(sqlCommand9A);

                                    sendMessage(newUsers.EmailAddress, newUsers.Code);

                                    Response.Redirect("LogIn.aspx");
                                }

                            }
                            else
                            {
                                Response.Write("<script>alert('There has been an error. Please try again.') </script>");
                            }


                        }
                        else
                        {
                            Response.Write("<script>alert('The EmailAddress is already taken! Please Try Again!') </script>");
                        }
                        
                    }
                    else
                    {
                        Response.Write("<script>alert('Please Select Different Security Questions') </script>");
                    }

                    
                }
                else
                {
                    lblPassError.Visible = true;
                    lblPassError1.Visible = true;
                    lblPassword.Visible = false;
                    lblPassword1.Visible = false;

                }
                
            }
            else
            {
                Response.Write("<script>alert('Every Field Is Needed To Make An Account Dummy!') </script>");
            }

            
        }
        protected void btnBackToSign_Click(object sender, EventArgs e)
        {
            Response.Redirect("LogIn.aspx");

        }

        protected void ddlImage_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddl;
            ddl = (DropDownList)FindControl("ddlImage");
            string selecteditem = ddl.SelectedValue.ToString();

            if (selecteditem == "Beginner")
            {
                profilePicture.ImageUrl = "../Images2/beginnerStock.png";
            }
            else if (selecteditem == "Intermediate")
            {
                profilePicture.ImageUrl = "../Images2/intermediate.png";
            }
            else if (selecteditem == "Advanced")
            {
                profilePicture.ImageUrl = "../Images2/advanced.png";
            }
        }

        protected void rbAnswer_SelectedIndexChanged(object sender, EventArgs e)
        {
            String moe = rbAnswer.Text;

            if (rbAnswer.Text == "Yes")
            {
                ShowQuestion(true);


            }
            else
            {
                ShowQuestion(false);

            }

        }

        public void ShowQuestion(Boolean boo)
        {
            Questions2.Visible = boo;
            Questions3.Visible = boo;
            Questions5.Visible = boo;

        }

        public void sendMessage(string emailAddress, int num)
        {
                       
            Emails objEmail = new Emails();
            String strTO = emailAddress;
            String strFROM = "tui34800@temple.edu";
            String strSubject = "Moe's Fitness Account Creations";
            String strMessage = "Thank you so much for signing up to Moe's Fitness. Please Verify your account to get access to our wonderful application!" +
                " Here's your verification code: " + num;

            try
            {
                objEmail.SendMail(strTO, strFROM, strSubject, strMessage);
                Response.Write("<script>alert('The email was sent!') </script>");

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('The email couldn't be sent! Please make sure you entered the correct e-mail!') </script>");

            }
            

        }

    }
}