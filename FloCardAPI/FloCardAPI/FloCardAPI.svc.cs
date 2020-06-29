using MySql.Data.MySqlClient;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.ServiceModel;
using System.Text;
using System.Web.Configuration;
using System.Web.Script.Serialization;

namespace FloCardAPI
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "FloCardAPI" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select FloCardAPI.svc or FloCardAPI.svc.cs at the Solution Explorer and start debugging.
    public class FloCardAPI : IFloCardAPI
    {
        public static string apiurl = WebConfigurationManager.AppSettings.Get("apiurl");
        public static string connStr = WebConfigurationManager.ConnectionStrings["dbcon"].ConnectionString;
        public Stream CreateCard(CreateCardRequest request)
        {
            string floapiurl = apiurl + "/sendtoaddress";
            string ret = "";
            string tranid = "";
            try
            {
                string keytrans = HelperClass.getKeyTransaction();
                string keyresponse = HelperClass.Call_Service_Get(apiurl + "/getrawtransaction/" + keytrans);
                var keyobj = JObject.Parse(keyresponse);
                string key = keyobj["result"]["floData"].ToString();

                SendToAddressRequest req = new SendToAddressRequest();
                req.address = WebConfigurationManager.AppSettings.Get("floaddress").ToString();
                req.amount = WebConfigurationManager.AppSettings.Get("amount").ToString();
                req.comment = WebConfigurationManager.AppSettings.Get("comment").ToString();
                req.comment_to = WebConfigurationManager.AppSettings.Get("comment_to").ToString();
                req.conf_target = WebConfigurationManager.AppSettings.Get("conf_target").ToString();
                req.estimate_mode = WebConfigurationManager.AppSettings.Get("estimate_mode").ToString();

                req.floData = "Flocard#" + HelperClass.Encrypt(request.floData, key) + "#" + HelperClass.getLastTransID(request.userid);
                req.replaceable = WebConfigurationManager.AppSettings.Get("replaceable").ToString();
                req.subtractfeefromamount = WebConfigurationManager.AppSettings.Get("subtractfeefromamount").ToString();

                JavaScriptSerializer json_serializer = new JavaScriptSerializer();
                string reqjson = json_serializer.Serialize(req);

                string resp = HelperClass.Call_Service_Post(reqjson, floapiurl);
                JObject obj = JObject.Parse(resp);
                if (string.IsNullOrEmpty(obj["error"].ToString()))
                {
                    tranid = obj["result"].ToString();
                }
                else
                {
                    tranid = "Error Creating FLOCard";
                }

                ret = obj.ToString();

                string qry = "insert into flocards_log SELECT * from flocards where user_id = @user_id";
                MySqlConnection conn = new MySqlConnection(connStr);
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(qry, conn);
                cmd.Parameters.AddWithValue("@user_id", request.userid);
                cmd.ExecuteNonQuery();
                conn.Close();

                qry = "delete from flocards where user_id = @user_id";
                conn = new MySqlConnection(connStr);
                conn.Open();
                cmd = new MySqlCommand(qry, conn);
                cmd.Parameters.AddWithValue("@user_id", request.userid);
                cmd.ExecuteNonQuery();
                conn.Close();

                qry = "insert into flocards(user_id,tran_id,ts) values(@user_id,@tran_id,@ts)";
                conn = new MySqlConnection(connStr);
                conn.Open();
                cmd = new MySqlCommand(qry, conn);
                cmd.Parameters.AddWithValue("@user_id", request.userid);
                cmd.Parameters.AddWithValue("@tran_id", tranid);
                cmd.Parameters.AddWithValue("@ts", DateTime.Now);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {

            }

            return new MemoryStream(Encoding.UTF8.GetBytes(ret.ToString()));
        }

        public Stream GetTransactionDetails(string txid)
        {
            string response = "";
            try
            {
                string keytrans = HelperClass.getKeyTransaction();
                string keyresponse = HelperClass.Call_Service_Get(apiurl + "/getrawtransaction/" + keytrans);
                var keyobj = JObject.Parse(keyresponse);
                string key = keyobj["result"]["floData"].ToString();

                response = HelperClass.Call_Service_Get(apiurl + "/getrawtransaction/" + txid);
                var obj = JObject.Parse(response);
                string flodata = obj["result"]["floData"].ToString();
                var data = flodata.Split('#');
                data[1] = HelperClass.Decrypt(data[1], key);
                flodata = data[0] + "#" + data[1] + "#" + data[2];
                obj["result"]["floData"] = flodata;

                response = obj.ToString();
            }
            catch (Exception ex)
            {

            }
            return new MemoryStream(Encoding.UTF8.GetBytes(response.ToString()));
        }

        public Stream Register(UserRequest request)
        {
            JObject response;
            UserResponse resp = new UserResponse();
            try
            {
                string qry = "insert into users(user_id,ts,status) values(@user_id,@ts,@status)";
                MySqlConnection conn = new MySqlConnection(connStr);
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(qry, conn);
                cmd.Parameters.AddWithValue("@user_id", request.userid);
                cmd.Parameters.AddWithValue("@ts", DateTime.Now);
                cmd.Parameters.AddWithValue("@status", "Active");
                cmd.ExecuteNonQuery();
                conn.Close();

                resp.status = 1;
                resp.message = "User Registered";
                resp.userid = request.userid;
            }
            catch (Exception ex)
            {
                resp.status = 0;
                resp.message = "Error";
                resp.userid = request.userid;
            }
            JavaScriptSerializer json_serializer = new JavaScriptSerializer();
            string respjson = json_serializer.Serialize(resp);

            response = JObject.Parse(respjson);
            return new MemoryStream(Encoding.UTF8.GetBytes(response.ToString()));
        }

        public Stream CheckUser(UserRequest request)
        {
            JObject response;
            UserResponse resp = new UserResponse();
            try
            {
                string qry = "select * from users where user_id = @userid";
                MySqlConnection conn = new MySqlConnection(connStr);
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(qry, conn);
                cmd.Parameters.AddWithValue("@userid", request.userid);
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    resp.status = 1;
                    resp.message = "User Found";
                    resp.userid = reader["user_id"].ToString();
                }
                else
                {
                    resp.status = 0;
                    resp.message = "User Not Found";
                }
                conn.Close();

            }
            catch (Exception ex)
            {
                resp.status = 0;
                resp.message = "Error";
            }

            JavaScriptSerializer json_serializer = new JavaScriptSerializer();
            string respjson = json_serializer.Serialize(resp);

            response = JObject.Parse(respjson);
            return new MemoryStream(Encoding.UTF8.GetBytes(response.ToString()));
        }

        public Stream GetCard(UserRequest request)
        {
            JObject response;
            UserCardResponse resp = new UserCardResponse();
            try
            {
                string qry = "select * from flocards where user_id = @userid";
                MySqlConnection conn = new MySqlConnection(connStr);
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(qry, conn);
                cmd.Parameters.AddWithValue("@userid", request.userid);
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    resp.status = 1;
                    resp.message = "Card Found";
                    resp.userid = reader["user_id"].ToString();
                    resp.tranid = reader["tran_id"].ToString();
                }
                else
                {
                    resp.status = 0;
                    resp.message = "Card Not Found";
                }
                conn.Close();

            }
            catch (Exception ex)
            {
                resp.status = 0;
                resp.message = "Error";
            }

            JavaScriptSerializer json_serializer = new JavaScriptSerializer();
            string respjson = json_serializer.Serialize(resp);

            response = JObject.Parse(respjson);
            return new MemoryStream(Encoding.UTF8.GetBytes(response.ToString()));
        }
    }
}
