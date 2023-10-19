using System.Collections;
using System.Collections.Generic;

// 房间信息，[System.Serializable]表示为序列化类，其数组才能被正确序列化
[System.Serializable]
public class RoomInfo
{
    public int id = -1; // 房间ID
    public int count = 0; // 人数
    public int status = 0; // 状态 0 - 未上锁， 1 - 上锁

}

//  请求房间列表
public class MsgGetRoomList : MsgBase
{
    public MsgGetRoomList() { protoName = "MsgGetRoomList"; }
    // 服务端回
    public RoomInfo[] rooms;
}

// 创建房间
public class MsgCreateRoom : MsgBase
{
    public MsgCreateRoom() { protoName = "MsgCreateRoom"; }
    // 服务端回
    public int result = 0;
}

// 进入房间
public class MsgEnterRoom : MsgBase
{
    public MsgEnterRoom() { protoName = "MsgEnterRoom"; }
    // 客户端发
    public int id = -1;
    // 服务端回
    public int result = 0;
}

// 玩家信息
[System.Serializable]
public class PlayerInfo
{
    public string id = ""; // id
    public int camp = 0; // 阵营（x）
    public int isOwner = 0; // 是否是房主
}

// 获取房间信息
public class MsgGetRoomInfo : MsgBase
{
    public MsgGetRoomInfo() { protoName = "MsgGetRoomInfo"; }
    // 服务端回
    public PlayerInfo[] players;
}

// 离开房间
public class MsgLeaveRoom : MsgBase
{
    public MsgLeaveRoom() { protoName = "MsgLeaveRoom"; }
    // 服务端回
    public int result = 0;
}

// 开战（x）
public class MsgStartBattle : MsgBase
{
    public MsgStartBattle() { protoName = "MsgStartBattle"; }
    // 服务端回
    public int result = 0;
}