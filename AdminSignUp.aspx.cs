using System;
using System.Collections;
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
    public partial class AdminSignUp : System.Web.UI.Page
    {
        DBConnect db = new DBConnect();
        ArrayList arrayNewUser = new ArrayList();
        FitnessService.FitnessSoap pxy = new FitnessService.FitnessSoap();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["UserID"] == null)
                {
                    navBar.Visible = false;
                    contentID.Visible = false;
                    youShallNotPass.Visible = true;
                }
                else
                {
                    navBar.Visible = true;
                    contentID.Visible = true;
                    youShallNotPass.Visible = false;
                }

             }
    }

        protected void btnCreate_Click1(object sender, EventArgs e)
        {
            //Gets values and passes it to variables 
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

            //Validation checks
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

            for (int i = 0; i < CheckList.Count; i++)
            {
                if (CheckList[i] != "")
                {
                    check = check + 1;
                }

            }
            //If validation passes, if passwords are accurate
            if (check == 15)
            {
                if (pass == pass2)
                {
                    lblPassError.Visible = false;
                    lblPassError1.Visible = false;
                    lblPassword.Visible = true;
                    lblPassword1.Visible = true;

                    //Checks to see if email exists
                    SqlCommand sqlCommand3 = new SqlCommand();

                    sqlCommand3.CommandType = CommandType.StoredProcedure;
                    sqlCommand3.CommandText = "TP_SelectUserIDEmailCreateUser";

                    SqlParameter EmailAddress = new SqlParameter("@Email", txtNewEmail.Text);
                    EmailAddress.Direction = ParameterDirection.Input;
                    sqlCommand3.Parameters.Add(EmailAddress);

                    DataSet ds = db.GetDataSetUsingCmdObj(sqlCommand3);

                    int size = ds.Tables[0].Rows.Count;

                    //If email doesn't exist
                    if (size == 0)
                    {
                        //Adds all values to a soap object
                        FitnessService.User newUsers = new FitnessService.User();
                        Users user = new Users();
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
                        newUsers.Type = "Admin";
                        newUsers.Experience = ddlImage.SelectedValue;
                        newUsers.UserImage = ddlImage.SelectedValue;
                        newUsers.DateCreated = DateTime.Now.ToString();
                        user.BinaryPassword = txtPassword.Text;
                        user.BinaryAddress = txtBillingAddress.Text;
                        arrayNewUser.Add(newUsers);

                        //Executes soap
                        Boolean test = pxy.AddUser(newUsers);

                        //Gets UserID from newly created account
                        SqlCommand sqlCommand3B = new SqlCommand();

                        sqlCommand3B.CommandType = CommandType.StoredProcedure;
                        sqlCommand3B.CommandText = "TP_SelectUserIDEmailCreateUser";

                        SqlParameter EmailAddress1 = new SqlParameter("@Email", txtNewEmail.Text);
                        EmailAddress1.Direction = ParameterDirection.Input;
                        sqlCommand3B.Parameters.Add(EmailAddress1);

                        DataSet ds2 = db.GetDataSetUsingCmdObj(sqlCommand3B);

                        //Assigns UserID value to int variable
                        int userId = Convert.ToInt32(ds2.Tables[0].Rows[0]["UserID"]);

                        //Serializes object containing password and address
                        BinaryFormatter serializer = new BinaryFormatter();
                        MemoryStream memStream = new MemoryStream();
                        Byte[] byteArray;

                        serializer.Serialize(memStream, user);
                        byteArray = memStream.ToArray();

                        //Inserts serialized object to database
                        SqlCommand sqlCommand3A = new SqlCommand();

                        sqlCommand3A.CommandType = CommandType.StoredProcedure;
                        sqlCommand3A.CommandText = "TP_UpdateUsersCreateBinary";

                        SqlParameter ID = new SqlParameter("@ID", userId);
                        ID.Direction = ParameterDirection.Input;
                        sqlCommand3A.Parameters.Add(ID);

                        SqlParameter objectBinary = new SqlParameter("@BinaryObject", byteArray);
                        objectBinary.Direction = ParameterDirection.Input;
                        sqlCommand3A.Parameters.Add(objectBinary);

                        db.DoUpdateUsingCmdObj(sqlCommand3A);

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

                        Response.Redirect("LogIn.aspx");

                    }

                    else
                    {
                        Response.Write("<script>alert('The EmailAddress is already taken! Please Try Again!') </script>");
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
            //Session["UserID"] = null;
            Response.Redirect("AdminPage.aspx");

        }



        protected void ddlImage_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddl;
            ddl = (DropDownList)FindControl("ddlImage");
            string selecteditem = ddl.SelectedValue.ToString();

            if (selecteditem == "Admin1")
            {
                profilePicture.ImageUrl = "../Images2/Admin1.png";
            }
            else if (selecteditem == "Admin2")
            {
                profilePicture.ImageUrl = "../Images2/Admin2.png";
            }
            else if (selecteditem == "Admin3")
            {
                profilePicture.ImageUrl = "../Images2/Admin3.png";
            }
        }

    }
}