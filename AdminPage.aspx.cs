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

namespace Term_Project
{
    public partial class AdminPage : System.Web.UI.Page
    {
        DBConnect db = new DBConnect();
        FitnessService.FitnessSoap pxy = new FitnessService.FitnessSoap();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                if (Session["UserID"] == null)
                {
                    navBar.Visible = false;
                    ContentID.Visible = false;
                    youShallNotPass.Visible = true;
                    headerContent.Visible = false;
                }
                else
                {
                    navBar.Visible = true;
                    ContentID.Visible = true;
                    youShallNotPass.Visible = false;
                    ShowUsers();
                }
            }
        }


        public void ShowUsers()
        {
            SqlCommand sqlCommand1 = new SqlCommand();
            ArrayList userList = new ArrayList();

            sqlCommand1.CommandType = CommandType.StoredProcedure;
            sqlCommand1.CommandText = "TP_SelectAllFromUsersWhereTypeUser";


            SqlParameter UserType = new SqlParameter("@User", "User");
            UserType.Direction = ParameterDirection.Input;
            sqlCommand1.Parameters.Add(UserType);

            DataSet myData = db.GetDataSetUsingCmdObj(sqlCommand1);

            // String sql = "SELECT * FROM Users WHERE UserType = 'User'";
            //DataSet myData = db.GetDataSet(sql);
            

            int size = myData.Tables[0].Rows.Count;

            if (size > 0)
            {
                for (int i = 0; i < size; i++)
                {
                    userList.Add(pxy.GetAllUsers(myData, i));
                }
                gvManageAccounts.DataSource = userList;
                gvManageAccounts.DataBind();
            }
            else
            {
                Response.Write("<script>alert('No Users Found') </script>");
            }
        }
    }
}