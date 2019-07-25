
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DeviceInfo  {

    public static string appname = "";
    public static string packagename = "";
    public static string appvercode = "";
    public static string appver = "";
    public static string userid = "";
    public static string idfv = "";
    public static string gps_adid = "";
    public static string devicecountry = "";
    public static string carriername = "";
    public static string syslanguage = "";
    public static string sysver = "";
    public static string devicemodel = "";
    public static string timezone = "";
    public static string unitysdkver = "";
    public static string sdkver = "";
    
    
    public static string netstatus()
    {
        string status = null;
        switch (Application.internetReachability)
        {
            case NetworkReachability.NotReachable:
                status = "NotReachable";
                break;
            case NetworkReachability.ReachableViaLocalAreaNetwork:
                status = "WIFI";
                break;
            case NetworkReachability.ReachableViaCarrierDataNetwork:
                status = "4G";
                break;
            default:
                status = "unknown";
                break;
        }
        return status;
    }


    public static void GetDeviceInfo()
	{
		//调用原生获取信息
		NativeMsgBridge.getInstance().GetDeviceInfo(DeviceInfoCallback);
	}

	private static void DeviceInfoCallback(string obj)
	{
        //在这里解析json,赋值给静态变量
        Debug.Log("拿到了json" + obj);


        Device device = JsonUtility.FromJson<Device>(obj);

        //静态变量持有
        appname = device.appname;
        packagename = device.packagename;
        appver = device.appver;
        userid = device.userid;
        idfv = device.idfv;
        devicecountry = device.devicecountry;
        carriername = device.carriername;
        syslanguage = device.syslanguage;
        sysver = device.sysver;
        devicemodel = device.devicemodel;
        timezone = device.timezone;
    }
}



/*
*{
*"appver":"0.1",
*"packagename":"com.fotoable.ahaha",
*"userid":"6E10A75B-E6C2-45FB-AB8E-07F1B073DCBE",
*"syslanguage":"en",
*"devicecountry":"CN",
*"idfv":"2B0A829F-6F91-4424-BC53-F0B3DEF88290",
*"sysver":"12.3.1",
*"devicemodel":"iPhone7",
*"appname":"FTNetDemo",
*"carriername":"中国移动"
*}
*/
[Serializable]
public class Device 
{
    public string appver;
    public string packagename;
    public string userid;
    public string syslanguage;
    public string devicecountry;
    public string idfv;
    public string sysver;
    public string devicemodel;
    public string appname;
    public string carriername;
    public string timezone;
}


