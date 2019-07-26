using System.Collections.Generic;
using System;
using System.Diagnostics;
using BestHTTP;
using Org.BouncyCastle.Asn1.Ocsp;

namespace FATRequest
{
    

    

    
    public delegate void OnRequestFinishedDelegate(Request request,object response);

    public class Request
    {        

        private MessagesIDS messageId;
        
        public object parameters;
        
        private ProtocolType protocolType;

        private SerializationType serializationType;

        public FATHttpMethods httpMethod;

        /// <summary>
        /// 在发送websocket消息之前,务必要先确保建立一条连接
        /// </summary>
        public static void EstablishWebsocketConnect()
        {
            WebSocketManager.GetInstance().Connect();
        }

        public static void CloseWebsocketConnect()
        {
            WebSocketManager.GetInstance().CloseConnect();
        }
        
        //接受请求的配置参数
        public Request(MessagesIDS message,ProtocolType protocolType,SerializationType serializationType)
        {
            this.messageId = message;
            this.protocolType = protocolType;
            this.serializationType = serializationType;
        }

        //发送请求
        public void Send()
        {
            switch (protocolType)
            {
                case ProtocolType.Http:
                    HttpRequestManager httpRequestManager = new HttpRequestManager("http://" + NetConfig.Host);
                    httpRequestManager.parameters = parameters;
                    httpRequestManager.methods = httpMethod;
                    httpRequestManager.response = (requst, response) =>
                    {
                        List<Action<object>> responses = null;
                        RequestManager.GetManager().Responses.TryGetValue(messageId.ToString(), out responses);
                        if (responses != null)
                        {
                            foreach (Action<object> action in responses)
                            {
                                action(response);
                            }
                        }
                    };
                    httpRequestManager.Send();
                    break;
                case ProtocolType.Websocket:
                    WebSocketManager webSocketManager = WebSocketManager.GetInstance();
                    webSocketManager.parameters = parameters;
                    webSocketManager.messageId = messageId;
                    webSocketManager.serializationType = serializationType;
                    webSocketManager.Send();
                    break;
                default:
                    break;
            }
        }

        
    }

}

