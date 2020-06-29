//Author : Abhijeet Das Gupta
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.ServiceModel.Web;
using System.Text;
using System.Web.Configuration;
using FloSDK.Exceptions;
using FloSDK.Methods;
using System.Web.Script.Serialization;

namespace FloAPI
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "FloApi" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select FloApi.svc or FloApi.svc.cs at the Solution Explorer and start debugging.
    public class FloApi : IFloApi
    {
        string username = WebConfigurationManager.AppSettings.Get("username");
        string password = WebConfigurationManager.AppSettings.Get("password");
        string wallet_url = WebConfigurationManager.AppSettings.Get("wallet_url");
        string wallet_port = WebConfigurationManager.AppSettings.Get("wallet_port");

        //== Control ==
        public Stream GetInfo()
        {
            RpcMethods rpc = new RpcMethods(username, password, wallet_url, wallet_port);
            WebOperationContext.Current.OutgoingResponse.ContentType = "application/json; charset=utf-8";
            try
            {
                JObject obj = JObject.Parse(rpc.GetInfo());
                return new MemoryStream(Encoding.UTF8.GetBytes(obj.ToString()));
            }
            catch (RpcInternalServerErrorException exception)
            {                                         
                return new MemoryStream(Encoding.UTF8.GetBytes(ExceptionHelper.PrintRpcException(exception)));
            }
            catch (WebFaultException exception)
            {
                return new MemoryStream(Encoding.UTF8.GetBytes(ExceptionHelper.PrintException(exception)));
            }
            catch (Exception exception)
            {                     
                return new MemoryStream(Encoding.UTF8.GetBytes(ExceptionHelper.PrintException(exception)));
            }

        }

        public Stream Help(string command)
        {
            if (string.IsNullOrEmpty(command))
            {
                command = "";
            }
            RpcMethods rpc = new RpcMethods(username, password, wallet_url, wallet_port);
            WebOperationContext.Current.OutgoingResponse.ContentType = "application/json; charset=utf-8";
            try
            {
                JObject obj = JObject.Parse(rpc.Help(command));
                return new MemoryStream(Encoding.UTF8.GetBytes(obj.ToString()));
            }
            catch (RpcInternalServerErrorException exception)
            {                
                return new MemoryStream(Encoding.UTF8.GetBytes(ExceptionHelper.PrintRpcException(exception)));
            }
            catch (Exception exception)
            {                          
                return new MemoryStream(Encoding.UTF8.GetBytes(ExceptionHelper.PrintException(exception)));
            }
        }

        //==Blockchain==

        public Stream GetBestBlockHash()
        {
            RpcMethods rpc = new RpcMethods(username, password, wallet_url, wallet_port);
            WebOperationContext.Current.OutgoingResponse.ContentType = "application/json; charset=utf-8";
            try
            {
                JObject obj = JObject.Parse(rpc.GetBestBlockHash());
                return new MemoryStream(Encoding.UTF8.GetBytes(obj.ToString()));
            }
            catch (RpcInternalServerErrorException exception)
            {
                return new MemoryStream(Encoding.UTF8.GetBytes(ExceptionHelper.PrintRpcException(exception)));
            }
            catch (Exception exception)
            {
                return new MemoryStream(Encoding.UTF8.GetBytes(ExceptionHelper.PrintException(exception)));
            }
        }

        public Stream GetBlock(string hash)
        {
            RpcMethods rpc = new RpcMethods(username, password, wallet_url, wallet_port);
            WebOperationContext.Current.OutgoingResponse.ContentType = "application/json; charset=utf-8";
            try
            {
                JObject obj = JObject.Parse(rpc.GetBlock(hash));
                return new MemoryStream(Encoding.UTF8.GetBytes(obj.ToString()));
            }
            catch (RpcInternalServerErrorException exception)
            {
                return new MemoryStream(Encoding.UTF8.GetBytes(ExceptionHelper.PrintRpcException(exception)));
            }
            catch (Exception exception)
            {
                return new MemoryStream(Encoding.UTF8.GetBytes(ExceptionHelper.PrintException(exception)));
            }

        }

        public Stream GetBlockChainInfo()
        {
            RpcMethods rpc = new RpcMethods(username, password, wallet_url, wallet_port);
            WebOperationContext.Current.OutgoingResponse.ContentType = "application/json; charset=utf-8";
            try
            {
                JObject obj = JObject.Parse(rpc.GetBlockChainInfo());
                return new MemoryStream(Encoding.UTF8.GetBytes(obj.ToString()));
            }
            catch (RpcInternalServerErrorException exception)
            {
                return new MemoryStream(Encoding.UTF8.GetBytes(ExceptionHelper.PrintRpcException(exception)));
            }
            catch (Exception exception)
            {
                return new MemoryStream(Encoding.UTF8.GetBytes(ExceptionHelper.PrintException(exception)));
            }

        }

        public Stream GetBlockCount()
        {
            RpcMethods rpc = new RpcMethods(username, password, wallet_url, wallet_port);
            WebOperationContext.Current.OutgoingResponse.ContentType = "application/json; charset=utf-8";
            try
            {
                JObject obj = JObject.Parse(rpc.GetBlockCount());
                return new MemoryStream(Encoding.UTF8.GetBytes(obj.ToString()));
            }
            catch (RpcInternalServerErrorException exception)
            {
                return new MemoryStream(Encoding.UTF8.GetBytes(ExceptionHelper.PrintRpcException(exception)));
            }
            catch (Exception exception)
            {
                return new MemoryStream(Encoding.UTF8.GetBytes(ExceptionHelper.PrintException(exception)));
            }

        }

        public Stream GetBlockHash(string block)
        {
            RpcMethods rpc = new RpcMethods(username, password, wallet_url, wallet_port);
            WebOperationContext.Current.OutgoingResponse.ContentType = "application/json; charset=utf-8";
            try
            {
                JObject obj = JObject.Parse(rpc.GetBlockHash(Convert.ToInt32(block)));
                return new MemoryStream(Encoding.UTF8.GetBytes(obj.ToString()));
            }
            catch (RpcInternalServerErrorException exception)
            {
                return new MemoryStream(Encoding.UTF8.GetBytes(ExceptionHelper.PrintRpcException(exception)));
            }
            catch (Exception exception)
            {
                return new MemoryStream(Encoding.UTF8.GetBytes(ExceptionHelper.PrintException(exception)));
            }

        }

        public Stream GetChainTips()
        {
            RpcMethods rpc = new RpcMethods(username, password, wallet_url, wallet_port);
            WebOperationContext.Current.OutgoingResponse.ContentType = "application/json; charset=utf-8";
            try
            {
                JObject obj = JObject.Parse(rpc.GetChainTips());
                return new MemoryStream(Encoding.UTF8.GetBytes(obj.ToString()));
            }
            catch (RpcInternalServerErrorException exception)
            {
                return new MemoryStream(Encoding.UTF8.GetBytes(ExceptionHelper.PrintRpcException(exception)));
            }
            catch (Exception exception)
            {
                return new MemoryStream(Encoding.UTF8.GetBytes(ExceptionHelper.PrintException(exception)));
            }

        }

        public Stream GetDifficulty()
        {
            RpcMethods rpc = new RpcMethods(username, password, wallet_url, wallet_port);
            WebOperationContext.Current.OutgoingResponse.ContentType = "application/json; charset=utf-8";
            try
            {
                JObject obj = JObject.Parse(rpc.GetDifficulty());
                return new MemoryStream(Encoding.UTF8.GetBytes(obj.ToString()));
            }
            catch (RpcInternalServerErrorException exception)
            {
                return new MemoryStream(Encoding.UTF8.GetBytes(ExceptionHelper.PrintRpcException(exception)));
            }
            catch (Exception exception)
            {
                return new MemoryStream(Encoding.UTF8.GetBytes(ExceptionHelper.PrintException(exception)));
            }

        }

        public Stream GetMemPoolInfo()
        {
            RpcMethods rpc = new RpcMethods(username, password, wallet_url, wallet_port);
            WebOperationContext.Current.OutgoingResponse.ContentType = "application/json; charset=utf-8";
            try
            {
                JObject obj = JObject.Parse(rpc.GetMemPoolInfo());
                return new MemoryStream(Encoding.UTF8.GetBytes(obj.ToString()));
            }
            catch (RpcInternalServerErrorException exception)
            {
                return new MemoryStream(Encoding.UTF8.GetBytes(ExceptionHelper.PrintRpcException(exception)));
            }
            catch (Exception exception)
            {
                return new MemoryStream(Encoding.UTF8.GetBytes(ExceptionHelper.PrintException(exception)));
            }

        }

        public Stream GetRawMemPool()
        {
            RpcMethods rpc = new RpcMethods(username, password, wallet_url, wallet_port);
            WebOperationContext.Current.OutgoingResponse.ContentType = "application/json; charset=utf-8";
            try
            {
                JObject obj = JObject.Parse(rpc.GetRawMemPool());
                return new MemoryStream(Encoding.UTF8.GetBytes(obj.ToString()));
            }
            catch (RpcInternalServerErrorException exception)
            {
                return new MemoryStream(Encoding.UTF8.GetBytes(ExceptionHelper.PrintRpcException(exception)));
            }
            catch (Exception exception)
            {
                return new MemoryStream(Encoding.UTF8.GetBytes(ExceptionHelper.PrintException(exception)));
            }

        }

        public Stream GetTxOut(string txid, string vout)
        {
            RpcMethods rpc = new RpcMethods(username, password, wallet_url, wallet_port);
            WebOperationContext.Current.OutgoingResponse.ContentType = "application/json; charset=utf-8";
            try
            {
                JObject obj = JObject.Parse(rpc.GetTxOut(txid, Convert.ToInt32(vout)));
                return new MemoryStream(Encoding.UTF8.GetBytes(obj.ToString()));
            }
            catch (RpcInternalServerErrorException exception)
            {
                return new MemoryStream(Encoding.UTF8.GetBytes(ExceptionHelper.PrintRpcException(exception)));
            }
            catch (Exception exception)
            {
                return new MemoryStream(Encoding.UTF8.GetBytes(ExceptionHelper.PrintException(exception)));
            }

        }

        public Stream GetTxOutSetInfo()
        {
            RpcMethods rpc = new RpcMethods(username, password, wallet_url, wallet_port);
            WebOperationContext.Current.OutgoingResponse.ContentType = "application/json; charset=utf-8";
            try
            {
                JObject obj = JObject.Parse(rpc.GetTxOutSetInfo());
                return new MemoryStream(Encoding.UTF8.GetBytes(obj.ToString()));
            }
            catch (RpcInternalServerErrorException exception)
            {
                return new MemoryStream(Encoding.UTF8.GetBytes(ExceptionHelper.PrintRpcException(exception)));
            }
            catch (Exception exception)
            {
                return new MemoryStream(Encoding.UTF8.GetBytes(ExceptionHelper.PrintException(exception)));
            }

        }

        public Stream VerifyChain()
        {
            RpcMethods rpc = new RpcMethods(username, password, wallet_url, wallet_port);
            WebOperationContext.Current.OutgoingResponse.ContentType = "application/json; charset=utf-8";
            try
            {
                JObject obj = JObject.Parse(rpc.VerifyChain());
                return new MemoryStream(Encoding.UTF8.GetBytes(obj.ToString()));
            }
            catch (RpcInternalServerErrorException exception)
            {
                return new MemoryStream(Encoding.UTF8.GetBytes(ExceptionHelper.PrintRpcException(exception)));
            }
            catch (Exception exception)
            {
                return new MemoryStream(Encoding.UTF8.GetBytes(ExceptionHelper.PrintException(exception)));
            }

        }

        //== Generating ==

        public Stream GetGenerate()
        {
            RpcMethods rpc = new RpcMethods(username, password, wallet_url, wallet_port);
            WebOperationContext.Current.OutgoingResponse.ContentType = "application/json; charset=utf-8";
            try
            {
                JObject obj = JObject.Parse(rpc.GetGenerate());
                return new MemoryStream(Encoding.UTF8.GetBytes(obj.ToString()));
            }
            catch (RpcInternalServerErrorException exception)
            {
                return new MemoryStream(Encoding.UTF8.GetBytes(ExceptionHelper.PrintRpcException(exception)));
            }
            catch (Exception exception)
            {
                return new MemoryStream(Encoding.UTF8.GetBytes(ExceptionHelper.PrintException(exception)));
            }

        }

        public Stream GetHashesPerSec()
        {
            RpcMethods rpc = new RpcMethods(username, password, wallet_url, wallet_port);
            WebOperationContext.Current.OutgoingResponse.ContentType = "application/json; charset=utf-8";
            try
            {
                JObject obj = JObject.Parse(rpc.GetHashesPerSec());
                return new MemoryStream(Encoding.UTF8.GetBytes(obj.ToString()));
            }
            catch (RpcInternalServerErrorException exception)
            {
                return new MemoryStream(Encoding.UTF8.GetBytes(ExceptionHelper.PrintRpcException(exception)));
            }
            catch (Exception exception)
            {
                return new MemoryStream(Encoding.UTF8.GetBytes(ExceptionHelper.PrintException(exception)));
            }

        }

        public Stream SetGenerate(string generate)
        {
            RpcMethods rpc = new RpcMethods(username, password, wallet_url, wallet_port);
            WebOperationContext.Current.OutgoingResponse.ContentType = "application/json; charset=utf-8";
            try
            {
                JObject obj = JObject.Parse(rpc.SetGenerate(Convert.ToBoolean(generate)));
                return new MemoryStream(Encoding.UTF8.GetBytes(obj.ToString()));
            }
            catch (RpcInternalServerErrorException exception)
            {
                return new MemoryStream(Encoding.UTF8.GetBytes(ExceptionHelper.PrintRpcException(exception)));
            }
            catch (Exception exception)
            {
                return new MemoryStream(Encoding.UTF8.GetBytes(ExceptionHelper.PrintException(exception)));
            }

        }

        //== Mining ==

        public Stream GetBlockTemplate()
        {
            RpcMethods rpc = new RpcMethods(username, password, wallet_url, wallet_port);
            WebOperationContext.Current.OutgoingResponse.ContentType = "application/json; charset=utf-8";
            try
            {
                JObject obj = JObject.Parse(rpc.GetBlockTemplate());
                return new MemoryStream(Encoding.UTF8.GetBytes(obj.ToString()));
            }
            catch (RpcInternalServerErrorException exception)
            {
                return new MemoryStream(Encoding.UTF8.GetBytes(ExceptionHelper.PrintRpcException(exception)));
            }
            catch (Exception exception)
            {
                return new MemoryStream(Encoding.UTF8.GetBytes(ExceptionHelper.PrintException(exception)));
            }

        }

        public Stream GetMiningInfo()
        {
            RpcMethods rpc = new RpcMethods(username, password, wallet_url, wallet_port);
            WebOperationContext.Current.OutgoingResponse.ContentType = "application/json; charset=utf-8";
            try
            {
                JObject obj = JObject.Parse(rpc.GetMiningInfo());
                return new MemoryStream(Encoding.UTF8.GetBytes(obj.ToString()));
            }
            catch (RpcInternalServerErrorException exception)
            {
                return new MemoryStream(Encoding.UTF8.GetBytes(ExceptionHelper.PrintRpcException(exception)));
            }
            catch (Exception exception)
            {
                return new MemoryStream(Encoding.UTF8.GetBytes(ExceptionHelper.PrintException(exception)));
            }

        }

        public Stream GetNetworkHashPs()
        {
            RpcMethods rpc = new RpcMethods(username, password, wallet_url, wallet_port);
            WebOperationContext.Current.OutgoingResponse.ContentType = "application/json; charset=utf-8";
            try
            {
                JObject obj = JObject.Parse(rpc.GetNetworkHashPs());
                return new MemoryStream(Encoding.UTF8.GetBytes(obj.ToString()));
            }
            catch (RpcInternalServerErrorException exception)
            {
                return new MemoryStream(Encoding.UTF8.GetBytes(ExceptionHelper.PrintRpcException(exception)));
            }
            catch (Exception exception)
            {
                return new MemoryStream(Encoding.UTF8.GetBytes(ExceptionHelper.PrintException(exception)));
            }

        }

        public Stream PrioritiseTransaction(string txid, string priority, string fee)
        {
            RpcMethods rpc = new RpcMethods(username, password, wallet_url, wallet_port);
            WebOperationContext.Current.OutgoingResponse.ContentType = "application/json; charset=utf-8";
            try
            {
                JObject obj = JObject.Parse(rpc.PrioritiseTransaction(txid, Convert.ToDecimal(priority), Convert.ToInt32(fee)));
                return new MemoryStream(Encoding.UTF8.GetBytes(obj.ToString()));
            }
            catch (RpcInternalServerErrorException exception)
            {
                return new MemoryStream(Encoding.UTF8.GetBytes(ExceptionHelper.PrintRpcException(exception)));
            }
            catch (Exception exception)
            {
                return new MemoryStream(Encoding.UTF8.GetBytes(ExceptionHelper.PrintException(exception)));
            }

        }

        public Stream SubmitBlock(string hexdata)
        {
            RpcMethods rpc = new RpcMethods(username, password, wallet_url, wallet_port);
            WebOperationContext.Current.OutgoingResponse.ContentType = "application/json; charset=utf-8";
            try
            {
                JObject obj = JObject.Parse(rpc.SubmitBlock(hexdata));
                return new MemoryStream(Encoding.UTF8.GetBytes(obj.ToString()));
            }
            catch (RpcInternalServerErrorException exception)
            {
                return new MemoryStream(Encoding.UTF8.GetBytes(ExceptionHelper.PrintRpcException(exception)));
            }
            catch (Exception exception)
            {
                return new MemoryStream(Encoding.UTF8.GetBytes(ExceptionHelper.PrintException(exception)));
            }

        }

        //== Network ==

        public Stream AddNode(string node, string command)
        {
            RpcMethods rpc = new RpcMethods(username, password, wallet_url, wallet_port);
            WebOperationContext.Current.OutgoingResponse.ContentType = "application/json; charset=utf-8";
            try
            {
                JObject obj = JObject.Parse(rpc.AddNode(node, command));
                return new MemoryStream(Encoding.UTF8.GetBytes(obj.ToString()));
            }
            catch (RpcInternalServerErrorException exception)
            {
                return new MemoryStream(Encoding.UTF8.GetBytes(ExceptionHelper.PrintRpcException(exception)));
            }
            catch (Exception exception)
            {
                return new MemoryStream(Encoding.UTF8.GetBytes(ExceptionHelper.PrintException(exception)));
            }

        }

        public Stream GetAddedNodeInfo(string dns)
        {
            RpcMethods rpc = new RpcMethods(username, password, wallet_url, wallet_port);
            WebOperationContext.Current.OutgoingResponse.ContentType = "application/json; charset=utf-8";
            try
            {
                JObject obj = JObject.Parse(rpc.GetAddedNodeInfo(Convert.ToBoolean(dns)));
                return new MemoryStream(Encoding.UTF8.GetBytes(obj.ToString()));
            }
            catch (RpcInternalServerErrorException exception)
            {
                return new MemoryStream(Encoding.UTF8.GetBytes(ExceptionHelper.PrintRpcException(exception)));
            }
            catch (Exception exception)
            {
                return new MemoryStream(Encoding.UTF8.GetBytes(ExceptionHelper.PrintException(exception)));
            }

        }

        public Stream GetConnectionCount()
        {
            RpcMethods rpc = new RpcMethods(username, password, wallet_url, wallet_port);
            WebOperationContext.Current.OutgoingResponse.ContentType = "application/json; charset=utf-8";
            try
            {
                JObject obj = JObject.Parse(rpc.GetConnectionCount());
                return new MemoryStream(Encoding.UTF8.GetBytes(obj.ToString()));
            }
            catch (RpcInternalServerErrorException exception)
            {
                return new MemoryStream(Encoding.UTF8.GetBytes(ExceptionHelper.PrintRpcException(exception)));
            }
            catch (Exception exception)
            {
                return new MemoryStream(Encoding.UTF8.GetBytes(ExceptionHelper.PrintException(exception)));
            }

        }

        public Stream GetNetTotals()
        {
            RpcMethods rpc = new RpcMethods(username, password, wallet_url, wallet_port);
            WebOperationContext.Current.OutgoingResponse.ContentType = "application/json; charset=utf-8";
            try
            {
                JObject obj = JObject.Parse(rpc.GetNetTotals());
                return new MemoryStream(Encoding.UTF8.GetBytes(obj.ToString()));
            }
            catch (RpcInternalServerErrorException exception)
            {
                return new MemoryStream(Encoding.UTF8.GetBytes(ExceptionHelper.PrintRpcException(exception)));
            }
            catch (Exception exception)
            {
                return new MemoryStream(Encoding.UTF8.GetBytes(ExceptionHelper.PrintException(exception)));
            }

        }

        public Stream GetNetworkInfo()
        {
            RpcMethods rpc = new RpcMethods(username, password, wallet_url, wallet_port);
            WebOperationContext.Current.OutgoingResponse.ContentType = "application/json; charset=utf-8";
            try
            {
                JObject obj = JObject.Parse(rpc.GetNetworkInfo());
                return new MemoryStream(Encoding.UTF8.GetBytes(obj.ToString()));
            }
            catch (RpcInternalServerErrorException exception)
            {
                return new MemoryStream(Encoding.UTF8.GetBytes(ExceptionHelper.PrintRpcException(exception)));
            }
            catch (Exception exception)
            {
                return new MemoryStream(Encoding.UTF8.GetBytes(ExceptionHelper.PrintException(exception)));
            }

        }

        public Stream GetPeerInfo()
        {
            RpcMethods rpc = new RpcMethods(username, password, wallet_url, wallet_port);
            WebOperationContext.Current.OutgoingResponse.ContentType = "application/json; charset=utf-8";
            try
            {
                JObject obj = JObject.Parse(rpc.GetPeerInfo());
                return new MemoryStream(Encoding.UTF8.GetBytes(obj.ToString()));
            }
            catch (RpcInternalServerErrorException exception)
            {
                return new MemoryStream(Encoding.UTF8.GetBytes(ExceptionHelper.PrintRpcException(exception)));
            }
            catch (Exception exception)
            {
                return new MemoryStream(Encoding.UTF8.GetBytes(ExceptionHelper.PrintException(exception)));
            }

        }

        public Stream Ping()
        {
            RpcMethods rpc = new RpcMethods(username, password, wallet_url, wallet_port);
            WebOperationContext.Current.OutgoingResponse.ContentType = "application/json; charset=utf-8";
            try
            {
                JObject obj = JObject.Parse(rpc.Ping());
                return new MemoryStream(Encoding.UTF8.GetBytes(obj.ToString()));
            }
            catch (RpcInternalServerErrorException exception)
            {
                return new MemoryStream(Encoding.UTF8.GetBytes(ExceptionHelper.PrintRpcException(exception)));
            }
            catch (Exception exception)
            {
                return new MemoryStream(Encoding.UTF8.GetBytes(ExceptionHelper.PrintException(exception)));
            }

        }

        //== Rawtransactions ==

        public Stream CreateRawTransaction(CreateRawTranasctionRequest request)
        {
            RpcMethods rpc = new RpcMethods(username, password, wallet_url, wallet_port);
            WebOperationContext.Current.OutgoingResponse.ContentType = "application/json; charset=utf-8";
            try
            {
                var addresses = new JObject();
                foreach(var a in request.addresses)
                {
                    addresses.Add(a.address, a.amount);
                }

                var transactions = new JArray();
                foreach(var t in request.transactions)
                {
                    var trans = new JObject();
                    trans.Add("txid", t.txid);
                    trans.Add("vout", t.vout);
                    transactions.Add(trans);
                }
                
                JObject obj = JObject.Parse(rpc.CreateRawTransaction(transactions,addresses));
                return new MemoryStream(Encoding.UTF8.GetBytes(obj.ToString()));
            }
            catch (RpcInternalServerErrorException exception)
            {
                return new MemoryStream(Encoding.UTF8.GetBytes(ExceptionHelper.PrintRpcException(exception)));
            }
            catch (Exception exception)
            {
                return new MemoryStream(Encoding.UTF8.GetBytes(ExceptionHelper.PrintException(exception)));
            }
        }

        public Stream DecodeRawTransaction(string hexstring)
        {
            RpcMethods rpc = new RpcMethods(username, password, wallet_url, wallet_port);
            WebOperationContext.Current.OutgoingResponse.ContentType = "application/json; charset=utf-8";
            try
            {
                JObject obj = JObject.Parse(rpc.DecodeRawTransaction(hexstring));
                return new MemoryStream(Encoding.UTF8.GetBytes(obj.ToString()));
            }
            catch (RpcInternalServerErrorException exception)
            {
                return new MemoryStream(Encoding.UTF8.GetBytes(ExceptionHelper.PrintRpcException(exception)));
            }
            catch (Exception exception)
            {
                return new MemoryStream(Encoding.UTF8.GetBytes(ExceptionHelper.PrintException(exception)));
            }

        }

        public Stream DecodeScript(string hex)
        {
            RpcMethods rpc = new RpcMethods(username, password, wallet_url, wallet_port);
            WebOperationContext.Current.OutgoingResponse.ContentType = "application/json; charset=utf-8";
            try
            {
                JObject obj = JObject.Parse(rpc.DecodeScript(hex));
                return new MemoryStream(Encoding.UTF8.GetBytes(obj.ToString()));
            }
            catch (RpcInternalServerErrorException exception)
            {
                return new MemoryStream(Encoding.UTF8.GetBytes(ExceptionHelper.PrintRpcException(exception)));
            }
            catch (Exception exception)
            {
                return new MemoryStream(Encoding.UTF8.GetBytes(ExceptionHelper.PrintException(exception)));
            }

        }

        public Stream GetRawTransaction(string txid)
        {
            RpcMethods rpc = new RpcMethods(username, password, wallet_url, wallet_port);
            WebOperationContext.Current.OutgoingResponse.ContentType = "application/json; charset=utf-8";
            try
            {
                JObject obj = JObject.Parse(rpc.GetRawTransaction(txid));
                return new MemoryStream(Encoding.UTF8.GetBytes(obj.ToString()));
            }
            catch (RpcInternalServerErrorException exception)
            {
                return new MemoryStream(Encoding.UTF8.GetBytes(ExceptionHelper.PrintRpcException(exception)));
            }
            catch (Exception exception)
            {
                return new MemoryStream(Encoding.UTF8.GetBytes(ExceptionHelper.PrintException(exception)));
            }

        }

        public Stream SendRawTransaction(string hexstring)
        {
            RpcMethods rpc = new RpcMethods(username, password, wallet_url, wallet_port);
            WebOperationContext.Current.OutgoingResponse.ContentType = "application/json; charset=utf-8";
            try
            {
                JObject obj = JObject.Parse(rpc.SendRawTransaction(hexstring));
                return new MemoryStream(Encoding.UTF8.GetBytes(obj.ToString()));
            }
            catch (RpcInternalServerErrorException exception)
            {
                return new MemoryStream(Encoding.UTF8.GetBytes(ExceptionHelper.PrintRpcException(exception)));
            }
            catch (Exception exception)
            {
                return new MemoryStream(Encoding.UTF8.GetBytes(ExceptionHelper.PrintException(exception)));
            }

        }

        public Stream SignRawTransaction(string hexstring)
        {
            RpcMethods rpc = new RpcMethods(username, password, wallet_url, wallet_port);
            WebOperationContext.Current.OutgoingResponse.ContentType = "application/json; charset=utf-8";
            try
            {
                JObject obj = JObject.Parse(rpc.SignRawTransaction(hexstring));
                return new MemoryStream(Encoding.UTF8.GetBytes(obj.ToString()));
            }
            catch (RpcInternalServerErrorException exception)
            {
                return new MemoryStream(Encoding.UTF8.GetBytes(ExceptionHelper.PrintRpcException(exception)));
            }
            catch (Exception exception)
            {
                return new MemoryStream(Encoding.UTF8.GetBytes(ExceptionHelper.PrintException(exception)));
            }

        }

        //== Util ==

        public Stream CreateMultiSig(MultiSigRequest request)
        {
            RpcMethods rpc = new RpcMethods(username, password, wallet_url, wallet_port);
            WebOperationContext.Current.OutgoingResponse.ContentType = "application/json; charset=utf-8";
            try
            {
                var keys = new JArray();
                foreach(var k in request.keys)
                {
                    keys.Add(k.key);
                }                

                JObject obj = JObject.Parse(rpc.CreateMultisig(request.nrequired, keys));
                return new MemoryStream(Encoding.UTF8.GetBytes(obj.ToString()));
            }
            catch (RpcInternalServerErrorException exception)
            {
                return new MemoryStream(Encoding.UTF8.GetBytes(ExceptionHelper.PrintRpcException(exception)));
            }
            catch (Exception exception)
            {
                return new MemoryStream(Encoding.UTF8.GetBytes(ExceptionHelper.PrintException(exception)));
            }
        }
        public Stream EstimateFee(string nblocks)
        {
            RpcMethods rpc = new RpcMethods(username, password, wallet_url, wallet_port);
            WebOperationContext.Current.OutgoingResponse.ContentType = "application/json; charset=utf-8";
            try
            {
                JObject obj = JObject.Parse(rpc.EstimateFee(Convert.ToInt32(nblocks)));
                return new MemoryStream(Encoding.UTF8.GetBytes(obj.ToString()));
            }
            catch (RpcInternalServerErrorException exception)
            {
                return new MemoryStream(Encoding.UTF8.GetBytes(ExceptionHelper.PrintRpcException(exception)));
            }
            catch (Exception exception)
            {
                return new MemoryStream(Encoding.UTF8.GetBytes(ExceptionHelper.PrintException(exception)));
            }

        }

        public Stream EstimatePriority(string nblocks)
        {
            RpcMethods rpc = new RpcMethods(username, password, wallet_url, wallet_port);
            WebOperationContext.Current.OutgoingResponse.ContentType = "application/json; charset=utf-8";
            try
            {
                JObject obj = JObject.Parse(rpc.EstimatePriority(nblocks));
                return new MemoryStream(Encoding.UTF8.GetBytes(obj.ToString()));
            }
            catch (RpcInternalServerErrorException exception)
            {
                return new MemoryStream(Encoding.UTF8.GetBytes(ExceptionHelper.PrintRpcException(exception)));
            }
            catch (Exception exception)
            {
                return new MemoryStream(Encoding.UTF8.GetBytes(ExceptionHelper.PrintException(exception)));
            }

        }

        public Stream ValidateAddress(string florincoinaddress)
        {
            RpcMethods rpc = new RpcMethods(username, password, wallet_url, wallet_port);
            WebOperationContext.Current.OutgoingResponse.ContentType = "application/json; charset=utf-8";
            try
            {
                JObject obj = JObject.Parse(rpc.ValidateAddress(florincoinaddress));
                return new MemoryStream(Encoding.UTF8.GetBytes(obj.ToString()));
            }
            catch (RpcInternalServerErrorException exception)
            {
                return new MemoryStream(Encoding.UTF8.GetBytes(ExceptionHelper.PrintRpcException(exception)));
            }
            catch (Exception exception)
            {
                return new MemoryStream(Encoding.UTF8.GetBytes(ExceptionHelper.PrintException(exception)));
            }

        }

        public Stream VerifyMessage(string florincoinaddress, string signature, string message)
        {
            RpcMethods rpc = new RpcMethods(username, password, wallet_url, wallet_port);
            WebOperationContext.Current.OutgoingResponse.ContentType = "application/json; charset=utf-8";
            try
            {
                JObject obj = JObject.Parse(rpc.VerifyMessage(florincoinaddress, signature, message));
                return new MemoryStream(Encoding.UTF8.GetBytes(obj.ToString()));
            }
            catch (RpcInternalServerErrorException exception)
            {
                return new MemoryStream(Encoding.UTF8.GetBytes(ExceptionHelper.PrintRpcException(exception)));
            }
            catch (Exception exception)
            {
                return new MemoryStream(Encoding.UTF8.GetBytes(ExceptionHelper.PrintException(exception)));
            }

        }

        //== Wallet ==

        public Stream AddMultiSigAddress(MultiSigRequest request)
        {
            RpcMethods rpc = new RpcMethods(username, password, wallet_url, wallet_port);
            WebOperationContext.Current.OutgoingResponse.ContentType = "application/json; charset=utf-8";
            try
            {
                var keys = new JArray();
                foreach (var k in request.keys)
                {
                    keys.Add(k.key);
                }

                JObject obj = JObject.Parse(rpc.AddMultisigAddress(request.nrequired, keys));
                return new MemoryStream(Encoding.UTF8.GetBytes(obj.ToString()));
            }
            catch (RpcInternalServerErrorException exception)
            {
                return new MemoryStream(Encoding.UTF8.GetBytes(ExceptionHelper.PrintRpcException(exception)));
            }
            catch (Exception exception)
            {
                return new MemoryStream(Encoding.UTF8.GetBytes(ExceptionHelper.PrintException(exception)));
            }
        }
        public Stream DumpPrivkey(string florincoinaddress)
        {
            RpcMethods rpc = new RpcMethods(username, password, wallet_url, wallet_port);
            WebOperationContext.Current.OutgoingResponse.ContentType = "application/json; charset=utf-8";
            try
            {
                JObject obj = JObject.Parse(rpc.DumpPrivkey(florincoinaddress));
                return new MemoryStream(Encoding.UTF8.GetBytes(obj.ToString()));
            }
            catch (RpcInternalServerErrorException exception)
            {
                return new MemoryStream(Encoding.UTF8.GetBytes(ExceptionHelper.PrintRpcException(exception)));
            }
            catch (Exception exception)
            {
                return new MemoryStream(Encoding.UTF8.GetBytes(ExceptionHelper.PrintException(exception)));
            }

        }

        public Stream DumpWallet(string filename)
        {
            RpcMethods rpc = new RpcMethods(username, password, wallet_url, wallet_port);
            WebOperationContext.Current.OutgoingResponse.ContentType = "application/json; charset=utf-8";
            try
            {
                JObject obj = JObject.Parse(rpc.DumpWallet(filename));
                return new MemoryStream(Encoding.UTF8.GetBytes(obj.ToString()));
            }
            catch (RpcInternalServerErrorException exception)
            {
                return new MemoryStream(Encoding.UTF8.GetBytes(ExceptionHelper.PrintRpcException(exception)));
            }
            catch (Exception exception)
            {
                return new MemoryStream(Encoding.UTF8.GetBytes(ExceptionHelper.PrintException(exception)));
            }

        }

        public Stream EncryptWallet(string passphrase)
        {
            RpcMethods rpc = new RpcMethods(username, password, wallet_url, wallet_port);
            WebOperationContext.Current.OutgoingResponse.ContentType = "application/json; charset=utf-8";
            try
            {
                JObject obj = JObject.Parse(rpc.EncryptWallet(passphrase));
                return new MemoryStream(Encoding.UTF8.GetBytes(obj.ToString()));
            }
            catch (RpcInternalServerErrorException exception)
            {
                return new MemoryStream(Encoding.UTF8.GetBytes(ExceptionHelper.PrintRpcException(exception)));
            }
            catch (Exception exception)
            {
                return new MemoryStream(Encoding.UTF8.GetBytes(ExceptionHelper.PrintException(exception)));
            }

        }

        public Stream GetAccount(string florincoinaddress)
        {
            RpcMethods rpc = new RpcMethods(username, password, wallet_url, wallet_port);
            WebOperationContext.Current.OutgoingResponse.ContentType = "application/json; charset=utf-8";
            try
            {
                JObject obj = JObject.Parse(rpc.GetAccount(florincoinaddress));
                return new MemoryStream(Encoding.UTF8.GetBytes(obj.ToString()));
            }
            catch (RpcInternalServerErrorException exception)
            {
                return new MemoryStream(Encoding.UTF8.GetBytes(ExceptionHelper.PrintRpcException(exception)));
            }
            catch (Exception exception)
            {
                return new MemoryStream(Encoding.UTF8.GetBytes(ExceptionHelper.PrintException(exception)));
            }

        }

        public Stream GetAccountAddress(string account)
        {
            RpcMethods rpc = new RpcMethods(username, password, wallet_url, wallet_port);
            WebOperationContext.Current.OutgoingResponse.ContentType = "application/json; charset=utf-8";
            try
            {
                JObject obj = JObject.Parse(rpc.GetAccountAddress(account));
                return new MemoryStream(Encoding.UTF8.GetBytes(obj.ToString()));
            }
            catch (RpcInternalServerErrorException exception)
            {
                return new MemoryStream(Encoding.UTF8.GetBytes(ExceptionHelper.PrintRpcException(exception)));
            }
            catch (Exception exception)
            {
                return new MemoryStream(Encoding.UTF8.GetBytes(ExceptionHelper.PrintException(exception)));
            }

        }

        public Stream GetAddressesByAccount(string account)
        {
            RpcMethods rpc = new RpcMethods(username, password, wallet_url, wallet_port);
            WebOperationContext.Current.OutgoingResponse.ContentType = "application/json; charset=utf-8";
            try
            {
                JObject obj = JObject.Parse(rpc.GetAddressesByAccount(account));
                return new MemoryStream(Encoding.UTF8.GetBytes(obj.ToString()));
            }
            catch (RpcInternalServerErrorException exception)
            {
                return new MemoryStream(Encoding.UTF8.GetBytes(ExceptionHelper.PrintRpcException(exception)));
            }
            catch (Exception exception)
            {
                return new MemoryStream(Encoding.UTF8.GetBytes(ExceptionHelper.PrintException(exception)));
            }

        }

        public Stream GetBalance(string account)
        {
            if(string.IsNullOrEmpty(account))
            {
                account = "";
            }
            RpcMethods rpc = new RpcMethods(username, password, wallet_url, wallet_port);
            WebOperationContext.Current.OutgoingResponse.ContentType = "application/json; charset=utf-8";
            try
            {
                JObject obj = JObject.Parse(rpc.GetBalance(account));
                return new MemoryStream(Encoding.UTF8.GetBytes(obj.ToString()));
            }
            catch (RpcInternalServerErrorException exception)
            {
                return new MemoryStream(Encoding.UTF8.GetBytes(ExceptionHelper.PrintRpcException(exception)));
            }
            catch (Exception exception)
            {
                return new MemoryStream(Encoding.UTF8.GetBytes(ExceptionHelper.PrintException(exception)));
            }

        }

        public Stream GetNewAddress(string account)
        {
            if (string.IsNullOrEmpty(account))
            {
                account = "";
            }
            RpcMethods rpc = new RpcMethods(username, password, wallet_url, wallet_port);
            WebOperationContext.Current.OutgoingResponse.ContentType = "application/json; charset=utf-8";
            try
            {
                JObject obj = JObject.Parse(rpc.GetNewAddress(account));
                return new MemoryStream(Encoding.UTF8.GetBytes(obj.ToString()));
            }
            catch (RpcInternalServerErrorException exception)
            {
                return new MemoryStream(Encoding.UTF8.GetBytes(ExceptionHelper.PrintRpcException(exception)));
            }
            catch (Exception exception)
            {
                return new MemoryStream(Encoding.UTF8.GetBytes(ExceptionHelper.PrintException(exception)));
            }

        }

        public Stream GetRawChangeAddress()
        {
            RpcMethods rpc = new RpcMethods(username, password, wallet_url, wallet_port);
            WebOperationContext.Current.OutgoingResponse.ContentType = "application/json; charset=utf-8";
            try
            {
                JObject obj = JObject.Parse(rpc.GetRawChangeAddress());
                return new MemoryStream(Encoding.UTF8.GetBytes(obj.ToString()));
            }
            catch (RpcInternalServerErrorException exception)
            {
                return new MemoryStream(Encoding.UTF8.GetBytes(ExceptionHelper.PrintRpcException(exception)));
            }
            catch (Exception exception)
            {
                return new MemoryStream(Encoding.UTF8.GetBytes(ExceptionHelper.PrintException(exception)));
            }

        }

        public Stream GetReceivedByAccount(string account)
        {
            RpcMethods rpc = new RpcMethods(username, password, wallet_url, wallet_port);
            WebOperationContext.Current.OutgoingResponse.ContentType = "application/json; charset=utf-8";
            try
            {
                JObject obj = JObject.Parse(rpc.GetReceivedByAccount(account));
                return new MemoryStream(Encoding.UTF8.GetBytes(obj.ToString()));
            }
            catch (RpcInternalServerErrorException exception)
            {
                return new MemoryStream(Encoding.UTF8.GetBytes(ExceptionHelper.PrintRpcException(exception)));
            }
            catch (Exception exception)
            {
                return new MemoryStream(Encoding.UTF8.GetBytes(ExceptionHelper.PrintException(exception)));
            }

        }

        public Stream GetReceivedByAddress(string florincoinaddress)
        {
            RpcMethods rpc = new RpcMethods(username, password, wallet_url, wallet_port);
            WebOperationContext.Current.OutgoingResponse.ContentType = "application/json; charset=utf-8";
            try
            {
                JObject obj = JObject.Parse(rpc.GetReceivedByAddress(florincoinaddress));
                return new MemoryStream(Encoding.UTF8.GetBytes(obj.ToString()));
            }
            catch (RpcInternalServerErrorException exception)
            {
                return new MemoryStream(Encoding.UTF8.GetBytes(ExceptionHelper.PrintRpcException(exception)));
            }
            catch (Exception exception)
            {
                return new MemoryStream(Encoding.UTF8.GetBytes(ExceptionHelper.PrintException(exception)));
            }

        }

        public Stream GetTransaction(string txid)
        {
            RpcMethods rpc = new RpcMethods(username, password, wallet_url, wallet_port);
            WebOperationContext.Current.OutgoingResponse.ContentType = "application/json; charset=utf-8";
            try
            {
                JObject obj = JObject.Parse(rpc.GetTransaction(txid));
                return new MemoryStream(Encoding.UTF8.GetBytes(obj.ToString()));
            }
            catch (RpcInternalServerErrorException exception)
            {
                return new MemoryStream(Encoding.UTF8.GetBytes(ExceptionHelper.PrintRpcException(exception)));
            }
            catch (Exception exception)
            {
                return new MemoryStream(Encoding.UTF8.GetBytes(ExceptionHelper.PrintException(exception)));
            }

        }

        public Stream GetUnconfirmedBalance()
        {
            RpcMethods rpc = new RpcMethods(username, password, wallet_url, wallet_port);
            WebOperationContext.Current.OutgoingResponse.ContentType = "application/json; charset=utf-8";
            try
            {
                JObject obj = JObject.Parse(rpc.GetUnconfirmedBalance());
                return new MemoryStream(Encoding.UTF8.GetBytes(obj.ToString()));
            }
            catch (RpcInternalServerErrorException exception)
            {
                return new MemoryStream(Encoding.UTF8.GetBytes(ExceptionHelper.PrintRpcException(exception)));
            }
            catch (Exception exception)
            {
                return new MemoryStream(Encoding.UTF8.GetBytes(ExceptionHelper.PrintException(exception)));
            }

        }

        public Stream GetWalletInfo()
        {
            RpcMethods rpc = new RpcMethods(username, password, wallet_url, wallet_port);
            WebOperationContext.Current.OutgoingResponse.ContentType = "application/json; charset=utf-8";
            try
            {
                JObject obj = JObject.Parse(rpc.GetWalletInfo());
                return new MemoryStream(Encoding.UTF8.GetBytes(obj.ToString()));
            }
            catch (RpcInternalServerErrorException exception)
            {
                return new MemoryStream(Encoding.UTF8.GetBytes(ExceptionHelper.PrintRpcException(exception)));
            }
            catch (Exception exception)
            {
                return new MemoryStream(Encoding.UTF8.GetBytes(ExceptionHelper.PrintException(exception)));
            }

        }

        public Stream ImportAddress(string address)
        {
            RpcMethods rpc = new RpcMethods(username, password, wallet_url, wallet_port);
            WebOperationContext.Current.OutgoingResponse.ContentType = "application/json; charset=utf-8";
            try
            {
                JObject obj = JObject.Parse(rpc.ImportAddress(address));
                return new MemoryStream(Encoding.UTF8.GetBytes(obj.ToString()));
            }
            catch (RpcInternalServerErrorException exception)
            {
                return new MemoryStream(Encoding.UTF8.GetBytes(ExceptionHelper.PrintRpcException(exception)));
            }
            catch (Exception exception)
            {
                return new MemoryStream(Encoding.UTF8.GetBytes(ExceptionHelper.PrintException(exception)));
            }

        }

        public Stream ImportPrivKey(string florincoinprivkey)
        {
            RpcMethods rpc = new RpcMethods(username, password, wallet_url, wallet_port);
            WebOperationContext.Current.OutgoingResponse.ContentType = "application/json; charset=utf-8";
            try
            {
                JObject obj = JObject.Parse(rpc.ImportPrivKey(florincoinprivkey));
                return new MemoryStream(Encoding.UTF8.GetBytes(obj.ToString()));
            }
            catch (RpcInternalServerErrorException exception)
            {
                return new MemoryStream(Encoding.UTF8.GetBytes(ExceptionHelper.PrintRpcException(exception)));
            }
            catch (Exception exception)
            {
                return new MemoryStream(Encoding.UTF8.GetBytes(ExceptionHelper.PrintException(exception)));
            }

        }

        public Stream ImportWallet(string filename)
        {
            RpcMethods rpc = new RpcMethods(username, password, wallet_url, wallet_port);
            WebOperationContext.Current.OutgoingResponse.ContentType = "application/json; charset=utf-8";
            try
            {
                JObject obj = JObject.Parse(rpc.ImportWallet(filename));
                return new MemoryStream(Encoding.UTF8.GetBytes(obj.ToString()));
            }
            catch (RpcInternalServerErrorException exception)
            {
                return new MemoryStream(Encoding.UTF8.GetBytes(ExceptionHelper.PrintRpcException(exception)));
            }
            catch (Exception exception)
            {
                return new MemoryStream(Encoding.UTF8.GetBytes(ExceptionHelper.PrintException(exception)));
            }

        }

        public Stream KeypoolRefill()
        {
            RpcMethods rpc = new RpcMethods(username, password, wallet_url, wallet_port);
            WebOperationContext.Current.OutgoingResponse.ContentType = "application/json; charset=utf-8";
            try
            {
                JObject obj = JObject.Parse(rpc.KeypoolRefill());
                return new MemoryStream(Encoding.UTF8.GetBytes(obj.ToString()));
            }
            catch (RpcInternalServerErrorException exception)
            {
                return new MemoryStream(Encoding.UTF8.GetBytes(ExceptionHelper.PrintRpcException(exception)));
            }
            catch (Exception exception)
            {
                return new MemoryStream(Encoding.UTF8.GetBytes(ExceptionHelper.PrintException(exception)));
            }

        }

        public Stream ListAccounts()
        {
            RpcMethods rpc = new RpcMethods(username, password, wallet_url, wallet_port);
            WebOperationContext.Current.OutgoingResponse.ContentType = "application/json; charset=utf-8";
            try
            {
                JObject obj = JObject.Parse(rpc.ListAccounts());
                return new MemoryStream(Encoding.UTF8.GetBytes(obj.ToString()));
            }
            catch (RpcInternalServerErrorException exception)
            {
                return new MemoryStream(Encoding.UTF8.GetBytes(ExceptionHelper.PrintRpcException(exception)));
            }
            catch (Exception exception)
            {
                return new MemoryStream(Encoding.UTF8.GetBytes(ExceptionHelper.PrintException(exception)));
            }

        }

        public Stream ListAddressGroupings()
        {
            RpcMethods rpc = new RpcMethods(username, password, wallet_url, wallet_port);
            WebOperationContext.Current.OutgoingResponse.ContentType = "application/json; charset=utf-8";
            try
            {
                JObject obj = JObject.Parse(rpc.ListAddressGroupings());
                return new MemoryStream(Encoding.UTF8.GetBytes(obj.ToString()));
            }
            catch (RpcInternalServerErrorException exception)
            {
                return new MemoryStream(Encoding.UTF8.GetBytes(ExceptionHelper.PrintRpcException(exception)));
            }
            catch (Exception exception)
            {
                return new MemoryStream(Encoding.UTF8.GetBytes(ExceptionHelper.PrintException(exception)));
            }

        }

        public Stream ListLockUnspent()
        {
            RpcMethods rpc = new RpcMethods(username, password, wallet_url, wallet_port);
            WebOperationContext.Current.OutgoingResponse.ContentType = "application/json; charset=utf-8";
            try
            {
                JObject obj = JObject.Parse(rpc.ListLockUnspent());
                return new MemoryStream(Encoding.UTF8.GetBytes(obj.ToString()));
            }
            catch (RpcInternalServerErrorException exception)
            {
                return new MemoryStream(Encoding.UTF8.GetBytes(ExceptionHelper.PrintRpcException(exception)));
            }
            catch (Exception exception)
            {
                return new MemoryStream(Encoding.UTF8.GetBytes(ExceptionHelper.PrintException(exception)));
            }

        }

        public Stream ListReceivedByAccount()
        {
            RpcMethods rpc = new RpcMethods(username, password, wallet_url, wallet_port);
            WebOperationContext.Current.OutgoingResponse.ContentType = "application/json; charset=utf-8";
            try
            {
                JObject obj = JObject.Parse(rpc.ListReceivedByAccount());
                return new MemoryStream(Encoding.UTF8.GetBytes(obj.ToString()));
            }
            catch (RpcInternalServerErrorException exception)
            {
                return new MemoryStream(Encoding.UTF8.GetBytes(ExceptionHelper.PrintRpcException(exception)));
            }
            catch (Exception exception)
            {
                return new MemoryStream(Encoding.UTF8.GetBytes(ExceptionHelper.PrintException(exception)));
            }

        }

        public Stream ListReceivedByAddress()
        {
            RpcMethods rpc = new RpcMethods(username, password, wallet_url, wallet_port);
            WebOperationContext.Current.OutgoingResponse.ContentType = "application/json; charset=utf-8";
            try
            {
                JObject obj = JObject.Parse(rpc.ListReceivedByAddress());
                return new MemoryStream(Encoding.UTF8.GetBytes(obj.ToString()));
            }
            catch (RpcInternalServerErrorException exception)
            {
                return new MemoryStream(Encoding.UTF8.GetBytes(ExceptionHelper.PrintRpcException(exception)));
            }
            catch (Exception exception)
            {
                return new MemoryStream(Encoding.UTF8.GetBytes(ExceptionHelper.PrintException(exception)));
            }

        }

        public Stream ListSinceBlock()
        {
            RpcMethods rpc = new RpcMethods(username, password, wallet_url, wallet_port);
            WebOperationContext.Current.OutgoingResponse.ContentType = "application/json; charset=utf-8";
            try
            {
                JObject obj = JObject.Parse(rpc.ListSinceBlock());
                return new MemoryStream(Encoding.UTF8.GetBytes(obj.ToString()));
            }
            catch (RpcInternalServerErrorException exception)
            {
                return new MemoryStream(Encoding.UTF8.GetBytes(ExceptionHelper.PrintRpcException(exception)));
            }
            catch (Exception exception)
            {
                return new MemoryStream(Encoding.UTF8.GetBytes(ExceptionHelper.PrintException(exception)));
            }

        }

        public Stream ListTransactions()
        {
            RpcMethods rpc = new RpcMethods(username, password, wallet_url, wallet_port);
            WebOperationContext.Current.OutgoingResponse.ContentType = "application/json; charset=utf-8";
            try
            {
                JObject obj = JObject.Parse(rpc.ListTransactions());
                return new MemoryStream(Encoding.UTF8.GetBytes(obj.ToString()));
            }
            catch (RpcInternalServerErrorException exception)
            {
                return new MemoryStream(Encoding.UTF8.GetBytes(ExceptionHelper.PrintRpcException(exception)));
            }
            catch (Exception exception)
            {
                return new MemoryStream(Encoding.UTF8.GetBytes(ExceptionHelper.PrintException(exception)));
            }

        }

        public Stream ListUnspent()
        {
            RpcMethods rpc = new RpcMethods(username, password, wallet_url, wallet_port);
            WebOperationContext.Current.OutgoingResponse.ContentType = "application/json; charset=utf-8";
            try
            {
                JObject obj = JObject.Parse(rpc.ListUnspent());
                return new MemoryStream(Encoding.UTF8.GetBytes(obj.ToString()));
            }
            catch (RpcInternalServerErrorException exception)
            {
                return new MemoryStream(Encoding.UTF8.GetBytes(ExceptionHelper.PrintRpcException(exception)));
            }
            catch (Exception exception)
            {
                return new MemoryStream(Encoding.UTF8.GetBytes(ExceptionHelper.PrintException(exception)));
            }

        }

        public Stream LockUnspent(LockUnspentRequest request)
        {
            RpcMethods rpc = new RpcMethods(username, password, wallet_url, wallet_port);
            WebOperationContext.Current.OutgoingResponse.ContentType = "application/json; charset=utf-8";
            try
            {
                var transactions = new JArray();
                foreach (var t in request.transactions)
                {
                    var trans = new JObject();
                    trans.Add("txid", t.txid);
                    trans.Add("vout", t.vout);
                    transactions.Add(trans);
                }

                JObject obj = JObject.Parse(rpc.LockUnspent(request.unlock, transactions));
                return new MemoryStream(Encoding.UTF8.GetBytes(obj.ToString()));
            }
            catch (RpcInternalServerErrorException exception)
            {
                return new MemoryStream(Encoding.UTF8.GetBytes(ExceptionHelper.PrintRpcException(exception)));
            }
            catch (Exception exception)
            {
                return new MemoryStream(Encoding.UTF8.GetBytes(ExceptionHelper.PrintException(exception)));
            }
        }

        public Stream Move(string fromaccount, string toaccount, string amount)
        {
            RpcMethods rpc = new RpcMethods(username, password, wallet_url, wallet_port);
            WebOperationContext.Current.OutgoingResponse.ContentType = "application/json; charset=utf-8";
            try
            {
                JObject obj = JObject.Parse(rpc.Move(fromaccount, toaccount, Convert.ToDecimal(amount)));
                return new MemoryStream(Encoding.UTF8.GetBytes(obj.ToString()));
            }
            catch (RpcInternalServerErrorException exception)
            {
                return new MemoryStream(Encoding.UTF8.GetBytes(ExceptionHelper.PrintRpcException(exception)));
            }
            catch (Exception exception)
            {
                return new MemoryStream(Encoding.UTF8.GetBytes(ExceptionHelper.PrintException(exception)));
            }

        }

        public Stream SendFrom(string fromaccount, string toflorincoinaddress, string amount)
        {
            RpcMethods rpc = new RpcMethods(username, password, wallet_url, wallet_port);
            WebOperationContext.Current.OutgoingResponse.ContentType = "application/json; charset=utf-8";
            try
            {
                JObject obj = JObject.Parse(rpc.SendFrom(fromaccount, toflorincoinaddress, Convert.ToDecimal(amount)));
                return new MemoryStream(Encoding.UTF8.GetBytes(obj.ToString()));
            }
            catch (RpcInternalServerErrorException exception)
            {
                return new MemoryStream(Encoding.UTF8.GetBytes(ExceptionHelper.PrintRpcException(exception)));
            }
            catch (Exception exception)
            {
                return new MemoryStream(Encoding.UTF8.GetBytes(ExceptionHelper.PrintException(exception)));
            }

        }

        public Stream SendMany(SendManyRequest request)
        {
            RpcMethods rpc = new RpcMethods(username, password, wallet_url, wallet_port);
            WebOperationContext.Current.OutgoingResponse.ContentType = "application/json; charset=utf-8";
            try
            {
                var transactions = new JObject();
                foreach(var t in request.addresses)
                {
                    transactions.Add(t.txid, t.vout);
                }

                JObject obj = JObject.Parse(rpc.SendMany(request.fromaddress, transactions));
                return new MemoryStream(Encoding.UTF8.GetBytes(obj.ToString()));
            }
            catch (RpcInternalServerErrorException exception)
            {
                return new MemoryStream(Encoding.UTF8.GetBytes(ExceptionHelper.PrintRpcException(exception)));
            }
            catch (Exception exception)
            {
                return new MemoryStream(Encoding.UTF8.GetBytes(ExceptionHelper.PrintException(exception)));
            }
        }

        //public Stream SendToAddress(string address, string amount, string comment, string comment_to, string subtractfeefromamount, string replaceable, string conf_target, string estimate_mode, string floData)
        //{
        //    if (string.IsNullOrEmpty(comment))
        //    {
        //        comment = "";
        //    }

        //    if (string.IsNullOrEmpty(comment_to))
        //    {
        //        comment_to = "";
        //    }            

        //    if (string.IsNullOrEmpty(floData))
        //    {
        //        floData = "";
        //    }

        //    RpcMethods rpc = new RpcMethods(username, password, wallet_url, wallet_port);
        //    WebOperationContext.Current.OutgoingResponse.ContentType = "application/json; charset=utf-8";
        //    try
        //    {
        //        JObject obj = JObject.Parse(rpc.SendToAddress(address, Convert.ToDecimal(amount), comment, comment_to,Convert.ToBoolean(subtractfeefromamount), Convert.ToBoolean(replaceable),Convert.ToInt32(conf_target),estimate_mode,floData));
        //        return new MemoryStream(Encoding.UTF8.GetBytes(obj.ToString()));
        //    }
        //    catch (RpcInternalServerErrorException exception)
        //    {
        //        return new MemoryStream(Encoding.UTF8.GetBytes(ExceptionHelper.PrintRpcException(exception)));
        //    }
        //    catch (Exception exception)
        //    {
        //        return new MemoryStream(Encoding.UTF8.GetBytes(ExceptionHelper.PrintException(exception)));
        //    }

        //}

        //POST
        public Stream SendToAddress(SendToAddressRequest request)
        {
            if (string.IsNullOrEmpty(request.comment))
            {
                request.comment = "";
            }

            if (string.IsNullOrEmpty(request.comment_to))
            {
                request.comment_to = "";
            }

            if (string.IsNullOrEmpty(request.floData))
            {
                request.floData = "";
            }

            RpcMethods rpc = new RpcMethods(username, password, wallet_url, wallet_port);
            WebOperationContext.Current.OutgoingResponse.ContentType = "application/json; charset=utf-8";
            try
            {
                JObject obj = JObject.Parse(rpc.SendToAddress(request.address, Convert.ToDecimal(request.amount), request.comment, request.comment_to, Convert.ToBoolean(request.subtractfeefromamount), Convert.ToBoolean(request.replaceable), Convert.ToInt32(request.conf_target), request.estimate_mode, request.floData));
                return new MemoryStream(Encoding.UTF8.GetBytes(obj.ToString()));
            }
            catch (RpcInternalServerErrorException exception)
            {
                return new MemoryStream(Encoding.UTF8.GetBytes(ExceptionHelper.PrintRpcException(exception)));
            }
            catch (Exception exception)
            {
                return new MemoryStream(Encoding.UTF8.GetBytes(ExceptionHelper.PrintException(exception)));
            }

        }

        public Stream SetAccount(string florincoinaddress, string account)
        {
            RpcMethods rpc = new RpcMethods(username, password, wallet_url, wallet_port);
            WebOperationContext.Current.OutgoingResponse.ContentType = "application/json; charset=utf-8";
            try
            {
                JObject obj = JObject.Parse(rpc.SetAccount(florincoinaddress, account));
                return new MemoryStream(Encoding.UTF8.GetBytes(obj.ToString()));
            }
            catch (RpcInternalServerErrorException exception)
            {
                return new MemoryStream(Encoding.UTF8.GetBytes(ExceptionHelper.PrintRpcException(exception)));
            }
            catch (Exception exception)
            {
                return new MemoryStream(Encoding.UTF8.GetBytes(ExceptionHelper.PrintException(exception)));
            }

        }

        public Stream SetTxFee(string amount)
        {
            RpcMethods rpc = new RpcMethods(username, password, wallet_url, wallet_port);
            WebOperationContext.Current.OutgoingResponse.ContentType = "application/json; charset=utf-8";
            try
            {
                JObject obj = JObject.Parse(rpc.SetTxFee(Convert.ToDecimal(amount)));
                return new MemoryStream(Encoding.UTF8.GetBytes(obj.ToString()));
            }
            catch (RpcInternalServerErrorException exception)
            {
                return new MemoryStream(Encoding.UTF8.GetBytes(ExceptionHelper.PrintRpcException(exception)));
            }
            catch (Exception exception)
            {
                return new MemoryStream(Encoding.UTF8.GetBytes(ExceptionHelper.PrintException(exception)));
            }

        }

        public Stream SignMessage(string florincoinaddress, string message)
        {
            RpcMethods rpc = new RpcMethods(username, password, wallet_url, wallet_port);
            WebOperationContext.Current.OutgoingResponse.ContentType = "application/json; charset=utf-8";
            try
            {
                JObject obj = JObject.Parse(rpc.SignMessage(florincoinaddress, message));
                return new MemoryStream(Encoding.UTF8.GetBytes(obj.ToString()));
            }
            catch (RpcInternalServerErrorException exception)
            {
                return new MemoryStream(Encoding.UTF8.GetBytes(ExceptionHelper.PrintRpcException(exception)));
            }
            catch (Exception exception)
            {
                return new MemoryStream(Encoding.UTF8.GetBytes(ExceptionHelper.PrintException(exception)));
            }

        }

        //===Extended Methods===
        public Stream GetAddrBalance(string address)
        {
            RpcMethods rpc = new RpcMethods(username, password, wallet_url, wallet_port);
            WebOperationContext.Current.OutgoingResponse.ContentType = "application/json; charset=utf-8";
            try
            {
                JavaScriptSerializer json_serializer = new JavaScriptSerializer();
                ValidateAddressResponse obj = (ValidateAddressResponse)json_serializer.DeserializeObject(rpc.ValidateAddress(address));


                if (!obj.isvalid)
                {
                    throw new GetAddressBalanceException($"Address {inWalletAddress} is invalid!");
                }






                return new MemoryStream(Encoding.UTF8.GetBytes(obj.ToString()));
            }
            catch (RpcInternalServerErrorException exception)
            {
                return new MemoryStream(Encoding.UTF8.GetBytes(ExceptionHelper.PrintRpcException(exception)));
            }
            catch (Exception exception)
            {
                return new MemoryStream(Encoding.UTF8.GetBytes(ExceptionHelper.PrintException(exception)));
            }

        }

    }
}
