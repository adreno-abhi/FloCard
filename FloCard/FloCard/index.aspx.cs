using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FloCard
{
    public partial class index : System.Web.UI.Page
    {        
        public string redirect_url = "https://www.linkedin.com/oauth/v2/authorization?response_type=code&client_id=YOUR_LINKEDIN_CLIENT_ID&redirect_uri=APP_REDIRECT_URL&state=LINKED_API_STATE_VALUE&scope=r_basicprofile%20r_emailaddress";

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnGetStrated_Click(object sender, EventArgs e)
        {
            
            
        }
    }
}