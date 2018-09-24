<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="FloCard.index" %>

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
    <link href="assets/demo/demo.css" rel="stylesheet" />
</head>

<body class="landing-page sidebar-collapse">
    <form runat="server">
        <nav class="navbar navbar-transparent navbar-color-on-scroll fixed-top navbar-expand-lg" color-on-scroll="100" id="sectionsNav">
            <div class="container">
                <div class="navbar-translate">
                    <a class="navbar-brand" href="#">
                        <img src="assets/img/logo-black.png" height="100%" />
                        FloCard (CE) </a>

                </div>

            </div>
        </nav>
        <div class="page-header header-filter" data-parallax="true" style="background-image: url('assets/img/img.jpg')">
            <div class="container">
                <div class="row">
                    <div class="col-md-12">
                        <h1 class="title">In an infinite universe of data, FLOCard keeps your contacts safe</h1>
                        <h4>FLOCard is a one-stop solution securely built on the Blockchain. Create, Store and, Exchange business cards with ease of use and ease of mind. Finally, an indestructible card wallet!</h4>
                        <br>
                        <a href="<%=redirect_url %>" class="btn btn-linkedin btn-raised btn-lg" id="btnGetStrated" target="_blank">
                            <i class="fa fa-linkedin" style="padding-right: 6px; padding-bottom: 4px;"></i>Login with Linkedin
          </a>
                    </div>
                </div>
            </div>
        </div>
        <div class="main main-raised">
            <div class="container">
                <div class="section text-center">
                    <div class="row">
                        <div class="col-md-8 ml-auto mr-auto">
                            <h2 class="title">Travel Light</h2>
                            <h5 class="description">FLOCard is a worry-free way to carry a card-holder and manage an infinite amount of business cards while going for a meeting or travelling. FloCard provides unlimited space to store all your contact information in one place. Network Smart with FloCard.</h5>
                        </div>
                    </div>
                    <div class="features">
                        <div class="row">
                            <div class="col-md-4">
                                <div class="info">
                                    <div class="icon icon-info">
                                        <i class="material-icons">create</i>
                                    </div>
                                    <h4 class="info-title">Create Card</h4>

                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="info">
                                    <div class="icon icon-success">
                                        <i class="material-icons">visibility</i>
                                    </div>
                                    <h4 class="info-title">View Card</h4>

                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="info">
                                    <div class="icon icon-danger">
                                        <i class="material-icons">share</i>
                                    </div>
                                    <h4 class="info-title">Exchange Card</h4>

                                </div>
                            </div>
                        </div>
                    </div>
                </div>

            </div>
        </div>
        <footer class="footer footer-default">
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

    </form>
</body>

</html>
