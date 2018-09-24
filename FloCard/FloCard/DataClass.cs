using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FloCard
{
    public class Token
    {
        public string access_token { get; set; }
        public string expires_in { get; set; }
    }

    public class Company
    {
        public int id { get; set; }
        public string industry { get; set; }
        public string name { get; set; }
        public string size { get; set; }
        public string type { get; set; }
    }

    public class Country
    {
        public string code { get; set; }
        public string name { get; set; }
    }

    public class Location
    {
        public Country country { get; set; }
        public string name { get; set; }
    }

    public class StartDate
    {
        public int month { get; set; }
        public int year { get; set; }
    }

    public class Value
    {
        public Company company { get; set; }
        public int id { get; set; }
        public bool isCurrent { get; set; }
        public Location location { get; set; }
        public StartDate startDate { get; set; }
        public string title { get; set; }
        public string summary { get; set; }
    }

    public class Positions
    {
        public int _total { get; set; }
        public List<Value> values { get; set; }
    }

    public class LinkedInData
    {
        public string emailAddress { get; set; }
        public string formattedName { get; set; }
        public string headline { get; set; }
        public string pictureUrl { get; set; }
        public Positions positions { get; set; }
        public string publicProfileUrl { get; set; }
    }

    public class SendToAddressRequest
    {
        public string address { get; set; }
        public string amount { get; set; }
        public string comment { get; set; }
        public string comment_to { get; set; }
        public string subtractfeefromamount { get; set; }
        public string replaceable { get; set; }
        public string conf_target { get; set; }
        public string estimate_mode { get; set; }
        public string floData { get; set; }
    }



}