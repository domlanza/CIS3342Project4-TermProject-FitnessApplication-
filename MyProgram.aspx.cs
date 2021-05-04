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
    public partial class MyProgram : System.Web.UI.Page
    {

        DBConnect db = new DBConnect();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserId"] != null)
            {

                navBar.Visible = true;
                ContentID.Visible = true;
                youShallNotPass.Visible = false;   
                ProgramLoad();

            }
            else if (Session["UserID"] == null)
            {
                navBar.Visible = false;
                ContentID.Visible = false;
                youShallNotPass.Visible = true;
            }
            

        }

      

        public void ProgramLoad() {
            //First Get the Program Id for the User

            int UserId = Convert.ToInt32(Session["UserID"]);
            String sql = "SELECT ProgramID FROM TP_Users WHERE UserID = " + UserId;
            DBConnect dBConnect = new DBConnect();
            DataSet data = dBConnect.GetDataSet(sql);

            int ProgramID = Int32.Parse(data.Tables[0].Rows[0]["ProgramID"].ToString());

            //Next use the Program Id and add that to the Repeater

            String sql2 = "SELECT * FROM TP_Program WHERE ProgramID = " + ProgramID;
            DBConnect dBConnect2 = new DBConnect();
       //     DataSet data2 = dBConnect2.GetDataSet(sql2);
            rptPrograms.DataSource = dBConnect2.GetDataSet(sql2);
            rptPrograms.DataBind();


            //Second Once the Program Id is grabbed now grab all workouts from the Program Id
            //Then grab all exercises from the workout

            lvMonday.DataSource = lvWorkoutDays(ProgramID, "Monday");
            lvMonday.DataBind();

            lvTuesday.DataSource = lvWorkoutDays(ProgramID, "Tuesday");
            lvTuesday.DataBind();

            lvWednesday.DataSource = lvWorkoutDays(ProgramID, "Wednesday");
            lvWednesday.DataBind();

            lvThursday.DataSource = lvWorkoutDays(ProgramID, "Thursday");
            lvThursday.DataBind();

            lvFriday.DataSource = lvWorkoutDays(ProgramID, "Friday");
            lvFriday.DataBind();

            lvSaturday.DataSource = lvWorkoutDays(ProgramID, "Saturday");
            lvSaturday.DataBind();

            lvSunday.DataSource = lvWorkoutDays(ProgramID, "Sunday");
            lvSunday.DataBind();
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


    }
}