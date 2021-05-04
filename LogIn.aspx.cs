using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilities;
using WorkoutLibrary;

namespace Term_Project
{
    public partial class LogIn : System.Web.UI.Page
    {
        DBConnect db = new DBConnect();
        private Byte[] key = { 250, 101, 18, 76, 45, 135, 207, 118, 4, 171, 3, 168, 202, 241, 37, 199 };
        private Byte[] vector = { 146, 64, 191, 111, 23, 3, 113, 119, 231, 121, 252, 112, 79, 32, 114, 156 };

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && Request.Cookies["LoginCookie"] != null)

            {
                if (Request.Cookies["LoginCookie"] != null)
                {
                    HttpCookie myCookie = Request.Cookies["LoginCookie"];
                    txtEmail.Text = myCookie.Values["Username"];
                    txtPassword.Text = myCookie.Values["Password"];
                     cbRememberMe.Checked = true;
                }
                else
                {
                    cbRememberMe.Checked = false;

                }
            }
 

        }
        
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text;
            string password = txtPassword.Text;
            if (email == "" && password == "")
            {

                lblinputEmailError.Visible = true;
                lblInputPassError.Visible = true;
            }
            else
            {
                /*
                SqlCommand objCommand = new SqlCommand();

                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "TP_SelectAllFromUsers";

                SqlParameter Email = new SqlParameter("@InputEmail", email);
                Email.Direction = ParameterDirection.Input;
                objCommand.Parameters.Add(Email);

                SqlParameter Password = new SqlParameter("@InputPassword", password);
                Password.Direction = ParameterDirection.Input;
                objCommand.Parameters.Add(Password);
                */

                SqlCommand objCommand = new SqlCommand();

                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "TP_SelectBinaryDataFromUsers";

                SqlParameter Email = new SqlParameter("@Email", email);
                Email.Direction = ParameterDirection.Input;
                objCommand.Parameters.Add(Email);

                DataSet mydata = db.GetDataSetUsingCmdObj(objCommand);
                int size = mydata.Tables[0].Rows.Count;

                if (size > 0)
                {

                    Byte[] byteArray = (Byte[])db.GetField("BinaryObject", 0);

                    BinaryFormatter deSerializer = new BinaryFormatter();

                    MemoryStream memStream = new MemoryStream(byteArray);

                    Users users = (Users)deSerializer.Deserialize(memStream);

                    if (users.BinaryPassword == txtPassword.Text)
                    {

                        string Type = db.GetField("Type", 0).ToString();
                        string Verified = db.GetField("Verified", 0).ToString();
                        String user = txtEmail.Text;
                        String plainTextPassword = txtPassword.Text;

                        if (Verified == "Yes")
                        {
                            if (cbRememberMe.Checked)
                            {
                                CreateCookie(plainTextPassword, user);
                                logIN(Type);
                            }
                            else
                            {
                                EncryptPassword(plainTextPassword, user);
                                HttpCookie myCookie = Request.Cookies["LoginCookie"];
                                logIN(Type);

                            }
                        }
                        else
                        {
                            Response.Write("<script>alert('You must verify your email to get access!')</script>");
                        }
                    }
                    else
                    {
                        Response.Write("<script>alert('Password was incorrect!')</script>");
                    }
                }
                else
                {
                    Response.Write("<script>alert('Wrong Email/Password Fool')</script>");

                }
            }
        }

    


        protected void btnSignUp_Click(object sender, EventArgs e)
        {
            Response.Redirect("SignUp.aspx");

        }

        private void logIN(string Type)
        {
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
                Session["Assistance"] = db.GetField("Assistance", 0);
                Session["ProgramID"] = db.GetField("ProgramID", 0);
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
     }

        private void CreateCookie(string plainTextPassword, string user)
        {
            String encryptedPassword;

            UTF8Encoding encoder = new UTF8Encoding();      // used to convert bytes to characters, and back
            Byte[] textBytes;                               // stores the plain text data as bytes



            // Perform Encryption
            //-------------------
            // Convert a string to a byte array, which will be used in the encryption process.
            textBytes = encoder.GetBytes(plainTextPassword);


            // Create an instances of the encryption algorithm (Rinjdael AES) for the encryption to perform,
            // a memory stream used to store the encrypted data temporarily, and
            // a crypto stream that performs the encryption algorithm.
            RijndaelManaged rmEncryption = new RijndaelManaged();
            MemoryStream myMemoryStream = new MemoryStream();
            CryptoStream myEncryptionStream = new CryptoStream(myMemoryStream, rmEncryption.CreateEncryptor(key, vector), CryptoStreamMode.Write);


            // Use the crypto stream to perform the encryption on the plain text byte array.
            myEncryptionStream.Write(textBytes, 0, textBytes.Length);
            myEncryptionStream.FlushFinalBlock();


            // Retrieve the encrypted data from the memory stream, and write it to a separate byte array.
            myMemoryStream.Position = 0;
            Byte[] encryptedBytes = new Byte[myMemoryStream.Length];
            myMemoryStream.Read(encryptedBytes, 0, encryptedBytes.Length);


            // Close all the streams.
            myEncryptionStream.Close();
            myMemoryStream.Close();

            // Convert the bytes to a string and display it.
            encryptedPassword = Convert.ToBase64String(encryptedBytes);


            // Write encrypted password to a cookie
            HttpCookie myCookie = new HttpCookie("LoginCookie");
            myCookie.Values["Username"] = user;
            myCookie.Values["Password"] = plainTextPassword;
            myCookie.Expires = new DateTime(2025, 2, 1);
            Response.Cookies.Add(myCookie);
        }





        private void EncryptPassword(string plainTextPassword, string user)
        {
            String encryptedPassword;

            UTF8Encoding encoder = new UTF8Encoding();      // used to convert bytes to characters, and back
            Byte[] textBytes;                               // stores the plain text data as bytes



            // Perform Encryption
            //-------------------
            // Convert a string to a byte array, which will be used in the encryption process.
            textBytes = encoder.GetBytes(plainTextPassword);


            // Create an instances of the encryption algorithm (Rinjdael AES) for the encryption to perform,
            // a memory stream used to store the encrypted data temporarily, and
            // a crypto stream that performs the encryption algorithm.
            RijndaelManaged rmEncryption = new RijndaelManaged();
            MemoryStream myMemoryStream = new MemoryStream();
            CryptoStream myEncryptionStream = new CryptoStream(myMemoryStream, rmEncryption.CreateEncryptor(key, vector), CryptoStreamMode.Write);


            // Use the crypto stream to perform the encryption on the plain text byte array.
            myEncryptionStream.Write(textBytes, 0, textBytes.Length);
            myEncryptionStream.FlushFinalBlock();


            // Retrieve the encrypted data from the memory stream, and write it to a separate byte array.
            myMemoryStream.Position = 0;
            Byte[] encryptedBytes = new Byte[myMemoryStream.Length];
            myMemoryStream.Read(encryptedBytes, 0, encryptedBytes.Length);


            // Close all the streams.
            myEncryptionStream.Close();
            myMemoryStream.Close();

            // Convert the bytes to a string and display it.
            encryptedPassword = Convert.ToBase64String(encryptedBytes);


            // Write encrypted password to a cookie
            HttpCookie myCookie = new HttpCookie("LoginCookie");
            myCookie.Values["Username"] = user;
            myCookie.Values["Password"] = encryptedPassword;
            myCookie.Expires = new DateTime(2025, 2, 1);
            Response.Cookies.Add(myCookie);
        }



        //    private void test()
        //    {
        //        // Serialize a Team object into a JSON string.
        //        JavaScriptSerializer js = new JavaScriptSerializer();
        //        String jsonTeam = js.Serialize(theTeam);

        //        try
        //        {

        //            // Setup an HTTP POST Web Request and get the HTTP Web Response from the server.

        //            WebRequest request = WebRequest.Create("https://localhost:44392/MoesFitness/Values/User/");

        //            request.Method = "POST";

        //            request.ContentLength = jsonTeam.Length;

        //            request.ContentType = "application/json";



        //            // Write the JSON data to the Web Request

        //            StreamWriter writer = new StreamWriter(request.GetRequestStream());

        //            writer.Write(jsonTeam);

        //            writer.Flush();

        //            writer.Close();



        //            // Read the data from the Web Response, which requires working with streams.

        //            WebResponse response = request.GetResponse();

        //            Stream theDataStream = response.GetResponseStream();

        //            StreamReader reader = new StreamReader(theDataStream);

        //            String data = reader.ReadToEnd();

        //            reader.Close();

        //            response.Close();



        //            if (data == "true")

        //                lblMessage.Text = "The team was successfully saved to the database.";



        //            else

        //                lblMessage.Text = "The team wasn't saved to the database.";

        //        }

        //        catch (Exception ex)
        //        {
        //        }

        //}


        //    private double ExecuteCallToWebAPI(string operation, double value1, double value2)

        //    {
        //        String url = "https://localhost:44392/MoesFitness/Values/User";

        //        // Create an HTTP Web Request and get the HTTP Web Response from the server.
        //        WebRequest request = WebRequest.Create(url);
        //        WebResponse response = request.GetResponse();

        //        // Read the data from the Web Response, which requires working with streams.
        //        Stream theDataStream = response.GetResponseStream();
        //        StreamReader reader = new StreamReader(theDataStream);
        //        String data = reader.ReadToEnd();
        //        reader.Close();
        //        response.Close();

        //        // Deserialize a JSON string into a double.
        //        JavaScriptSerializer js = new JavaScriptSerializer();
        //        double result = js.Deserialize<double>(data);

        //        return result;

        //    }
    }
}