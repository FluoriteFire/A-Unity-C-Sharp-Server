﻿using System;


public partial class MsgHandler
{
	public static void MsgMove(ClientState c, MsgBase msgBase)
	{
		MsgMove msgMove = (MsgMove)msgBase;
		Console.WriteLine(msgMove.x);
		msgMove.x++;
		NetManager.Send(c, msgMove);
	}
}


