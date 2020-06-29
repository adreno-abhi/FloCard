using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FloAPI
{
    public class AddressandAmount
    {
        public string address { get; set; }
        public decimal amount { get; set; }
    }

    public class TransandVout
    {
        public string txid { get; set; }
        public int vout { get; set; }
    }

    public class Key
    {
        public string key { get; set; }
    }

    public class CreateRawTranasctionRequest
    {
        public List<AddressandAmount> addresses { get; set; }
        public List<TransandVout> transactions { get; set; }
    }

    public class MultiSigRequest
    {
        public int nrequired { get; set; }
        public List<Key> keys { get; set; }
    }

    public class LockUnspentRequest
    {
        public bool unlock { get; set; }
        public List<TransandVout> transactions { get; set; }
    }

    public class SendManyRequest
    {
        public string fromaddress { get; set; }
        public List<TransandVout> addresses { get; set; }
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

    public class ValidateAddressResponse
    {
        public bool isvalid { get; set; }
        public string address { get; set; }
        public bool ismine { get; set; }
        public bool isscript { get; set; }
        public string pubkey { get; set; }
        public bool iscompressed { get; set; }
        public string account { get; set; }
        public string scriptPubKey { get; set; }
        public string iswatchonly { get; set; }
        public string timestamp { get; set; }
    }
}