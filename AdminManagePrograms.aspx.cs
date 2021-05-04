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
    public partial class AdminManagePrograms : System.Web.UI.Page
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
                    btnDelete.Visible = false;
                }
                else
                {
                    navBar.Visible = true;
                    ContentID.Visible = true;
                    youShallNotPass.Visible = false;
                    ShowPrograms();
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

        public void ShowPrograms()
        {
            SqlCommand sqlCommand1 = new SqlCommand();
            ArrayList programList = new ArrayList();

            sqlCommand1.CommandType = CommandType.StoredProcedure;
            sqlCommand1.CommandText = "TP_SelectEverythingFromProgram";

            DataSet myData = db.GetDataSetUsingCmdObj(sqlCommand1);

            // String sql = "SELECT * FROM Users WHERE UserType = 'User'";
            //DataSet myData = db.GetDataSet(sql);


            int size = myData.Tables[0].Rows.Count;

            if (size > 0)
            {
                for (int i = 0; i < size; i++)
                {
                    programList.Add(pxy.GetAllProgram(myData, i));
                }
                gvManagePrograms.DataSource = programList;
                gvManagePrograms.DataBind();         
                gvManagePrograms.Rows[0].Visible = false;

            }
            else
            {
                Response.Write("<script>alert('No Users Found') </script>");
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < gvManagePrograms.Rows.Count; i++)
            {
                CheckBox cb;
                cb = (CheckBox)gvManagePrograms.Rows[i].FindControl("cbSelect");

                if (cb.Checked)
                {
                    //SqlCommand sqlCommand5 = new SqlCommand();

                    String programName = gvManagePrograms.Rows[i].Cells[4].Text;

                    int programID = Convert.ToInt32(gvManagePrograms.Rows[i].Cells[3].Text);


                    JavaScriptSerializer js = new JavaScriptSerializer();
                    String jsonWorkout = js.Serialize(programID);



                    JavaScriptSerializer JS = new JavaScriptSerializer();
                    String jsonProgram = JS.Serialize(programName);
                    string data = "";

                    try
                    {
                        WebRequest request = WebRequest.Create("https://localhost:44314/api/Fitness/DeleteWorkout/" + programID);
                        request.Method = "DELETE";
                        request.ContentLength = jsonWorkout.Length;
                        request.ContentType = "application/json";

                        StreamWriter writer = new StreamWriter(request.GetRequestStream());
                        writer.Write(jsonWorkout);
                        writer.Flush();
                        writer.Close();

                        WebResponse response = request.GetResponse();
                        Stream theDataStream = response.GetResponseStream();
                        StreamReader reader = new StreamReader(theDataStream);
                        data = reader.ReadToEnd();
                        reader.Close();
                        response.Close();



                        try
                        {

                            SqlCommand objCommand1 = new SqlCommand();

                            objCommand1.CommandType = CommandType.StoredProcedure;
                            objCommand1.CommandText = "TP_SelectProgramNameWhereID";

                            SqlParameter ProgramName = new SqlParameter("@ProgramName", programName);
                            ProgramName.Direction = ParameterDirection.Input;
                            objCommand1.Parameters.Add(ProgramName);

                            DataSet ds = db.GetDataSetUsingCmdObj(objCommand1);

                            int id = Convert.ToInt32(ds.Tables[0].Rows[0]["ProgramID"]);



                            SqlCommand objCommand = new SqlCommand();

                            objCommand.CommandType = CommandType.StoredProcedure;
                            objCommand.CommandText = "TP_UpdateUserIDWhereProgram";

                            SqlParameter ID = new SqlParameter("@ID", id);
                            ID.Direction = ParameterDirection.Input;
                            objCommand.Parameters.Add(ID);


                            int result = db.DoUpdateUsingCmdObj(objCommand);


                            SqlCommand objCommand2 = new SqlCommand();

                            objCommand2.CommandType = CommandType.StoredProcedure;
                            objCommand2.CommandText = "TP_DeleteFromSavedPrograms";

                            SqlParameter SavedID = new SqlParameter("@ID", id);
                            SavedID.Direction = ParameterDirection.Input;
                            objCommand2.Parameters.Add(SavedID);

                            db.DoUpdateUsingCmdObj(objCommand2);

                            WebRequest request1 = WebRequest.Create("https://localhost:44314/api/Fitness/DeleteProgram/" + programName);
                                request1.Method = "DELETE";
                                request1.ContentLength = jsonProgram.Length;
                                request1.ContentType = "application/json";

                                StreamWriter writer1 = new StreamWriter(request1.GetRequestStream());
                                writer1.Write(jsonProgram);
                                writer1.Flush();
                                writer1.Close();

                                WebResponse response1 = request1.GetResponse();
                                Stream theDataStream1 = response1.GetResponseStream();
                                StreamReader reader1 = new StreamReader(theDataStream1);
                                String data1 = reader1.ReadToEnd();
                                reader1.Close();
                                response1.Close();

                      
                        }

                        catch (Exception ex)
                        {
                            Response.Write("<script>alert('Delete not work') </script>");

                        }

                    }

                    catch (Exception ex)
                    {
                        Response.Write("<script>alert('Delete not work') </script>");

                    }
                    // Response.Write("<script>alert('" + data + "') </script>");


                }
            }
            Response.Redirect("AdminManagePrograms.aspx");

        }

        protected void gvManagePrograms_SelectedIndexChanged(object sender, EventArgs e)
        {

            int ID = Convert.ToInt32(gvManagePrograms.SelectedRow.Cells[3].Text);

            lvMonday.DataSource = lvWorkoutDays(ID, "Monday");


            lvTuesday.DataSource = lvWorkoutDays(ID, "Tuesday");

            lvWednesday.DataSource = lvWorkoutDays(ID, "Wednesday");

            lvThursday.DataSource = lvWorkoutDays(ID, "Thursday");

            lvFriday.DataSource = lvWorkoutDays(ID, "Friday");

            lvSaturday.DataSource = lvWorkoutDays(ID, "Saturday");

            lvSunday.DataSource = lvWorkoutDays(ID, "Sunday");


            lvMonday.DataBind();
            lvTuesday.DataBind();
            lvWednesday.DataBind();
            lvThursday.DataBind();
            lvFriday.DataBind();
            lvSaturday.DataBind();
            lvSunday.DataBind();

            lvVisible(true);
            gvManagePrograms.Visible = false;
            ProgramLoad(ID);
            btnDelete.Visible = false;

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
                return arrayExercise;

            }
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
            lvContent.Visible = boo;
            Repeater1.Visible = boo;
            card.Visible = boo;
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            gvManagePrograms.Visible = true;
            // ListViewDisplayWorkout.Visible = false;
            lvVisible(false);
            btnDelete.Visible = true;

        }
    }
}