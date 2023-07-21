using System.Collections;
using System.Net.Sockets;
using System.Numerics;

public class ClientState
{
    public Socket socket;
    public ByteArray readBuff = new ByteArray();
    //Ping
    public long lastPingTime = 0;
    //玩家
    public Player player;
}