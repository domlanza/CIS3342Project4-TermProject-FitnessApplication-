<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LogIn.aspx.cs" Inherits="Term_Project.LogIn" %>

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
        <script src="https://ajax.aspnetcdn.com/ajax/jQuery/jquery-3.3.1.min.js"></script>

</head>
<body>
	
         <header>
        <nav class="navbar navbar-expand-md navbar-dark bg-primary fixed-top " runat="server" id="headerNav">
            <a class="navbar-brand" href="LogIn.aspx">Moe's Fitness</a>
        </nav>
    </header>

    <br />
        <br />

	<div class="limiter">
		<div class="container-login100" style="background-image: url('images2/background3.jpg');">
			<div class="text-center mb-4">
				<form class="form-sigin" runat="server">
					<img id="mb-4"  src="Images2/Asset_4.png" width="130" height="130" /> 

                    <h1 class="h3 mt-2 mb-3 font-weight-normal">Login</h1>
                    <asp:HiddenField id="hdn" runat="server"></asp:HiddenField>

                    <div class ="validate-input mb-1" id="lblEmail" runat="server" data-validate ="Enter Email">
                          <asp:Label ID="lblinputEmailError" Visibile="false" runat="server"  Text="Please input a valid Email Address" ForeColor="Red" data-validate ="Enter Email" class="sr-only">Email address</asp:Label>
                          <asp:Textbox runat="server" CssClass="form-control input-md"  id="txtEmail" name="pass" placeholder="Email Address"></asp:Textbox>
                    </div>
                     <div class ="validate-input mb-2" id="lblPassword" runat="server" data-validate ="Enter password">
                          <asp:Label ID="lblInputPassError" Visibile="false" runat="server" Text="Please input a valid Password" ForeColor="Red"  data-validate ="Enter Email" class="sr-only">Email address</asp:Label>
                          <asp:Textbox type="password" runat="server" CssClass="form-control input-md"  id="txtPassword" name="pass" placeholder="Password"></asp:Textbox>
                    </div>
                      
				<%--	<div class="wrap-input100 validate-input" id="lblEmail" runat="server" data-validate = "Enter Email">
						 <asp:Label ID="lblinputEmailError" Visible="false" runat="server" Text="Please input a valid Email Address" ForeColor="Red"></asp:Label>
                         <asp:TextBox class="input100" runat="server" id="txtEmail" name="pass" placeholder="Email Address"></asp:TextBox>
						<span class="focus-input100" data-placeholder="&#xf207;"></span>
					</div>--%>

				<%--	<div class="wrap-input100 validate-input" runat="server" id="lblPassword" data-validate="Enter password">
				    <asp:Label ID="lblInputPassError" Visible="false" runat="server" Text="Please input a valid Password" ForeColor="Red"></asp:Label>
						<asp:TextBox class="input100" runat="server" type="password" id="txtPassword" name="pass" placeholder="Password"></asp:TextBox>
						<span class="focus-input100" data-placeholder="&#xf191;"></span>
					</div>--%>

                    <div class="d-inline bg-danger-primary text-white">
						<asp:Button ID="btnLogin" runat="server" class="btn btn-md btn-primary" Text="Login" type="submit" OnClick="btnLogin_Click"/>
 						<asp:Button ID="btnSignUp" runat="server" class="btn btn-md btn-primary" Text="Signup" OnClick="btnSignUp_Click"/>
                     </div>
                    <br />
                    	<div class="checkbox mt-2 mb-2">
                        <asp:CheckBox ID="cbRememberMe"  runat="server" AutoPostBack="True" /><p style="display:inline; color:black;"> Remember Me</p>
					</div>
					<div>
                        <p> <a href="ForgotPassword.aspx">
							Forgot Password? </a>
						<br />
                        <a href="Verification.aspx">
					    Verify Your Email </a>
                            </p>
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

    
	<script>
        var stats;          // global variable used to store the fetched data before it's needed
        var request;        // global variable used to store the XMLHttpRequest object used to handle AJAX.

        try {
            // Code for IE7+, Firefox, Chrome, Opera, Safari
            request = new XMLHttpRequest();
        }

        catch (try_older_microsoft) {
            try {
                // Code for IE6, IE5
                request = new ActiveXObject("Microsoft.XMLHTTP");
            }

            catch (other) {
                request = false;
                alert("Your browser doesn't support AJAX!");
            }
        }

        window.onload = function () {
            if (document.getElementById('txtEmail').value != "" && document.getElementById('txtPassword').value != "") {
                var email = document.getElementById('txtEmail').value;
                var password = document.getElementById('txtPassword').value;

                // Use the JavaScript proxy object to make an AJAX call to an ASP.NET Core 2.0 Web API
                request.open("GET", "https://localhost:44314/api/Fitness/User/" + "dom@dom.con" + "/" + "hi", true);

                //xmlhttp.setRequestHeader("Access-Control-Allow-Origin", "*");
                request.onreadystatechange = onComplete;
                document.getElementById('<%=hdn.ClientID%>').value = 1;

                request.send();
            }
        }

        // Callback function used to perform some action when an asynchronous request is completed
        function onComplete() {
            if (request.readyState == 4 && request.status == 200) {
                stats = request.responseText;
            }
    
        }
        

    </script>


</body>
</html>