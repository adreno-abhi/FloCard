using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FloCardAPI
{
    public class UserRequest
    {
        public string userid { get; set; }
    }

    public class UserResponse
    {
        public int status { get; set; }
        public string message { get; set; }
        public string userid { get; set; }
    }
    public class CreateCardRequest
    {        
        public string floData { get; set; }
        public string userid { get; set; }
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

    public class UserCardResponse
    {
        public string tranid { get; set; }
        public string userid { get; set; }
        public int status { get; set; }
        public string message { get; set; }

    }


}