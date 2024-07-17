using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Client
{
    private int clientId;
    public Client(int clientId)
    {
        this.clientId = clientId;
    }
    public void HandleData(ArraySegment<byte> data)
    {
        ushort _packetID = BitConverter.ToUInt16(data.Array, data.Offset);

        MyServer.packetHandlers[_packetID](clientId, data);

        return;
    }
}
