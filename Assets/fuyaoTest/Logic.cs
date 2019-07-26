using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FATRequest;




public class Logic : MonoBehaviour
{
	private RequestType curRequestType = RequestType.Http;
	private SerializationType curSerializationType = SerializationType.Json;
	

	private void Start()
	{
		//监听注册回调,多次注册会多次回调,小心
		RequestManager.GetManager().Subscribe(MessagesIDS.Register.ToString(), RegisterCallBack);
	}

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
		Debug.Log("Client 断开");
		Request.CloseWebsocketConnect();
	}
	
	public void WebSocketConnect()
	{
		Debug.Log("开始建立连接");
		Request.EstablishWebsocketConnect();
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
						Register_webSocket_protobuf();
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
		//参数
		Dictionary<string, object> parameters = new Dictionary<string, object>
		{
			{"name", "register_c2s"},
			{"type", "type"},
			{"id", "id"},
			{"deviceid", DeviceInfo.userid}
		};

		Request req = new Request(MessagesIDS.Register,ProtocolType.Http,FATRequest.SerializationType.Json);
		req.parameters = parameters;
		req.httpMethod = FATHttpMethods.Post;
		req.Send();
		
	}

	private void Register_webSocket_json()
	{
		Dictionary<string, object> parameters = new Dictionary<string, object>
		{
			{"name", "register_c2s"},
			{"type", "type"},
			{"id", "id"},
			{"deviceid", DeviceInfo.userid}
		};
		Request req = new Request(MessagesIDS.Register,ProtocolType.Websocket,FATRequest.SerializationType.Json);
		req.parameters = parameters;
		req.Send();
	}

	private void Register_webSocket_protobuf()
	{
		Dictionary<string, object> parameters = new Dictionary<string, object>
		{
			{"name", "register_c2s"},
			{"type", "type"},
			{"id", "id"},
			{"deviceid", DeviceInfo.userid}
		};
		Request req = new Request(MessagesIDS.Register,ProtocolType.Websocket,FATRequest.SerializationType.Protobuf);
		req.parameters = parameters;
		req.Send();
	}
	
	
	
	private void RegisterCallBack(object obj)
	{
		Debug.Log("call");
	}

	#endregion

}
