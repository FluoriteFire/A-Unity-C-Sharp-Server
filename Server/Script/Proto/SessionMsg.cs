using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class SessionMsg: MsgBase
{
    public SessionMsg() { protoName = "SessionMsg"; }

    public string  session_key { get; set; } = "";
}
