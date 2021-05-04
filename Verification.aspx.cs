using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilities;

namespace Term_Project
{
    public partial class Verification : System.Web.UI.Page
    {
        DBConnect db = new DBConnect();
 
        string email;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtEmail.Text = "";
                txtVerification.Text = "";
                btnHtmlContinue.Visible = false;
            }
        }

        protected void btnContinue_Click(object sender, EventArgs e)
        {

             email = txtEmail.Text;

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

                    hdn.Value = txtEmail.Text;
                    btnBackToHome2.Visible = false;
                    btnBack.Visible = true;
                    btnContinue.Visible = false;
                   // btnSignIn.Visible = true;
                    lblinputEmailError.Visible = false;

                    var rand = new Random();
                    lblVerification.Visible = true;
                    txtVerification.Visible = true;
                    lblEmail2.Visible = false;
                    txtEmail.Visible = false;
                    btnHtmlContinue.Visible = true;

                    lblVerification.Text = "What's the verification code?";
                 }
                else
                {
                    Response.Write("<script>alert('Wrong Email Fool')</script>");
                    btnBackToHome2.Visible = true;
                    btnBack.Visible = false;
                    btnContinue.Visible = true;
                   // btnSignIn.Visible = false;
                }
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            btnBackToHome2.Visible = true;
            btnBack.Visible = false;
            lblVerification.Visible = false;
            txtVerification.Visible = false;
            lblEmail2.Visible = true;
            txtEmail.Visible = true;
            btnContinue.Visible = true;
           // btnSignIn.Visible = false;
            txtEmail.Text = "";
            txtVerification.Text = "";
            btnHtmlContinue.Visible = false;
        }

        protected void btnBackToHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("LogIn.aspx");
        }

      /*  protected void btnSignIn_Click(object sender, EventArgs e)
        {

            SqlCommand sqlCommand1 = new SqlCommand();

            sqlCommand1.CommandType = CommandType.StoredProcedure;
            sqlCommand1.CommandText = "TP_SelectVerificationCodeFromUsers";

            string email11 = txtEmail.Text;
            string email111 = email;

            SqlParameter email1 = new SqlParameter("@Email", email11);
            email1.Direction = ParameterDirection.Input;
            sqlCommand1.Parameters.Add(email1);

            DataSet ds1 = db.GetDataSetUsingCmdObj(sqlCommand1);

            int verificationCode = Convert.ToInt32(ds1.Tables[0].Rows[0]["VerificationCode"]);
            int userVerificationCode = Convert.ToInt32(txtVerification.Text);

            if (userVerificationCode == verificationCode)
            {
                SqlCommand sqlCommand2 = new SqlCommand();

                sqlCommand2.CommandType = CommandType.StoredProcedure;
                sqlCommand2.CommandText = "TP_UpdateUsersToYes";

                SqlParameter Yes = new SqlParameter("@Yes", "Yes");
                Yes.Direction = ParameterDirection.Input;
                sqlCommand2.Parameters.Add(Yes);

                db.DoUpdateUsingCmdObj(sqlCommand2);
                Response.Redirect("LogIn.aspx");

            }
            else
            {
                Response.Write("<script>alert('Verification Code is incorrect. Please try again.')</script>");

            }
        }
      */

        private void QuickSignIn()
        {

        }
    }


}