// Generated by the protocol buffer compiler.  DO NOT EDIT!
// source: message_define.proto
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace MsgDefine {

  /// <summary>Holder for reflection information generated from message_define.proto</summary>
  public static partial class MessageDefineReflection {

    #region Descriptor
    /// <summary>File descriptor for message_define.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static MessageDefineReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "ChRtZXNzYWdlX2RlZmluZS5wcm90bxIKbXNnX2RlZmluZSIuCghBc2tMb2dp",
            "bhIQCgh1c2VybmFtZRgBIAEoCRIQCghwYXNzd29yZBgCIAEoCSI/CghScHlM",
            "b2dpbhITCgtsb2dpblJlc3VsdBgBIAEoBRIQCghncmVldGluZxgCIAEoDBIM",
            "CgR0ZXN0GAMgASgFYgZwcm90bzM="));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { },
          new pbr::GeneratedClrTypeInfo(null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::MsgDefine.AskLogin), global::MsgDefine.AskLogin.Parser, new[]{ "Username", "Password" }, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::MsgDefine.RpyLogin), global::MsgDefine.RpyLogin.Parser, new[]{ "LoginResult", "Greeting", "Test" }, null, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  public sealed partial class AskLogin : pb::IMessage<AskLogin> {
    private static readonly pb::MessageParser<AskLogin> _parser = new pb::MessageParser<AskLogin>(() => new AskLogin());
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<AskLogin> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::MsgDefine.MessageDefineReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public AskLogin() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public AskLogin(AskLogin other) : this() {
      username_ = other.username_;
      password_ = other.password_;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public AskLogin Clone() {
      return new AskLogin(this);
    }

    /// <summary>Field number for the "username" field.</summary>
    public const int UsernameFieldNumber = 1;
    private string username_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Username {
      get { return username_; }
      set {
        username_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "password" field.</summary>
    public const int PasswordFieldNumber = 2;
    private string password_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Password {
      get { return password_; }
      set {
        password_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as AskLogin);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(AskLogin other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (Username != other.Username) return false;
      if (Password != other.Password) return false;
      return true;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (Username.Length != 0) hash ^= Username.GetHashCode();
      if (Password.Length != 0) hash ^= Password.GetHashCode();
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (Username.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(Username);
      }
      if (Password.Length != 0) {
        output.WriteRawTag(18);
        output.WriteString(Password);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (Username.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Username);
      }
      if (Password.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Password);
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(AskLogin other) {
      if (other == null) {
        return;
      }
      if (other.Username.Length != 0) {
        Username = other.Username;
      }
      if (other.Password.Length != 0) {
        Password = other.Password;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            input.SkipLastField();
            break;
          case 10: {
            Username = input.ReadString();
            break;
          }
          case 18: {
            Password = input.ReadString();
            break;
          }
        }
      }
    }

  }

  public sealed partial class RpyLogin : pb::IMessage<RpyLogin> {
    private static readonly pb::MessageParser<RpyLogin> _parser = new pb::MessageParser<RpyLogin>(() => new RpyLogin());
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<RpyLogin> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::MsgDefine.MessageDefineReflection.Descriptor.MessageTypes[1]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public RpyLogin() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public RpyLogin(RpyLogin other) : this() {
      loginResult_ = other.loginResult_;
      greeting_ = other.greeting_;
      test_ = other.test_;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public RpyLogin Clone() {
      return new RpyLogin(this);
    }

    /// <summary>Field number for the "loginResult" field.</summary>
    public const int LoginResultFieldNumber = 1;
    private int loginResult_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int LoginResult {
      get { return loginResult_; }
      set {
        loginResult_ = value;
      }
    }

    /// <summary>Field number for the "greeting" field.</summary>
    public const int GreetingFieldNumber = 2;
    private pb::ByteString greeting_ = pb::ByteString.Empty;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public pb::ByteString Greeting {
      get { return greeting_; }
      set {
        greeting_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "test" field.</summary>
    public const int TestFieldNumber = 3;
    private int test_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int Test {
      get { return test_; }
      set {
        test_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as RpyLogin);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(RpyLogin other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (LoginResult != other.LoginResult) return false;
      if (Greeting != other.Greeting) return false;
      if (Test != other.Test) return false;
      return true;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (LoginResult != 0) hash ^= LoginResult.GetHashCode();
      if (Greeting.Length != 0) hash ^= Greeting.GetHashCode();
      if (Test != 0) hash ^= Test.GetHashCode();
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (LoginResult != 0) {
        output.WriteRawTag(8);
        output.WriteInt32(LoginResult);
      }
      if (Greeting.Length != 0) {
        output.WriteRawTag(18);
        output.WriteBytes(Greeting);
      }
      if (Test != 0) {
        output.WriteRawTag(24);
        output.WriteInt32(Test);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (LoginResult != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(LoginResult);
      }
      if (Greeting.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeBytesSize(Greeting);
      }
      if (Test != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(Test);
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(RpyLogin other) {
      if (other == null) {
        return;
      }
      if (other.LoginResult != 0) {
        LoginResult = other.LoginResult;
      }
      if (other.Greeting.Length != 0) {
        Greeting = other.Greeting;
      }
      if (other.Test != 0) {
        Test = other.Test;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            input.SkipLastField();
            break;
          case 8: {
            LoginResult = input.ReadInt32();
            break;
          }
          case 18: {
            Greeting = input.ReadBytes();
            break;
          }
          case 24: {
            Test = input.ReadInt32();
            break;
          }
        }
      }
    }

  }

  #endregion

}

#endregion Designer generated code
