using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Player
{
    public string id = "";
    public ClientState state;
    // 在哪个房间
    public int roomId = -1;
    // 数据库数据
    public PlayerData data;

    public Player(ClientState state)
    {
        this.state = state;
    }

    // 发送信息
    public void Send(MsgBase msgBase)
    {
        NetManager.Send(state, msgBase);
    }
}
