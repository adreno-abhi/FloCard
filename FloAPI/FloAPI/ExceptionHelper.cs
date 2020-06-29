using FloSDK.Exceptions;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace FloAPI
{
    public class ExceptionHelper
    {
        public static string PrintRpcException(RpcInternalServerErrorException exception)
        {
            var errorCode = 0;
            var errorMessage = string.Empty;

            if (exception.RpcErrorCode.GetHashCode() != 0)
            {
                errorCode = exception.RpcErrorCode.GetHashCode();
                errorMessage = exception.RpcErrorCode.ToString();
            }

            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("[Failed] {0} {1} {2}", exception.Message, errorCode != 0 ? "Error code: " + errorCode : string.Empty, !string.IsNullOrWhiteSpace(errorMessage) ? errorMessage : string.Empty);
            JObject obj = new JObject();
            obj.Add("error", sb.ToString());
            return obj.ToString();
        }

        public static string PrintException(Exception exception)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("[Failed] Please check your configuration and make sure that the daemon is up and running and that it is synchronized.");
            JObject obj = new JObject();
            obj.Add("error", sb.ToString());
            return obj.ToString();
        }

    }
}