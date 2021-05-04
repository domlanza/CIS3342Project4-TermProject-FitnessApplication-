<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminMessage.aspx.cs" Inherits="Term_Project.AdminMessage" %>
<%@ Register Src="~/LogoutNav.ascx" TagPrefix="uc1" TagName="LogoutNav" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Email</title>
    <meta charset="UTF-8" />

    <meta name="viewport" content="width=device-width, initial-scale=1" />
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
    <!--===============================================================================================-->
    <link href="Css/EmailCSS.css" rel="stylesheet" />







</head>
<body>
    <form id="form1" runat="server">

        <div id="youShallNotPass" runat="server" class="text-center">
            <h2 class="text-center">You Must Log In To See This Site!</h2>
            <img src="Images2/ShallNotPass.gif" style="margin-top: 100px;" />
            <uc1:LogoutNav runat="server" ID="LogoutNav1" />

        </div>


        <div id="divContent" runat="server">
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
                    <uc1:LogoutNav runat="server" ID="LogoutNav2" />
                </div>
            </div>
      </nav>
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />

      <%--          end nav bar--%>

        </div>

<%--        NEW MAILBOX--%>
        <div id="containerContent" runat="server">
        <div class="container mb-10">
    <div class="row" >
        <div class="col-md-12 col-lg-8">
            <div class="card">
                <div class="card-body bg-primary text-white mailbox-widget pb-0">
                    <h2 class="text-white pb-3">Your Mailbox</h2>
                    <ul class="nav nav-tabs custom-tab border-bottom-0 mt-4" id="myTab" role="tablist">
                        <li class="nav-item">
                          <asp:Image ID="userAvatar" runat="server" ImageUrl="Images2/ivysaur.jpg" Width="100" Height="100" class="rounded" />

                            <span class="btn-group">
                            <a class="nav-link" id="inbox-tab" data-toggle="tab" aria-controls="inbox" href="#inbox" role="tab" aria-selected="true">
                    <asp:LinkButton ID="linkbtnInbox" runat="server" class="list-group-item list-group-item-action bg-dark text-light active" OnClick="linkbtnInbox_Click">Inbox</asp:LinkButton>
                            </a>

                   <a class="nav-link" id="sent-tab" data-toggle="tab" aria-controls="sent" href="#sent" role="tab" aria-selected="false">
                <asp:LinkButton ID="linkbtnSent" runat="server" class="list-group-item list-group-item-action bg-dark text-light" OnClick="linkbtnSent_Click">Sent</asp:LinkButton> 
                       </a>
                            </span>
                       </li>                    
                    </ul>
                </div>
                <div class="tab-content" id="myTabContent">
                    <div class="tab-pane fade active show" id="inbox" aria-labelledby="inbox-tab" role="tabpanel">
                        <div>
                            <div class="row p-4 no-gutters align-items-center">
                                <div class="col-sm-12 col-md-6">
                                    <h3 class="font-light mb-0"><i class="ti-email mr-2" runat="server" id="folderName">INBOX FOLDER</i></h3>
                                </div>
                                <div class="col-sm-12 col-md-6">
                                    <ul class="list-inline dl mb-0 float-left float-md-right">
                                        <li class="list-inline-item text-info mr-3">
                                            <a href="#">
                                        
                <asp:Button ID="btnCompose" runat="server" Text="Compose" class="btn btn-success" OnClick="btnCompose_Click" />
                                            </a>
                                        </li>

                                    </ul>
                                </div>
                            </div>
                            </div>
                        
                            <!-- Mail list-->
                            <div class="table-responsive">
                                <table class="table email-table no-wrap table-hover v-middle mb-0 font-14">
                                    <tbody>
                                         <asp:GridView ID="gvEmails" runat="server" AutoGenerateColumns="False" GridLines="Horizontal" CssClass="table table-hover" BorderStyle="None"  OnSelectedIndexChanged="gvEmails_SelectedIndexChanged" AutoGenerateSelectButton ="true">
                    <Columns>
                        <asp:TemplateField HeaderText="Select: ">
                            <ItemTemplate>
                                <asp:CheckBox ID="cbSelectEmail" runat="server" AutoPostBack="true" ></asp:CheckBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Sender" HeaderText="Sender: " />
                        <asp:BoundField DataField="Receiver" HeaderText="Receiver: " />
                        <asp:BoundField DataField="EmailSubject" HeaderText="Subject: " />
                        <asp:BoundField DataField="EmailBody" HeaderText="Content: " />
                        <asp:BoundField DataField="Time" HeaderText="CreatedTime: " />
                    </Columns>
                    <RowStyle VerticalAlign="Middle" />
                </asp:GridView>


                                    </tbody>
                                </table>
                            </div>
                        </div>
                    </div>

                   
                <div class="container-fluid">
 
                    <br />

                    <asp:Label ID="lblEmpty" runat="server" Text="Your Inbox Is Empty" ></asp:Label>

               

                 <div id="tbEmail" runat="server" class="container-fluid" style="margin-right: auto; margin-left: auto;">
                <h3>
                    <asp:Label ID="subjectID" runat="server" Text="" Visible="true"></asp:Label></h3>
                     <div id="showEmail" class="text-center">
                <table class="table table-borderless text-center">
                    <tbody>
                        <tr>
                            <td>
                                <asp:Label ID="lblCreateTime" runat="server" Text="CreatedTime: " style="font-weight:bold;"  class="mr-sm-2"></asp:Label></td>
                           
                        </tr>

                             <tr>
                            <td colspan="2">
                                <asp:Label ID="lblCreatedTime2" runat="server" Text="" class="mr-sm-2"></asp:Label></td>
                        </tr>
                        

                        <tr>
                            <td>
                                <asp:Label ID="lblFromWho" runat="server" Text="From: " style="font-weight:bold;" class="mr-sm-2"></asp:Label></td>
                             
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:Label ID="lblFromEmail" runat="server" Text="" class="mr-sm-2"></asp:Label></td>
                        </tr>
                        
                         <tr>
                            <td>
                                <asp:Label ID="lblTo" runat="server" Text="To: " style="font-weight:bold;" class="mr-sm-2"></asp:Label></td>
                             
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:Label ID="lblToWho" runat="server" Text="" class="mr-sm-2"></asp:Label></td>
                        </tr>

                        <tr>
                            <td>
                                <asp:Label ID="lblSubject1" runat="server" Text="Subject: " style="font-weight:bold;" class="mr-sm-2"></asp:Label></td>
                            
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:Label ID="lblSub" runat="server" Text="" class="mr-sm-2"></asp:Label></td>
                        </tr>


                        <tr>
                            <td>
                                <asp:Label ID="lblEmailBody" runat="server" Text="Body: " style="font-weight:bold;" class="mr-sm-2 "></asp:Label></td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:Label ID="lblBodyEmail" runat="server" Text="" class="mr-sm-2"></asp:Label></td>
                        </tr>
                    </tbody>
                </table>
                <asp:Button ID="btnBack2" runat="server" Text="Back" class="btn btn-primary" OnClick="btnBack2_Click" />
              </div>

            </div>

            </div>

                <div class="container-fluid">
                    <div id="emailContent" runat="server" class="container-fluid" visible="false">
                        <asp:Label ID="lblTitle" runat="server"><h3>New Message</h3></asp:Label>
                        <asp:Label ID="lblSendTo" runat="server" Text="To: " class="mr-sm-2"></asp:Label>
                        <asp:TextBox ID="txtEmailTo" runat="server" class="form-control my-2 my-sm-0" placeholder="Receiver" Width="300px"></asp:TextBox>
                        <br />
                        <asp:Label ID="lblSubject" runat="server" Text="Subject: " class="mr-sm-2"></asp:Label>
                        <asp:TextBox ID="txtSubject" runat="server" class="form-control my-2 my-sm-0" placeholder="Subject: " Width="300px"></asp:TextBox>
                        <br />
                        <asp:Label ID="lvlContent" runat="server" Text="Body: " class="mr-sm-2"></asp:Label>
                        <asp:TextBox ID="txtContent" runat="server" class="form-control my-2 my-sm-0" placeholder="Receiver" Height="200px" Width="300px" TextMode="MultiLine"></asp:TextBox>
                        <br />
                        <asp:Button ID="btnBack" runat="server" Text="Back" class="btn btn-primary" OnClick="btnBack_Click" />
                        <asp:Button ID="btnSend" runat="server" Text="Send" class="btn btn-primary" OnClick="btnSend_Click" />

                    </div>
                </div>
            </div>
        </div>
    </div>
        </div>

        </div>
    </form>
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
