using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ProtoData;

namespace FATRequest
{
    public class ProtocolBufferTool  {	
	
        public static byte[] DataFromObject(MessagesIDS messageId,object obj)
        {
            switch (messageId)
            {
                case MessagesIDS.Register:
                    return GetRegisterSendData(obj);
                    break;
                default:
                    Debug.LogError("未匹配到对应的消息协议");
                    return null;
                    break;
            }
        }

        public static T ObjectFromData<T>(MessagesIDS messagesIds, byte[] data)
        {
            switch (messagesIds)
            {
                case MessagesIDS.Register:
                    return GetRegisterReceiveData<T>(data);
                    break;
                default:
                    Debug.LogError("未匹配到对应的消息协议");
                    return default(T);
                    break;
            }
        }



        private static byte[] GetRegisterSendData(object obj)
        {
            if (obj is Dictionary<string,object>)
            {
                Dictionary<string,object> dic = (Dictionary<string, object>)obj;
                register_c2s sendData = new register_c2s();
                if (dic.ContainsKey("name"))
                {
                    sendData.name = dic["name"].ToString();
                }

                if (dic.ContainsKey("echo"))
                {
                    sendData.echo = Convert.ToInt32(dic["echo"]);
                }

                if (dic.ContainsKey("id"))
                {
                    sendData.id = dic["id"].ToString();
                }
			
                if (dic.ContainsKey("type"))
                {
                    sendData.type = dic["type"].ToString();
                }
			
                if (dic.ContainsKey("deviceid"))
                {
                    sendData.deviceid = dic["deviceid"].ToString();
                }

                return PackCodec.Serialize(sendData);
            }
		
            return null;
        }

        private static T GetRegisterReceiveData<T>(byte[] data)
        {
            return PackCodec.Deserialize<T>(data);
		
		
        }
    }

}

