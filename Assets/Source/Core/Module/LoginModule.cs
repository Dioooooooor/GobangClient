using MsgDefine;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UnityEngine;
using Google.Protobuf;

class LoginModule : Module
{
    private NetModule netModule;

    private MemoryStream mxBody = new MemoryStream();

    public override void RegisterOver()
    {
        netModule = ModuleManager.Instance().FindModule<NetModule>();
    }


    public void Start()
    {
        netModule.ConnectEvent += Connected;
        netModule.AddListener(Message.LOGIN, onLogin);
    }

    public void Connect(string host, int port)
    {
        netModule.ConncetServer(host, port);
    }

    public void Connected(NetEventType type)
    {
        if(NetEventType.Connected == type)
        {
            Debug.Log("Login Success!");
        }else if(NetEventType.ConnectionRefused == type)
        {
            Debug.LogError("Login Fail!");
        }
    }

    public void Login(string username, string password)
    {
        byte[] data;

        AskLogin askLogin = new AskLogin();
        askLogin.Username = username;
        askLogin.Password = password;

        using(MemoryStream ms = new MemoryStream())
        {
            askLogin.WriteTo(ms);
            data = ms.ToArray();
        }

        netModule.SendMessage((ushort)Message.LOGIN, data);
        //buffer.Close();
    }

    public void onLogin(byte[] buffer)
    {
        RpyLogin rpyLogin = RpyLogin.Parser.ParseFrom(buffer);
        if (rpyLogin.LoginResult == 1)
        {
            //Enter Main Scene
        }
        else
        {
            Debug.LogError("Login Fail!");
        }
    }
}
