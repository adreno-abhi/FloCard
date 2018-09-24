using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FloCard
{
    public partial class FlocardForm : System.Web.UI.Page
    {
        public static LinkedInData data;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["linkedindata"] != null)
                {
                    data = (LinkedInData)Session["linkedindata"];

                    usrImg.Src = data.pictureUrl;
                    txtName.Value = data.formattedName;
                    data.headline = Regex.Replace(data.headline, @"\p{Cs}", "");
                    txtHeader.Value = data.headline;
                    txtEmail.Value = data.emailAddress;
                }
                else
                {
                    Response.Redirect("index.aspx", true);
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string floapiurl = "http://FLO_API_DOMAIN/FloApi.svc/sendtoaddress";
            
            string flodata = "";
            string separator = "#";
            string floaddress = "FLO_RECEIVE ADDRESS";

            flodata += txtName.Value + separator + txtHeader.Value + separator + txtEmail.Value + separator + txtPhone.Value + separator + data.publicProfileUrl + separator + data.pictureUrl;

            SendToAddressRequest request = new SendToAddressRequest();
            request.address = floaddress;
            request.amount = "0.01";
            request.comment = "test";
            request.comment_to = "test";
            request.conf_target = "1";
            request.estimate_mode = "UNSET";
            request.floData = flodata;
            request.replaceable = "false";
            request.subtractfeefromamount = "false";

            JavaScriptSerializer json_serializer = new JavaScriptSerializer();
            string reqjson = json_serializer.Serialize(request);

            string resp = Call_Service_Post(reqjson, floapiurl);
            JObject obj = JObject.Parse(resp);

            if (string.IsNullOrEmpty(obj["error"].ToString()))
            {
                string tranid = obj["result"].ToString();

                Response.Redirect("FloCard.aspx?id=" + tranid, true);
            }
            else
            {
                string message = "Error Creating FloCard";
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


        public static string Call_Service_Post(string req, string url)
        {
            string resultData = "";
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "POST";
                request.ProtocolVersion = HttpVersion.Version11;
                request.ContentType = "application/json";

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
    }
}