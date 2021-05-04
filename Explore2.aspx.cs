using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilities;
using WorkoutLibrary;

namespace Term_Project
{
    public partial class Explore2 : System.Web.UI.Page
    {              
        DBConnect db = new DBConnect();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["UserID"] == null)
                {
                    contentID.Visible = false;
                    youShallNotPass.Visible = true;
                    navBar.Visible = false;
                }
                else
                {
                    //Repeater

                    WebRequest request = WebRequest.Create("https://localhost:44314/api/Fitness/AllPrograms/");
                    WebResponse response = request.GetResponse();

                    // Read the data from the Web Response, which requires working with streams.
                    Stream theDataStream = response.GetResponseStream();
                    StreamReader reader = new StreamReader(theDataStream);
                    String data = reader.ReadToEnd();
                    reader.Close();
                    response.Close();

                    // Deserialize a JSON string that contains an array of JSON objects into an Array of Team objects.
                    JavaScriptSerializer js = new JavaScriptSerializer();
                    List<Program> programList = js.Deserialize<List<Program>>(data);

                    //String strSQL = "Select * FROM TP_Program";
                    lvVisible(false);
                    // Set the datasource of the Repeater and bind the data
                    rptPrograms.DataSource = programList;
                    rptPrograms.DataBind();
                }
            }
        }

        public void ProgramLoad(int programID)
        {
            programDiv.Visible = true;

            //Next use the Program Id and add that to the Repeater
            SqlCommand objCommand1 = new SqlCommand();

            objCommand1.CommandType = CommandType.StoredProcedure;
            objCommand1.CommandText = "TP_SelectAllFromProgramWhereID";

            SqlParameter ProgramID1 = new SqlParameter("@ID", programID);
            ProgramID1.Direction = ParameterDirection.Input;
            objCommand1.Parameters.Add(ProgramID1);

            Repeater1.DataSource = db.GetDataSetUsingCmdObj(objCommand1);
            Repeater1.DataBind();


         
        }


        protected void rptPrograms_OnItemCommand(object sender, System.Web.UI.WebControls.RepeaterCommandEventArgs e)
        {
            // Retrieve the row index for the item that fired the ItemCommand event
            int rowIndex = e.Item.ItemIndex;

            // Retrieve a value from a control in the Repeater's Items collection
            Label id = (Label)(rptPrograms.Items[rowIndex].FindControl("lblProgramID"));
             int ID = Convert.ToInt32(id.Text);
            Label myLabel = (Label)rptPrograms.Items[rowIndex].FindControl("ProgramID");

            //List View Workout
            // String strSQLForWorkoutDisplay = "SELECT * FROM TP_Workouts Where ProgramID = " + ID;

            lvMonday.DataSource = lvWorkoutDays(ID, "Monday");
            lvMonday.DataBind();

            lvTuesday.DataSource = lvWorkoutDays(ID, "Tuesday");
            lvTuesday.DataBind();

            lvWednesday.DataSource = lvWorkoutDays(ID, "Wednesday");
            lvWednesday.DataBind();

            lvThursday.DataSource = lvWorkoutDays(ID, "Thursday");
            lvThursday.DataBind();

            lvFriday.DataSource = lvWorkoutDays(ID, "Friday");
            lvFriday.DataBind();

            lvSaturday.DataSource = lvWorkoutDays(ID, "Saturday");
            lvSaturday.DataBind();

            lvSunday.DataSource = lvWorkoutDays(ID, "Sunday");
            lvSunday.DataBind();

            ProgramLoad(ID);
        }

        protected void btnDetailView_Click(object sender, EventArgs e)
        {
            rptPrograms.Visible = false;
            //ListViewDisplayWorkout.Visible = true;
            lvVisible(true);

        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            rptPrograms.Visible = true;
            Repeater1.Visible = false;
             // ListViewDisplayWorkout.Visible = false;
            lvVisible(false);
        }


        protected void btnSaveProgram_Click(object sender, EventArgs e)
        {

            var btn = (Button)sender;
            var item = (RepeaterItem)btn.NamingContainer;
            Label labelProgram = (Label)item.FindControl("lblProgramID");
            int programID = Convert.ToInt32(labelProgram.Text);
            lvVisible(false);


            SqlCommand objCommand1 = new SqlCommand();

            objCommand1.CommandType = CommandType.StoredProcedure;
            objCommand1.CommandText = "TP_SelectAllFromSaved";

            SqlParameter ProgramID1 = new SqlParameter("@ProgramID", programID);
            ProgramID1.Direction = ParameterDirection.Input;
            objCommand1.Parameters.Add(ProgramID1);

            SqlParameter UserID1 = new SqlParameter("@UserID", Convert.ToInt32(Session["UserID"]));
            UserID1.Direction = ParameterDirection.Input;
            objCommand1.Parameters.Add(UserID1);

            DataSet ds = db.GetDataSetUsingCmdObj(objCommand1);
            int size = ds.Tables[0].Rows.Count;

            if (size == 0)
            {

                SqlCommand objCommand = new SqlCommand();

                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "TP_InsertIntoSaved";

                SqlParameter ProgramID = new SqlParameter("@ProgramID", programID);
                ProgramID.Direction = ParameterDirection.Input;
                objCommand.Parameters.Add(ProgramID);

                SqlParameter UserID = new SqlParameter("@UserID", Convert.ToInt32(Session["UserID"]));
                UserID.Direction = ParameterDirection.Input;
                objCommand.Parameters.Add(UserID);

                SqlParameter Date = new SqlParameter("@Date", DateTime.Now);
                Date.Direction = ParameterDirection.Input;
                objCommand.Parameters.Add(Date);


                db.DoUpdateUsingCmdObj(objCommand);

                Response.Write("<script>alert('Program Has Been Saved!') </script>");

                programDiv.Visible = false;
            }

            else
            {
                Response.Write("<script>alert('Program Has Already Been Saved Dummy!') </script>");
                programDiv.Visible = false;


            }
        }

        protected void btnSelectProgram_Click(object sender, EventArgs e)
        {

            var btn = (Button)sender;
            var item = (RepeaterItem)btn.NamingContainer;
            Label labelProgram = (Label)item.FindControl("lblProgramID");
            int programID = Convert.ToInt32(labelProgram.Text);


            SqlCommand objCommand1 = new SqlCommand();

            objCommand1.CommandType = CommandType.StoredProcedure;
            objCommand1.CommandText = "TP_SelectALLFromUsersWhereProgam";

            SqlParameter ProgramID1 = new SqlParameter("@ProgramID", programID);
            ProgramID1.Direction = ParameterDirection.Input;
            objCommand1.Parameters.Add(ProgramID1);

            SqlParameter UserID1 = new SqlParameter("@UserID", Convert.ToInt32(Session["UserID"]));
            UserID1.Direction = ParameterDirection.Input;
            objCommand1.Parameters.Add(UserID1);

            DataSet ds = db.GetDataSetUsingCmdObj(objCommand1);
            int size = ds.Tables[0].Rows.Count;

            if (size == 0)
            {

                SqlCommand objCommand = new SqlCommand();

                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "TP_UpdateUsersSetProgramID";

                SqlParameter ProgramID = new SqlParameter("@ProgramID", programID);
                ProgramID.Direction = ParameterDirection.Input;
                objCommand.Parameters.Add(ProgramID);

                SqlParameter UserID = new SqlParameter("@UserID", Convert.ToInt32(Session["UserID"]));
                UserID.Direction = ParameterDirection.Input;
                objCommand.Parameters.Add(UserID);

                SqlParameter Date = new SqlParameter("@Date", DateTime.Now);
                Date.Direction = ParameterDirection.Input;
                objCommand.Parameters.Add(Date);

                Session["ProgramID"] = programID;

                db.DoUpdateUsingCmdObj(objCommand);
                Response.Redirect("HomePage.aspx");

                Response.Write("<script>alert('Program Has Been Selected!') </script>");
            }

            else
            {
                Response.Write("<script>alert('You have already selected this program!!') </script>");

            }
        }

        private ArrayList lvWorkoutDays(int ID, string dayName)
        {
            SqlCommand objCommand = new SqlCommand();

            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_SelectAllFromExercisesWhereDay";

            SqlParameter workoutID = new SqlParameter("@ID", ID);
            workoutID.Direction = ParameterDirection.Input;
            objCommand.Parameters.Add(workoutID);

            SqlParameter day = new SqlParameter("@Day", dayName);
            day.Direction = ParameterDirection.Input;
            objCommand.Parameters.Add(day);


            DataSet mydata1 = db.GetDataSetUsingCmdObj(objCommand);


            ArrayList arrayExercise = new ArrayList();
            int size = mydata1.Tables[0].Rows.Count;
            if (size > 0)
            {
                for (int row = 0; row < mydata1.Tables[0].Rows.Count; row++)
                {
                    Exercise exercise = new Exercise();
                    exercise.exerciseName = mydata1.Tables[0].Rows[row]["ExerciseName"].ToString();
                    exercise.sets = Convert.ToInt32(mydata1.Tables[0].Rows[row]["Sets"]);
                    exercise.reps = Convert.ToInt32(mydata1.Tables[0].Rows[row]["Reps"]);

                    arrayExercise.Add(exercise);
                }
                return arrayExercise;
            }
            else
            {
                Exercise exercise = new Exercise();
                exercise.exerciseName = "rest";
                arrayExercise.Add(exercise);
            }
            return arrayExercise;

        }

        private void lvVisible(Boolean boo)
        {
            lvMonday.Visible = boo;
            lvTuesday.Visible = boo;
            lvWednesday.Visible = boo;
            lvThursday.Visible = boo;
            lvFriday.Visible = boo;
            lvSaturday.Visible = boo;
            lvSunday.Visible = boo;
            btnBack.Visible = boo;
            lvWorkouts.Visible = boo;
            programDiv.Visible = boo;
            Repeater1.Visible = boo;
        }

    }
}