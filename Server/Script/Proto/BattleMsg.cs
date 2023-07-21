
public class MsgMove:MsgBase {
    public MsgMove() {protoName = "MsgMove";}

    public int x { get; set; } = 0;
    public int y { get; set; } = 0;
    public int z { get; set; } = 0;
}


public class MsgAttack:MsgBase {
    public MsgAttack() {protoName = "MsgAttack";}

    public string desc = "127.0.0.1:6543";
} 
