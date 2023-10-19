using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

public class Room
{
    // 房间id（初始化为-1）
    public int id = -1;
    // 房间最大人数
    public int maxPlayer = 4;
    // 玩家列表
    public Dictionary<string, bool> playerIds = new Dictionary<string, bool>();
    // 房主id
    public string ownerId = "";
    // 房间状态（暂未完善）
    public enum Status
    {
        UNLOCK = 0,
        LOCK = 1,
    }
    public Status status = Status.UNLOCK;

    // 添加玩家
    public bool AddPlayer(string id)
    {
        // 获取玩家
        Player player = PlayerManager.GetPlayer(id);
        if (player == null)
        {
            Console.WriteLine("room.AddPlayer fail, player is null");
            return false;
        }
        // 房间人数
        if (playerIds.Count >= maxPlayer)
        {
            Console.WriteLine("room.AddPlayer fail, reach maxPlayer");
            return false;
        }
        // 未上锁状态才能加入
        if (status != Status.UNLOCK)
        {
            Console.WriteLine("room.AddPlayer fail, player not UNLOCK");
            return false;
        }
        // 已经在房间里
        if (playerIds.ContainsKey(id))
        {
            Console.WriteLine("room.AddPlayer fail, not UNLOCK");
            return false;
        }
        // 加入列表
        playerIds[id] = true;
        // 设置玩家数据
        player.roomId = this.id;
        // 设置房主
        if (ownerId == "")
        {
            ownerId = player.id;
        }
        // 广播
        Broadcast(ToMsg());
        return true;
    }

    // 删除玩家
    public bool RemovePlayer(string id)
    {
        // 获取玩家
        Player player = PlayerManager.GetPlayer(id);
        if (player == null)
        {
            Console.WriteLine("romm.RemovePlayer fail, player is null");
            return false;
        }
        // 没有在房间里
        if (!playerIds.ContainsKey(id))
        {
            Console.WriteLine("romm.RemovePlayer fail, player not in the room");
        }
        // 删除列表
        playerIds.Remove(id);
        // 设置玩家数据
        player.roomId = -1;
        // 设置房主
        if (isOwner(player))
        {
            ownerId = SwitchOwner();
        }
        // 房间为空
        if (playerIds.Count == 0)
        {
            RoomManager.RemoveRoom(this.id);
        }
        // 广播
        Broadcast(ToMsg());
        return true;
    }

    // 是不是房主
    public bool isOwner(Player player)
    {
        return player.id == ownerId;
    }

    // 选择房主
    public string SwitchOwner()
    {
        foreach (string id in playerIds.Keys)
        {
            return id;
        }
        // 房间没人
        return "";
    }

    // 广播信息
    public void Broadcast(MsgBase msg)
    {
        foreach (string id in playerIds.Keys)
        {
            Player player = PlayerManager.GetPlayer(id);
            player.Send(msg);
        }
    }
    
    // 广播加密消息
    public void EnBroadcast(string content)
    {
        foreach (string id in playerIds.Keys)
        {
            Player player = PlayerManager.GetPlayer(id);
            ClientState state = player.state;
            // 用每个会话密钥加密
            string encontent = myAES.Encrypt(content, state.session_key);
            MsgChat msg = new MsgChat(encontent);

            player.Send(msg);
        }
    }

    // 生成MsgGetRoomInfo协议
    public MsgBase ToMsg()
    {
        MsgGetRoomInfo msg = new MsgGetRoomInfo();
        int count = playerIds.Count;
        msg.players = new PlayerInfo[count];
        // players
        int i = 0;
        foreach (string id in playerIds.Keys)
        {
            Player player = PlayerManager.GetPlayer(id);
            PlayerInfo playerInfo = new PlayerInfo();
            // 赋值
            playerInfo.id = player.id;
            playerInfo.isOwner = 0;
            if (isOwner(player))
            {
                playerInfo.isOwner = 1;
            }

            msg.players[i] = playerInfo;
            i++;
        }
        return msg;
    }
}
