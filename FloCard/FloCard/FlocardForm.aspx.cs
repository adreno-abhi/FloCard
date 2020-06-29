using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Configuration;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FloCard
{
    public partial class FlocardForm : System.Web.UI.Page
    {
        public static string apiurl = WebConfigurationManager.AppSettings.Get("apiurl");
        public static string noimageurl = WebConfigurationManager.AppSettings.Get("noimageurl");
        public string tranid = "";
        public LinkedInData data;
        public string linkedinurl = "", picurl = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.CacheControl = "private";
            Response.ExpiresAbsolute = DateTime.Now.AddDays(-1d);
            Response.Cache.SetCacheability(HttpCacheability.NoCache);

            viewdiv.Visible = false;
            if (!IsPostBack)
            {
                if (Session["linkedindata"] != null)
                {
                    data = new LinkedInData();
                    data = (LinkedInData)Session["linkedindata"];
                    UserRequest req = new UserRequest();
                    req.userid = data.id;
                    JavaScriptSerializer json_serializer = new JavaScriptSerializer();
                    string reqjson = json_serializer.Serialize(req);
                    string resp = Call_Service_Post(reqjson, apiurl+ "/checkuser");
                    JObject obj = JObject.Parse(resp);

                    if(obj["status"].ToString().Equals("0"))
                    {
                        resp = Call_Service_Post(reqjson, apiurl + "/register");
                        obj = JObject.Parse(resp);

                        
                        txtName.Value = data.formattedName;
                        //data.headline = Regex.Replace(data.headline, @"\p{Cs}", "");
                        if(data.positions is null)
                        {
                            data.headline = "";
                        }
                        else
                        {
                            data.headline = data.positions.values[0].title.ToString();
                        }

                        
                        //if(string.IsNullOrEmpty(data.headline))
                        //{
                        //    data.headline = "";
                        //}
                        txtHeader.Value = data.headline;
                        txtEmail.Value = data.emailAddress;

                        if(string.IsNullOrEmpty(data.pictureUrl))
                        {
                            data.pictureUrl = noimageurl;
                        }

                        string profile_pic = ConvertImageURLToBase64(data.pictureUrl);

                        liurlctrl.Value = data.publicProfileUrl;

                        usrImg.Src = "data:image/jpeg;base64," + profile_pic;
                        picurlctrl.Value = "data:image/jpeg;base64," + profile_pic;
                        //usrImg.Src = data.pictureUrl;
                        //picurlctrl.Value = data.pictureUrl;
                    }
                    else
                    {
                        //fetch card transid from api

                        resp = Call_Service_Post(reqjson, apiurl + "/getcard");
                        obj = JObject.Parse(resp);

                        if (obj["status"].ToString().Equals("0"))
                        {
                            if (string.IsNullOrEmpty(data.pictureUrl))
                            {
                               
                                data.pictureUrl = noimageurl;
                            }

                            string profile_pic = ConvertImageURLToBase64(data.pictureUrl);


                            //usrImg.Src = data.pictureUrl;
                            usrImg.Src = "data:image/jpeg;base64," + profile_pic;
                            txtName.Value = data.formattedName;
                            //data.headline = Regex.Replace(data.headline, @"\p{Cs}", "");
                            if(data.positions is null)
                            {
                                data.headline = "";
                            }
                            else
                            {
                                data.headline = data.positions.values[0].title.ToString();
                            }
                            
                            txtHeader.Value = data.headline;
                            txtEmail.Value = data.emailAddress;
                            liurlctrl.Value = data.publicProfileUrl;
                            //picurlctrl.Value = data.pictureUrl;
                            picurlctrl.Value = "data:image/jpeg;base64," + profile_pic;

                        }
                        else
                        {
                            tranid = obj["tranid"].ToString();

                           var response = Call_Service_Get(apiurl + "/gettransactiondetails/" + tranid);
                            var obj1 = JObject.Parse(response);
                            string floData = obj1["result"]["floData"].ToString();
                            var data1 = floData.Split('#');
                            txtName.Value = data1[1].ToString();
                            txtHeader.Value = data1[2].ToString();
                            txtEmail.Value = data1[3].ToString();
                            txtPhone.Value = data1[4].ToString();
                            if (string.IsNullOrEmpty(data.pictureUrl))
                            {
                                data.pictureUrl = noimageurl;
                            }
                            //string linkedin = data[6].ToString();
                            string profile_pic = data.pictureUrl;
                            if(profile_pic.StartsWith("http"))
                            {
                                profile_pic = ConvertImageURLToBase64(profile_pic);
                            }
                            

                            liurlctrl.Value = data.publicProfileUrl;
                            
                            //picurlctrl.Value = data.pictureUrl;

                            usrImg.Src = "data:image/jpeg;base64," + profile_pic;
                            picurlctrl.Value = "data:image/jpeg;base64," + profile_pic;
                            //string gen_on = DateTime.UtcNow.ToString();
                            btnClick.Text = "Update FloCard";
                            viewdiv.Visible = true;
                            lblTransId.Text = "Your Unique Blockchain ID is : <a href=\"FloCard.aspx?id=" + tranid+"\" style=\"color:#fff;\">" + tranid+"</a>";
                            btnView.HRef = "FloCard.aspx?id=" + tranid;
                        }

                    }


                    
                    
                }
                else
                {
                    Response.Redirect("index.aspx", true);
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string confirmValue = Request.Form["confirm_value"];
            if (confirmValue == "Yes")
            {
                string floapiurl = apiurl + "/createcard";
                //string flodata = "366pi#bcardnew#";
                string flodata = "";
                string separator = "#";

                flodata += txtName.Value + separator + txtHeader.Value + separator + txtEmail.Value + separator + txtPhone.Value + separator + liurlctrl.Value + separator + picurlctrl.Value;

                data = (LinkedInData)Session["linkedindata"];
                SendToAddressRequest request = new SendToAddressRequest();

                request.floData = flodata;

                request.userid = data.id;

                JavaScriptSerializer json_serializer = new JavaScriptSerializer();
                string reqjson = json_serializer.Serialize(request);

                string resp = Call_Service_Post(reqjson, floapiurl);
                JObject obj = JObject.Parse(resp);

                if (string.IsNullOrEmpty(obj["error"].ToString()))
                {
                    tranid = obj["result"].ToString();

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
            else
            {
                Response.Redirect("index.aspx", true);
            }

            
        }


        protected void btnView_Click(object sender, EventArgs e)
        {
            Response.Redirect("FloCard.aspx?id=" + tranid, true);
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
    }
}