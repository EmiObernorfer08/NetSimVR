using System.Collections.Generic;
using UnityEngine;

public class NetworkDevice : MonoBehaviour
{
    public string DeviceName;
    public string IPAddress;

    public Port Port; // Only one port for the test
    public List<RouteEntry> RoutingTable = new List<RouteEntry>();

    void Start()
    {
        DeviceName = gameObject.name;
    }

    public void ReceivePacket(NetworkPacket packet, Port incomingPort)
    {
        Debug.Log($"{DeviceName} RECEIVED packet ({packet.Type}) from {packet.SourceIP}");

        // If packet is for me: reply
        if (packet.Type == PacketType.PING && packet.TargetIP == IPAddress)
        {
            Debug.Log($"{DeviceName}: Ping received! Sending reply...");
            SendPingReply(packet);
            return;
        }

        // Otherwise: forward
        ForwardPacket(packet, incomingPort);
    }

    void ForwardPacket(NetworkPacket packet, Port incomingPort)
    {
        foreach (var entry in RoutingTable)
        {
            if (entry.TargetNetwork == packet.TargetIP)
            {
                entry.OutPort.SendPacket(packet);
                Debug.Log($"{DeviceName}: Forwarding packet via {entry.OutPort.PortName}");
                return;
            }
        }

        Debug.LogWarning($"{DeviceName}: NO ROUTE for {packet.TargetIP}");
    }

    public void SendPing(string targetIP)
    {
        Debug.Log($"{DeviceName}: Sending ping to {targetIP}");
        NetworkPacket p = new NetworkPacket(IPAddress, targetIP, PacketType.PING);
        Port.SendPacket(p);
    }

    void SendPingReply(NetworkPacket incoming)
    {
        NetworkPacket reply = new NetworkPacket(
            IPAddress,
            incoming.SourceIP,
            PacketType.PING_REPLY
        );

        Port.SendPacket(reply);
        Debug.Log($"{DeviceName}: Ping reply sent.");
    }
}
