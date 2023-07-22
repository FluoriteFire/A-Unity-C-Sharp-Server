using System;

public partial class MsgHandler
{
    public static void MsgRegister(ClientState c, MsgBase msgBase)
    {
        MsgRegister msg = (MsgRegister)msgBase;
        if (DbManager.Register(msg.id, msg.pw))
            msg.result = 1;
        else
            msg.result = 0;
        NetManager.Send(c, msg);
    }
}


