using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class ExchangeMsg: MsgBase
{
    public ExchangeMsg()
    {
        protoName = "ExchangeMsg";
    }
    // 客户端发送一个ExchangeMsg包，服务器生成RSA密钥后将公钥发给客户端（通过ExchangeMsg）
    public string pkey = "";
}
