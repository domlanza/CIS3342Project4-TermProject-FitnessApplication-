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
using Term_Project.FitnessService;
using Utilities;
using WorkoutLibrary;

namespace Term_Project
{
    public partial class ForgotPassword : System.Web.UI.Page
    {
        DBConnect db = new DBConnect();
        string question1 = "";
        string question2 = "";
        string question3 = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtEmail.Text = "";
                txtSQ.Text = "";
            }
        }

        protected void btnContinue_Click(object sender, EventArgs e)
        {
           
            string email = txtEmail.Text;

            if (email == "")
            {
                lblinputEmailError.Visible = true;
            }
            else
            {
                SqlCommand objCommand = new SqlCommand();

                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "TP_SelectAllFromUserForgotPassword";

                SqlParameter Email = new SqlParameter("@InputEmail", email);
                Email.Direction = ParameterDirection.Input;
                objCommand.Parameters.Add(Email);

                DataSet mydata = db.GetDataSetUsingCmdObj(objCommand);
                int size = mydata.Tables[0].Rows.Count;

                if (size > 0)
                {


                    btnBackToHome2.Visible = false;
                    btnBack.Visible = true;
                    btnContinue.Visible = false;
                    btnContinue2.Visible = true;
                    lblinputEmailError.Visible = false;

                    var rand = new Random();
                    int num = rand.Next(1,4);
                    lblSQ1.Visible = true;
                    txtSQ.Visible = true;
                    lblEmail2.Visible = false;
                    txtEmail.Visible = false;

                    if (num == 1)
                    {
                        SqlCommand sqlCommand1 = new SqlCommand();

                        sqlCommand1.CommandType = CommandType.StoredProcedure;
                        sqlCommand1.CommandText = "TP_SelectSQ1Randomly";

                        SqlParameter email1 = new SqlParameter("@InputEmail", email);
                        email1.Direction = ParameterDirection.Input;
                        sqlCommand1.Parameters.Add(email1);

                        DataSet ds1 = db.GetDataSetUsingCmdObj(sqlCommand1);

                        string SQ = ds1.Tables[0].Rows[0]["SecurityQuestion1"].ToString();

                        lblSQ1.Text = SQ;    
                        question1 = lblSQ1.Text;

                    }
                    else if(num == 2)
                    {
                        SqlCommand sqlCommand1 = new SqlCommand();

                        sqlCommand1.CommandType = CommandType.StoredProcedure;
                        sqlCommand1.CommandText = "TP_SelectSQ2Randomly";

                        SqlParameter email1 = new SqlParameter("@InputEmail", email);
                        email1.Direction = ParameterDirection.Input;
                        sqlCommand1.Parameters.Add(email1);

                        DataSet ds1 = db.GetDataSetUsingCmdObj(sqlCommand1);

                        string SQ = ds1.Tables[0].Rows[0]["SecurityQuestion2"].ToString();
 
                        lblSQ1.Text = SQ;

                        question2 = lblSQ1.Text;
                    }
                    else if(num == 3)
                    {
                        SqlCommand sqlCommand1 = new SqlCommand();

                        sqlCommand1.CommandType = CommandType.StoredProcedure;
                        sqlCommand1.CommandText = "TP_SelectSQ3Randomly";

                        SqlParameter email1 = new SqlParameter("@InputEmail", email);
                        email1.Direction = ParameterDirection.Input;
                        sqlCommand1.Parameters.Add(email1);

                        DataSet ds1 = db.GetDataSetUsingCmdObj(sqlCommand1);

                        string SQ = ds1.Tables[0].Rows[0]["SecurityQuestion3"].ToString();

                        lblSQ1.Text = SQ;

                        question3 = lblSQ1.Text;

                    }
                }
                else
                {
                    Response.Write("<script>alert('Wrong Email Fool')</script>");
                    btnBackToHome2.Visible = true;
                    btnBack.Visible = false;
                    btnContinue.Visible = true;
                    btnContinue2.Visible = false;
                }
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            btnBackToHome2.Visible = true;
            btnBack.Visible = false;
            lblSQ1.Visible = false;
            txtSQ.Visible = false;
            lblEmail2.Visible = true;
            txtEmail.Visible = true;
            btnContinue.Visible = true;
            btnContinue2.Visible = false;
            txtEmail.Text = "";
            txtSQ.Text = "";
        }
        protected void btnBackToLogIn_Click(object sender, EventArgs e)
        {
            Response.Redirect("LogIn.aspx");
        }

        protected void btnBack2_Click(object sender, EventArgs e)
        {
            btnBackToHome2.Visible = false;
            btnBack.Visible = true;
            lblSQ1.Visible = true;
            txtSQ.Visible = true;
            lblEmail2.Visible = false;
            txtEmail.Visible = false;
            btnContinue.Visible = false;
            btnContinue2.Visible = true;
            btnBack2.Visible = false;
            btnReset.Visible = false;
            lblPass.Visible = false;
            lblPassError.Visible = false;
            lblReenterPass.Visible = false;
            lblReenterPassError.Visible = false;
            txtPass.Visible = false;
            txtPass2.Visible = false;
        }

        protected void btnBackToHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("LogIn.aspx");
        }

        protected void btnContinue2_Click(object sender, EventArgs e)
        {

            string answer = txtSQ.Text;

            SqlCommand objCommand = new SqlCommand();

            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_SelectSecurityAnswer";

            SqlParameter SQ = new SqlParameter("@SQ", lblSQ1.Text);
            SQ.Direction = ParameterDirection.Input;
            objCommand.Parameters.Add(SQ);

            SqlParameter SA = new SqlParameter("@SA", answer);
            SA.Direction = ParameterDirection.Input;
            objCommand.Parameters.Add(SA);

            DataSet mydata = db.GetDataSetUsingCmdObj(objCommand);
            int size = mydata.Tables[0].Rows.Count;

            if (size > 0)
            {


                btnBackToHome2.Visible = false;
                btnBack.Visible = false;
                btnContinue.Visible = false;
                btnContinue2.Visible = false;
                lblinputEmailError.Visible = false;
                lblSQ1.Visible = false;
                txtSQ.Visible = false;
                lblEmail2.Visible = false;
                txtEmail.Visible = false;
                btnBack2.Visible = true;
                btnReset.Visible = true;
                lblPass.Visible = true;
                lblReenterPass.Visible = true;
                txtPass.Visible = true;
                txtPass2.Visible = true;
                /*
                string Type = db.GetField("Type", 0).ToString();
                if (Type.CompareTo("User") == 0)
                {
                    Session["UserId"] = db.GetField("UserId", 0);
                    Session["FirstName"] = db.GetField("FirstName", 0);
                    Session["LastName"] = db.GetField("LastName", 0);
                    Session["EmailAddress"] = db.GetField("EmailAddress", 0);
                    Session["DateCreated"] = db.GetField("DateCreated", 0);
                    Session["UserImage"] = db.GetField("UserImage", 0);
                    Session["Experience"] = db.GetField("Experience", 0);
                    Session["Type"] = db.GetField("Type", 0);
                    Session["Password"] = db.GetField("Password", 0);
                    Session["UserName"] = db.GetField("UserName", 0);
                    Session["BillingAddress"] = db.GetField("BillingAddress", 0);
                    Session["UserWeight"] = db.GetField("UserWeight", 0);
                    Session["UserAge"] = db.GetField("UserAge", 0);
                    Session["UserDays"] = db.GetField("UserDays", 0);
                    Session["UserTraining"] = db.GetField("UserTraining", 0);
                    Session["UserGoals"] = db.GetField("UserGoals", 0);
                    Response.Redirect("HomePage.aspx");

                }
                else
                {
                    Session["UserId"] = db.GetField("UserId", 0);
                    Session["FirstName"] = db.GetField("FirstName", 0);
                    Session["LastName"] = db.GetField("LastName", 0);
                    Session["EmailAddress"] = db.GetField("EmailAddress", 0);
                    Session["DateCreated"] = db.GetField("DateCreated", 0);
                    Session["UserImage"] = db.GetField("UserImage", 0);
                    Session["Experience"] = db.GetField("Experience", 0);
                    Session["Type"] = db.GetField("Type", 0);
                    Session["Password"] = db.GetField("Password", 0);
                    Session["UserName"] = db.GetField("UserName", 0);
                    Session["BillingAddress"] = db.GetField("BillingAddress", 0);
                    Session["UserWeight"] = db.GetField("UserWeight", 0);
                    Session["UserAge"] = db.GetField("UserAge", 0);
                    Session["UserDays"] = db.GetField("UserDays", 0);
                    Session["UserTraining"] = db.GetField("UserTraining", 0);
                    Session["UserGoals"] = db.GetField("UserGoals", 0);
                    Response.Redirect("AdminPage.aspx");
                }
                */
            }
            else
            {
                Response.Write("<script>alert('Wrong Answer Fool')</script>");

            }
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            Boolean passCheck1 = true;
            Boolean passCheck2 = true;
            if(txtPass.Text == "")
            {
                lblPassError.Visible = true;
                passCheck1 = false;
            }
            if(txtPass2.Text == "")
            {
                lblReenterPassError.Visible = true;
                passCheck2 = false;
            }
            if(passCheck1 == true && passCheck2 == true)
            {
                if(txtPass.Text == txtPass2.Text)
                {
                    Users user = new Users();
                    user.BinaryPassword = txtPass.Text;
                    //Serializes an object 
                    BinaryFormatter serializer = new BinaryFormatter();
                    MemoryStream memStream = new MemoryStream();
                    Byte[] byteArray;

                    serializer.Serialize(memStream, user);
                    byteArray = memStream.ToArray();


                    SqlCommand objCommand = new SqlCommand();

                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.CommandText = "TP_InsertIntoUserEncryptedPassword";

                    SqlParameter Password = new SqlParameter("@Password", txtPass.Text);
                    Password.Direction = ParameterDirection.Input;
                    objCommand.Parameters.Add(Password);

                    SqlParameter Email = new SqlParameter("@Email", txtEmail.Text);
                    Email.Direction = ParameterDirection.Input;
                    objCommand.Parameters.Add(Email);

                    SqlParameter binary = new SqlParameter("@Binary", byteArray);
                    binary.Direction = ParameterDirection.Input;
                    objCommand.Parameters.Add(binary);

                    db.DoUpdateUsingCmdObj(objCommand);

                    Response.Redirect("LogIn.aspx");

                }
                else
                {
                    Response.Write("<script>alert('Both Passwords Must Be the Same!')</script>");
                }
            }
        }
    }


}