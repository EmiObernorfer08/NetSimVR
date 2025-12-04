public enum PacketType { PING, PING_REPLY }

public class NetworkPacket
{
    public string SourceIP;
    public string TargetIP;
    public PacketType Type;

    public NetworkPacket(string s, string t, PacketType ty)
    {
        SourceIP = s;
        TargetIP = t;
        Type = ty;
    }
}
