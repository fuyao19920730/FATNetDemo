//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: Proto/message.proto
namespace ProtoData
{
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"register_c2s")]
  public partial class register_c2s : global::ProtoBuf.IExtensible
  {
    public register_c2s() {}
    
    private string _name;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"name", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public string name
    {
      get { return _name; }
      set { _name = value; }
    }
    private int _echo;
    [global::ProtoBuf.ProtoMember(2, IsRequired = true, Name=@"echo", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public int echo
    {
      get { return _echo; }
      set { _echo = value; }
    }
    private string _id;
    [global::ProtoBuf.ProtoMember(3, IsRequired = true, Name=@"id", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public string id
    {
      get { return _id; }
      set { _id = value; }
    }
    private string _type;
    [global::ProtoBuf.ProtoMember(4, IsRequired = true, Name=@"type", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public string type
    {
      get { return _type; }
      set { _type = value; }
    }
    private string _deviceid;
    [global::ProtoBuf.ProtoMember(5, IsRequired = true, Name=@"deviceid", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public string deviceid
    {
      get { return _deviceid; }
      set { _deviceid = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"register_s2c")]
  public partial class register_s2c : global::ProtoBuf.IExtensible
  {
    public register_s2c() {}
    
    private string _name;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"name", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public string name
    {
      get { return _name; }
      set { _name = value; }
    }
    private int _echo;
    [global::ProtoBuf.ProtoMember(2, IsRequired = true, Name=@"echo", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public int echo
    {
      get { return _echo; }
      set { _echo = value; }
    }
    private int _code;
    [global::ProtoBuf.ProtoMember(3, IsRequired = true, Name=@"code", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public int code
    {
      get { return _code; }
      set { _code = value; }
    }
    private string _id;
    [global::ProtoBuf.ProtoMember(4, IsRequired = true, Name=@"id", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public string id
    {
      get { return _id; }
      set { _id = value; }
    }
    private string _security;
    [global::ProtoBuf.ProtoMember(5, IsRequired = true, Name=@"security", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public string security
    {
      get { return _security; }
      set { _security = value; }
    }
    private string _session;
    [global::ProtoBuf.ProtoMember(6, IsRequired = true, Name=@"session", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public string session
    {
      get { return _session; }
      set { _session = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"login_c2s")]
  public partial class login_c2s : global::ProtoBuf.IExtensible
  {
    public login_c2s() {}
    
    private string _name;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"name", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public string name
    {
      get { return _name; }
      set { _name = value; }
    }
    private int _echo;
    [global::ProtoBuf.ProtoMember(2, IsRequired = true, Name=@"echo", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public int echo
    {
      get { return _echo; }
      set { _echo = value; }
    }
    private string _id;
    [global::ProtoBuf.ProtoMember(3, IsRequired = true, Name=@"id", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public string id
    {
      get { return _id; }
      set { _id = value; }
    }
    private string _deviceid;
    [global::ProtoBuf.ProtoMember(4, IsRequired = true, Name=@"deviceid", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public string deviceid
    {
      get { return _deviceid; }
      set { _deviceid = value; }
    }
    private string _security;
    [global::ProtoBuf.ProtoMember(5, IsRequired = true, Name=@"security", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public string security
    {
      get { return _security; }
      set { _security = value; }
    }
    private string _appid;
    [global::ProtoBuf.ProtoMember(6, IsRequired = true, Name=@"appid", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public string appid
    {
      get { return _appid; }
      set { _appid = value; }
    }
    private string _time;
    [global::ProtoBuf.ProtoMember(7, IsRequired = true, Name=@"time", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public string time
    {
      get { return _time; }
      set { _time = value; }
    }
    private string _pver;
    [global::ProtoBuf.ProtoMember(8, IsRequired = true, Name=@"pver", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public string pver
    {
      get { return _pver; }
      set { _pver = value; }
    }
    private string _sign;
    [global::ProtoBuf.ProtoMember(9, IsRequired = true, Name=@"sign", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public string sign
    {
      get { return _sign; }
      set { _sign = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"login_s2c")]
  public partial class login_s2c : global::ProtoBuf.IExtensible
  {
    public login_s2c() {}
    
    private string _name;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"name", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public string name
    {
      get { return _name; }
      set { _name = value; }
    }
    private int _echo;
    [global::ProtoBuf.ProtoMember(2, IsRequired = true, Name=@"echo", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public int echo
    {
      get { return _echo; }
      set { _echo = value; }
    }
    private int _code;
    [global::ProtoBuf.ProtoMember(3, IsRequired = true, Name=@"code", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public int code
    {
      get { return _code; }
      set { _code = value; }
    }
    private string _session;
    [global::ProtoBuf.ProtoMember(4, IsRequired = true, Name=@"session", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public string session
    {
      get { return _session; }
      set { _session = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"base_message")]
  public partial class base_message : global::ProtoBuf.IExtensible
  {
    public base_message() {}
    
    private string _name;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"name", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public string name
    {
      get { return _name; }
      set { _name = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}