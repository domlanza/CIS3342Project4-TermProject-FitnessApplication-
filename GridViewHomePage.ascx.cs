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
    public partial class GridViewHomePage : System.Web.UI.UserControl
    {

        DBConnect db = new DBConnect();

        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["UserID"] == null){

            }
            else
            {
            DailyWorkout();

            }
        }


        public void DailyWorkout()
        {
            ArrayList arrayExercises = new ArrayList();
            ArrayList arrayExerciseID = new ArrayList();
            SqlCommand objCommand = new SqlCommand();

            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_SelectProgramID";

            SqlParameter ID = new SqlParameter("@UserID", Convert.ToInt32(Session["UserID"]));
            ID.Direction = ParameterDirection.Input;
            objCommand.Parameters.Add(ID);

            DataSet mydata = db.GetDataSetUsingCmdObj(objCommand);
            int programID = Convert.ToInt32(mydata.Tables[0].Rows[0]["ProgramID"]);


            SqlCommand sqlCommand = new SqlCommand();

            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.CommandText = "TP_SelectExerciseIDWhereDay";

            SqlParameter Day = new SqlParameter("@Day", DateTime.Now.DayOfWeek.ToString());
            Day.Direction = ParameterDirection.Input;
            sqlCommand.Parameters.Add(Day);

            SqlParameter ProgramID = new SqlParameter("@ID", programID);
            ProgramID.Direction = ParameterDirection.Input;
            sqlCommand.Parameters.Add(ProgramID);

            DataSet mydata1 = db.GetDataSetUsingCmdObj(sqlCommand);
            int size = mydata1.Tables[0].Rows.Count;

            if (size > 0)
            {
                for (int row = 0; row < size; row++)
                {
                    Exercise exercises = new Exercise();
                    exercises.ExerciseID = Convert.ToInt32(mydata1.Tables[0].Rows[row]["ExerciseID"]);
                    // arrayExerciseID.Add(exercises.ExerciseID);

                    SqlCommand sqlCommand1 = new SqlCommand();

                    sqlCommand1.CommandType = CommandType.StoredProcedure;
                    sqlCommand1.CommandText = "TP_SelectAllFromExercise";


                    SqlParameter ExerciseID = new SqlParameter("@ID", exercises.ExerciseID);
                    ExerciseID.Direction = ParameterDirection.Input;
                    sqlCommand1.Parameters.Add(ExerciseID);

                    DataSet mydata2 = db.GetDataSetUsingCmdObj(sqlCommand1);

                    for (int i = 0; i < mydata2.Tables.Count; i++)
                    {
                        Exercise exercise = new Exercise();
                        exercise.exerciseName = mydata2.Tables[0].Rows[i]["ExerciseName"].ToString();
                        exercise.sets = Convert.ToInt32(mydata2.Tables[0].Rows[i]["Sets"]);
                        exercise.reps = Convert.ToInt32(mydata2.Tables[0].Rows[i]["Reps"]);
                        arrayExercises.Add(exercise);
                    }
                }
                h6Day.InnerText = DateTime.Now.DayOfWeek.ToString() + " Workouts";
                gvWorkoutOftheDay.DataSource = arrayExercises;
                gvWorkoutOftheDay.DataBind();
            }
            else
            {
                Response.Write("<script>alert('rest day!')</script>");

            }

        }
    }
}