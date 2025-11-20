using UnityEngine;

public class Port : MonoBehaviour
{
    [Header("Port Info")]
    public string PortName;

    [Header("Connected Port")]
    public Port ConnectedPort;    // Verweis auf anderen Port

    public bool IsConnected => ConnectedPort != null;



    void Start()
    {
        PortName = gameObject.name;
    }



    // Verbindet diesen Port mit einem anderen
    public void ConnectTo(Port other)
    {
        ConnectedPort = other;
        Debug.Log($"[Port] {PortName} verbunden mit {other.PortName}");
    }



    // Trennt beide Ports sauber
    public void Disconnect()
    {
        if (ConnectedPort != null)
        {
            Debug.Log($"[Port] {PortName} getrennt von {ConnectedPort.PortName}");

            // Gegen-Link löschen
            Port other = ConnectedPort;
            ConnectedPort = null;

            if (other.ConnectedPort == this)
            {
                other.ConnectedPort = null;
            }
        }
    }
}
