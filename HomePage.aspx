<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="Term_Project.HomePage" %>
<%@ Register Src="~/LogoutNav.ascx" TagPrefix="uc1" TagName="LogoutNav" %>
<%@ Register Src="~/GridViewHomePage.ascx" TagPrefix="uc1" TagName="GridViewHomePage" %>



<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T" crossorigin="anonymous" />

</head>
<body>
    <form runat="server">
        <div id="youShallNotPass" runat="server" class="text-center">
            <h2 class="text-center">You Must Log In To See This Site!</h2>
            <img src="Images2/ShallNotPass.gif" style="margin-top: 100px;" />
            <uc1:LogoutNav runat="server" ID="LogoutNav1" />
        </div>
        <%--    nav bar start--%>
        <nav class="navbar navbar-expand-md navbar-dark fixed-top bg-primary" id="navBar" runat="server">
            <a class="navbar-brand" href="HomePage.aspx">Moe's Fitness</a>
            <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarsExampleDefault" aria-controls="navbarsExampleDefault" aria-expanded="false" aria-label="Toggle navigation">
                <span class="navbar-toggler-icon"></span>
            </button>

            <div class="collapse navbar-collapse" id="navbarsExampleDefault">
                <ul class="navbar-nav mr-auto">
                    <li class="nav-item active">
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
                    <li class="nav-item">
                        <a class="nav-link" href="MyProfilePage.aspx">My Profile</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="UserMessages.aspx">Customer Service</a>
                    </li>
                </ul>
                <div class="form-inline my-2 my-lg-0" runat="server">
                    <uc1:LogoutNav runat="server" ID="LogoutNav" />
                </div>
            </div>
        </nav>

        <br />
        <br />
  
        <%--          end nav bar--%>

        <div>
            <!-- Begin Page Content -->
            <div class="container-fluid text-center" id="ContentID" runat="server">

                <!-- Page Heading -->
                <div class="d-sm-flex align-items-center justify-content-between mb-4 mt-3">
                    <h1 class="h3 mb-0 mt-1 text-gray-800">Dashboard</h1>
                </div>

                <!-- Content Row -->
                    <div class="row">

                        <!-- Weight Card -->
                        <div class="col-xl-2 col-md-6 mb-4">
                            <div class="card border-left-primary shadow h-100 py-2">
                                <div class="card-body">
                                    <div class="row no-gutters align-items-center">
                                        <div class="col mr-2">
                                            <div class="text-xs font-weight-bold text-primary text-uppercase mb-1">
                                                Current Weight</div>
                                            <div class="h5 mb-0 font-weight-bold text-gray-800">
                                                <asp:Label ID="lblCurrentWeight" runat="server" Text="Label"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="col-auto">
                                            <i class="fas fa-calendar fa-2x text-gray-300"></i>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <!-- Goals card -->
                        <div class="col-xl-2 col-md-6 mb-4">
                            <div class="card border-left-primary shadow h-100 py-2">
                                <div class="card-body">
                                    <div class="row no-gutters align-items-center">
                                        <div class="col mr-2">
                                            <div class="text-xs font-weight-bold text-primary text-uppercase mb-1">
                                                Workout Goals
                                            </div>
                                            <div class="h5 mb-0 font-weight-bold text-gray-800">
                                                <asp:Label ID="lblGoals" runat="server" Text="Label"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="col-auto">
                                            <i class="fas fa-calendar fa-2x text-gray-300"></i>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <!-- Program card -->
                        <div class="col-xl-2 col-md-6 mb-4">
                            <div class="card border-left-success shadow h-100 py-2">
                                <div class="card-body">
                                    <div class="row no-gutters align-items-center">
                                        <div class="col mr-2">
                                            <div class="text-xs font-weight-bold text-success text-uppercase mb-1">
                                                You chose this program:
                                            </div>
                                            <div class="h5 mb-0 font-weight-bold text-gray-800">

                                                <asp:ScriptManager ID="ScriptManager1" runat="server" />
                                                <asp:Timer runat="server" ID="UpdateTimer" Interval="1000" OnTick="UpdateTimer_Tick" />
                                                <asp:UpdatePanel runat="server" ID="TimedPanel" UpdateMode="Conditional">
                                                    <Triggers>
                                                        <asp:AsyncPostBackTrigger ControlID="UpdateTimer" EventName="Tick" />
                                                    </Triggers>
                                                    <ContentTemplate>
                                                        <asp:Label runat="server" ID="DateStampLabel" />
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>

                                            </div>
                                        </div>
                                        <div class="col-auto">
                                            <i class="fas fa-dollar-sign fa-2x text-gray-300"></i>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <!-- Percentage card -->
                        <div class="col-xl-2 col-md-6 mb-4">
                            <div class="card border-left-info shadow h-100 py-2">
                                <div class="card-body">
                                    <div class="row no-gutters align-items-center">
                                        <div class="col mr-2">
                                            <div class="text-xs font-weight-bold text-info text-uppercase mb-1">
                                                <asp:Label ID="lblProgram" runat="server" Text="Label"></asp:Label>
                                            </div>
                                            <div class="row no-gutters align-items-center">
                                                <div class="col-auto">
                                                    <div class="h5 mb-0 mr-3 font-weight-bold text-gray-800">
                                                        <asp:Label ID="lblCompletionPercentage" runat="server" Text="Label"></asp:Label>                                                       
                                                    </div>
                                                </div>
                                                <div class="col">
                                                    <div class="progress progress-sm mr-2">
                                                        <div class="progress-bar bg-info" runat="server" id="progressBar" role="progressbar"
                                                            style="width: 60%" aria-valuenow="70" aria-valuemin="0"
                                                            aria-valuemax="100"></div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-auto">
                                            <i class="fas fa-clipboard-list fa-2x text-gray-300"></i>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <!-- Days left card -->
                        <div class="col-xl-2 col-md-6 mb-4">
                            <div class="card border-left-warning shadow h-100 py-2">
                                <div class="card-body">
                                    <div class="row no-gutters align-items-center">
                                        <div class="col mr-2">
                                            <div class="text-xs font-weight-bold text-warning text-uppercase mb-1">
                                                Days left of program:</div>
                                            <div class="h5 mb-0 font-weight-bold text-gray-800">
                                                <asp:Label ID="lblDaysLeft" runat="server" Text=""></asp:Label>
                                            </div>
                                        </div>
                                        <div class="col-auto">
                                            <i class="fas fa-comments fa-2x text-gray-300"></i>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                    <!-- Content Row -->
                    <div class="row">
                        <center>
                        <div class="col-lg-8 mb-4">

                            <!-- Workout Gridview -->
                            <uc1:GridViewHomePage runat="server" id="GridViewHomePage" />

                            <!-- Welcome Card -->
                            <div class="card shadow mb-4">
                                <div class="card-header py-3">
                                    <h6 class="m-0 font-weight-bold text-primary">Welcome Message</h6>
                                </div>
                                <div class="card-body">
                                    <p>Welcome To Moe's Fitness! Here you will find all the help you will need in all things regarding fitness.
                                        There are multiple workout programs for you, 24/7 trainer support, and a site created by the best fitness mind in the world!
                                    </p>
                                    <p class="mb-0">I have been involved in the world of fitness for over 21 years, and I'm incredibly proud to show the world
                                        how I succeeded. This site has all my knowledge and I hope it can help you as well!
                                    </p>
                                </div>
                            </div>

                        </div>
                            </center>
                    </div>

                </div>
            <!-- /.container-fluid -->

        </div>
            <!-- End of Main Content -->      
    </form> 

</body>
</html>
