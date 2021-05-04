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
    public partial class UserMessages : System.Web.UI.Page
    {
        DBConnect db = new DBConnect();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserId"] != null)
            {
                Session["Tags"] = "Inbox";
                showEmail();
                 tbEmail.Visible = false;             
                navBar.Visible = true;
                content.Visible = true;
                youShallNotPass.Visible = false;
            }
            else if (Session["UserID"] == null)
            {
                navBar.Visible = false;
                content.Visible = false;
                youShallNotPass.Visible = true;
                divContent.Visible = false;
            }
        }

        protected void gvEmails_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int row = 0; row < gvEmails.Rows.Count; row++)
            {
                emailContent.Visible = false;
                lblEmpty.Visible = false;
                gvEmails.Visible = false;



                lblCreatedTime2.Text = gvEmails.SelectedRow.Cells[6].Text;
                lblFromEmail.Text = gvEmails.SelectedRow.Cells[2].Text;
                lblToWho.Text = gvEmails.SelectedRow.Cells[3].Text;
                lblSub.Text = gvEmails.SelectedRow.Cells[4].Text;
                lblBodyEmail.Text = gvEmails.SelectedRow.Cells[5].Text;

                tbEmail.Visible = true;


            }
        }

        protected void linkbtnInbox_Click(object sender, EventArgs e)
        {
            folderName.InnerText = "INBOX FOLDER";
            emailContent.Visible = false;
            gvEmails.Visible = true;
            tbEmail.Visible = false;

            Session["Tags"] = "Inbox";
            ViewInbox("Inbox");
        }

        protected void linkbtnSent_Click(object sender, EventArgs e)
        {
            folderName.InnerText = "SENT FOLDER";
            tbEmail.Visible = false;
            emailContent.Visible = false;
            gvEmails.Visible = true;
            Session["Tags"] = "Sent";
            ViewSent("Sent");

        }

        public void ViewSent(String tags)
        {
            String tag = tags;

            SqlCommand sqlCommandA3A = new SqlCommand();


            sqlCommandA3A.CommandType = CommandType.StoredProcedure;
            sqlCommandA3A.CommandText = "TP_SelectTagsIDFromTags";

            SqlParameter UserID = new SqlParameter("@UserID", Session["UserId"]);
            UserID.Direction = ParameterDirection.Input;
            sqlCommandA3A.Parameters.Add(UserID);

            SqlParameter TagName = new SqlParameter("@TagName", tag);
            TagName.Direction = ParameterDirection.Input;
            sqlCommandA3A.Parameters.Add(TagName);

            DataSet ds = db.GetDataSetUsingCmdObj(sqlCommandA3A);

            /*
            String sql = "SELECT TagsId FROM Tags WHERE Tags.UserId = " + Session["UserId"].ToString() + " AND Tags.TagName = '" + tag + "'";
            DataSet ds = db.GetDataSet(sql);
            */
            String tag1 = ds.Tables[0].Rows[0]["TagID"].ToString();

            SqlCommand sqlCommandA4A = new SqlCommand();

            sqlCommandA4A.CommandType = CommandType.StoredProcedure;
            sqlCommandA4A.CommandText = "TP_AllFromEmailandEmailReceipt";

            SqlParameter UserID2 = new SqlParameter("@UserID", Session["UserId"]);
            UserID2.Direction = ParameterDirection.Input;
            sqlCommandA4A.Parameters.Add(UserID2);

            SqlParameter TagName2 = new SqlParameter("@Tag", tag1);
            TagName2.Direction = ParameterDirection.Input;
            sqlCommandA4A.Parameters.Add(TagName2);

            DataSet ds1 = db.GetDataSetUsingCmdObj(sqlCommandA4A);

            /*
            String sql1 = "SELECT SenderID, Subject, EmailBody, SentTime FROM Email, EmailReceipt WHERE EmailReceipt.UserId = " + Session["UserId"].ToString() +
                " AND EmailReceipt.EmailTag = " + tag1 + " AND Email.EmailID = EmailReceipt.EmailId AND Email.SenderID = " + Session["UserId"].ToString();

            DataSet ds1 = db.GetDataSet(sql1);
           */
            int size = ds1.Tables[0].Rows.Count;

            if (size > 0)
            {
                ArrayList listEmails = new ArrayList();

                for (int i = 0; i < size; i++)
                {

                    String senderID = ds1.Tables[0].Rows[i]["SenderID"].ToString();
                    String receiverID = ds1.Tables[0].Rows[i]["ReceiverID"].ToString();

                    SqlCommand sqlCommand2A = new SqlCommand();

                    sqlCommand2A.CommandType = CommandType.StoredProcedure;
                    sqlCommand2A.CommandText = "TP_SelectUserNameEmailFromUsersEmail";

                    SqlParameter SenderID = new SqlParameter("@SenderID", senderID);
                    SenderID.Direction = ParameterDirection.Input;
                    sqlCommand2A.Parameters.Add(SenderID);
                    DataSet ds2 = db.GetDataSetUsingCmdObj(sqlCommand2A);

                    SqlCommand sqlCommand2AA = new SqlCommand();

                    sqlCommand2AA.CommandType = CommandType.StoredProcedure;
                    sqlCommand2AA.CommandText = "TP_SelectUserNameEmailFromUsersEmail";

                    SqlParameter receiverID2 = new SqlParameter("@SenderID", receiverID);
                    receiverID2.Direction = ParameterDirection.Input;
                    sqlCommand2AA.Parameters.Add(receiverID2);
                    DataSet DS1 = db.GetDataSetUsingCmdObj(sqlCommand2AA);

                    /*
                    String sql2 = "SELECT UserName, CreateEmailAddress FROM Users WHERE Users.UserId = " + senderID + " ";
                    DataSet ds2 = db.GetDataSet(sql2);
                    */
                    Email newEmail = new Email();
                    newEmail.sender = ds2.Tables[0].Rows[0]["UserName"].ToString();
                    newEmail.receiver = DS1.Tables[0].Rows[0]["UserName"].ToString();
                    newEmail.emailSubject = ds1.Tables[0].Rows[i]["Subject"].ToString();
                    newEmail.emailBody = ds1.Tables[0].Rows[i]["Body"].ToString();
                    newEmail.time = DateTime.Parse(ds1.Tables[0].Rows[i]["SentTime"].ToString()).ToString();

                    listEmails.Add(newEmail);
                }
                gvEmails.Columns[0].Visible = false;
                gvEmails.DataSource = listEmails;
                gvEmails.DataBind();

                gvEmails.Visible = true;
                lblEmpty.Visible = false;
            }
            else
            {
                lblEmpty.Text = "Your " + tag + " Folder Is Empty";
                gvEmails.Visible = false;
                lblEmpty.Visible = true;
                emailContent.Visible = false;
                //  ddlDropDown.Visible = false;
            }
        }

        protected void btnCompose_Click(object sender, EventArgs e)
        {
            emailContent.Visible = true;
            lblEmpty.Visible = false;
            gvEmails.Visible = false;
            tbEmail.Visible = false;
            // ddlDropDown.Visible = false;
        }

        protected void btnBack2_Click(object sender, EventArgs e)
        {
            tbEmail.Visible = false;
            emailContent.Visible = false;
            lblEmpty.Visible = false;
            gvEmails.Visible = true;
            // Response.Redirect("EmailClient.aspx");

        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            tbEmail.Visible = false;
            emailContent.Visible = false;
            lblEmpty.Visible = false;
            gvEmails.Visible = true;

            //txtEmailTo.Text = "";
            txtSubject.Text = "";
            txtContent.Text = "";
            //Response.Redirect("EmailClient.aspx");

        }
        public void ViewInbox(String tags)
        {

            String tag = tags;
            int user = Convert.ToInt32(Session["UserId"]);

            SqlCommand sqlCommandA3A = new SqlCommand();

            sqlCommandA3A.CommandType = CommandType.StoredProcedure;
            sqlCommandA3A.CommandText = "TP_SelectTagsIDFromTags";

            SqlParameter UserID = new SqlParameter("@UserID", user);
            UserID.Direction = ParameterDirection.Input;
            sqlCommandA3A.Parameters.Add(UserID);

            SqlParameter TagName = new SqlParameter("@TagName", tag);
            TagName.Direction = ParameterDirection.Input;
            sqlCommandA3A.Parameters.Add(TagName);

            DataSet ds = db.GetDataSetUsingCmdObj(sqlCommandA3A);

            /*
            String sql = "SELECT TagsId FROM Tags WHERE Tags.UserId = " + Session["UserId"].ToString() + " AND Tags.TagName = '" + tag + "'";
            DataSet ds = db.GetDataSet(sql);
            */
            String tag1 = ds.Tables[0].Rows[0]["TagID"].ToString();

            SqlCommand sqlCommand5A = new SqlCommand();

            sqlCommand5A.CommandType = CommandType.StoredProcedure;
            sqlCommand5A.CommandText = "TP_SelectAllFromEmailsTableEmail";

            SqlParameter UserID2 = new SqlParameter("@UserID", Session["UserId"]);
            UserID2.Direction = ParameterDirection.Input;
            sqlCommand5A.Parameters.Add(UserID2);

            SqlParameter TagName2 = new SqlParameter("@Tag", tag1);
            TagName2.Direction = ParameterDirection.Input;
            sqlCommand5A.Parameters.Add(TagName2);

            DataSet ds1 = db.GetDataSetUsingCmdObj(sqlCommand5A);

            /*
            String sql1 = "SELECT SenderID, Subject, EmailBody, SentTime FROM Email, EmailReceipt WHERE EmailReceipt.UserId = " + Session["UserId"].ToString() +
                " AND EmailReceipt.EmailTag = " + tag1 + " AND Email.EmailID = EmailReceipt.EmailId AND Email.ReceiverId = " + Session["UserId"].ToString();

            DataSet ds1 = db.GetDataSet(sql1);
            */
            int size = ds1.Tables[0].Rows.Count;

            if (size > 0)
            {
                ArrayList listEmails = new ArrayList();

                for (int i = 0; i < size; i++)
                {
                    String senderID = ds1.Tables[0].Rows[i]["SenderID"].ToString();

                    SqlCommand sqlCommand6A = new SqlCommand();


                    sqlCommand6A.CommandType = CommandType.StoredProcedure;
                    sqlCommand6A.CommandText = "TP_SelectUserNameEmailFromUsersEmail";

                    SqlParameter SenderID = new SqlParameter("@SenderID", senderID);
                    SenderID.Direction = ParameterDirection.Input;
                    sqlCommand6A.Parameters.Add(SenderID);
                    DataSet ds2 = db.GetDataSetUsingCmdObj(sqlCommand6A);


                    SqlCommand sqlCommand7A = new SqlCommand();


                    sqlCommand7A.CommandType = CommandType.StoredProcedure;
                    sqlCommand7A.CommandText = "TP_SelectUserNameEmailFromUsersEmail";

                    SqlParameter UserID1 = new SqlParameter("@SenderID", Session["UserId"]);
                    UserID1.Direction = ParameterDirection.Input;
                    sqlCommand7A.Parameters.Add(UserID1);
                    DataSet ds3 = db.GetDataSetUsingCmdObj(sqlCommand7A);
                    /*

                    String sql2 = "SELECT UserName, CreateEmailAddress FROM Users WHERE Users.UserId = " + senderID + " ";
                    DataSet ds2 = db.GetDataSet(sql2);
                    */
                    Email newEmail = new Email();
                    newEmail.sender = ds2.Tables[0].Rows[0]["UserName"].ToString();
                    newEmail.receiver = ds3.Tables[0].Rows[0]["UserName"].ToString();
                    newEmail.emailSubject = ds1.Tables[0].Rows[i]["Subject"].ToString();
                    newEmail.emailBody = ds1.Tables[0].Rows[i]["Body"].ToString();
                    newEmail.time = DateTime.Parse(ds1.Tables[0].Rows[i]["SentTime"].ToString()).ToString();

                    listEmails.Add(newEmail);
                }

                gvEmails.Columns[0].Visible = true;
                gvEmails.DataSource = listEmails;
                gvEmails.DataBind();
                gvEmails.Visible = true;
                lblEmpty.Visible = false;
            }
            else
            {
                lblEmpty.Text = "Your " + tag + " Folder Is Empty";
                gvEmails.Visible = false;
                lblEmpty.Visible = true;
                emailContent.Visible = false;
            }

        }

        public void showEmail()
        {

            SqlCommand sqlCommand9 = new SqlCommand();


            sqlCommand9.CommandType = CommandType.StoredProcedure;
            sqlCommand9.CommandText = "TP_SelectTagsIDFromTags";

            SqlParameter UserID = new SqlParameter("@UserID", Session["UserId"]);
            UserID.Direction = ParameterDirection.Input;
            sqlCommand9.Parameters.Add(UserID);

            SqlParameter TagName = new SqlParameter("@TagName", "Inbox");
            TagName.Direction = ParameterDirection.Input;
            sqlCommand9.Parameters.Add(TagName);

            DataSet ds = db.GetDataSetUsingCmdObj(sqlCommand9);

            /*
            String sql = "SELECT TagsId FROM Tags WHERE Tags.UserId = " + Session["UserId"].ToString() + " AND Tags.TagName = 'Inbox'";
            DataSet ds = db.GetDataSet(sql);
            */

            int tag = (int)ds.Tables[0].Rows[0]["TagID"];

            string m = Session["UserImage"].ToString();
            userAvatar.ImageUrl = Session["UserImage"].ToString();


            //userLabel.Text = Session["UserName"].ToString();

            SqlCommand sqlCommand1A = new SqlCommand();

            sqlCommand1A.CommandType = CommandType.StoredProcedure;
            sqlCommand1A.CommandText = "TP_SelectAllFromEmailsTableEmail";

            SqlParameter UserID2 = new SqlParameter("@UserID", Session["UserId"]);
            UserID2.Direction = ParameterDirection.Input;
            sqlCommand1A.Parameters.Add(UserID2);

            SqlParameter TagName2 = new SqlParameter("@Tag", tag);
            TagName2.Direction = ParameterDirection.Input;
            sqlCommand1A.Parameters.Add(TagName2);

            /*
            String sql1 = "SELECT SenderID, Subject, EmailBody, SentTime FROM Email, EmailReceipt WHERE EmailReceipt.UserID = " + Session["UserId"].ToString() +
                " AND EmailReceipt.EmailTag = " + tag + " AND Email.EmailID = EmailReceipt.EmailID AND Email.ReceiverID = " + Session["UserId"].ToString();
            */

            DataSet ds1 = db.GetDataSetUsingCmdObj(sqlCommand1A);
            int size = ds1.Tables[0].Rows.Count;

            if (size > 0)
            {
                ArrayList listEmails = new ArrayList();

                for (int i = 0; i < size; i++)
                {
                    String senderID = ds1.Tables[0].Rows[i]["SenderId"].ToString();
                    SqlCommand sqlCommand2A = new SqlCommand();


                    sqlCommand2A.CommandType = CommandType.StoredProcedure;
                    sqlCommand2A.CommandText = "TP_SelectUserNameEmailFromUsersEmail";

                    SqlParameter SenderID = new SqlParameter("@SenderID", senderID);
                    SenderID.Direction = ParameterDirection.Input;
                    sqlCommand2A.Parameters.Add(SenderID);
                    DataSet ds2 = db.GetDataSetUsingCmdObj(sqlCommand2A);

                    SqlCommand sqlCommand7A = new SqlCommand();


                    sqlCommand7A.CommandType = CommandType.StoredProcedure;
                    sqlCommand7A.CommandText = "TP_SelectUserNameEmailFromUsersEmail";

                    SqlParameter UserID1 = new SqlParameter("@SenderID", Session["UserId"]);
                    UserID1.Direction = ParameterDirection.Input;
                    sqlCommand7A.Parameters.Add(UserID1);
                    DataSet ds3 = db.GetDataSetUsingCmdObj(sqlCommand7A);

                    /*
                    String sql2 = "SELECT UserName, CreateEmailAddress FROM Users WHERE Users.UserId = " + senderID + " ";
                    DataSet ds2 = db.GetDataSet(sql2);
                    */

                    Email newEmail = new Email();
                    newEmail.sender = ds2.Tables[0].Rows[0]["UserName"].ToString();
                    newEmail.receiver = ds3.Tables[0].Rows[0]["UserName"].ToString();
                    newEmail.emailSubject = ds1.Tables[0].Rows[i]["Subject"].ToString();
                    newEmail.emailBody = ds1.Tables[0].Rows[i]["Body"].ToString();
                    newEmail.time = DateTime.Parse(ds1.Tables[0].Rows[i]["SentTime"].ToString()).ToString();

                    listEmails.Add(newEmail);
                }
                gvEmails.Columns[0].Visible = true;
                gvEmails.DataSource = listEmails;
                gvEmails.DataBind();

                gvEmails.Visible = true;
                lblEmpty.Visible = false;
            }
            else
            {
                lblEmpty.Text = "Your Inbox Folder Is Empty";
                gvEmails.Visible = false;
                lblEmpty.Visible = true;
                //ddlDropDown.Visible = false;

            }
        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            Email newEmail = new Email();
            //string To = txtEmailTo.Text;
            string Subject = txtSubject.Text;
            string Body = txtContent.Text;
            string Time = DateTime.Now.ToString("MM-dd-yyyy HH:mm:ss");
            Boolean check = true;
            Boolean check2 = true;
            Boolean check3 = true;


            newEmail.sender = Session["UserId"].ToString();
            newEmail.emailSubject = Subject;
            newEmail.emailBody = Body;
            newEmail.time = Time;

            //SqlCommand sqlCommandM = new SqlCommand();

            //sqlCommandM.CommandType = CommandType.StoredProcedure;
            //sqlCommandM.CommandText = "TP_SelectUserIDEmailCreateUser";

            //SqlParameter EmailAddress = new SqlParameter("@Email", To);
            //EmailAddress.Direction = ParameterDirection.Input;
            //sqlCommandM.Parameters.Add(EmailAddress);

            //DataSet DS1 = db.GetDataSetUsingCmdObj(sqlCommandM);

            //int size = DS1.Tables[0].Rows.Count;

            if (Subject == "")
            {
                check2 = false;
            }
            else
            {
                check2 = true;
            }
            if (Body == "")
            {
                check3 = false;
            }
            else
            {
                check3 = true;
            }

            if (check == true && check2 == true && check3 == true)
            {

                //if (size > 0)
                //{
                //    /*Get ReceiverID
                     
                    SqlCommand sqlCommand3A = new SqlCommand();

                    sqlCommand3A.CommandType = CommandType.StoredProcedure;
                    sqlCommand3A.CommandText = "TP_SelectRandomAdmin";

                    SqlParameter SendTo = new SqlParameter("@Type", "Admin");
                    SendTo.Direction = ParameterDirection.Input;
                    sqlCommand3A.Parameters.Add(SendTo);

                    DataSet ds = db.GetDataSetUsingCmdObj(sqlCommand3A);
                    /*
                    String sql = "SELECT UserId FROM Users WHERE CreateEmailAddress = '" + To + "'";
                    DataSet ds = db.GetDataSet(sql);
                    */

                    String user = ds.Tables[0].Rows[0]["UserID"].ToString();

                    /*Assign ReceiverId to Class
                     */
                    newEmail.receiver = user;


                    /*Run SQL To add to Email Table
                     */

                    SqlCommand sqlCommand4A = new SqlCommand();

                    sqlCommand4A.CommandType = CommandType.StoredProcedure;
                    sqlCommand4A.CommandText = "TP_InsertEmailEverythingMEMAILASPX";

                    SqlParameter SenderName = new SqlParameter("@SenderName", newEmail.sender);
                    SenderName.Direction = ParameterDirection.Input;
                    sqlCommand4A.Parameters.Add(SenderName);


                    SqlParameter ReceiverName = new SqlParameter("@ReceiverName", newEmail.receiver);
                    ReceiverName.Direction = ParameterDirection.Input;
                    sqlCommand4A.Parameters.Add(ReceiverName);

                    SqlParameter Subject1 = new SqlParameter("@Subject", newEmail.emailSubject);
                    Subject1.Direction = ParameterDirection.Input;
                    sqlCommand4A.Parameters.Add(Subject1);

                    SqlParameter EmailBody = new SqlParameter("@EmailBody", newEmail.emailBody);
                    EmailBody.Direction = ParameterDirection.Input;
                    sqlCommand4A.Parameters.Add(EmailBody);

                    SqlParameter Time1 = new SqlParameter("@CreatedTime", newEmail.time);
                    Time1.Direction = ParameterDirection.Input;
                    sqlCommand4A.Parameters.Add(Time1);


                    db.DoUpdateUsingCmdObj(sqlCommand4A);
                    // DataSet DS1 = db.DoUpdateUsingCmdObj(sqlCommand4A);

                    /*
                    String sql1 = "INSERT INTO Email(SenderID, ReceiverID, Subject, EmailBody, SentTime) VALUES (" + newEmail.senderName + ", " + newEmail.recieverName +
                        ", '" + newEmail.subject + "', '" + newEmail.emailBody + "', '" + newEmail.createdTime + "')";
                    db.DoUpdate(sql1);
                    */

                    /*Get EmailId          [SelectEmailIDFromEmail]
                     */
                    //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------//
                    SqlCommand sqlCommand5A = new SqlCommand();

                    sqlCommand5A.CommandType = CommandType.StoredProcedure;
                    sqlCommand5A.CommandText = "TP_SelectEmailIDFromEmail";

                    SqlParameter recieverName = new SqlParameter("@ReceiverName", newEmail.receiver);
                    recieverName.Direction = ParameterDirection.Input;
                    sqlCommand5A.Parameters.Add(recieverName);

                    SqlParameter Body1 = new SqlParameter("@Body", newEmail.emailBody);
                    Body1.Direction = ParameterDirection.Input;
                    sqlCommand5A.Parameters.Add(Body1);

                    SqlParameter Subject2 = new SqlParameter("@Subject", newEmail.emailSubject);
                    Subject2.Direction = ParameterDirection.Input;
                    sqlCommand5A.Parameters.Add(Subject2);

                    SqlParameter Time2 = new SqlParameter("@Time", newEmail.time);
                    Time2.Direction = ParameterDirection.Input;
                    sqlCommand5A.Parameters.Add(Time2);

                    /*
                    String sql2 = "SELECT EmailID FROM Email WHERE ReceiverID = '" + newEmail.recieverName + "'";
                    */
                    DataSet ds1 = db.GetDataSetUsingCmdObj(sqlCommand5A);
                    int user1 = Convert.ToInt32(ds1.Tables[0].Rows[0]["EmailID"]);
                    //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------//


                    SqlCommand sqlCommand6A = new SqlCommand();

                    sqlCommand6A.CommandType = CommandType.StoredProcedure;
                    sqlCommand6A.CommandText = "TP_SelectTagsIDFROMTagsEMAIL";

                    SqlParameter recieverName1 = new SqlParameter("@ReceiverName", newEmail.receiver);
                    recieverName1.Direction = ParameterDirection.Input;
                    sqlCommand6A.Parameters.Add(recieverName1);
                    // String sql5 = "SELECT TagsId FROM Tags WHERE UserId = '" + newEmail.recieverName + "'";

                    DataSet ds2 = db.GetDataSetUsingCmdObj(sqlCommand6A);
                    int tagId = Convert.ToInt32(ds2.Tables[0].Rows[0]["TagID"]);

                    //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------//
                    /*Run SQL To add to EmailReceipt Table
                     */

                    //String sql3 = "INSERT INTO EmailReceipt(UserId, EmailId, EmailTag, Flag) VALUES (" + Convert.ToInt32(newEmail.recieverName) + ", " + user1 +
                    //  ", " + tagId + ", '" + flag + "')";

                    SqlCommand sqlCommand7A = new SqlCommand();

                    sqlCommand7A.CommandType = CommandType.StoredProcedure;
                    sqlCommand7A.CommandText = "TP_InsertEverythingIntoReceipt";

                    SqlParameter ReceiverName2 = new SqlParameter("@ReceiverName", Convert.ToInt32(newEmail.receiver));
                    ReceiverName2.Direction = ParameterDirection.Input;
                    sqlCommand7A.Parameters.Add(ReceiverName2);

                    SqlParameter EmailID2 = new SqlParameter("@EmailID", user1);
                    EmailID2.Direction = ParameterDirection.Input;
                    sqlCommand7A.Parameters.Add(EmailID2);

                    SqlParameter TagID2 = new SqlParameter("@TagID", tagId);
                    TagID2.Direction = ParameterDirection.Input;
                    sqlCommand7A.Parameters.Add(TagID2);
                    db.DoUpdateUsingCmdObj(sqlCommand7A);

                    //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------//

                    //String sql6 = "INSERT INTO Email (SenderID, ReceiverID, Subject, EmailBody, SentTime) VALUES ("
                    //    + newEmail.senderName + ", " + newEmail.recieverName + ", '" + newEmail.subject +
                    //    "', '" + newEmail.emailBody + "', '" + newEmail.createdTime + "')";
                    /*
                    SqlCommand sqlCommand8A = new SqlCommand();

                    sqlCommand8A.CommandType = CommandType.StoredProcedure;
                    sqlCommand8A.CommandText = "InsertIntoEmailEverything";

                    SqlParameter SenderID = new SqlParameter("@SenderId", newEmail.senderName);
                    SenderID.Direction = ParameterDirection.Input;
                    sqlCommand8A.Parameters.Add(SenderID);

                    SqlParameter ReceiverID3 = new SqlParameter("@ReceiverID", newEmail.recieverName);
                    ReceiverID3.Direction = ParameterDirection.Input;
                    sqlCommand8A.Parameters.Add(ReceiverID3);

                    SqlParameter Subject2 = new SqlParameter("@Subject", newEmail.subject);
                    Subject2.Direction = ParameterDirection.Input;
                    sqlCommand8A.Parameters.Add(Subject2);

                    SqlParameter EmailBody1 = new SqlParameter("@EmailBody", newEmail.emailBody);
                    EmailBody1.Direction = ParameterDirection.Input;
                    sqlCommand8A.Parameters.Add(EmailBody1);

                    SqlParameter Time2 = new SqlParameter("@CreatedTime", newEmail.createdTime);
                    Time2.Direction = ParameterDirection.Input;
                    sqlCommand8A.Parameters.Add(Time2);

                    db.DoUpdateUsingCmdObj(sqlCommand8A);
                    */
                    //db.DoUpdate(sql6);

                    //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------//

                    //String sql7 = "SELECT EmailID FROM Email WHERE ReceiverID = '" + newEmail.recieverName + "'";
                    SqlCommand sqlCommand9A = new SqlCommand();

                    sqlCommand9A.CommandType = CommandType.StoredProcedure;
                    sqlCommand9A.CommandText = "TP_SelectEmailIDFromEmail";

                    SqlParameter ReceiverName4 = new SqlParameter("@ReceiverName", newEmail.receiver);
                    ReceiverName4.Direction = ParameterDirection.Input;
                    sqlCommand9A.Parameters.Add(ReceiverName4);

                    SqlParameter Body2 = new SqlParameter("@Body", newEmail.emailBody);
                    Body2.Direction = ParameterDirection.Input;
                    sqlCommand9A.Parameters.Add(Body2);

                    SqlParameter Subject3 = new SqlParameter("@Subject", newEmail.emailSubject);
                    Subject3.Direction = ParameterDirection.Input;
                    sqlCommand9A.Parameters.Add(Subject3);

                    SqlParameter Time3 = new SqlParameter("@Time", newEmail.time);
                    Time3.Direction = ParameterDirection.Input;
                    sqlCommand9A.Parameters.Add(Time3);

                    DataSet data3 = db.GetDataSetUsingCmdObj(sqlCommand9A);
                    int nameReceiver2 = Convert.ToInt32(data3.Tables[0].Rows[0]["EmailID"]);
                    //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------//

                    String sentTag = "Sent";

                    SqlCommand sqlCommand10A = new SqlCommand();

                    sqlCommand10A.CommandType = CommandType.StoredProcedure;
                    sqlCommand10A.CommandText = "TP_SelectTagsIdShowMailEmail";

                    SqlParameter UserId = new SqlParameter("@UserID", Session["UserId"]);
                    UserId.Direction = ParameterDirection.Input;
                    sqlCommand10A.Parameters.Add(UserId);

                    SqlParameter Sent = new SqlParameter("@TagName", sentTag);
                    Sent.Direction = ParameterDirection.Input;
                    sqlCommand10A.Parameters.Add(Sent);

                    //String sql8 = "SELECT TagsId FROM Tags WHERE UserId = " + Session["UserId"] +
                    //    " AND TagName = '" + sentTag + "'";

                    DataSet data4 = db.GetDataSetUsingCmdObj(sqlCommand10A);
                    int tagID = Convert.ToInt32(data4.Tables[0].Rows[0]["TagID"]);
                    //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------//



                    SqlCommand sqlCommand11A = new SqlCommand();

                    sqlCommand11A.CommandType = CommandType.StoredProcedure;
                    sqlCommand11A.CommandText = "TP_InsertEverythingIntoReceipt";

                    SqlParameter ReceiverName3 = new SqlParameter("@ReceiverName", Session["UserId"]);
                    ReceiverName3.Direction = ParameterDirection.Input;
                    sqlCommand11A.Parameters.Add(ReceiverName3);

                    SqlParameter EmailID3 = new SqlParameter("@EmailID", nameReceiver2);
                    EmailID3.Direction = ParameterDirection.Input;
                    sqlCommand11A.Parameters.Add(EmailID3);

                    SqlParameter TagID3 = new SqlParameter("@TagID", tagID);
                    TagID3.Direction = ParameterDirection.Input;
                    sqlCommand11A.Parameters.Add(TagID3);
                    db.DoUpdateUsingCmdObj(sqlCommand11A);

                    //String sql9 = "INSERT INTO EmailReceipt(UserId, EmailId, EmailTag, Flag) VALUES (" + Session["UserId"] + ", "
                    //    + nameReceiver2 + ", " + tagID + ", '" + flag + "')";
                    //db.DoUpdate(sql9);
                    Response.Write("<script>alert('Email Has Been Sent!') </script>");

                   // txtEmailTo.Text = "";
                    txtSubject.Text = "";
                    txtContent.Text = "";

                    showEmail();
                    emailContent.Visible = false;
                //}
                //else
                //{
                //    Response.Write("<script>alert('User Does NOT Exist! Please Try Again!') </script>");
                //}
            }
            else
            {
                Response.Write("<script>alert('Please fill out all the information before sending an email!') </script>");
            }
        }


   
    }
}