using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace Broadleaf.Windows.Forms
{

    /// <summary>
    /// このソースに関してはセキュリティの為、あえて書かない
    /// </summary>
    public class FileEncryptgraphy
    {

        RijndaelManaged aes;

        public FileEncryptgraphy(string PassKey)
        {
            aes = new RijndaelManaged();

            byte[] bKey = System.Text.Encoding.UTF8.GetBytes(PassKey);

            aes.Key = ResizeBytesArray(bKey, aes.Key.Length);
            aes.IV = ResizeBytesArray(bKey, aes.IV.Length);
        }

        public int EncryptFile(string sFileName, MemoryStream ms)
        {
            try
            {
                ms.Position = 0;
                byte[] source = new byte[ms.Length];
                ms.Read(source, 0, (int)ms.Length);

                using (FileStream streamWrite = new FileStream(sFileName, FileMode.Create, FileAccess.ReadWrite))
                {
                    using (CryptoStream cs = new CryptoStream(streamWrite, aes.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(source, 0, source.Length);
                        cs.FlushFinalBlock();
                        streamWrite.Close();
                    }
                }

                return 0;;
            }
            catch (Exception)
            {

                return 5;

            }

        }

        public MemoryStream DecryptFile(string sFileName)
        {
            if (File.Exists(sFileName) == false)
            {
                return null;
            }


            try
            {
                MemoryStream ms = new MemoryStream();

                using (FileStream streamRead = new FileStream(sFileName, FileMode.Open, FileAccess.Read))
                {
                    using (CryptoStream cs = new CryptoStream(streamRead, aes.CreateDecryptor(), CryptoStreamMode.Read))
                    {
                        byte[] source = new byte[256];
                        int readLen;
                        while ((readLen = cs.Read(source, 0, source.Length)) > 0)
                        {
                            ms.Write(source, 0, readLen);
                        }
                    }
                }

                ms.Position = 0;

                return ms;
            }
            catch (Exception)
            {

                return null;

            }


        }

        /// <summary>
        /// 共有キー用に、バイト配列のサイズを変更する
        /// </summary>
        /// <param name="bytes">サイズを変更するバイト配列</param>
        /// <param name="newSize">バイト配列の新しい大きさ</param>
        /// <returns>サイズが変更されたバイト配列</returns>
        private static byte[] ResizeBytesArray(byte[] bytes, int newSize)
        {
            byte[] newBytes = new byte[newSize];
            if (bytes.Length <= newSize)
            {
                for (int i = 0; i < bytes.Length; i++)
                    newBytes[i] = bytes[i];
            }
            else
            {
                int pos = 0;
                for (int i = 0; i < bytes.Length; i++)
                {
                    newBytes[pos++] ^= bytes[i];
                    if (pos >= newBytes.Length)
                        pos = 0;
                }
            }
            return newBytes;
        }

    }


    public class StringHashEncryptgraphy
    {

        MACTripleDES mtdes;

        public StringHashEncryptgraphy(string PassKey)
        {
            mtdes = new MACTripleDES();

            byte[] bytesKey = System.Text.Encoding.ASCII.GetBytes(PassKey);
            mtdes.Key = ResizeBytesArray(bytesKey, mtdes.Key.Length);
        }

        public string CreateHash(string str)
        {
            try
            {
                byte[] bs = mtdes.ComputeHash(System.Text.Encoding.UTF8.GetBytes(str));

                //            return System.Convert.ToBase64String(bs);
                return BitConverter.ToString(bs).ToLower().Replace("-", "");
            }
            catch(Exception)
            {
                return "";

            }


        }

        /// <summary>
        /// 共有キー用に、バイト配列のサイズを変更する
        /// </summary>
        /// <param name="bytes">サイズを変更するバイト配列</param>
        /// <param name="newSize">バイト配列の新しい大きさ</param>
        /// <returns>サイズが変更されたバイト配列</returns>
        private byte[] ResizeBytesArray(byte[] bytes, int newSize)
        {
            byte[] newBytes = new byte[newSize];
            if (bytes.Length <= newSize)
            {
                for (int i = 0; i < bytes.Length; i++)
                    newBytes[i] = bytes[i];
            }
            else
            {
                int pos = 0;
                for (int i = 0; i < bytes.Length; i++)
                {
                    newBytes[pos++] ^= bytes[i];
                    if (pos >= newBytes.Length)
                        pos = 0;
                }
            }
            return newBytes;
        }

    }




    public class StringEncryptgraphyFast
    {

        RijndaelManaged aes = new RijndaelManaged();

        public StringEncryptgraphyFast(string PassKey)
        {
            //共有キーと初期化ベクタを決定
            //パスワードをバイト配列にする
            byte[] bytesKey = System.Text.Encoding.UTF8.GetBytes(PassKey);

            //共有キーと初期化ベクタを設定
            aes.Key = ResizeBytesArray(bytesKey, aes.Key.Length);
            aes.IV = ResizeBytesArray(bytesKey, aes.IV.Length);

        }
        
        /// <summary>
        /// 文字列を暗号化
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public string EncryptString(string str)
        {
            byte[] source = Encoding.Unicode.GetBytes(str);
            byte[] destination;
            using (MemoryStream ms = new MemoryStream())
            using (CryptoStream cs = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write))
            {
                cs.Write(source, 0, source.Length);
                cs.FlushFinalBlock();
                destination = ms.ToArray();
            }
//            return Encoding.Unicode.GetString(destination);
//            return System.Convert.ToBase64String(destination);
//            return Encoding.ASCII.GetString(destination);
            return BitConverter.ToString(destination).ToLower().Replace("-", "");

        }

        /// <summary>
        /// 文字列を復号化
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private string DecryptString(string str)
        {
//            byte[] source = Encoding.Unicode.GetBytes(str);
            byte[] source = System.Convert.FromBase64String(str);
            byte[] destination;
            using (MemoryStream ms = new MemoryStream())
            using (CryptoStream cs = new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Write))
            {
                cs.Write(source, 0, source.Length);
                cs.FlushFinalBlock();
                destination = ms.ToArray();
            }
            return Encoding.Unicode.GetString(destination);
        }

        /// <summary>
        /// 共有キー用に、バイト配列のサイズを変更する
        /// </summary>
        /// <param name="bytes">サイズを変更するバイト配列</param>
        /// <param name="newSize">バイト配列の新しい大きさ</param>
        /// <returns>サイズが変更されたバイト配列</returns>
        private byte[] ResizeBytesArray(byte[] bytes, int newSize)
        {
            byte[] newBytes = new byte[newSize];
            if (bytes.Length <= newSize)
            {
                for (int i = 0; i < bytes.Length; i++)
                    newBytes[i] = bytes[i];
            }
            else
            {
                int pos = 0;
                for (int i = 0; i < bytes.Length; i++)
                {
                    newBytes[pos++] ^= bytes[i];
                    if (pos >= newBytes.Length)
                        pos = 0;
                }
            }
            return newBytes;
        }

    }

    public class StringEncryptgraphy
    {

        public static string EncryptString(string str, string key, int ReturnType)
        {
            //文字列をバイト型配列にする
            byte[] bytesIn = System.Text.Encoding.UTF8.GetBytes(str);

            //DESCryptoServiceProviderオブジェクトの作成
            System.Security.Cryptography.DESCryptoServiceProvider des = new System.Security.Cryptography.DESCryptoServiceProvider();

            //共有キーと初期化ベクタを決定
            //パスワードをバイト配列にする
            byte[] bytesKey = System.Text.Encoding.UTF8.GetBytes(key);
            //共有キーと初期化ベクタを設定
            des.Key = ResizeBytesArray(bytesKey, des.Key.Length);
            des.IV = ResizeBytesArray(bytesKey, des.IV.Length);

            //暗号化されたデータを書き出すためのMemoryStream
            System.IO.MemoryStream msOut = new System.IO.MemoryStream();
            //DES暗号化オブジェクトの作成
            System.Security.Cryptography.ICryptoTransform desdecrypt =
                des.CreateEncryptor();
            //書き込むためのCryptoStreamの作成
            System.Security.Cryptography.CryptoStream cryptStreem =
                new System.Security.Cryptography.CryptoStream(msOut,
                desdecrypt,
                System.Security.Cryptography.CryptoStreamMode.Write);
            //書き込む
            cryptStreem.Write(bytesIn, 0, bytesIn.Length);
            cryptStreem.FlushFinalBlock();
            //暗号化されたデータを取得
            byte[] bytesOut = msOut.ToArray();

            //閉じる
            cryptStreem.Close();
            msOut.Close();

            if (ReturnType == 0)
            {
                //Base64で文字列に変更して結果を返す
                return System.Convert.ToBase64String(bytesOut);
            }
            else
            {
                //16進で文字列に変更して結果を返す
                return BitConverter.ToString(bytesOut).ToLower().Replace("-", "");
            }
        }

        /// <summary>
        /// 暗号化された文字列を復号化する
        /// </summary>
        /// <param name="str">暗号化された文字列</param>
        /// <param name="key">パスワード</param>
        /// <returns>復号化された文字列</returns>
        public static string DecryptString(string str, string key)
        {
            //DESCryptoServiceProviderオブジェクトの作成
            System.Security.Cryptography.DESCryptoServiceProvider des = new System.Security.Cryptography.DESCryptoServiceProvider();

            //共有キーと初期化ベクタを決定
            //パスワードをバイト配列にする
            byte[] bytesKey = System.Text.Encoding.UTF8.GetBytes(key);
            //共有キーと初期化ベクタを設定
            des.Key = ResizeBytesArray(bytesKey, des.Key.Length);
            des.IV = ResizeBytesArray(bytesKey, des.IV.Length);

            //Base64で文字列をバイト配列に戻す
            byte[] bytesIn = System.Convert.FromBase64String(str);
            //暗号化されたデータを読み込むためのMemoryStream
            System.IO.MemoryStream msIn =
                new System.IO.MemoryStream(bytesIn);
            //DES復号化オブジェクトの作成
            System.Security.Cryptography.ICryptoTransform desdecrypt =
                des.CreateDecryptor();
            //読み込むためのCryptoStreamの作成
            System.Security.Cryptography.CryptoStream cryptStreem =
                new System.Security.Cryptography.CryptoStream(msIn,
                desdecrypt,
                System.Security.Cryptography.CryptoStreamMode.Read);

            //復号化されたデータを取得するためのStreamReader
            System.IO.StreamReader srOut =
                new System.IO.StreamReader(cryptStreem,
                System.Text.Encoding.UTF8);
            //復号化されたデータを取得する
            string result = srOut.ReadToEnd();

            //閉じる
            srOut.Close();
            cryptStreem.Close();
            msIn.Close();

            return result;
        }

        /// <summary>
        /// 共有キー用に、バイト配列のサイズを変更する
        /// </summary>
        /// <param name="bytes">サイズを変更するバイト配列</param>
        /// <param name="newSize">バイト配列の新しい大きさ</param>
        /// <returns>サイズが変更されたバイト配列</returns>
        private static byte[] ResizeBytesArray(byte[] bytes, int newSize)
        {
            byte[] newBytes = new byte[newSize];
            if (bytes.Length <= newSize)
            {
                for (int i = 0; i < bytes.Length; i++)
                    newBytes[i] = bytes[i];
            }
            else
            {
                int pos = 0;
                for (int i = 0; i < bytes.Length; i++)
                {
                    newBytes[pos++] ^= bytes[i];
                    if (pos >= newBytes.Length)
                        pos = 0;
                }
            }
            return newBytes;
        }
    }
}
