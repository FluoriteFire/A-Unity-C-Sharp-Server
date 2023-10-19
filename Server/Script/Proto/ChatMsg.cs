using System.Collections;
using System.Collections.Generic;

public class MsgChat : MsgBase
{
    public string Content = "";

    public MsgChat()
    {
        protoName = "MsgChat";
    }
    public MsgChat(string content)
    {
        protoName = "MsgChat";
        Content = content;
    }

    public override string ToString()
    {
        return Content;
    }
}
