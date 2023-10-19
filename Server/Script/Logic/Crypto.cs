using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Metadata;

public static class myRSA
{
    public static void GetKeyPair(out string public_Key, out string private_Key)
    {
        System.Security.Cryptography.RSACryptoServiceProvider RSA = new RSACryptoServiceProvider();
        public_Key = Convert.ToBase64String(RSA.ExportCspBlob(false));
        private_Key = Convert.ToBase64String(RSA.ExportCspBlob(true));

    }
    public static string Encrypt(string plainText, string PublicKey)
    {
        using (var rsa = new RSACryptoServiceProvider(2048))
        {
            try
            {
                //加载公钥
                var pubKey = Convert.FromBase64String(PublicKey);
                rsa.ImportCspBlob(pubKey);

                var bytesToEncrypt = System.Text.Encoding.Unicode.GetBytes(plainText);

                var bytesEncrypted = rsa.Encrypt(bytesToEncrypt, false);

                return Convert.ToBase64String(bytesEncrypted);
            }
            finally
            {
                rsa.PersistKeyInCsp = false;
            }

        }
    }
    public static string Decrypt(string encryptedText, string PrivateKey)
    {
        using (var rsa = new RSACryptoServiceProvider(2048))
        {
            try
            {
                var privateKey = Convert.FromBase64String(PrivateKey);
                rsa.ImportCspBlob(privateKey);

                var bytesEncrypted = Convert.FromBase64String(encryptedText);

                var bytesPlainText = rsa.Decrypt(bytesEncrypted, false);

                return System.Text.Encoding.Unicode.GetString(bytesPlainText);
            }
            finally
            {
                rsa.PersistKeyInCsp = false;
            }
        }
    }

}
public static class myAES
{
   
    public static string Encrypt(string plainText, string Key)
    {
        if (string.IsNullOrEmpty(plainText)) return null;
        Byte[] toEncryptArray = Encoding.UTF8.GetBytes(plainText);
        RijndaelManaged rm = new RijndaelManaged
        {
            Key = Encoding.UTF8.GetBytes(Key),
            Mode = CipherMode.ECB,
            Padding = PaddingMode.PKCS7
        };
        ICryptoTransform cTransform = rm.CreateEncryptor();
        Byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

        return Convert.ToBase64String(Encoding.UTF8.GetBytes(Convert.ToBase64String(resultArray, 0, resultArray.Length)));

    }
    public static string Decrypt(string Cipher, string Key)
    {
        if (string.IsNullOrEmpty(Cipher)) return null;
        Byte[] toEncryptArray = Convert.FromBase64String(Encoding.UTF8.GetString(Convert.FromBase64String(Cipher)));
        RijndaelManaged rm = new RijndaelManaged
        {
            Key = Encoding.UTF8.GetBytes(Key),
            Mode = CipherMode.ECB,
            Padding = PaddingMode.PKCS7
        };
        ICryptoTransform cTransform = rm.CreateDecryptor();
        Byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
        return Encoding.UTF8.GetString(resultArray);

    }
}
