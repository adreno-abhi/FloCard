<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FlocardForm.aspx.cs" Inherits="FloCard.FlocardForm" %>
<%@ OutputCache NoStore="true" Duration="1" VaryByParam="*"   %>
<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="utf-8" />
    <link rel="apple-touch-icon" sizes="76x76" href="assets/img/apple-icon.png">
    <link rel="icon" type="image/png" href="assets/img/favicon.png">
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
    <title>FloCard
  </title>
    <meta content='width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=0, shrink-to-fit=no' name='viewport' />
    <!--     Fonts and icons     -->
    <link rel="stylesheet" type="text/css" href="https://fonts.googleapis.com/css?family=Roboto:300,400,500,700|Roboto+Slab:400,700|Material+Icons" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/font-awesome/latest/css/font-awesome.min.css">
    <!-- CSS Files -->
    <link href="assets/css/material-kit.css?v=2.0.4" rel="stylesheet" />
    <!-- CSS Just for demo purpose, don't include it in your project -->
    <link href="assets/demo/demo.css" rel="stylesheet" />
    <script type = "text/javascript">
        function Confirm() {
            var confirm_value = document.createElement("input");
            confirm_value.type = "hidden";
            confirm_value.name = "confirm_value";
            if (confirm("I agree to give explicit permissions to store my data on FLO Blockchain.")) {
               confirm_value.value = "Yes";
            } else {
                confirm_value.value = "No";
            }
            document.forms[0].appendChild(confirm_value);
        }
    </script>
</head>

<body class="login-page sidebar-collapse">
    <nav class="navbar navbar-transparent navbar-color-on-scroll fixed-top navbar-expand-lg" color-on-scroll="100" id="sectionsNav">
        <div class="container">
            <div class="navbar-translate">
                <a class="navbar-brand" href="#">
                    <img src="assets/img/logo-black.png" height="100%" />
                    FloCard (CE) </a>

            </div>

        </div>
    </nav>
    <div class="page-header header-filter" style="background-image: url('assets/img/img.jpg'); background-size: cover; background-position: top center;">
        <div class="container">
            <div class="row">
                <div class="col-lg-8 ml-auto mr-auto">
                    <div class="card card-login">
                        <form class="form" method="" action="" runat="server">
                            <div class="card-header card-header-primary text-center">
                                <h4 class="card-title">FloCard Details 
                                    <img src="assets/img/logo-v2.png" height="40" class="pull-right" style="padding-right: 30px;" /></h4>
                               <small style="color:white"> <asp:Label ID="lblTransId" runat="server" Text=""></asp:Label></small>
                            </div>
                            <div class="card-body">
                                <div class="row">
                                    <div class="col-lg-4 ml-auto mr-auto" style="padding-top: 50px;">
                                        <img src="" id="usrImg" runat="server" height="200">
                                    </div>
                                    <div class="col-lg-8 ml-auto mr-auto">
                                        <div class="input-group">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text">
                                                    <i class="material-icons">face</i>
                                                </span>
                                            </div>
                                            <input type="text" class="form-control" placeholder="Name" id="txtName" runat="server">
                                        </div>
                                        <div class="input-group">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text">
                                                    <i class="material-icons">description</i>
                                                </span>
                                            </div>
                                            <input type="text" class="form-control" placeholder="Header" id="txtHeader" runat="server">
                                        </div>
                                        <div class="input-group">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text">
                                                    <i class="material-icons">email</i>
                                                </span>
                                            </div>
                                            <input type="email" class="form-control" placeholder="Email" id="txtEmail" runat="server">
                                        </div>
                                        <div class="input-group">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text">
                                                    <i class="material-icons">phone</i>
                                                </span>
                                            </div>
                                            <input type="phone" class="form-control" placeholder="Phone" id="txtPhone" runat="server">
                                        </div>
                                        <div class="row">
                                            <asp:HiddenField ID="liurlctrl" runat="server" />   
                                            <asp:HiddenField ID="picurlctrl" runat="server" />
                                            <div class="col-6">
                                                <div class="input-group text-center">
                                                    <asp:Button ID="btnClick" runat="server" Text="Create FloCard" CssClass="btn btn-linkedin btn-raised" style="padding-bottom: 10px;" OnClick="btnSubmit_Click" OnClientClick = "Confirm()" />
                                            <%--        <a href="#" class="btn btn-linkedin btn-raised" style="padding-bottom: 10px;" id="btnSubmit" runat="server" onserverclick="btnSubmit_Click" OnClientClick="if(!UserDeleteConfirmation()) return false;">
                                                        <asp:Label ID="lblButton" runat="server" Text="Create FloCard"></asp:Label>--%>
                                                    <%--</a>--%>
                                                </div>
                                            </div>
                                            <div class="col-6">
                                                <div class="input-group text-center" id="viewdiv" runat="server">
                                                    <a href="#" class="btn btn-linkedin btn-raised" style="padding-bottom: 10px;" id="btnView" runat="server" >
                                                        <asp:Label ID="Label1" runat="server" Text="Download FloCard"></asp:Label>
                                                    </a>
                                                </div>
                                            </div>
                                        </div>


                                    </div>
                                </div>


                            </div>
                            <%--             <div class="footer text-center">
                
              </div>--%>
                        </form>
                    </div>
                </div>
            </div>
        </div>
        <footer class="footer">
            <div class="container">

                <div class="copyright float-right">
                    &copy;
       
                    <script>
                        document.write(new Date().getFullYear())
        </script>
                    ,
       
                    <a href="http://366pi.tech/" target="_blank">366Pi Technologies</a>
                </div>
            </div>
        </footer>
    </div>
    <!--   Core JS Files   -->
    <script src="assets/js/core/jquery.min.js" type="text/javascript"></script>
    <script src="assets/js/core/popper.min.js" type="text/javascript"></script>
    <script src="assets/js/core/bootstrap-material-design.min.js" type="text/javascript"></script>
    <script src="assets/js/plugins/moment.min.js"></script>
    <!--	Plugin for the Datepicker, full documentation here: https://github.com/Eonasdan/bootstrap-datetimepicker -->
    <script src="assets/js/plugins/bootstrap-datetimepicker.js" type="text/javascript"></script>
    <!--  Plugin for the Sliders, full documentation here: http://refreshless.com/nouislider/ -->
    <script src="assets/js/plugins/nouislider.min.js" type="text/javascript"></script>
    <!--	Plugin for Sharrre btn -->
    <script src="assets/js/plugins/jquery.sharrre.js" type="text/javascript"></script>
    <!-- Control Center for Material Kit: parallax effects, scripts for the example pages etc -->
    <script src="assets/js/material-kit.js?v=2.0.4" type="text/javascript"></script>
    <script src="assets/js/jquery.nicescroll.min.js" type="text/javascript"></script>
    <script>
        $("body").niceScroll();
  </script>
    <script>
        function UserDeleteConfirmation() {
    return confirm("Are you sure you want to delete this user?");
}
    </script>
</body>

</html>
