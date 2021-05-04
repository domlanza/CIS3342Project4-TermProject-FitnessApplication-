using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilities;
using WorkoutLibrary;

namespace Term_Project
{
    public partial class MyProfilePage : System.Web.UI.Page
    {
        DBConnect db = new DBConnect();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["UserID"] == null)
                {
                    youShallNotPass.Visible = true;
                    navBar.Visible = false;
                    divContent.Visible = false;
                }
                else
                {
                    youShallNotPass.Visible = false;
                    lblProfileUserName.Text = "Welcome " + Session["Username"].ToString();

                    lblExperience.Text = "Experience Level: " + Session["Experience"].ToString();

                    lblType.Text = "Type of User: " + Session["Type"].ToString();

                    lblUserWeight.Text = "Your Weight (lbs): " + Session["UserAge"].ToString();

                    lblUserAge.Text = "Your Age: " + Session["UserWeight"].ToString();

                    lblUserGoals.Text = "Your Goals: " + Session["UserGoals"].ToString();

                    userAvatar.ImageUrl = Session["UserImage"].ToString();
                }
            }
           
           
        }

        protected void btnEditProfile_Click(object sender, EventArgs e)
        {
            secondCard.Visible = true;

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

        public void SaveFirstPortion()
        {
            Boolean passCheck1 = true;
            Boolean passCheck2 = true;
            if (txtPassword.Text == "")
            {
                passCheck1 = false;
            }
            if (txtPass2.Text == "")
            {
                passCheck2 = false;
            }
            if (passCheck1 == true && passCheck2 == true)
            {
                if (txtPassword.Text == txtPass2.Text)
                {
                    Users user = new Users();
                    user.BinaryPassword = txtPassword.Text;
                    //Serializes an object 
                    BinaryFormatter serializer = new BinaryFormatter();
                    MemoryStream memStream = new MemoryStream();
                    Byte[] byteArray;

                    serializer.Serialize(memStream, user);
                    byteArray = memStream.ToArray();


                    SqlCommand objCommand = new SqlCommand();

                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.CommandText = "TP_InsertIntoUserEncryptedPassword";

                    SqlParameter Password = new SqlParameter("@Password", txtPassword.Text);
                    Password.Direction = ParameterDirection.Input;
                    objCommand.Parameters.Add(Password);

                    SqlParameter Email = new SqlParameter("@Email", Session["EmailAddress"].ToString());
                    Email.Direction = ParameterDirection.Input;
                    objCommand.Parameters.Add(Email);

                    SqlParameter binary = new SqlParameter("@Binary", byteArray);
                    binary.Direction = ParameterDirection.Input;
                    objCommand.Parameters.Add(binary);

                    db.DoUpdateUsingCmdObj(objCommand);

                    Response.Write("<script>alert('Password has been updated!')</script>");

                }
                else
                {
                    Response.Write("<script>alert('Both Passwords Must Be the Same!')</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Both Passwords Must Be Entered!')</script>");
            }
        }

                protected void btnSaveChanges_Click(object sender, EventArgs e)
        {
            SaveFirstPortion();
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
            btnSaveAll.Visible = boo;
            Questions6.Visible = boo;
            Questions7.Visible = boo;
        }

        protected void btnSaveAll_Click(object sender, EventArgs e)
        {
            SaveSecondPortion();
        }

        public void SaveSecondPortion()
        {

            int UserId = Convert.ToInt32(Session["UserID"]);
            String UserNewGoals = ddlGoals.SelectedValue;
            String UserNewDaysAWeek = ddlDays.SelectedValue;
            String UserNewTypeOfTraining = ddlTraining.SelectedValue;
            int userWeight = Convert.ToInt32(txtWeight.Text);
            int userAge = Convert.ToInt32(txtAge.Text);
            String experience = ddlImage.SelectedValue;
            string newImage = ddlImage.SelectedValue;

            SqlCommand objCommand = new SqlCommand();

            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_UpdateUsersQuestionsAndSettings";

            SqlParameter goals = new SqlParameter("@UserNewGoals", UserNewGoals);
            goals.Direction = ParameterDirection.Input;
            objCommand.Parameters.Add(goals);

            SqlParameter days = new SqlParameter("@UserNewDaysAWeek", UserNewDaysAWeek);
            days.Direction = ParameterDirection.Input;
            objCommand.Parameters.Add(days);

            SqlParameter training = new SqlParameter("@UserNewTypeOfTraining", UserNewTypeOfTraining);
            training.Direction = ParameterDirection.Input;
            objCommand.Parameters.Add(training);

            SqlParameter ID = new SqlParameter("@UserID", UserId);
            ID.Direction = ParameterDirection.Input;
            objCommand.Parameters.Add(ID);

            SqlParameter yes = new SqlParameter("@Yes", "Yes");
            yes.Direction = ParameterDirection.Input;
            objCommand.Parameters.Add(yes);

            SqlParameter Age = new SqlParameter("@Age", userWeight);
            Age.Direction = ParameterDirection.Input;
            objCommand.Parameters.Add(Age);

            SqlParameter Weight = new SqlParameter("@Weight", userAge);
            Weight.Direction = ParameterDirection.Input;
            objCommand.Parameters.Add(Weight);

            SqlParameter Experience = new SqlParameter("@Experience", experience);
            Experience.Direction = ParameterDirection.Input;
            objCommand.Parameters.Add(Experience);

            SqlParameter Image = new SqlParameter("@Image", "Images2/" + newImage + ".png");
            Image.Direction = ParameterDirection.Input;
            objCommand.Parameters.Add(Image);
            int ret = db.DoUpdateUsingCmdObj(objCommand);

            Response.Write("<script>alert('Your preferences have been updated!')</script>");

            Session["Experience"] = experience;


            Session["UserWeight"] = userWeight;

            Session["UserAge"] = userAge;

            Session["UserGoals"] = UserNewGoals;

            Session["UserImage"] = "Images2/" + newImage + ".png";

            Response.Redirect("MyProfilePage.aspx");


        }
    }
}