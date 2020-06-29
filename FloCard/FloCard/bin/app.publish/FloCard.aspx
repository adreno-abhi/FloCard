<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FloCard.aspx.cs" Inherits="FloCard.FloCard" ValidateRequest="false" %>

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
</head>

<body>
    <form class="form" runat="server">
        <%--    <nav class="navbar navbar-transparent navbar-color-on-scroll fixed-top navbar-expand-lg" color-on-scroll="100" id="sectionsNav">
        <div class="container">
            <div class="navbar-translate">
                <a class="navbar-brand" href="#">
                    <img src="assets/img/logo-black.png" height="50" />
                    FloCard (Alpha) </a>

            </div>

        </div>
    </nav>--%>
        <%--  <div class="page-header header-filter">--%>
        <div class="container">
            <div class="row">
                <div class="col-lg-9 col-md-9 ml-auto mr-auto text-center">
                    <div class="card" id="floDataDiv">
                        <div class="card-body">
                            <div class="row">
                                <div class="col-lg-3 col-md-3 ml-auto mr-auto text-center">
                                    <br />
                                    <img src="" id="usrImg" runat="server" height="180">
                                </div>
                                <div class="col-lg-5 col-md-5 ml-auto mr-auto text-center">
                                    <%--<div class="row">
                                            <div class="col-lg-10 col-md-10 ml-auto mr-auto text-center">
                                                <h5 class="title"><a href="<%=linkedin %>" title="View Linkedin Profile"><%=name %></a></h5>
                                            </div>
                                            <div class="col-lg-2 col-md-2 ml-auto mr-auto text-center">
                                                <img src="assets/img/legacy.png" width="75">
                                            </div>
                                        </div>--%>
                                    <h5 class="title"><a href="<%=linkedin %>" title="View Linkedin Profile"><%=name %></a></h5>
                                    <h5><%=heading %></h5>
                                    <h5><%=email %></h5>
                                    <h5><%=phone %></h5>
                                    <a href="<%=linkedin %>" target="_blank" title="View Linkedin Profile">
                                        <img src="assets/img/linkedin-social-media-logo-7.png" width="50"></a>
                                    <a href="<%=flo_tx_url %>" target="_blank" title="View This Transaction on FLO Blockchain Explorer">
                                        <img src="assets/img/FLO_teal.png" width="50"></a>
                                    <%--<img src="assets/img/Legacy.png" width="50">--%>
                                </div>
                                <div class="col-lg-4 col-md-4 ml-auto mr-auto text-center" style="padding-left: 0px;padding-right: 15px;">
                                    <br />
                                    <img src="" id="ImgQr1" runat="server" height="220">
                                </div>

                                <%--<div class="col-lg-1 col-md-1 ml-auto mr-auto text-center">
                                        <img src="assets/img/FLO_teal.png" width="50">
                                    </div>--%>
                            </div>
                            <div class="row">
                                <div class="col-lg-6 col-md-6">
                                    <small class="pull-left">Generated on <%=gen_on %> UTC</small>
                                </div>
                                <div class="col-lg-6 col-md-6">
                                    <small class="pull-right">FloCard by 366Pi</small>
                                </div>
                            </div>
                        </div>
                    </div>




                    <asp:HiddenField ID="flocardData" runat="server" />
                    <asp:Button ID="btnExportCard" Text="Save as PNG" CssClass="btn btn-linkedin" runat="server" UseSubmitBehavior="false"
                        OnClick="ExportCardToImage" OnClientClick="return ConvertCardToImage(this)" />
                    <input type="button" value="Show Embed Code" id="btnEmbed" class="btn btn-linkedin" onclick="showhideEmbed()" />
                    
                    <br />
                    <div class="card" id="divEmbed" style="display:none">
                        <div class="card-body">
                            <div class="input-group">
                             <textarea name="txtEmbed1" id="txtEmbed1" rows="5" cols="100" readonly class="form-control" runat="server"></textarea>   
                               </div>
                            <br />
                            <input type="button" id="btnCopy" value="Copy to Clipboard" class="btn" />
                        </div>
                        
                    </div>
                    
                     <br />
                    
                    Create Your Business Card on Blockchain. <a href="index.aspx">Click Here</a>
                </div>

                <%--<div class="col-lg-4 col-md-4 ml-auto mr-auto text-center">
                    <div class="card" id="qrDataDiv">
                        <div class="card-body">
                            <img src="" id="imgQr" runat="server" height="240">
        
                            <br />
                            <br />
                            <br />
                        </div>
                    </div>

                    
                    <asp:Button ID="btnExportQR" Text="Share FLOCard" CssClass="btn btn-linkedin" runat="server" UseSubmitBehavior="false"
                        OnClick="ExportQRToImage" OnClientClick="return ConvertQRToImage(this)" />


                </div>--%>
                <asp:HiddenField ID="qrData" runat="server" />



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
        <%--<div class="row">
            <div class="col-lg-8">
                <div class="card" id="floDataDiv1">

                    <div class="card-body">
                        <div class="row">
                            <div class="col-lg-4 col-md-4 ml-auto mr-auto text-center">
                                <img src="" id="Img11" runat="server" height="200">
                            </div>
                            <div class="col-lg-8 col-md-8 ml-auto mr-auto text-center">
                                <h5 class="title"><a href="<%=linkedin %>" title="View Linkedin Profile"><%=name %></a></h5>
                                <h5><%=heading %></h5>
                                <h5><%=email %></h5>
                                <h5><%=phone %></h5>
                                <img src="assets/img/Legacy.png" width="50">
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-lg-6 col-md-6">
                                <small class="pull-left">Generated on <%=gen_on %> UTC</small>
                            </div>
                            <div class="col-lg-6 col-md-6">
                                <small class="pull-right">FloCard by 366Pi</small>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>--%>




        <%--   </div>--%>
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
        <script type="text/javascript" src="assets/js/html2canvas.js"></script>
        <script>
            $("body").niceScroll();
  </script>
        <script type="text/javascript">
            function ConvertCardToImage(btnExportCard) {
                html2canvas($("#floDataDiv")[0]).then(function (canvas) {
                    var base64 = canvas.toDataURL();
                    $("[id*=flocardData]").val(base64);
                    __doPostBack(btnExportCard.name, "");
                });
                return false;
            }

            function ConvertQRToImage(btnExportQR) {
                html2canvas($("#qrDataDiv")[0]).then(function (canvas) {
                    var base64 = canvas.toDataURL();
                    $("[id*=qrData]").val(base64);
                    __doPostBack(btnExportQR.name, "");
                });
                return false;
            }

            function showhideEmbed() {
               var x = document.getElementById("divEmbed");
                  if (x.style.display === "none") {
                      x.style.display = "block";
                      $("#btnEmbed").val("Hide Embed Code");
                  } else {
                      x.style.display = "none";
                      $("#btnEmbed").val("Show Embed Code");
                  }
            }

            $("#btnCopy").click(function(){
                $("#txtEmbed1").select();
                document.execCommand('copy');
            });
        </script>
    </form>
</body>

</html>
