﻿using System;

public class Player
{
	//id
	public int id;
	//指向ClientState
	public ClientState state;
	//构造函数
	public Player(ClientState state)
	{
		this.state = state;
	}
	//临时数据，如：坐标
	public int x;
	public int y;
	public int z;
	//数据库数据
	public PlayerData data;

	//发送信息
	public void Send(MsgBase msgBase)
	{
		NetManager.Send(state, msgBase);
	}

}


