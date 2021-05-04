<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ForgotPassword.aspx.cs" Inherits="Term_Project.ForgotPassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
	<title>Moe's Fitness</title>
	<meta charset="UTF-8"/>
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

    <header>
        <nav class="navbar navbar-expand-md navbar-dark bg-primary fixed-top " runat="server" id="headerNav">
            <a class="navbar-brand" href="LogIn.aspx">Moe's Fitness</a>
        </nav>
    </header>

    <div class="limiter">
        <div class="container-login100" style="background-image: url('images2/background3.jpg');">
            <div class="text-center mb-4">
                <form class="form-sigin" runat="server">
                    <img id="imgLogo" class="img-responsive center-block" src="Images2/Asset_4.png" width="130" height="130" style="margin-right: 100px;" />
                    <h1 class="h3 mt-2 mb-1 font-weight-normal">Forgot Password?</h1>
                    <br />


                    <div class="validate-input mb-1" id="lblEmail" runat="server" data-validate="Enter Email">
                        <asp:Label ID="lblEmail2" runat="server" Text="Enter Email"></asp:Label>
                        <br />
                        <asp:Label ID="lblinputEmailError" Visible="false" runat="server" Text="Please input a valid Email Address" ForeColor="Red"></asp:Label>
                        <asp:TextBox runat="server" CssClass="form-control input-md" ID="txtEmail" name="pass" placeholder="Email Address"></asp:TextBox>
                    </div>

                    <%--					<div class="container">
                    <asp:Label ID="lblEmail2" runat="server" Text="Enter Email" style="margin-left:40px;"></asp:Label>
                    <asp:Label ID="lblinputEmailError" Visible="false" runat="server" Text="Please input a valid Email Address" ForeColor="Red"></asp:Label>
                    <asp:TextBox class="input100"  runat="server" ID="txtEmail" name="pass" placeholder="Email Address"></asp:TextBox>
                    <span class="focus-input100" data-placeholder="&#xf207;"></span>
						</div>--%>


                    <div class="container">
                        <asp:Label ID="lblSQ1" Visible="false" runat="server"></asp:Label>

                        <asp:Label ID="lblInputPassError" Visible="false" runat="server" Text="Please input a valid answer" ForeColor="Red"></asp:Label>
                        <asp:TextBox class="form-control" Visible="false" runat="server" ID="txtSQ" name="pass" placeholder="New Password"></asp:TextBox>
                    </div>

                    <div class="container">
                        <asp:Label ID="lblPass" Visible="false" runat="server">New Password</asp:Label>
                        <asp:Label ID="lblPassError" Visible="false" runat="server" Text="Please input a password" ForeColor="Red"></asp:Label>
                        <asp:TextBox class="form-control" Visible="false" runat="server" ID="txtPass" name="pass" placeholder="New Password"></asp:TextBox>
                    </div>

                    <div class="container">
                        <asp:Label ID="lblReenterPass" Visible="false" runat="server">Reenter Password</asp:Label>
                        <asp:Label ID="lblReenterPassError" Visible="false" runat="server" Text="Please input a password" ForeColor="Red"></asp:Label>
                        <asp:TextBox class="form-control" Visible="false" runat="server" ID="txtPass2" name="pass" placeholder="Reenter Password"></asp:TextBox>
                    </div>

                    <div class="d-inline bg-danger-primary text-white">

                        <asp:Button ID="btnContinue" runat="server" class="btn btn-md btn-primary" Text="Continue" OnClick="btnContinue_Click" />
                        <br />
                        <asp:Button ID="btnContinue2" runat="server" Visible="false" class="btn btn-md btn-primary" Text="Continue" OnClick="btnContinue2_Click" />
                        <br />



                        <asp:Button ID="btnReset" runat="server" Visible="false" class="btn btn-md btn-primary" Text="Reset Password" OnClick="btnReset_Click" />


                        <div class="text-center p-t-90">
                            <a class="txt1" id="btnBackToHome2" runat="server" href="LogIn.aspx">Back To Sign-In</a>
                        </div>

                        <asp:Button ID="btnBack" runat="server" class="btn btn-md btn-primary" Text="Back" OnClick="btnBack_Click" Visible="false" />


                        <asp:Button ID="btnBack2" runat="server" class="btn btn-md btn-primary" Text="Back" OnClick="btnBack2_Click" Visible="false" />

                        <asp:Button ID="btnBackToLogIn" runat="server" class="btn btn-md btn-primary" Text="Back To Login" OnClick="btnBackToLogIn_Click" Visible="true" />

                    </div>

                </form>
            </div>
        </div>
    </div>


    <!--===============================================================================================-->
    <script src="vendor/jquery/jquery-3.2.1.min.js"></script>
    <!--===============================================================================================-->
    <script src="vendor/animsition/js/animsition.min.js"></script>
    <!--===============================================================================================-->
    <script src="vendor/bootstrap/js/popper.js"></script>
    <script src="vendor/bootstrap/js/bootstrap.min.js"></script>
    <!--===============================================================================================-->
    <script src="vendor/select2/select2.min.js"></script>
    <!--===============================================================================================-->
    <script src="vendor/daterangepicker/moment.min.js"></script>
    <script src="vendor/daterangepicker/daterangepicker.js"></script>
    <!--===============================================================================================-->
    <script src="vendor/countdowntime/countdowntime.js"></script>
    <!--===============================================================================================-->
    <script src="js/main.js"></script>

</body>
</html>