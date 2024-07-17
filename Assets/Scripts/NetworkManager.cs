using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkManager : MonoBehaviour
{
    public static NetworkManager instance;
    private Telepathy.Server server;
    public int port = 2005;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else if(instance != this)
        {
            Destroy(this);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        MyServer.packetHandlers.Add(0x1000, (int _fromClient, ArraySegment<byte> _packet) =>
        {
            int generation = BitConverter.ToInt32(_packet.Array, 2+_packet.Offset);
            Debug.Log($"received 0x1000. Generation: {generation}");
        });
        MyServer.packetHandlers.Add(0x2000, (int _fromClient, ArraySegment<byte> _packet) =>
        {
            Debug.Log($"received 0x3000");
            for (int i = 0; i < 5; i++)
            {
                double output = BitConverter.ToDouble(_packet.Array, 2+_packet.Offset + i * 8);
                Debug.Log($"{output}");
            }
        });
        MyServer.packetHandlers.Add(0x3000, (int _fromClient, ArraySegment<byte> _packet) =>
        {
            
            int generation = BitConverter.ToInt32(_packet.Array, 2+_packet.Offset);
            Debug.Log($"received 0x2000. Generation: {generation}");
        });

        server = new Telepathy.Server(65536);
        server.OnConnected = OnClientConnected;
        server.OnData = OnClientdata;
        server.OnDisconnected = OnClientDisconnected;

        server.Start(port);
        Debug.Log($"Server started on port {port}");
    }

    // Update is called once per frame
    void Update()
    {
        server.Tick(100);
    }

    void OnClientConnected(int connectionId)
    {
        Debug.Log($"Client connected: {connectionId}");
        MyServer.clients.Add(connectionId, new Client(connectionId));

        List<byte> _packet = new List<byte>();
        _packet.AddRange(BitConverter.GetBytes((ushort)0x1000));
        server.Send(connectionId, new ArraySegment<byte>(_packet.ToArray()));
        Debug.Log($"send message {_packet.Count}");
    }

    void OnClientdata(int connectionId, ArraySegment<byte> data) {
        string message = System.Text.Encoding.UTF8.GetString(data);
        Debug.Log($"Received from {connectionId}: {data.Count}");
        MyServer.clients[connectionId].HandleData(data);
    }

    void OnClientDisconnected(int connectionId)
    {
        Debug.Log($"Client Disconnected: {connectionId}");
        MyServer.clients.Remove(connectionId);
    }

    void OnApplicationQuit()
    {
        server.Stop();
    }
}
