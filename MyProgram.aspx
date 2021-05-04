<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MyProgram.aspx.cs" Inherits="Term_Project.MyProgram" %>
<%@ Register Src="~/LogoutNav.ascx" TagPrefix="uc1" TagName="LogoutNav" %>


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
                     <a class="nav-link" href="#">My Profile</a>
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
        <br />
        <%--          end nav bar--%>

        <div class="col d-flex justify-content-center">
            <!-- Begin Page Content -->
            <div class="container-fluid" id="ContentID" runat="server">

                <!-- Page Heading -->
                <div class="d-sm-flex align-items-center justify-content-between mb-4">
                    <h1 class="h3 mb-0 text-gray-800">My Program</h1>
                </div>

                <!-- Content Row -->
                <div class="row"  >

                    <!-- Content Row -->
                    <div class="row" style="margin-left:auto; margin-right:auto;">
                        <center>
                        <div class="col mb-4">

                            <!-- Illustrations -->
                            <div class="card shadow mb-4">
                                <div class="card-header">
                                    <h6 id="h6Day" runat="server" class="m-0 font-weight-bold text-primary">Your Program</h6>
                                </div>
                                <div class="card-body">
                                   <div style="text-align: center; margin-left:20rem; margin-right:20rem;">

                        <table>
                
                <asp:Repeater ID="rptPrograms" runat="server">
                    <ItemTemplate>

                        <tr>

                            <td>
                                <asp:Label ID="lblProgramID" visible="false" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ProgramID") %>'></asp:Label>

                            </td>
                        </tr>
                        <tr>

                            <td>
                                <asp:Image ID="lblProgramImage" Height="100px" Width="100px" runat="server" ImageUrl='<%# Eval("ProgramImage") %>' />

                            </td>
                        </tr>

                        <tr>

                            <td>
                                <asp:Label ID="lblProgramName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ProgramName") %>'></asp:Label>
                            </td>
                        </tr>
                        <tr>

                            <td>
                                <asp:Label ID="lblProgramDesc" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Description") %>'></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblProgramType" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ProgramType") %>'></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblProgramExperience" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ProgramExperience") %>'></asp:Label>
                            </td>
                        </tr>
                        <tr>

                            <td>
                                <asp:Label ID="lblAmountOfDays" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "AmountOfDays") %>'></asp:Label>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </table>                               

            </div>
                                </div>
                            </div>
                        </div>
                            </center>
                    </div>

                </div>


                <%--        List View for each individual Workout and Program--%>

        <div class="album py-5 bg-light">
            <div class="container">
                <div class="row">
                        <!-- Illustrations -->
                    <div class="col-md-3">

                        <div class="card shadow mb-3">
                            <div class="card-header py-3">
                                <h6 id="h1" runat="server" class="m-0 font-weight-bold text-primary">Monday</h6>
                            </div>
                            <div class="card-body" style="height: auto; width: 15rem">

                                <asp:ListView ID="lvMonday" Visible="true" runat="server" ItemPlaceholderID="PlaceHolder1">
                                    <ItemTemplate>
                                        <strong>Exercise Name: </strong>
                                        <asp:Label runat="server" ID="ExerciseName" Text='<%# Eval("ExerciseName") %>'></asp:Label>
                                        <br />
                                        <strong>Sets: </strong>
                                        <asp:Label runat="server" ID="Sets" Text='<%# Eval("Sets") %>'></asp:Label>
                                        <br />
                                        <strong>Reps: </strong>
                                        <asp:Label runat="server" ID="Reps" Text='<%# Eval("Reps") %>'></asp:Label>
                                        <br />
                                    </ItemTemplate>
                                    <LayoutTemplate>
                                        <asp:PlaceHolder runat="server" ID="PlaceHolder1"></asp:PlaceHolder>
                                    </LayoutTemplate>
                                </asp:ListView>
                            </div>
                        </div>
                    </div>
                    <!-- Second Card -->
                    <div class="col-md-3">

                        <div class="card shadow mb-3">
                            <div class="card-header py-3">
                                <h6 id="h2" runat="server" class="m-0 font-weight-bold text-primary">Tuesday</h6>
                            </div>
                            <div class="card-body" style="height: auto; width: 15rem">

                                <asp:ListView ID="lvTuesday" Visible="true" runat="server" ItemPlaceholderID="PlaceHolder1">
                                    <ItemTemplate>
                                        <strong>Exercise Name: </strong>
                                        <asp:Label runat="server" ID="ExerciseName" Text='<%# Eval("ExerciseName") %>'></asp:Label>
                                        <br />
                                        <strong>Sets: </strong>
                                        <asp:Label runat="server" ID="Sets" Text='<%# Eval("Sets") %>'></asp:Label>
                                        <br />
                                        <strong>Reps: </strong>
                                        <asp:Label runat="server" ID="Reps" Text='<%# Eval("Reps") %>'></asp:Label>
                                        <br />
                                    </ItemTemplate>
                                    <LayoutTemplate>
                                        <asp:PlaceHolder runat="server" ID="PlaceHolder1"></asp:PlaceHolder>
                                    </LayoutTemplate>
                                </asp:ListView>
                            </div>
                        </div>
                    </div>
                    <!-- Third Card -->
                    <div class="col-md-3">

                        <div class="card shadow mb-3">
                            <div class="card-header py-3">
                                <h6 id="h3" runat="server" class="m-0 font-weight-bold text-primary">Wednesday</h6>
                            </div>
                            <div class="card-body" style="height: auto; width: 15rem">

                                <asp:ListView ID="lvWednesday" Visible="true" runat="server" ItemPlaceholderID="PlaceHolder1">
                                    <ItemTemplate>
                                        <strong>Exercise Name: </strong>
                                        <asp:Label runat="server" ID="ExerciseName" Text='<%# Eval("ExerciseName") %>'></asp:Label>
                                        <br />
                                        <strong>Sets: </strong>
                                        <asp:Label runat="server" ID="Sets" Text='<%# Eval("Sets") %>'></asp:Label>
                                        <br />
                                        <strong>Reps: </strong>
                                        <asp:Label runat="server" ID="Reps" Text='<%# Eval("Reps") %>'></asp:Label>
                                        <br />
                                    </ItemTemplate>
                                    <LayoutTemplate>
                                        <asp:PlaceHolder runat="server" ID="PlaceHolder1"></asp:PlaceHolder>
                                    </LayoutTemplate>
                                </asp:ListView>
                            </div>
                        </div>
                    </div>
                        <!--Fourth Card -->
                    <div class="col-md-3">

                        <div class="card shadow mb-3">
                            <div class="card-header py-3">
                                <h6 id="h4" runat="server" class="m-0 font-weight-bold text-primary">Thursday</h6>
                            </div>
                            <div class="card-body" style="height: auto; width: 15rem">

                                <asp:ListView ID="lvThursday" Visible="true" runat="server" ItemPlaceholderID="PlaceHolder1">
                                    <ItemTemplate>
                                        <strong>Exercise Name: </strong>
                                        <asp:Label runat="server" ID="ExerciseName" Text='<%# Eval("ExerciseName") %>'></asp:Label>
                                        <br />
                                        <strong>Sets: </strong>
                                        <asp:Label runat="server" ID="Sets" Text='<%# Eval("Sets") %>'></asp:Label>
                                        <br />
                                        <strong>Reps: </strong>
                                        <asp:Label runat="server" ID="Reps" Text='<%# Eval("Reps") %>'></asp:Label>
                                        <br />
                                    </ItemTemplate>
                                    <LayoutTemplate>
                                        <asp:PlaceHolder runat="server" ID="PlaceHolder1"></asp:PlaceHolder>
                                    </LayoutTemplate>
                                </asp:ListView>
                            </div>
                        </div>
                    </div>
                </div>


                <div class="row">
                    <!-- Illustrations -->
                    <div class="col-md-3">

                        <div class="card shadow mb-3">
                            <div class="card-header py-3">
                                <h6 id="h5" runat="server" class="m-0 font-weight-bold text-primary">Friday</h6>
                            </div>
                            <div class="card-body" style="height: auto; width: 15rem">

                                <asp:ListView ID="lvFriday" Visible="true" runat="server" ItemPlaceholderID="PlaceHolder1">
                                    <ItemTemplate>
                                        <strong>Exercise Name: </strong>
                                        <asp:Label runat="server" ID="ExerciseName" Text='<%# Eval("ExerciseName") %>'></asp:Label>
                                        <br />
                                        <strong>Sets: </strong>
                                        <asp:Label runat="server" ID="Sets" Text='<%# Eval("Sets") %>'></asp:Label>
                                        <br />
                                        <strong>Reps: </strong>
                                        <asp:Label runat="server" ID="Reps" Text='<%# Eval("Reps") %>'></asp:Label>
                                        <br />
                                    </ItemTemplate>
                                    <LayoutTemplate>
                                        <asp:PlaceHolder runat="server" ID="PlaceHolder1"></asp:PlaceHolder>
                                    </LayoutTemplate>
                                </asp:ListView>
                            </div>
                        </div>
                    </div>
                    <!-- Second Card -->
                    <div class="col-md-3">

                        <div class="card shadow mb-3">
                            <div class="card-header py-3">
                                <h6 id="h6" runat="server" class="m-0 font-weight-bold text-primary">Saturday</h6>
                            </div>
                            <div class="card-body" style="height: auto; width: 15rem">

                                <asp:ListView ID="lvSaturday" Visible="true" runat="server" ItemPlaceholderID="PlaceHolder1">
                                    <ItemTemplate>
                                        <strong>Exercise Name: </strong>
                                        <asp:Label runat="server" ID="ExerciseName" Text='<%# Eval("ExerciseName") %>'></asp:Label>
                                        <br />
                                        <strong>Sets: </strong>
                                        <asp:Label runat="server" ID="Sets" Text='<%# Eval("Sets") %>'></asp:Label>
                                        <br />
                                        <strong>Reps: </strong>
                                        <asp:Label runat="server" ID="Reps" Text='<%# Eval("Reps") %>'></asp:Label>
                                        <br />
                                    </ItemTemplate>
                                    <LayoutTemplate>
                                        <asp:PlaceHolder runat="server" ID="PlaceHolder1"></asp:PlaceHolder>
                                    </LayoutTemplate>
                                </asp:ListView>
                            </div>
                        </div>
                    </div>
                    <!-- Third Card -->
                    <div class="col-md-3">

                        <div class="card shadow mb-3">
                            <div class="card-header py-3">
                                <h6 id="h7" runat="server" class="m-0 font-weight-bold text-primary">Sunday</h6>
                            </div>
                            <div class="card-body" style="height: auto; width: 15rem">

                                <asp:ListView ID="lvSunday" Visible="true" runat="server" ItemPlaceholderID="PlaceHolder1">
                                    <ItemTemplate>
                                        <strong>Exercise Name: </strong>
                                        <asp:Label runat="server" ID="ExerciseName" Text='<%# Eval("ExerciseName") %>'></asp:Label>
                                        <br />
                                        <strong>Sets: </strong>
                                        <asp:Label runat="server" ID="Sets" Text='<%# Eval("Sets") %>'></asp:Label>
                                        <br />
                                        <strong>Reps: </strong>
                                        <asp:Label runat="server" ID="Reps" Text='<%# Eval("Reps") %>'></asp:Label>
                                        <br />
                                    </ItemTemplate>
                                    <LayoutTemplate>
                                        <asp:PlaceHolder runat="server" ID="PlaceHolder1"></asp:PlaceHolder>
                                    </LayoutTemplate>
                                </asp:ListView>
                            </div>
                        </div>
                    </div>              
                </div>
            </div>
        </div>




                <!-- /.container-fluid -->

            </div>
            <!-- End of Main Content -->
            <br>
        </div>
    </form>

</body>
</html>

