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
