using Newtonsoft.Json;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using System.Text;

namespace FloCard
{
    public partial class callback : System.Web.UI.Page
    {
        Bitmap img;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                if (Request.QueryString["error"] != null)
                {
                    string error = Request.QueryString["error"].ToString();
                    string error_description = Request.QueryString["error_description"].ToString();
                    string state = Request.QueryString["state"].ToString();
                }
                else
                {
                    string code = Request.QueryString["code"].ToString();
                    string state = Request.QueryString["state"].ToString();

                    string url = "https://www.linkedin.com/oauth/v2/accessToken";
                    string data = "grant_type=authorization_code&code=" + code + "&redirect_uri=APP_REDIRECT_URL&client_id=YOUR_LINKEDIN_CLIENT_ID&client_secret=LINKEDIN_CLIENT_SECRET";

                    string response = Call_Service_Post(data, url);

                    Token obj = JsonConvert.DeserializeObject<Token>(response);

                    string token = obj.access_token;
                    string expires = obj.expires_in;

                    url = "https://api.linkedin.com/v1/people/~:(formatted-name,headline,positions,picture-url;size=400,email-address,public-profile-url)?format=json";

                    response = Call_Service_Get(url, token);

                    LinkedInData linkedindata = JsonConvert.DeserializeObject<LinkedInData>(response);

                    Session["linkedindata"] = linkedindata;

                    Response.Redirect("FlocardForm.aspx", true);


                }



            }





        }


        public static string Call_Service_Post(string req, string url)
        {
            string resultData = "";
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "POST";
                request.ProtocolVersion = HttpVersion.Version11;
                request.ContentType = "application/x-www-form-urlencoded";
                string content = req;
                request.ContentLength = content.Length;
                Stream wri = request.GetRequestStream();
                byte[] array = Encoding.UTF8.GetBytes(content);
                wri.Write(array, 0, array.Length);
                wri.Flush();
                wri.Close();
                HttpWebResponse HttpWResp = (HttpWebResponse)request.GetResponse();
                int resCode = (int)HttpWResp.StatusCode;
                StreamReader reader = new StreamReader(HttpWResp.GetResponseStream(), System.Text.Encoding.UTF8);
                resultData = reader.ReadToEnd();
            }
            catch (Exception ex)
            {

            }
            return resultData;
        }

        public static string Call_Service_Get(string url, string token)
        {
            string resultData = "";
            try
            {
                WebRequest request = WebRequest.Create(url);
                request.Method = "GET";
                request.Headers["Authorization"] = "Bearer " + token;
                WebResponse response = request.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                resultData = reader.ReadToEnd();

            }
            catch (Exception ex)
            {

            }

            return resultData;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.ContentType = "image/png";
            Response.AddHeader("Content-Disposition", "attachment; filename=" + "qr.png");
            img.Save(Response.OutputStream, ImageFormat.Png);
        }
    }
}