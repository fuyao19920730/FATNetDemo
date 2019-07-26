using System;
using System.Collections;
using System.Collections.Generic;
using BestHTTP;
using BestHTTP.WebSocket;
using ProtoData;
using UnityEngine;

namespace FATRequest{
    public class WebSocketManager
    {
        private string address = "ws://" + NetConfig.Host;
        private static WebSocketManager instance;
        private WebSocket bestHttpSocket;
        public object parameters;
        public SerializationType serializationType = SerializationType.Json;
        public MessagesIDS messageId;


        public static WebSocketManager GetInstance()
        {
            if (instance == null)
                instance = new WebSocketManager();
		
            return instance;
        }

        public void Send()
        {
            //序列化参数
            byte[] sendData = GetRawData();
            SendMessage(sendData);
            
        }
        
        private byte[] GetRawData()
        {
            byte[] rawData = null;
            switch (serializationType)
            {
                case SerializationType.Json:
                    rawData = JsonTool.JsonDataFromObject(parameters);
                    break;
                case SerializationType.Protobuf:
                    rawData = ProtocolBufferTool.DataFromObject(messageId,parameters);
                    break;
                default:
                    break;
            }
            return rawData;
        }
        
        //发送socket消息前要确保已经有连接完成的websocket 连接了
        private void SendMessage(byte[] data)
        {
            //验证消息是否合法
            if (data.Length == 0)
            {
                return;
            }

            if (bestHttpSocket == null)
            {
                Debug.Log("no webSocket connect established");
                return;
            }
            
            //发送
            bestHttpSocket.Send(data);
        }

        public void CloseConnect()
        {
            if (bestHttpSocket == null)
            {
                Debug.Log("websocket 连接已经断开");
                return;
            }
            bestHttpSocket.Close();
        }
        
//        private void AddCustomHeaderFields()
//        {
//            StringBuilder sb = new StringBuilder();
//            switch (serializationType)
//            {
//                case SerializationType.Json:
//                    sb.Append("jsx_json");
//                    break;
//                case SerializationType.Protobuf:
//                    sb.Append("gpb");
//                    break;
//                case SerializationType.MsgPack:
//                    sb.Append("msgpack");
//                    break;
//            }
//            
//            httpReq.AddHeader("Proto",sb.ToString());
//            httpReq.AddHeader("MsgCarrier","false");
//            httpReq.AddHeader("Appid","Appid");
//            httpReq.AddHeader("Time",GetTimeStampSeconds());
//            httpReq.AddHeader("Pver",DeviceInfo.appver);
//            httpReq.AddHeader("Sign","Sign");
//            httpReq.AddHeader("Session","Session");
//        }
        
        //初始化的时候建立一条长连接
        public void Connect()
        {
            if (bestHttpSocket != null)
            {
                Debug.Log("webSocket connect has established");
                return;
            }
            
            bestHttpSocket = new WebSocket(new Uri(address));

            
            bestHttpSocket.InternalRequest.AddHeader("Proto","gpb");
            bestHttpSocket.InternalRequest.AddHeader("MsgCarrier","false");

            //开启心跳包连接
            bestHttpSocket.StartPingThread = true;
#if !BESTHTTP_DISABLE_PROXY && !UNITY_WEBGL
            if (HTTPManager.Proxy != null)
                bestHttpSocket.InternalRequest.Proxy = new HTTPProxy(HTTPManager.Proxy.Address, HTTPManager.Proxy.Credentials, false);
#endif

            // Subscribe to the WS events
            bestHttpSocket.OnOpen += OnOpen;
            bestHttpSocket.OnMessage += OnMessageReceived;
            bestHttpSocket.OnBinary += OnBinaryReceived;
            bestHttpSocket.OnClosed += OnClosed;
            bestHttpSocket.OnError += OnError;

            // Start connecting to the server
            bestHttpSocket.Open(); 
        }
        
        
        #region WebSocket Event Handlers

        /// <summary>
        /// Called when the web socket is open, and we are ready to send and receive data
        /// </summary>
        void OnOpen(WebSocket ws)
        {
            Debug.Log(string.Format("-WebSocket Open!\n"));
        }

        /// <summary>
        /// Called when we received a text message from the server
        /// </summary>
        void OnMessageReceived(WebSocket ws, string message)
        {
            Debug.Log(string.Format("-Message received: {0}\n", message));
        }
    
        /// <summary>
        ///  Called when a new binary message is received from the server.
        /// </summary>
        private void OnBinaryReceived(WebSocket websocket, byte[] data)+
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        {
            Debug.Log("this is received data");
            ByteBuffer buffer = new ByteBuffer(data);
            string messageName = buffer.ReadString();
            if (messageName.Contains("register_s2c"))
            {
                register_s2c re = ProtocolBufferTool.ObjectFromData<register_s2c>(MessagesIDS.Register,data);
                Debug.Log(re.name);
            }
            
        }

        /// <summary>
        /// Called when the web socket closed
        /// </summary>
        void OnClosed(WebSocket ws, UInt16 code, string message)
        {
            Debug.Log(string.Format("-WebSocket closed! Code: {0} Message: {1}\n", code, message));
            bestHttpSocket = null;
        }

        /// <summary>
        /// Called when an error occured on client side
        /// </summary>
        void OnError(WebSocket ws, Exception ex)
        {
            string errorMsg = string.Empty;
#if !UNITY_WEBGL || UNITY_EDITOR
            if (ws.InternalRequest.Response != null)
                errorMsg = string.Format("Status Code from Server: {0} and Message: {1}", ws.InternalRequest.Response.StatusCode, ws.InternalRequest.Response.Message);
#endif

            Debug.Log(string.Format("-An error occured: {0}\n", (ex != null ? ex.Message : "Unknown Error " + errorMsg)));
            bestHttpSocket = null;
        }

        #endregion
    }
}

