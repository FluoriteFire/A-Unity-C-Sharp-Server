using System;
using MySql.Data.MySqlClient;
using System.Text.RegularExpressions;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using MySql.EntityFrameworkCore;
using Server.Script.DB;
using Org.BouncyCastle.Crypto.Engines;

public class DbManager
{
    public static BaseDbContext baseDb;


    //连接mysql数据库
    public static bool Connect(string db, string ip, int port, string user, string pw)
    {
        //连接参数
        string s = string.Format("server={0};port={1};database={2};uid={3};pwd={4};CharSet=utf8", ip, port, db, user, pw);
        //创建baseDb对象
        baseDb = new BaseDbContext(s);
        //连接
        if (baseDb.Database.CanConnect())
        {
            Console.WriteLine("[数据库]connect succ ");
            return true;
        }
        else
        {
            Console.WriteLine("[数据库]connect fail ");
            return false;
        }
    }

    //是否存在该用户
    public static bool IsAccountExist(int id)
    {
        //TODO
        return true;
    }

    //注册
    public static bool Register(int id, string pw)
    {
        //能否注册
        if (!IsAccountExist(id))
        {
            Console.WriteLine("[数据库] Register fail, id exist");
            return false;
        }
        //写入数据库User表
        return true;
    }

}