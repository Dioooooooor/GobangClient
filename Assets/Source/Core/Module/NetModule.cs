using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum NetEventType
{
	Connected,
	Disconnected,
	ConnectionRefused,
}

public class NetModule : Module {
	private NetClient netClient;
	private Queue<KeyValuePair<int, byte[]>> netEvents = new Queue<KeyValuePair<int, byte[]>>();

	public delegate void NetEventDelegate(NetEventType netEventType);
	public delegate void NetEventHandleDelegate(byte[] buffer);
	private Dictionary<int, NetEventHandleDelegate> netEventHandles = new Dictionary<int, NetEventHandleDelegate>();
	public NetEventDelegate ConnectEvent;
	public NetEventDelegate DisconnectEvent;

	public void Start()
	{
		netClient = new NetClient(this);
	}

	public void Update()
	{
		if(netEvents.Count > 0)
		{
			lock (netEvents)
			{
				while (netEvents.Count > 0)
				{
					var netEvent = netEvents.Dequeue();
					int eventID = netEvent.Key;
					if (netEventHandles.ContainsKey(eventID))
					{
						netEventHandles[eventID](netEvent.Value);
					}
                }
			}
		}
	}

	public void ConncetServer(string host, int port)
	{
		netClient.Connect(host, port);
	}

	public void SendMessage(ushort msgID, byte[] message)
	{
		MessageHead messageHead = new MessageHead();
		messageHead.MsgID = msgID;
		messageHead.DataLen = Convert.ToUInt32(MessageHead.MESSAGE_HEAD_SIZE + message.Length);
		byte[] headBytes = messageHead.Encode();

		byte[] sendBytes = new byte[messageHead.DataLen];
		headBytes.CopyTo(sendBytes, 0);
		message.CopyTo(sendBytes, headBytes.Length);
		netClient.SendMessage(sendBytes);
	}

	public void AddNetEvent(int eventID, byte[] buffer)
	{
		lock (netEvents)
		{
			netEvents.Enqueue(new KeyValuePair<int, byte[]>(eventID, buffer));
		}
	}

	public void AddListener(Message messageID, NetEventHandleDelegate netEventHandle)
	{
		int eventID = (int)messageID;
		if (netEventHandles.ContainsKey(eventID))
		{
			netEventHandles[eventID] += netEventHandle;
		}
		else
		{
			netEventHandles.Add(eventID, netEventHandle);
		}
	}
}
