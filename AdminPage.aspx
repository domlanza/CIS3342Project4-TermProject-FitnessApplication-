<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminPage.aspx.cs" Inherits="Term_Project.AdminPage" %>
<%@ Register Src="~/LogoutNav.ascx" TagPrefix="uc1" TagName="LogoutNav" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    
    	<meta name="viewport" content="width=device-width, initial-scale=1"/>
<!--===============================================================================================-->	
	<link rel="icon" type="image/png" href="images/icons/favicon.ico"/>
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="vendor/bootstrap/css/bootstrap.min.css"/>
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="fonts/font-awesome-4.7.0/css/font-awesome.min.css"/>
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="fonts/iconic/css/material-design-iconic-font.min.css"/>
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="vendor/animate/animate.css"/>
<!--===============================================================================================-->	
	<link rel="stylesheet" type="text/css" href="vendor/css-hamburgers/hamburgers.min.css"/>
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="vendor/animsition/css/animsition.min.css"/>
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="vendor/select2/select2.min.css"/>
<!--===============================================================================================-->	
	<link rel="stylesheet" type="text/css" href="vendor/daterangepicker/daterangepicker.css"/>
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="css/LogIn.css"/>
	<link rel="stylesheet" type="text/css" href="css/StyleSheet1.css"/>
<!--===============================================================================================-->
</head>
<body>
    <form id="form1" runat="server">

    <div id="youShallNotPass" runat="server" class="text-center">
    <h2 class="text-center">You Must Log In To See This Site!</h2>
    <img src="Images2/ShallNotPass.gif" style="margin-top: 100px;"/>
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
                    <li class="nav-item active">
                        <a class="nav-link" href="AdminPage.aspx">Home<span class="sr-only">(current)</span></a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="AdminSignUp.aspx">Create Admin</a>
                    </li>
                    <li class="nav-item">
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


        <%--heading--%>
                            <div class="d-sm-flex align-items-center justify-content-between mb-4 mt-3" id="headerContent" runat="server">
                        <h1 class="h3 mb-0 mt-5 ml-3 text-gray-800">Current Users</h1>
                    </div>
    
        <!-- Content Row -->
        <div class="row justify-content-center" runat="server" id="ContentID">
                <asp:GridView ID="gvManageAccounts" style="margin-left:auto; margin-right:auto;" runat="server" AutoGenerateColumns="False" CssClass="table table-hover" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" Width="90%">
                    <Columns>
                        <asp:TemplateField HeaderText="Select: ">
                            <ItemTemplate>
                                <asp:CheckBox ID="cbSelect" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:ImageField DataImageUrlField="UserImage" HeaderText="UserImage" ControlStyle-Width="100" ControlStyle-Height="100">
                            <ControlStyle Height="100px" Width="100px"></ControlStyle>
                        </asp:ImageField>
                         <asp:BoundField DataField="FirstName" HeaderText="UserName" />
                        <asp:BoundField DataField="LastName" HeaderText="LastName: " />
                        <asp:BoundField DataField="EmailAddress" HeaderText="EmailAddress" />
                        <asp:BoundField DataField="UserName" HeaderText="UserName" />
                        <asp:BoundField DataField="DateCreated" HeaderText="DateCreated:" />
                        <asp:BoundField DataField="userWeight" HeaderText="User Weight" />
                        <asp:BoundField DataField="userAge" HeaderText="User Age: " />
                        <asp:BoundField DataField="UserGoals" HeaderText="User Goals:" />
                        <asp:BoundField DataField="userTrainingType" HeaderText="User Training Type: " />
                        <asp:BoundField DataField="Experience" HeaderText="Experience:" />
                        <asp:BoundField DataField="amountOfDays" HeaderText="Amount Of Days:" />
                        <asp:BoundField DataField="programName" HeaderText="Program:" />

                    </Columns>
                    <FooterStyle BackColor="White" ForeColor="#000066" />
                    <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                    <RowStyle ForeColor="#000066" />
                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#007DBB" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#00547E" />
                </asp:GridView>



        </div>
    </form>

</body>
</html>
