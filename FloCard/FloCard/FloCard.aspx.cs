using MessagingToolkit.QRCode.Codec;
using Newtonsoft.Json.Linq;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using System.Text;
using System.Web;

namespace FloCard
{
    public partial class FloCard : System.Web.UI.Page
    {
        public static string flo_tx_url = "";
        public static string name = "", heading = "", email = "", phone = "", linkedin = "", profile_pic = "", qrimgsrc = "", gen_on = "";

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
            var client = new WebClient();
            client.Headers.Add("user-agent", "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36  (KHTML, like Gecko) Chrome / 58.0.3029.110 Safari / 537.36");
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
                        response = client.DownloadString("https://testnet.flocha.in/api/tx/" + tranid);
                        
                        var obj = JObject.Parse(response);
                        string floData = obj["result"]["floData"].ToString();
                        var data = floData.Split('#');
                        name = data[2].ToString();
                        heading = data[3].ToString();
                        email = data[4].ToString();
                        phone = data[5].ToString();
                        linkedin = data[6].ToString();
                        profile_pic = data[7].ToString();
                        profile_pic = ConvertImageURLToBase64(profile_pic);

                        usrImg.Src = "data:image/jpeg;base64," + profile_pic;
                        gen_on = DateTime.UtcNow.ToString();

                        flo_tx_url = "https://testnet.flocha.in/tx/" + tranid;
                        string qrcode_url = "https://FLOCARD_DOMAIN_NAME/FloCard.aspx?id=" + tranid;
                        
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
                        imgQr.Src = qrimgsrc;

                        success = true;
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
            Response.AddHeader("Content-Disposition", "attachment; filename=FloCard.png");
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