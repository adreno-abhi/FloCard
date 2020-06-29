using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace FloCardAPI
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IFloCardAPI" in both code and config file together.
    [ServiceContract]
    public interface IFloCardAPI
    {
        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/createcard")]
        Stream CreateCard(CreateCardRequest request);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/register")]
        Stream Register(UserRequest request);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/checkuser")]
        Stream CheckUser(UserRequest request);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/getcard")]
        Stream GetCard(UserRequest request);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/gettransactiondetails/{txid}")]
        Stream GetTransactionDetails(string txid);
    }
}
