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
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
//#nullable disable


namespace UnityServer
{
    internal class Server
    {
        public static void Main()
        {
            //string public_Key = "";
            //string private_Key = "";
            //string plaintext = "I Love You";
            //string Cipher = "";
            //string plaintext1 = "";
            //myRSA.GetKeyPair(out public_Key, out private_Key);

            //Cipher = myRSA.Encrypt(plaintext, public_Key);
            //Console.WriteLine(Cipher);
            //plaintext1 = myRSA.Decrypt(Cipher, private_Key);
            //Console.WriteLine(plaintext1);

            // 数据库配置
            if (!DbManager.Connect("test", "172.25.194.41", 5432, "root", "123456"))
            {
                return;
            }

            //服务器启动端口
            //NetManager.StartLoop(9000);

        }
    }
}