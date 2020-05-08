using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using UnityEngine;

public class MessageHead
{
    public UInt16 MsgID;
    public UInt32 DataLen;
    public static UInt32 MESSAGE_HEAD_SIZE = sizeof(UInt16) + sizeof(UInt32);

    public byte[] Encode()
    {
        byte[] dataLenBytes = BitConverter.GetBytes(DataLen);
        byte[] msgIDBytes = BitConverter.GetBytes(MsgID);

        bool isLittle = BitConverter.IsLittleEndian;
        if (isLittle)
        {
            Array.Reverse(msgIDBytes);
            Array.Reverse(dataLenBytes);
        }
        byte[] headBytes = new byte[MESSAGE_HEAD_SIZE];

        Array.Copy(msgIDBytes, 0, headBytes, sizeof(UInt32), sizeof(UInt16));
        Array.Copy(dataLenBytes, headBytes, sizeof(UInt32));

        return headBytes;
    }

    public bool Decode(byte[] buffer)
    {
        if (buffer.Length >= MESSAGE_HEAD_SIZE)
        {
            byte[] dataLenBytes = new byte[sizeof(UInt32)];
            byte[] msgIDBytes = new byte[sizeof(UInt16)];

            Array.Copy(buffer, 0, dataLenBytes, 0, sizeof(UInt32));
            Array.Copy(buffer, sizeof(UInt32), msgIDBytes, 0, sizeof(UInt16));

            bool isLittle = BitConverter.IsLittleEndian;
            if (isLittle)
            {
                Array.Reverse(msgIDBytes);
                Array.Reverse(dataLenBytes);
            }

            DataLen = BitConverter.ToUInt32(dataLenBytes, 0);
            MsgID = BitConverter.ToUInt16(msgIDBytes, 0);
            return true;
        }

        return false;
    }


}

public class NetClient
{
    private TcpClient client;
    private NetworkStream netStream;
    private BinaryWriter writer = null;
    private BinaryReader reader = null;

    private const int MAX_BUFFER_CACHE = 0X1000;
    private byte[] recvBufferCache = new byte[MAX_BUFFER_CACHE];
    private byte[] curRecvBuffer = new byte[MAX_BUFFER_CACHE];
    int curRecvPoint = 0;
    int curRecvSize = 0;

    private NetModule netModule;

    public NetClient(NetModule netModule)
    {
        this.netModule = netModule;
    }

    public void Connect(string host, int port)
    {
        client = null;
        try {
            IPAddress[] address = Dns.GetHostAddresses(host);
            if (address.Length == 0)
            {
                //Debug.LogError("host invalid");
                return;
            }
            if (address[0].AddressFamily == AddressFamily.InterNetworkV6)
            {
                client = new TcpClient(AddressFamily.InterNetworkV6);
            }
            else
            {
                client = new TcpClient(AddressFamily.InterNetwork);
            }
            client.SendTimeout = 1000;
            client.ReceiveTimeout = 1000;
            client.NoDelay = true;
            client.BeginConnect(host, port, new AsyncCallback(onConnected), null);
        }
        catch
        {
            Close();
        }
    }

    private void onConnected(IAsyncResult asr)
    {
        try
        {
            client.EndConnect(asr);
            netStream = client.GetStream();
            netStream.BeginRead(recvBufferCache, 0, MAX_BUFFER_CACHE - curRecvSize, new AsyncCallback(onRead), null);
            netModule.ConnectEvent.Invoke(NetEventType.Connected);
        }
        catch (Exception e)
        {
            netModule.ConnectEvent.Invoke(NetEventType.ConnectionRefused);
            Close();
        }
    }

    private void onRead(IAsyncResult asr)
    {
        int readSize = 0;
        try
        {
            lock(netStream)
            {
                readSize = netStream.EndRead(asr);
            }
            if(readSize <= 0) Disconnect();
            if (curRecvSize + readSize > MAX_BUFFER_CACHE) Disconnect();    //exceeded package size,
            Array.Copy(recvBufferCache, 0, curRecvBuffer, curRecvSize, readSize);
            curRecvSize += readSize;
            MessageHead messageHead = new MessageHead();
            if (messageHead.Decode(curRecvBuffer))
            {
                if (curRecvSize >= messageHead.DataLen)
                {
                    RecvMessage(messageHead);
                }
            }
            lock (netStream)
            {
                netStream.BeginRead(recvBufferCache, 0, MAX_BUFFER_CACHE, new AsyncCallback(onRead), null);
            }
        }
        catch
        {
            Disconnect();
        }
    }

    private void onWrite(IAsyncResult asy)
    {
        try
        {
            netStream.EndWrite(asy);
        }
        catch (Exception ex)
        {
            Debug.LogError("OnWrite--->>>" + ex.Message);
        }
    }

    public void RecvMessage(MessageHead messageHead)
    {
        byte[] package;

        ushort messageID = messageHead.MsgID;
        uint messageBodySize = messageHead.DataLen - MessageHead.MESSAGE_HEAD_SIZE;
        package = new byte[messageBodySize];
        Array.Copy(curRecvBuffer, MessageHead.MESSAGE_HEAD_SIZE, package, 0, messageBodySize);
        netModule.AddNetEvent(messageID, package);
    }

    public void SendMessage(byte[] message)
    {
        if (client != null && client.Connected)
        {
            netStream.BeginWrite(message, 0, message.Length, new AsyncCallback(onWrite), null);
        }
        else
        {
            Debug.LogError("client.connected----->>false");
        }

    }

    public void Disconnect()
    {
        Debug.LogError("Disconncet!");
        Close();
        netModule.DisconnectEvent.Invoke(NetEventType.Disconnected);
    }

    public void Close()
    {
        if (client != null)
        {
            if (client.Connected) client.Close();
            client = null;
        }
    }
}
