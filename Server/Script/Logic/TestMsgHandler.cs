using System;


public partial class MsgHandler
{
	public static void TestMsg(ClientState c, MsgBase msgBase)
	{
        TestMsg msg = (TestMsg)msgBase;
		Console.WriteLine(msg.result);
		msg.result = 1;
		NetManager.Send(c, msg);
	}
}


