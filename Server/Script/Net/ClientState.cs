using System.Collections;
using System.Net.Sockets;
using System.Numerics;

public class ClientState
{
    public Socket socket;
    public ByteArray readBuff = new ByteArray();
    //Ping
    public long lastPingTime = NetManager.GetTimeStamp();
    
    public string rsa_publickey = "";
    public string rsa_privatekey = "";
    public string session_key = "";

    public Player player;
}