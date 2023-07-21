using Microsoft.EntityFrameworkCore;
using Server.Script.DB;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Numerics;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
#nullable disable
namespace UnityServer
{
    internal class Server
    {
        public static void Main()
        {
            //数据库配置
            if (!DbManager.Connect("test", "localhost", 5432, "root", "123456"))
            {
                return;
            }

            var s1 = new Student()
            {
                Id = 1,
                Name = "Stu1",
            };
            DbManager.baseDb.Student.Add(s1);

            var s2 = new Student()
            {
                Id = 2,
                Name = "Stu2",

            };
            DbManager.baseDb.Student.Add(s2);

            Console.WriteLine(DbManager.baseDb.SaveChanges());

            //服务器启动端口
            //NetManager.StartLoop(9000);
        }
    }
}