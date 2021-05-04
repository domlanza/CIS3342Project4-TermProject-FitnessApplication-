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
    public partial class HomePage : System.Web.UI.Page
    {
        DBConnect db = new DBConnect();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["UserID"] == null)
                {
                    ContentID.Visible = false;
                    youShallNotPass.Visible = true;
                    navBar.Visible = false;
                }
                else if (Session["Assistance"].ToString() == "Yes")
                {
                    Response.Redirect("UserFilteredWorkouts.aspx");

                    //FindWorkout(Convert.ToInt32(Session["UserDays"]), Session["UserTraining"].ToString(), Session["Experience"].ToString());
                }
                else
                {
                    string goals = Session["UserGoals"].ToString();
                    if (goals == "")
                    {
                        lblGoals.Text = "Get Stronger";
                    }
                    else
                    {
                        lblGoals.Text = Session["UserGoals"].ToString();
                    }
                    // int programID = Convert.ToInt32(Session["ProgramID"]);
                    DateTime f = DateTime.Now;
                    DateTime no = f.AddDays(12);
                    ContentID.Visible = true;
                    youShallNotPass.Visible = false;
                    SavedWorkouts();
                    int id = Convert.ToInt32(Session["ProgramID"]);
                    if (id == 32)
                    {
                        DateStampLabel.Text = "No Workout Program Selected!";
                        lblCurrentWeight.Text = Session["UserWeight"].ToString() + "lbs";
                        lblDaysLeft.Text = "N/A";
                    }
                    else
                    {
                        DisplayTime();
                        lblCurrentWeight.Text = Session["UserWeight"].ToString() + "lbs";
                        lblDaysLeft.Text = GetLengthOfProgram(Convert.ToInt32(Session["ProgramID"])).ToString();
                    }

                    //DailyWorkout();
                }

            }
        }

        protected void UpdateTimer_Tick(object sender, EventArgs e)
        {
            DisplayTime();
        }

        private void DisplayTime()
        {
            DateTime dateSelected = GetDate();
            TimeSpan totalDays = TimeSpan.FromSeconds((DateTime.Now - dateSelected).TotalSeconds);
            DateStampLabel.Text = totalDays.ToString(@"d'd, 'hh\hmm\mss") + "s ago";
        }

        private void SavedWorkouts()
        {
            ///* First Statement to get ProgramID */
            SqlCommand objCommand = new SqlCommand();

            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_SelectProgramID";

            SqlParameter ID = new SqlParameter("@UserID", Convert.ToInt32(Session["UserID"]));
            ID.Direction = ParameterDirection.Input;
            objCommand.Parameters.Add(ID);

            DataSet mydata = db.GetDataSetUsingCmdObj(objCommand);
            int ProgramID = Convert.ToInt32(mydata.Tables[0].Rows[0]["ProgramID"]);


            double LengthOfProgram = GetLengthOfProgram(ProgramID);

            DateTime dateSelected = GetDate();

            /*Date When User finished program */
            DateTime dateFinished = dateSelected.AddDays(LengthOfProgram);

            double difference = Convert.ToInt32((dateFinished - DateTime.Now).TotalDays);

            lblDaysLeft.Text = difference.ToString() + " days left!";

            double percentage = ((LengthOfProgram - difference) / LengthOfProgram) * 100;

            progressBar.Style["width"] = percentage.ToString() + "%";

            lblCompletionPercentage.Text = percentage.ToString("#.##") + "%";


            SqlCommand objCommand3 = new SqlCommand();

            objCommand3.CommandType = CommandType.StoredProcedure;
            objCommand3.CommandText = "TP_SelectProgramName";

            SqlParameter ProgramID1 = new SqlParameter("@ID", ProgramID);
            ProgramID1.Direction = ParameterDirection.Input;
            objCommand3.Parameters.Add(ProgramID1);

            DataSet mydata3 = db.GetDataSetUsingCmdObj(objCommand3);
            string ProgramName = mydata3.Tables[0].Rows[0]["ProgramName"].ToString();

            lblProgram.Text = "Program Selected: " + ProgramName;
        }

        public void FindWorkout(int days, string training, string experience)
        {

            SqlCommand objCommand = new SqlCommand();

            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_SelectProgramNameForUser";

            SqlParameter Days = new SqlParameter("@Days", days);
            Days.Direction = ParameterDirection.Input;
            objCommand.Parameters.Add(Days);

            SqlParameter Training = new SqlParameter("@Training", training);
            Training.Direction = ParameterDirection.Input;
            objCommand.Parameters.Add(Training);

            SqlParameter Exp = new SqlParameter("@Experience", experience);
            Exp.Direction = ParameterDirection.Input;
            objCommand.Parameters.Add(Exp);

            DataSet mydata = db.GetDataSetUsingCmdObj(objCommand);
            string programName = mydata.Tables[0].Rows[0]["ProgramName"].ToString();


        }

        public DateTime GetDate()
        {
            /* Third Statement to get Date Added Of Program */
            SqlCommand objCommand2 = new SqlCommand();

            objCommand2.CommandType = CommandType.StoredProcedure;
            objCommand2.CommandText = "TP_SelectDaySelected";

            SqlParameter userID = new SqlParameter("@ID", Convert.ToInt32(Session["UserID"]));
            userID.Direction = ParameterDirection.Input;
            objCommand2.Parameters.Add(userID);

            DataSet mydata2 = db.GetDataSetUsingCmdObj(objCommand2);
            DateTime dateSelected = Convert.ToDateTime(mydata2.Tables[0].Rows[0]["DayWorkoutSelected"]);

            return dateSelected;
        }

        public Double GetLengthOfProgram(int ProgramID)
        {
            /* Second Statement to get Length Of Program */
            SqlCommand objCommand1 = new SqlCommand();

            objCommand1.CommandType = CommandType.StoredProcedure;
            objCommand1.CommandText = "TP_SelectProgramLength";

            SqlParameter programID = new SqlParameter("@ID", ProgramID);
            programID.Direction = ParameterDirection.Input;
            objCommand1.Parameters.Add(programID);

            DataSet mydata1 = db.GetDataSetUsingCmdObj(objCommand1);
            double LengthOfProgram = Convert.ToInt32(mydata1.Tables[0].Rows[0]["LengthOfProgram"]);

            return LengthOfProgram;
        }



        //public void DailyWorkout()
        //{
        //    ArrayList arrayExercises = new ArrayList();
        //    ArrayList arrayExerciseID = new ArrayList();
        //    SqlCommand objCommand = new SqlCommand();

        //    objCommand.CommandType = CommandType.StoredProcedure;
        //    objCommand.CommandText = "TP_SelectProgramID";

        //    SqlParameter ID = new SqlParameter("@UserID", Convert.ToInt32(Session["UserID"]));
        //    ID.Direction = ParameterDirection.Input;
        //    objCommand.Parameters.Add(ID);

        //    DataSet mydata = db.GetDataSetUsingCmdObj(objCommand);
        //    int programID = Convert.ToInt32(mydata.Tables[0].Rows[0]["ProgramID"]);


        //    SqlCommand sqlCommand = new SqlCommand();

        //    sqlCommand.CommandType = CommandType.StoredProcedure;
        //    sqlCommand.CommandText = "TP_SelectExerciseIDWhereDay";

        //    SqlParameter Day = new SqlParameter("@Day", DateTime.Now.DayOfWeek.ToString());
        //    Day.Direction = ParameterDirection.Input;
        //    sqlCommand.Parameters.Add(Day);

        //    SqlParameter ProgramID = new SqlParameter("@ID", programID);
        //    ProgramID.Direction = ParameterDirection.Input;
        //    sqlCommand.Parameters.Add(ProgramID);

        //    DataSet mydata1 = db.GetDataSetUsingCmdObj(sqlCommand);
        //    int size = mydata1.Tables[0].Rows.Count;

        //    if (size > 0)
        //    {
        //        for (int row = 0; row < size; row++)
        //        {
        //            Exercise exercises = new Exercise();
        //            exercises.ExerciseID = Convert.ToInt32(mydata1.Tables[0].Rows[row]["ExerciseID"]);
        //            // arrayExerciseID.Add(exercises.ExerciseID);

        //            SqlCommand sqlCommand1 = new SqlCommand();

        //            sqlCommand1.CommandType = CommandType.StoredProcedure;
        //            sqlCommand1.CommandText = "TP_SelectAllFromExercise";


        //            SqlParameter ExerciseID = new SqlParameter("@ID", exercises.ExerciseID);
        //            ExerciseID.Direction = ParameterDirection.Input;
        //            sqlCommand1.Parameters.Add(ExerciseID);

        //            DataSet mydata2 = db.GetDataSetUsingCmdObj(sqlCommand1);

        //            for (int i = 0; i < mydata2.Tables.Count; i++)
        //            {
        //                Exercise exercise = new Exercise();
        //                exercise.exerciseName = mydata2.Tables[0].Rows[i]["ExerciseName"].ToString();
        //                exercise.sets = Convert.ToInt32(mydata2.Tables[0].Rows[i]["Sets"]);
        //                exercise.reps = Convert.ToInt32(mydata2.Tables[0].Rows[i]["Reps"]);
        //                arrayExercises.Add(exercise);
        //            }
        //        }
        //        h6Day.InnerText = DateTime.Now.DayOfWeek.ToString() + " Workouts";
        //        gvWorkoutOftheDay.DataSource = arrayExercises;
        //        gvWorkoutOftheDay.DataBind();
        //    }
        //    else
        //    {
        //        Response.Write("<script>alert('rest day!')</script>");

        //    }

        //}
    }
}
