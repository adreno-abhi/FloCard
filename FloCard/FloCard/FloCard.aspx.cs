using MessagingToolkit.QRCode.Codec;
using Newtonsoft.Json.Linq;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Configuration;

namespace FloCard
{
    public partial class FloCard : System.Web.UI.Page
    {
        public static string flo_tx_url = "";
        public static string name = "", heading = "", email = "", phone = "", linkedin = "", profile_pic = "", qrimgsrc = "", gen_on = "";
        public static string apiurl = WebConfigurationManager.AppSettings.Get("apiurl");


        protected void Page_Load(object sender, EventArgs e)
        {
            string tranid = "";
            if (Request.QueryString["id"] != null)
            {
                tranid = Request.QueryString["id"].ToString();
                FetchData(tranid);
            }
            else
            {
                Response.Redirect("index.aspx", true);
            }

        }

        private void FetchData(string tranid)
        {
            //var client = new WebClient();
            //client.Headers.Add("user-agent", "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36  (KHTML, like Gecko) Chrome / 58.0.3029.110 Safari / 537.36");
            var response = "";
            int attempt = 0;

            bool success = false;

            while (!success)
            {
                if (attempt <= 10)
                {
                    attempt++;
                    try
                    {
                        //response = client.DownloadString("https://testnet.flocha.in/api/tx/" + tranid);
                        response = Call_Service_Get(apiurl + "/gettransactiondetails/" + tranid);
                        var obj = JObject.Parse(response);
                        string floData = obj["result"]["floData"].ToString();
                        var data = floData.Split('#');
                        name = data[1].ToString();
                        heading = data[2].ToString();
                        email = data[3].ToString();
                        phone = data[4].ToString();
                        linkedin = data[5].ToString();
                        profile_pic = data[6].ToString();
                        if(profile_pic.StartsWith("http"))
                        {
                            profile_pic = ConvertImageURLToBase64(profile_pic);
                            usrImg.Src = "data:image/jpeg;base64," + profile_pic;
                        }
                        else
                        {
                            usrImg.Src = profile_pic;
                        }

                        

                        gen_on = DateTime.UtcNow.ToString();

                        //flo_tx_url = "https://testnet.flocha.in/tx/" + tranid;
                        //flo_tx_url = "https://livenet.flocha.in/tx/" + tranid;
                        flo_tx_url = "http://network.flo.cash/tx/" + tranid;
                        //flo_tx_url = "https://testnet.florincoin.info/tx/" + tranid;
                        string qrcode_url = "https://flocard.app/FloCard.aspx?id=" + tranid;
                       
                        QRCodeEncoder encoder = new QRCodeEncoder();
                        Bitmap img;
                        encoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.H;
                        encoder.QRCodeScale = 10;
                        img = encoder.Encode(qrcode_url);

                        string serverpath = Server.MapPath("~/assets/img/");

                        System.Drawing.Image logo = System.Drawing.Image.FromFile(serverpath + "logo-white.jpg");

                        int left = (img.Width / 2) - (logo.Width / 2);
                        int top = (img.Height / 2) - (logo.Height / 2);
                        Graphics g = Graphics.FromImage(img);
                        g.DrawImage(logo, new Point(left, top));

                        MemoryStream ms = new MemoryStream();
                        img.Save(ms, ImageFormat.Png);
                        var base64Data = Convert.ToBase64String(ms.ToArray());

                        qrimgsrc = "data:image/png;base64," + base64Data;
                        //imgQr.Src = qrimgsrc;
                        ImgQr1.Src = qrimgsrc;
                        success = true;

                        string embedhtml = @"<link rel=""stylesheet"" type=""text/css"" href=""https://fonts.googleapis.com/css?family=Roboto:300,400,500,700|Roboto+Slab:400,700|Material+Icons""><link rel=""stylesheet"" href=""https://maxcdn.bootstrapcdn.com/font-awesome/latest/css/font-awesome.min.css""><link href=""http://flocard.app/assets/css/material-kit.css?v=2.0.4"" rel=""stylesheet""><link href=""http://flocard.app/assets/demo/demo.css"" rel=""stylesheet""><div class=""container""> <div class=""row""> <div class=""col-lg-9 col-md-9 ml-auto mr-auto text-center""> <div class=""card"" id=""floDataDiv""> <div class=""card-body""> <div class=""row""> <div class=""col-lg-3 col-md-3 ml-auto mr-auto text-center""> <br><img src=""#usrImg#"" id=""usrImg"" height=""180""> </div><div class=""col-lg-5 col-md-5 ml-auto mr-auto text-center""> <h5 class=""title""><a href="""" title=""View Linkedin Profile"">#Name#</a></h5> <h5>#Headline#</h5> <h5>#Email#</h5> <h5>#Contact#</h5> <a href=""#LinkedIn#"" target=""_blank"" title=""View Linkedin Profile""> <img src=""http://flocard.app/assets/img/linkedin-social-media-logo-7.png"" width=""50""></a> <a href=""#txUrl#"" target=""_blank"" title=""View This Transaction on FLO Blockchain Explorer""> <img src=""http://flocard.app/assets/img/FLO_teal.png"" width=""50""></a> </div><div class=""col-lg-4 col-md-4 ml-auto mr-auto text-center"" style=""padding-left: 0px;padding-right: 15px;""> <br><img src=""#qrImg#"" id=""ImgQr1"" height=""220""> </div></div><div class=""row""> <div class=""col-lg-6 col-md-6""> <small class=""pull-left"">#genOn#</small> </div><div class=""col-lg-6 col-md-6""> <small class=""pull-right"">FloCard by 366Pi</small> </div></div></div></div></div></div>";
                        embedhtml = embedhtml.Replace("#usrImg#", "data:image/jpeg;base64," + profile_pic);
                        embedhtml = embedhtml.Replace("#Name#", name);
                        embedhtml = embedhtml.Replace("#Headline#", heading);
                        embedhtml = embedhtml.Replace("#Email#", email);
                        embedhtml = embedhtml.Replace("#Contact#", phone);
                        embedhtml = embedhtml.Replace("#LinkedIn#", linkedin);
                        embedhtml = embedhtml.Replace("#txUrl#", flo_tx_url);
                        embedhtml = embedhtml.Replace("#qrImg#", "data:image/png;base64," + base64Data);
                        embedhtml = embedhtml.Replace("#genOn#", gen_on);
                        txtEmbed1.InnerHtml = embedhtml;
                    }
                    catch (Exception ex)
                    {
                        System.Threading.Thread.Sleep(2000);
                        continue;
                    }
                }
                else
                {
                    string message = "Error Retrieving FloCard. Please Try Again Later";
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    sb.Append("<script type = 'text/javascript'>");
                    sb.Append("window.onload=function(){");
                    sb.Append("alert('");
                    sb.Append(message);
                    sb.Append("')};");
                    sb.Append("</script>");
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());
                }

            }
        }


        protected void ExportCardToImage(object sender, EventArgs e)
        {
            string base64 = Request.Form[flocardData.UniqueID].Split(',')[1];
            byte[] bytes = Convert.FromBase64String(base64);
            Response.Clear();
            Response.ContentType = "image/png";
            Response.AddHeader("Content-Disposition", "attachment; filename=FloCard_"+ name + ".png");
            Response.Buffer = true;
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.BinaryWrite(bytes);
            Response.End();
        }

        protected void ExportQRToImage(object sender, EventArgs e)
        {
            string base64 = Request.Form[qrData.UniqueID].Split(',')[1];
            byte[] bytes = Convert.FromBase64String(base64);
            Response.Clear();
            Response.ContentType = "image/png";
            Response.AddHeader("Content-Disposition", "attachment; filename=QR.png");
            Response.Buffer = true;
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.BinaryWrite(bytes);
            Response.End();
        }


        public String ConvertImageURLToBase64(String url)
        {
            StringBuilder _sb = new StringBuilder();

            Byte[] _byte = this.GetImage(url);

            _sb.Append(Convert.ToBase64String(_byte, 0, _byte.Length));

            return _sb.ToString();
        }

        private byte[] GetImage(string url)
        {
            Stream stream = null;
            byte[] buf;

            try
            {
                WebProxy myProxy = new WebProxy();
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);

                HttpWebResponse response = (HttpWebResponse)req.GetResponse();
                stream = response.GetResponseStream();

                using (BinaryReader br = new BinaryReader(stream))
                {
                    int len = (int)(response.ContentLength);
                    buf = br.ReadBytes(len);
                    br.Close();
                }

                stream.Close();
                response.Close();
            }
            catch (Exception exp)
            {
                buf = null;
            }

            return (buf);
        }

        public static string Call_Service_Get(string url)
        {
            string resultData = "";
            try
            {
                WebRequest request = WebRequest.Create(url);
                request.Method = "GET";
                WebResponse response = request.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                resultData = reader.ReadToEnd();

            }
            catch (Exception ex)
            {

            }

            return resultData;
        }

    }
}