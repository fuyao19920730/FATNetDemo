using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FATRequest
{
	//消息和request 的绑定
	public class RequestManager
	{
		public Dictionary<string,List<Action<object>>> Responses = new Dictionary<string, List<Action<object>>>();
		
		private static RequestManager instance;

		public static RequestManager GetManager()
		{
			if (null == instance)
			{
				instance = new RequestManager();
			}
			return instance;
		}

		
		public void Subscribe(string cmd, Action<object> callBack)
		{
			List<Action<object>> list;
			Responses.TryGetValue(cmd, out list);
			if (list == null)
			list = new List<Action<object>>();
			list.Add(callBack);
		}
		
		public void UnSubscribe(string cmd,Action<object> callBack)
		{
			List<Action<object>> list;
			Responses.TryGetValue(cmd, out list);
			if (list == null)
			{
				return;
			}

			if (list.Contains(callBack))
			{
				list.Remove(callBack);
			}

			if (list.Count == 0)
			{
				Responses.Remove(cmd);
			}	
		}		
	}
}

