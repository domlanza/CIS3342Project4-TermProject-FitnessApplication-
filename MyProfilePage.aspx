<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MyProfilePage.aspx.cs" Inherits="Term_Project.MyProfilePage" %>

<%@ Register Src="~/LogOutNav.ascx" TagPrefix="uc1" TagName="LogOutNav" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T" crossorigin="anonymous" />

</head>
<body>
    <form id="form1" runat="server">
        <div id="youShallNotPass" runat="server" class="text-center" visible="false">
            <h2 class="text-center">You Must Log In To See This Site!</h2>
            <img src="Images2/ShallNotPass.gif" style="margin-top: 100px;" />
            <uc1:LogOutNav runat="server" ID="LogoutNav1" />
        </div>
        <%--    nav bar start--%>
        <nav class="navbar navbar-expand-md navbar-dark fixed-top bg-primary" id="navBar" runat="server">
            <a class="navbar-brand" href="#">Moe's Fitness</a>
            <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarsExampleDefault" aria-controls="navbarsExampleDefault" aria-expanded="false" aria-label="Toggle navigation">
                <span class="navbar-toggler-icon"></span>
            </button>

            <div class="collapse navbar-collapse" id="navbarsExampleDefault">
                <ul class="navbar-nav mr-auto">
                    <li class="nav-item">
                        <a class="nav-link" href="HomePage.aspx">Home <span class="sr-only">(current)</span></a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="Explore2.aspx">Explore Workout Programs</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="UserSavedPrograms.aspx">Saved Programs</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="MyProgram.aspx">My Programs</a>
                    </li>
                    <li class="nav-item active">
                        <a class="nav-link" href="MyProfilePage.aspx">My Profile</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="UserMessages.aspx">Customer Service</a>
                    </li>
                </ul>
                <div class="form-inline my-2 my-lg-0" runat="server">
                    <uc1:LogOutNav runat="server" ID="LogOutNav" />

                </div>
            </div>
        </nav>
        <br />
        <br />
        <%--          end nav bar--%>

        <div id="divContent" runat="server">
        <div class="d-sm-flex align-items-center justify-content-between mb-4 mt-3 ml-3">
            <h1 class="h3 mb-0 mt-1 text-gray-800">Profile Page</h1>
        </div>

        <div class="col d-flex justify-content-center mb-4">
       <div id="FirstCard" runat="server" class="text-center" visible="true">


        <div class="card" style="width:18rem">
            <div class="card-header">
                User Profile
            </div>
            <div class="card-body">
                <h5>
                <asp:Label ID="lblProfileUserName" class="card-title" runat="server" Text="Label"></asp:Label>
                </h5>

                <asp:Image ID="userAvatar" runat="server" ImageUrl="Images2/ivysaur.jpg" Width="100" Height="100" class="rounded" />

                <h6>
                <asp:Label ID="lblExperience" class="card-text" runat="server" Text="Label"></asp:Label>
                </h6>

                <h6>
                <asp:Label ID="lblType" class="card-text"  runat="server" Text="Label"></asp:Label>
                </h6>

                <h6>

                <asp:Label ID="lblUserWeight" class="card-text"  runat="server" Text="Label"></asp:Label>
                </h6>

                 <h6>
                 <asp:Label ID="lblUserAge" class="card-text"  runat="server" Text="Label"></asp:Label>
                </h6>

                 <h6>
                 <asp:Label ID="lblUserGoals" class="card-text" runat="server" Text="Label"></asp:Label>
                </h6>

                <asp:Button ID="btnEditProfile" class="btn btn-primary" runat="server" Text="Edit Profile" OnClick="btnEditProfile_Click" />
            </div>
        </div>
        </div>
            </div>


        <div class="col d-flex justify-content-center mb-4">
        <div id="secondCard" runat="server" style="width:36rem" class="text-center" visible="false">
             <div class="card">
            <div class="card-header">
               Edit User Profile
            </div>
            <div class="card-body">
                <h5>
                <asp:Label ID="lblEditInformation" class="card-title" runat="server" Text="Edit Your Profile Information"></asp:Label>
                    </h5>

<%--
                //Password
                //Weight
                //Age
                //Goals--%>


                         <div class="row">
                        <div class="col-md-6 mb-3">
                            <label for="Password">Password</label>
                            <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" placeholder="xxxxxxx"></asp:TextBox>
                            <div class="invalid-feedback">A new password is required!</div>
                        </div>

                     <div class="col-md-6 mb-3">
                            <label for="Password">Password</label>
                            <asp:TextBox ID="txtPass2" runat="server" CssClass="form-control" placeholder="xxxxxxx"></asp:TextBox>
                            <div class="invalid-feedback">A new password is required!</div>
                        </div>
   </div>

<%--                    </div>--%>
                    <br />

           <asp:Button ID="btnSaveChanges" class="btn btn-primary btn-sm" runat="server" Text="Save Changes" OnClick="btnSaveChanges_Click" />

                 <hr />
                    <br />

                 <div class="form-check">
                     <div class="align-text: center">
                        <label for="UserType">Would you like our assistance in finding you the best possible workout?</label>
                        <br />

                        <asp:RadioButtonList ID="rbAnswer" CssClass="radioButtonList" AutoPostback="true" runat="server"  RepeatDirection="Vertical" OnSelectedIndexChanged="rbAnswer_SelectedIndexChanged" >
                            <asp:ListItem Value="Yes">Yes</asp:ListItem>
                            <asp:ListItem Value="No"  Selected="True">No</asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                </div>


                        <%--        ------------------------------------------ Goal Question-------------------------------------------------------%>

                        <div class="row" runat="server" visible="false" id="Questions2">
                            <div class="col mb-3">
                                <asp:Label ID="LabelGoals" runat="server"  Text="What are your fitness goals"></asp:Label>

                                <asp:DropDownList ID="ddlGoals" runat="server" CssClass="form-control-sm"  >
                                    <asp:ListItem Selected="True">Gain Weight?</asp:ListItem>
                                    <asp:ListItem>Lose Weight</asp:ListItem>
                                    <asp:ListItem>Maintain Weight</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <br />

                        </div>

                        <%--        ------------------------------------------ How many days a week question Question-------------------------------------------------------%>


                        <div class="row" runat="server" visible="false" id="Questions3">
                            <div class="col mb-3 ">
                                <asp:Label ID="DaysAWeekProgram" runat="server" Text="How many days a week would you look your program to be?"></asp:Label>
                                <asp:DropDownList ID="ddlDays" runat="server" CssClass="form-control-sm" >
                                    <asp:ListItem Selected="True" Value="3">3</asp:ListItem>
                                    <asp:ListItem Value="5">4-5</asp:ListItem>
                                    <asp:ListItem Value="7">6-7</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <br />

                        </div>


                <%--                  ----------------------------------------  Type of Training Question--%>
                <div class="row" runat="server" visible="false" id="Questions5">
                    <div class="col mb-3">
                        <asp:Label ID="lblTypeOfTraining" runat="server" Text="Type of Training?"></asp:Label>
                        <asp:DropDownList ID="ddlTraining" runat="server" CssClass="form-control-sm" >
                            <asp:ListItem Selected="True">Hypertrophy (High Repitions)</asp:ListItem>
                            <asp:ListItem>Strength (Lower Repitions)</asp:ListItem>
                            <asp:ListItem>Both</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <br />


                    <br />

                </div>
  <%--                  ----------------------------------------  Age and weight Questions--%>
                <div class="row" runat="server" visible="false" id="Questions6">

                    <div class="col-md-6 mb-3">
                        <label for="Weight">Your Weight</label><br />
                        <asp:TextBox ID="txtWeight" runat="server" type="number" CssClass="form-control" placeholder="135lbs" value="150"></asp:TextBox>
                        <div class="invalid-feedback">Your weight is required</div>
                    </div>

                    <br />

                    <div class="row">
                        <div class="col-md-6 mb-3">
                            <label for="Age">Your Age</label>
                            <asp:TextBox ID="txtAge" runat="server" type="number" CssClass="form-control" placeholder="25" value="16"></asp:TextBox>
                            <div class="invalid-feedback">Your age is required!</div>
                        </div>
                    </div>

                </div>
    <%--    ----------------------------------------  Experience Questions--%>

                <div class="row" runat="server" visible="false" id="Questions7">
                        <div class="col-md-6 mb-3">
                        <label for="Avatar">What is your experience level?</label><br />
                        <asp:Image ID="profilePicture" runat="server" ImageUrl="../Images2/beginnerStock.png" Width="110" Height="110" class="rounded" />
                        <asp:DropDownList ID="ddlImage" runat="server" AutoPostBack="true" CssClass="form-control" OnSelectedIndexChanged="ddlImage_SelectedIndexChanged">
                            <asp:ListItem Selected="True" Value="Beginner">Beginner</asp:ListItem>
                            <asp:ListItem Value="Intermediate">Intermediate</asp:ListItem>
                            <asp:ListItem Value="Advanced">Advanced</asp:ListItem>
                        </asp:DropDownList>
                        </div>
                </div>
                <br />


                <asp:Button ID="btnSaveAll" class="btn btn-primary btn-sm" runat="server" Visible="false" Text="Save All" OnClick="btnSaveAll_Click" />

            </div>
             </div>
        </div>
        </div>
        </div>
    </form>
</body>
</html>
