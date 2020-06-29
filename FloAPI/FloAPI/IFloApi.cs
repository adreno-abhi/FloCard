//Author : Abhijeet Das Gupta
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace FloAPI
{
    [ServiceContract]
    public interface IFloApi
    {
        //== Control ==

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/getinfo")]
        Stream GetInfo();

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/help/{command=null}")]
        Stream Help(string command);

        //==Blockchain==

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/getbestblockhash")]
        Stream GetBestBlockHash();

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/getblock/{hash}")]
        Stream GetBlock(string hash);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/getblockchaininfo")]
        Stream GetBlockChainInfo();

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/getblockcount")]
        Stream GetBlockCount();

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/getblockhash/{block}")]
        Stream GetBlockHash(string block);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/getchaintips")]
        Stream GetChainTips();

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/getdifficulty")]
        Stream GetDifficulty();

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/getmempoolinfo")]
        Stream GetMemPoolInfo();

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/getrawmempool")]
        Stream GetRawMemPool();

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/gettxout/{txid}/{vout}")]
        Stream GetTxOut(string txid, string vout);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/gettxoutsetinfo")]
        Stream GetTxOutSetInfo();

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/verifychain")]
        Stream VerifyChain();

        //== Generating ==

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/getgenerate")]
        Stream GetGenerate();

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/gethashespersec")]
        Stream GetHashesPerSec();

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/setgenerate/{generate}")]
        Stream SetGenerate(string generate);

        //== Mining ==

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/getblocktemplate")]
        Stream GetBlockTemplate();

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/getmininginfo")]
        Stream GetMiningInfo();

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/getnetworkhashps")]
        Stream GetNetworkHashPs();

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/prioritisetransaction/{txid}/{priority}/{fee}")]
        Stream PrioritiseTransaction(string txid, string priority, string fee);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/submitblock/{hexdata}")]
        Stream SubmitBlock(string hexdata);

        //== Network ==

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/addnode/{node}/{command}")]
        Stream AddNode(string node, string command);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/getaddednodeinfo/{dns}")]
        Stream GetAddedNodeInfo(string dns);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/getconnectioncount")]
        Stream GetConnectionCount();

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/getnettotals")]
        Stream GetNetTotals();

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/getnetworkinfo")]
        Stream GetNetworkInfo();

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/getpeerinfo")]
        Stream GetPeerInfo();

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/ping")]
        Stream Ping();

        //== Rawtransactions ==

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/createrawtransaction")]
        Stream CreateRawTransaction(CreateRawTranasctionRequest request);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/decoderawtransaction/{hexstring}")]
        Stream DecodeRawTransaction(string hexstring);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/decodescript/{hex}")]
        Stream DecodeScript(string hex);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/getrawtransaction/{txid}")]
        Stream GetRawTransaction(string txid);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/sendrawtransaction/{hexstring}")]
        Stream SendRawTransaction(string hexstring);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/signrawtransaction/{hexstring}")]
        Stream SignRawTransaction(string hexstring);

        //== Util ==

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/createmultisig")]
        Stream CreateMultiSig(MultiSigRequest request);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/estimatefee/{nblocks}")]
        Stream EstimateFee(string nblocks);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/estimatepriority/{nblocks}")]
        Stream EstimatePriority(string nblocks);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/validateaddress/{florincoinaddress}")]
        Stream ValidateAddress(string florincoinaddress);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/verifymessage/{florincoinaddress}/{signature}/{message}")]
        Stream VerifyMessage(string florincoinaddress, string signature, string message);

        //== Wallet ==

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/addmultisigaddress")]
        Stream AddMultiSigAddress(MultiSigRequest request);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/dumpprivkey/{florincoinaddress}")]
        Stream DumpPrivkey(string florincoinaddress);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/dumpwallet/{filename}")]
        Stream DumpWallet(string filename);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/encryptwallet/{passphrase}")]
        Stream EncryptWallet(string passphrase);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/getaccount/{florincoinaddress}")]
        Stream GetAccount(string florincoinaddress);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/getaccountaddress/{account}")]
        Stream GetAccountAddress(string account);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/getaddressesbyaccount/{account}")]
        Stream GetAddressesByAccount(string account);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/getbalance/{account=null}")]
        Stream GetBalance(string account);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/getnewaddress/{account=null}")]
        Stream GetNewAddress(string account);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/getrawchangeaddress")]
        Stream GetRawChangeAddress();

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/getreceivedbyaccount/{account}")]
        Stream GetReceivedByAccount(string account);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/getreceivedbyaddress/{florincoinaddress}")]
        Stream GetReceivedByAddress(string florincoinaddress);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/gettransaction/{txid}")]
        Stream GetTransaction(string txid);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/getunconfirmedbalance")]
        Stream GetUnconfirmedBalance();

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/getwalletinfo")]
        Stream GetWalletInfo();

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/importaddress/{address}")]
        Stream ImportAddress(string address);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/importprivkey/{florincoinprivkey}")]
        Stream ImportPrivKey(string florincoinprivkey);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/importwallet/{filename}")]
        Stream ImportWallet(string filename);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/keypoolrefill")]
        Stream KeypoolRefill();

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/listaccounts")]
        Stream ListAccounts();

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/listaddressgroupings")]
        Stream ListAddressGroupings();

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/listlockunspent")]
        Stream ListLockUnspent();

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/listreceivedbyaccount")]
        Stream ListReceivedByAccount();

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/listreceivedbyaddress")]
        Stream ListReceivedByAddress();

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/listsinceblock")]
        Stream ListSinceBlock();

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/listtransactions")]
        Stream ListTransactions();

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/listunspent")]
        Stream ListUnspent();

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/lockunspent")]
        Stream LockUnspent(LockUnspentRequest request);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/move/{fromaccount}/{toaccount}/{amount}")]
        Stream Move(string fromaccount, string toaccount, string amount);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/sendfrom/{fromaccount}/{toflorincoinaddress}/{amount}")]
        Stream SendFrom(string fromaccount, string toflorincoinaddress, string amount);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/sendmany")]
        Stream SendMany(SendManyRequest request);

        //[OperationContract]
        //[WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/sendtoaddress/{florincoinaddress}/{amount}/{comment=null}/{commentto=null}/{txcomment=null}")]
        //Stream SendToAddress(string florincoinaddress, string amount, string comment, string commentto, string txcomment);

        ////GET
        //[OperationContract]
        //[WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/sendtoaddress/{address}/{amount}/{comment}/{comment_to}/{subtractfeefromamount}/{replaceable}/{conf_target}/{estimate_mode}/{floData=null}")]
        //Stream SendToAddress(string address, string amount, string comment, string comment_to, string subtractfeefromamount, string replaceable, string conf_target, string estimate_mode, string floData);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/sendtoaddress")]
        Stream SendToAddress(SendToAddressRequest request);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/setaccount/{florincoinaddress}/{account}")]
        Stream SetAccount(string florincoinaddress, string account);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/settxfee/{amount}")]
        Stream SetTxFee(string amount);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/signmessage/{florincoinaddress}/{message}")]
        Stream SignMessage(string florincoinaddress, string message);


        //==Extended Methods
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/ext/getaddrbalance/{address}")]
        Stream GetAddrBalance(string address);

    }
}
