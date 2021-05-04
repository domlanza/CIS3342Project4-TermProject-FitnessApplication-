<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminAddWorkout.aspx.cs" Inherits="Term_Project.AdminAddWorkout" %>

<%@ Register Src="~/LogoutNav.ascx" TagPrefix="uc1" TagName="LogoutNav" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>


    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <!--===============================================================================================-->
    <link rel="icon" type="image/png" href="images/icons/favicon.ico" />
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="vendor/bootstrap/css/bootstrap.min.css" />
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="fonts/font-awesome-4.7.0/css/font-awesome.min.css" />
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="fonts/iconic/css/material-design-iconic-font.min.css" />
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="vendor/animate/animate.css" />
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="vendor/css-hamburgers/hamburgers.min.css" />
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="vendor/animsition/css/animsition.min.css" />
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="vendor/select2/select2.min.css" />
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="vendor/daterangepicker/daterangepicker.css" />
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="css/LogIn.css" />
    <link rel="stylesheet" type="text/css" href="css/StyleSheet1.css" />
    <link href="Css/SignUpCSS.css" rel="stylesheet" />
    <!--===============================================================================================-->
    <script language="JavaScript" type="text/javascript" src="/js/jquery-1.2.6.min.js"></script>
    <script language="JavaScript" type="text/javascript" src="/js/jquery-ui-personalized-1.5.2.packed.js"></script>
    <script language="JavaScript" type="text/javascript" src="/js/sprinkle.js"></script>
    <script src="https://ajax.aspnetcdn.com/ajax/jQuery/jquery-3.3.1.min.js"></script>

</head>
<body>
    <form id="form1" runat="server">

        <div id="youShallNotPass" runat="server" class="text-center" visible="false">
            <h2 class="text-center">You Must Log In To See This Site!</h2>
            <img src="Images2/ShallNotPass.gif" style="margin-top: 100px;" />
            <uc1:LogoutNav runat="server" ID="LogoutNav2" />

        </div>

        <%--    nav bar start--%>
        <nav class="navbar navbar-expand-md navbar-dark fixed-top bg-primary" id="navBar" runat="server">
            <a class="navbar-brand" href="AdminPage.aspx">Moe's Fitness</a>
            <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarsExampleDefault" aria-controls="navbarsExampleDefault" aria-expanded="false" aria-label="Toggle navigation">
                <span class="navbar-toggler-icon"></span>
            </button>

            <div class="collapse navbar-collapse" id="navbarsExampleDefault">
                <ul class="navbar-nav mr-auto">
                    <li class="nav-item">
                        <a class="nav-link" href="AdminPage.aspx">Home<span class="sr-only">(current)</span></a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="AdminSignUp.aspx">Create Admin</a>
                    </li>
                    <li class="nav-item active">
                        <a class="nav-link" href="AdminAddWorkout.aspx">Make A Program</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="AdminManagePrograms.aspx">Manage Programs</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="AdminMessage.aspx">Customer's Questions</a>
                    </li>
                </ul>
                <div class="form-inline my-2 my-lg-0" runat="server">
                    <uc1:LogoutNav runat="server" ID="LogoutNav1" />
                </div>
            </div>
        </nav>


        <%--          end nav bar--%>
        <div class="container-login100" style="background-image: url('images2/background3.jpg');" id="ContentID" runat="server">

            <div id="userInput" class="d-flex justify-content-center text-center">
                <div class="card" id="cardSize" runat="server" style="width: 50rem; height: auto;">
                    <div class="container">
                        <br />

                        <div class="row">
                            <br />

                            <div class="col-md-1 mb-3">
                                <img src="../Images2/Asset_4.png" width="100" height="100" />
                            </div>
                            <br />

                            <div class="col-md-8 mb-3" id="Heading">
                                <h4 class="mb-3">Create A Workout Program</h4>
                            </div>
                        </div>
                        <br />

                        <div id="programContent" runat="server">
                            <div class="row">
                                <div class="col-md-6 mb-3">
                                    <label for="ProgramName">Program Name</label>
                                    <asp:TextBox ID="txtProgramName" runat="server" class="form-control" placeholder="Name" autofocus=""></asp:TextBox>
                                    <div class="invalid-feedback">Your Program Name Is Required</div>
                                </div>

                                <div class="col-md-6 mb-3">
                                    <label for="Experience">Program experience level?</label><br />
                                    <asp:DropDownList ID="ddlExperience" CssClass="form-control" runat="server" AutoPostBack="true">
                                        <asp:ListItem Selected="True" Value="Beginner">Beginner</asp:ListItem>
                                        <asp:ListItem Value="Intermediate">Intermediate</asp:ListItem>
                                        <asp:ListItem Value="Advanced">Advanced</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <br />

                            <div class="row">
                                <div class="col-md-6 mb-3">
                                    <label for="Program">Program Type</label>
                                    <asp:DropDownList ID="ddlType" CssClass="form-control" runat="server" AutoPostBack="true">
                                        <asp:ListItem Selected="True" Value="Hypertrophy">Hypertrophy</asp:ListItem>
                                        <asp:ListItem Value="Strength">Strength</asp:ListItem>
                                        <asp:ListItem Value="Mixed">Mixed</asp:ListItem>
                                    </asp:DropDownList>
                                </div>

                                <div class="col-md-6 mb-3">
                                    <label for="Program">Days of Workout</label>
                                    <asp:RadioButtonList ID="rbDays" runat="server" CssClass="radioButtonList" AutoPostBack="true" RepeatColumns="3" RepeatLayout="Table" Width="100%">
                                        <asp:ListItem Selected="True" Value="3">3 Days</asp:ListItem>
                                        <asp:ListItem Value="5">4-5 Days</asp:ListItem>
                                        <asp:ListItem Value="7">6-7 Days</asp:ListItem>
                                    </asp:RadioButtonList>
                                </div>

                            </div>

                            <div class="row">
                                <div class="col-md-6 mb-3">
                                    <div class="col-md-6 mb-3">
                                        <label for="ProgramName">Program Image</label>
                                        <asp:TextBox ID="txtImage" runat="server" class="form-control" placeholder="image src link" autofocus=""></asp:TextBox>
                                        <div class="invalid-feedback">Your Program Name Is Required</div>
                                    </div>
                                </div>

                                <div class="col-md-6 mb-3">
                                    <div class="col-md-6 mb-3">
                                        <label for="ProgramName">Program Length in Days</label>
                                        <asp:TextBox ID="txtLength" type="number" runat="server" class="form-control" placeholder="60 days" autofocus=""></asp:TextBox>
                                        <div class="invalid-feedback">Your Program Length Is Required</div>
                                    </div>
                                </div>

                            </div>

                            <div class="row">
                                <div class="col-md-6 mb-3">
                                    <label for="Program">Description Of Program</label>
                                    <asp:TextBox ID="txtDesc" runat="server" class="form-control" placeholder="Description" autofocus=""></asp:TextBox>
                                    <div class="invalid-feedback">Your Program Description Is Required</div>
                                </div>
                            </div>
                            <br />
                            <hr />
                        </div>
                        <div id="divContent" runat="server">
                            <!-- Monday -->
                            <h3 id="h3Monday" class="text-center" runat="server">Monday Workout</h3>
                            <br />

                            <div class="col-md-6 mb-3 text-center" style="margin-left: 180px;">
                                <label for="Desc">Workout Description</label>
                                <asp:TextBox ID="txtMondayDescription" runat="server" class="form-control" placeholder="Back/Biceps"></asp:TextBox>
                                <div class="invalid-feedback">Your Description is required!</div>
                            </div>



                            <div class="col-md-6 mb-3" style="margin-left: 180px;">
                                <label for="ExerciseName">Exercise Name</label>
                                <asp:TextBox ID="txtExerciseMonday" runat="server" CssClass="form-control" placeholder="Deadlift"></asp:TextBox>
                                <div class="invalid-feedback">Your Exercise is required!</div>
                            </div>


                            <br />

                            <div class="row">
                                <div class="col-md-5 mb-2" style="margin-left: 230px;">
                                    <label for="Sets">Sets for this exercise</label>
                                    <asp:TextBox ID="txtSetsMonday" runat="server"  type="number" FilterType="Numbers" min= "1" max = "12" CssClass="form-control" placeholder="3"></asp:TextBox>
                                    <div class="invalid-feedback">Sets are required!</div>
                                </div>
                            </div>
                            <div class="row">

                                <div class="col-md-5 mb-2" style="margin-left: 230px;">
                                    <label for="Reps">Reps for this exercise</label><br />
                                    <asp:TextBox ID="txtRepsMonday" runat="server"  type="number" FilterType="Numbers" min= "1" max = "100" CssClass="form-control" placeholder="8"></asp:TextBox>
                                    <div class="invalid-feedback">Reps are required!</div>
                                </div>

                            </div>
                            <br />

                            <asp:Button ID="btnAddMonday" runat="server" Text="Add Workouts!" OnClick="btnAddMonday_Click" />

                            <hr />

                            <!-- Tuesday -->
                            <h3 id="h1" class="text-center" runat="server">Tuesday Workout</h3>
                            <br />



                            <div class="col-md-6 mb-3 text-center" style="margin-left: 180px;">
                                <label for="Desc">Workout Description</label>
                                <asp:TextBox ID="txtDescTuesday" runat="server" class="form-control" placeholder="Back/Biceps"></asp:TextBox>
                                <div class="invalid-feedback">Your Description is required!</div>
                            </div>


                            <div class="col-md-6 mb-3" style="margin-left: 180px;">
                                <label for="ExerciseName">Exercise Name</label>
                                <asp:TextBox ID="txtExcerciseTuesday" runat="server" CssClass="form-control" placeholder="Deadlift"></asp:TextBox>
                                <div class="invalid-feedback">Your Exercise is required!</div>
                            </div>


                            <br />

                            <div class="row">
                                <div class="col-md-5 mb-2" style="margin-left: 230px;">
                                    <label for="Sets">Sets for this exercise</label>
                                    <asp:TextBox ID="txtSetsTuesday" runat="server" type="number" CssClass="form-control" placeholder="3"></asp:TextBox>
                                    <div class="invalid-feedback">Sets are required!</div>
                                </div>
                            </div>
                            <div class="row">

                                <div class="col-md-5 mb-2" style="margin-left: 230px;">
                                    <label for="Reps">Reps for this exercise</label><br />
                                    <asp:TextBox ID="txtRepsTuesday" runat="server" type="number" CssClass="form-control" placeholder="8"></asp:TextBox>
                                    <div class="invalid-feedback">Reps are required!</div>
                                </div>

                            </div>
                            <asp:Button ID="btnSubmitTuesday" runat="server" Text="Add Workout" OnClick="btnSubmitTuesday_Click" />
                            <br />
                            <hr />

                            <!-- Wednesday -->
                            <h3 id="h2" class="text-center" runat="server">Wednesday Workout</h3>
                            <br />



                            <div class="col-md-6 mb-3 text-center" style="margin-left: 180px;">
                                <label for="Desc">Workout Description</label>
                                <asp:TextBox ID="txtDescWed" runat="server" class="form-control" placeholder="Back/Biceps"></asp:TextBox>
                                <div class="invalid-feedback">Your Description is required!</div>
                            </div>


                            <div class="col-md-6 mb-3" style="margin-left: 180px;">
                                <label for="ExerciseName">Exercise Name</label>
                                <asp:TextBox ID="txtExerciseWed" runat="server" CssClass="form-control" placeholder="Deadlift"></asp:TextBox>
                                <div class="invalid-feedback">Your Exercise is required!</div>
                            </div>


                            <br />

                            <div class="row">
                                <div class="col-md-5 mb-2" style="margin-left: 230px;">
                                    <label for="Sets">Sets for this exercise</label>
                                    <asp:TextBox ID="txtSetsWed" runat="server" type="number" CssClass="form-control" placeholder="3"></asp:TextBox>
                                    <div class="invalid-feedback">Sets are required!</div>
                                </div>
                            </div>
                            <div class="row">

                                <div class="col-md-5 mb-2" style="margin-left: 230px;">
                                    <label for="Reps">Reps for this exercise</label><br />
                                    <asp:TextBox ID="txtRepsWed" runat="server" type="number" CssClass="form-control" placeholder="8"></asp:TextBox>
                                    <div class="invalid-feedback">Reps are required!</div>
                                </div>     

                            </div>

                                <asp:Button ID="btnAddWednesday" runat="server" Text="Add Workout" OnClick="btnAddWednesday_Click" />

                            <br />
                            <hr />

                            <!-- Thursday -->
                            <h3 id="h3" class="text-center" runat="server">Thursday Workout</h3>
                            <br />



                            <div class="col-md-6 mb-3 text-center" style="margin-left: 180px;">
                                <label for="Desc">Workout Description</label>
                                <asp:TextBox ID="txtDesThurs" runat="server" class="form-control" placeholder="Back/Biceps"></asp:TextBox>
                                <div class="invalid-feedback">Your Description is required!</div>
                            </div>


                            <div class="col-md-6 mb-3" style="margin-left: 180px;">
                                <label for="ExerciseName">Exercise Name</label>
                                <asp:TextBox ID="txtExerciseThurs" runat="server" CssClass="form-control" placeholder="Deadlift"></asp:TextBox>
                                <div class="invalid-feedback">Your Exercise is required!</div>
                            </div>


                            <br />

                            <div class="row">
                                <div class="col-md-5 mb-2" style="margin-left: 230px;">
                                    <label for="Sets">Sets for this exercise</label>
                                    <asp:TextBox ID="txtSetsThurs" runat="server" type="number" CssClass="form-control" placeholder="3"></asp:TextBox>
                                    <div class="invalid-feedback">Sets are required!</div>
                                </div>
                            </div>
                            <div class="row">

                                <div class="col-md-5 mb-2" style="margin-left: 230px;">
                                    <label for="Reps">Reps for this exercise</label><br />
                                    <asp:TextBox ID="txtRepsThurs" runat="server" type="number" CssClass="form-control" placeholder="8"></asp:TextBox>
                                    <div class="invalid-feedback">Reps are required!</div>
                                </div>
                            </div>

                            <asp:Button ID="btnAddThursday" runat="server" Text="Add Workout" OnClick="btnAddThursday_Click" />

                            <br />
                            <hr />

                            <!-- Friday -->
                            <h3 id="h4" class="text-center" runat="server">Friday Workout</h3>
                            <br />

                            <div class="col-md-6 mb-3 text-center" style="margin-left: 180px;">
                                <label for="Desc">Workout Description</label>
                                <asp:TextBox ID="txtDescFri" runat="server" class="form-control" placeholder="Back/Biceps"></asp:TextBox>
                                <div class="invalid-feedback">Your Description is required!</div>
                            </div>


                            <div class="col-md-6 mb-3" style="margin-left: 180px;">
                                <label for="ExerciseName">Exercise Name</label>
                                <asp:TextBox ID="txtExerciseFri" runat="server" CssClass="form-control" placeholder="Deadlift"></asp:TextBox>
                                <div class="invalid-feedback">Your Exercise is required!</div>
                            </div>


                            <br />

                            <div class="row">
                                <div class="col-md-5 mb-2" style="margin-left: 230px;">
                                    <label for="Sets">Sets for this exercise</label>
                                    <asp:TextBox ID="txtSetsFri" runat="server" type="number" CssClass="form-control" placeholder="3"></asp:TextBox>
                                    <div class="invalid-feedback">Sets are required!</div>
                                </div>
                            </div>
                            <div class="row">

                                <div class="col-md-5 mb-2" style="margin-left: 230px;">
                                    <label for="Reps">Reps for this exercise</label><br />
                                    <asp:TextBox ID="txtRepsFri" runat="server" type="number" CssClass="form-control" placeholder="8"></asp:TextBox>
                                    <div class="invalid-feedback">Reps are required!</div>
                                </div>
                            </div>

                            <asp:Button ID="btnFriday" runat="server" Text="Add Workout" OnClick="btnFriday_Click" />

                            <br />
                            <hr />

                            <!-- Saturday -->
                            <h3 id="h5" class="text-center" runat="server">Saturday Workout</h3>
                            <br />



                            <div class="col-md-6 mb-3 text-center" style="margin-left: 180px;">
                                <label for="Desc">Workout Description</label>
                                <asp:TextBox ID="txtDescSat" runat="server" class="form-control" placeholder="Back/Biceps"></asp:TextBox>
                                <div class="invalid-feedback">Your Description is required!</div>
                            </div>


                            <div class="col-md-6 mb-3" style="margin-left: 180px;">
                                <label for="ExerciseName">Exercise Name</label>
                                <asp:TextBox ID="txtExerciseSat" runat="server" CssClass="form-control" placeholder="Deadlift"></asp:TextBox>
                                <div class="invalid-feedback">Your Exercise is required!</div>
                            </div>


                            <br />

                            <div class="row">
                                <div class="col-md-5 mb-2" style="margin-left: 230px;">
                                    <label for="Sets">Sets for this exercise</label>
                                    <asp:TextBox ID="txtSetsSat" runat="server" type="number" CssClass="form-control" placeholder="3"></asp:TextBox>
                                    <div class="invalid-feedback">Sets are required!</div>
                                </div>
                            </div>
                            <div class="row">

                                <div class="col-md-5 mb-2" style="margin-left: 230px;">
                                    <label for="Reps">Reps for this exercise</label><br />
                                    <asp:TextBox ID="txtRepsSat" runat="server" type="number" CssClass="form-control" placeholder="8"></asp:TextBox>
                                    <div class="invalid-feedback">Reps are required!</div>
                                </div>
                            </div>

                            <asp:Button ID="btnAddSaturday" runat="server" Text="Add Workout" OnClick="btnAddSaturday_Click" />

                            <br />
                            <hr />

                            <!-- Sunday -->
                            <h3 id="h6" class="text-center" runat="server">Sunday Workout</h3>
                            <br />



                            <div class="col-md-6 mb-3 text-center" style="margin-left: 180px;">
                                <label for="Desc">Workout Description</label>
                                <asp:TextBox ID="txtDescSun" runat="server" class="form-control" placeholder="Back/Biceps"></asp:TextBox>
                                <div class="invalid-feedback">Your Description is required!</div>
                            </div>


                            <div class="col-md-6 mb-3" style="margin-left: 180px;">
                                <label for="ExerciseName">Exercise Name</label>
                                <asp:TextBox ID="txtExerciseSun" runat="server" CssClass="form-control" placeholder="Deadlift"></asp:TextBox>
                                <div class="invalid-feedback">Your Exercise is required!</div>
                            </div>


                            <br />

                            <div class="row">
                                <div class="col-md-5 mb-2" style="margin-left: 230px;">
                                    <label for="Sets">Sets for this exercise</label>
                                    <asp:TextBox ID="txtSetsSun" runat="server" type="number" CssClass="form-control" placeholder="3"></asp:TextBox>
                                    <div class="invalid-feedback">Sets are required!</div>
                                </div>
                            </div>
                            <div class="row">

                                <div class="col-md-5 mb-2" style="margin-left: 230px;">
                                    <label for="Reps">Reps for this exercise</label><br />
                                    <asp:TextBox ID="txtRepsSun" runat="server" type="number" CssClass="form-control" placeholder="8"></asp:TextBox>
                                    <div class="invalid-feedback">Reps are required!</div>
                                </div>
                            </div>

                            <asp:Button ID="btnAddSunday" runat="server" Text="Add Workout" OnClick="btnAddSunday_Click" />

                            <br />
                            <hr />
                        </div>


                        <div class="mb-3">
                        <input type="button" value="Create Program" id="btnCreate" style="width:100%; height:30px;" onclick="btnCreate_Click()" />
                        <input type="button" value="Back" id="btnBackToCreate" style="width:100%; height:30px;" onclick="btnBackToCreate_Click()" />
                         <asp:Button ID="btnBack" class="btn btn-md btn-light btn-block" runat="server" Text="Finish!" OnClick="btnBack_Click" />

                        <br />

<%--            <asp:Button ID="btnCreate" class="btn btn-md btn-light btn-block" runat="server" Text="Create Program" onclick="btnCreate_Click()" />--%>
                            </div>


                    </div>
                </div>
            </div>
        </div>
        <asp:HiddenField ID="hdn" runat="server"></asp:HiddenField>

    </form>


    <script>

        window.onload = function () {
            $("#divContent").hide();
            $("#btnBackToCreate").hide();
            if ($("#hdn").val() == "1") {
                $("#divContent").show();
                $("#programContent").hide();
                $("#btnCreate").hide();
                $("#btnBackToCreate").show();
            }
        }

        function btnCreate_Click() {

            var strURL = "https://localhost:44314/api/Fitness/addprogram";
            var date = new Date();
            var rb = $('input[name="rbDays"]:checked').val();
            var program = new Object();
            program.programName = $("#txtProgramName").val();
            program.dateAdded = date;
            program.description = $("#txtDesc").val();
            program.programType = $("#ddlType").val();
            program.programExperience = $("#ddlExperience").val();
            program.days = rb;
            program.Image = $("#txtImage").val();
            program.programLength = $("#txtLength").val();
            var d = true;

            var strInput = JSON.stringify(program);

            if (program.programName == "") {
                d = false;
            }
            if (program.description == "") {
                d = false;
            }

            if (program.programExperience == "") {
                d = false;
            }
            if (program.Image == "") {
                d = false;
            }
            if (program.programLength == 0) {
                d = false;
            }
 
            if (d === true) {
                $.ajax({
                    type: "POST",
                    url: strURL,
                    contentType: "application/json",
                    dataType: "json",
                    data: strInput,
                    success: function (data) {
                        if (data == false) {
                            alert("Program already exists!");
                        }
                        else {
                            $("#hdn").val("1");
                            $("#divContent").show();
                            $("#programContent").hide();
                            $("#btnCreate").hide();
                            $("#btnBackToCreate").show();
                        }

                    },
                    error: function (req, status, error) {
                        alert("error");
                    }

                });
            }
            else {
                alert("All fields must be filled in!");
            }

        }

        function btnBackToCreate_Click() {
            $("#btnCreate").show();
            $("#divContent").hide();
            $("#programContent").show();
            $("#btnBackToCreate").hide();
            $("#txtProgramName").val("");
            $("#txtDesc").val("");
            $("#txtImage").val("");
            $("#txtLength").val("");
        }

    </script>
</body>
</html>
