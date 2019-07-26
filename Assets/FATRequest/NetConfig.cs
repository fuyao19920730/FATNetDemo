using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FATRequest
{
    public enum RequestType
    {
        Http = 0,
        Websocket = 1
    }

    public enum SerializationType
    {
        Json = 0,
        Protobuf = 1,
        MsgPack = 2
    }



    public enum MessagesIDS
    {
        Register = 0,
    }
    
    public enum ProtocolType
    {
        Http,
        Websocket
    }
    
    class NetConfig
    {
        public const string Host = "10.0.111.230:10101/";
    }

}

