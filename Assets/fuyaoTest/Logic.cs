using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BestHTTP;
using BestHTTP.WebSocket;

enum RequestType
{
	Http = 0,
	Websocket = 1
}

enum SerializationType
{
	Json = 0,
	Protobuf = 1,
	MsgPack = 2
}

public class Logic : MonoBehaviour
{
	private RequestType curRequestType = RequestType.Http;
	private SerializationType curSerializationType = SerializationType.Json;
	
	private const string Host = "10.0.111.230:10101/";
	private WebSocket webSocket;
	
	public void OnRequestTypeChanged(int selectIndex)
	{
		curRequestType = (RequestType)selectIndex;
	}

	public void OnSerializationTypeChanged(int selectIndex)
	{
		curSerializationType = (SerializationType) selectIndex;
	}

	public void WebsocketClose()
	{
		webSocket.Close();
		webSocket = null;
	}
	
	public void WebSocketConnect()
	{
		Debug.Log("建立连接");
		// Create the WebSocket instance
		webSocket = new WebSocket(new Uri("ws://"+Host));
		webSocket.StartPingThread = true;
		webSocket.PingFrequency = 2000;
		// Subscribe to the WS events
		webSocket.OnOpen += OnOpen;
		webSocket.OnMessage += OnMessageReceived;
		webSocket.OnBinary += OnBinaryReceived;
		webSocket.OnClosed += OnClosed;
		webSocket.OnError += OnError;

		// Start connecting to the server
		webSocket.Open();
	}
	

	public void Register()
	{
		switch (curRequestType)
		{
			case RequestType.Http:
				switch (curSerializationType)
				{
					case SerializationType.Json:
						Register_http_json();
						break;
					case SerializationType.Protobuf:
						break;
					case SerializationType.MsgPack:
						break;
				}
				break;
			case RequestType.Websocket:
				switch (curSerializationType)
				{
					case SerializationType.Json:
						Register_webSocket_json();
						break;
					case SerializationType.Protobuf:
						break;
					case SerializationType.MsgPack:
						break;
				}
				break;
			
		}
	}

	public void Login()
	{
		switch (curRequestType)
		{
			case RequestType.Http:
				switch (curSerializationType)
				{
					case SerializationType.Json:
						Login_http_json();
						break;
					case SerializationType.Protobuf:
						break;
					case SerializationType.MsgPack:
						break;
				}
				break;
			case RequestType.Websocket:
				switch (curSerializationType)
				{
					case SerializationType.Json:
						break;
					case SerializationType.Protobuf:
						break;
					case SerializationType.MsgPack:
						break;
				}
				break;
			
		}
	}

	private void Login_http_json()
	{
		
	}

	#region Register
	private void Register_http_json()
	{
		HTTPRequest registerReq = new HTTPRequest(new Uri("http://"+Host),HTTPMethods.Post, (request, response) =>
		{
			//回调方法
			Debug.Log("回调成功");
		});
		
		//请求头
		registerReq.AddHeader("Proto","jsx_json");
		registerReq.AddHeader("MsgCarrier","false");
		registerReq.AddHeader("Appid","Appid");
		registerReq.AddHeader("Time",GetTimeStampSeconds());
		registerReq.AddHeader("Pver","Pver");
		registerReq.AddHeader("Sign","Sign");
		registerReq.AddHeader("Session","Session");
		
		//请求body
		registerReq.AddField("name", "QRegisterId");
		registerReq.AddField("type", "type");
		registerReq.AddField("id", "id");
		registerReq.AddField("deviceid", DeviceInfo.userid);

		//发送
		registerReq.Send();
	}

	private void Register_webSocket_json()
	{
		if (webSocket == null)
		{
			return;
		}
		
		Dictionary<string,object> obj = new Dictionary<string, object>();
		obj.Add("name","QRegisterId");
		obj.Add("type","type");
		obj.Add("id","id");
		obj.Add("deviceid",DeviceInfo.userid);
		string jsonStr = JsonTool.JsonStringFromObject(obj);
		webSocket.Send(jsonStr);
	}

	#endregion


	private string GetTimeStampSeconds()
	{
		TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
		long ret = Convert.ToInt64(ts.TotalSeconds);
		return ret.ToString();
	}
	
	
	
	#region WebSocket Event Handlers

	void OnOpen(WebSocket ws)
	{
		Debug.Log("-WebSocket Open!\n");
	}


	void OnMessageReceived(WebSocket ws, string message)
	{
		Debug.Log(string.Format("-Message received: {0}\n", message));
	}
    
	/// <summary>
	///  Called when a new binary message is received from the server.
	/// </summary>
	private void OnBinaryReceived(WebSocket websocket, byte[] data)
	{
		throw new NotImplementedException();
	}

	/// <summary>
	/// Called when the web socket closed
	/// </summary>
	void OnClosed(WebSocket ws, UInt16 code, string message)
	{
		Debug.Log(string.Format("-WebSocket closed! Code: {0} Message: {1}\n", code, message));
		webSocket = null;
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

		webSocket = null;
	}

	#endregion
}
