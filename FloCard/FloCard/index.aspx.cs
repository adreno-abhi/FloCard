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
        public string redirect_url = "https://www.linkedin.com/oauth/v2/authorization?response_type=code&client_id=[client_id]&redirect_uri=http%3A%2F%2Flocalhost%3A33861%2Fcallback.aspx&state=366pitest&scope=r_liteprofile%20r_emailaddress";

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnGetStrated_Click(object sender, EventArgs e)
        {
            
            
        }
    }
}