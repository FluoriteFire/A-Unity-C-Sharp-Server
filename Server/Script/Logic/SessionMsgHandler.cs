using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



public partial class MsgHandler
{
    // 发送服务器公钥
    public static void ExchangeMsg(ClientState c, MsgBase msgBase)
    {
        ExchangeMsg msg = (ExchangeMsg)msgBase;
        // 生成公钥
        myRSA.GetKeyPair(out c.rsa_publickey,out c.rsa_privatekey);

        ExchangeMsg sendmsg = new ExchangeMsg();
        sendmsg.pkey = c.rsa_publickey;
        NetManager.Send(c, sendmsg);
    }

    // 获得会话密钥
    public static void SessionMsg(ClientState c, MsgBase msgBase)
    {
        SessionMsg msg = (SessionMsg)msgBase;

        c.session_key = myRSA.Decrypt(msg.session_key, c.rsa_privatekey);

    }

}



