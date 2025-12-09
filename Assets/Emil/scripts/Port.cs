using UnityEngine;

public class Port : MonoBehaviour
{
    public string PortName;
    public Port ConnectedPort;
    public NetworkDevice ParentDevice;

    void Start()
    {
        PortName = gameObject.name;
        ParentDevice = GetComponentInParent<NetworkDevice>();
    }

    // WICHTIG: Diese Funktion hat dir gefehlt!
    public void ConnectTo(Port other)
    {
        ConnectedPort = other;
        other.ConnectedPort = this;
    }

    public void Disconnect()
    {
        if (ConnectedPort != null)
        {
            Port temp = ConnectedPort;
            ConnectedPort = null;
            temp.ConnectedPort = null;
        }
    }

    public void SendPacket(NetworkPacket packet)
    {
        if (ConnectedPort != null)
        {
            ConnectedPort.ParentDevice.ReceivePacket(packet, ConnectedPort);
        }
        else
        {
            Debug.LogWarning($"{PortName}: No connected port!");
        }
    }
}
