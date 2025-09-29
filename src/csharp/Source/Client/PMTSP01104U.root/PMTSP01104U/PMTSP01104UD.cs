using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.IO;
using Broadleaf.Application.Controller;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// XMLリーダークラス
    /// </summary>
    internal class TSPSendXMLReader
    {
        public TSPSendXMLReader()
        {
        }
        /// <summary>
        /// 復号化処理
        /// </summary>
        public static byte[] DecryptXML( FileStream stream)
        {
            MemoryStream ms = new MemoryStream();
            // 3DES復号化
            byte[] byteBuffer = new byte[stream.Length];
            stream.Read(byteBuffer, 0, byteBuffer.Length);
            using (TripleDESCryptoServiceProvider des3 = new TripleDESCryptoServiceProvider())
            {
                // キー及び初期化ベクタを設定
                des3.Key = TspXMLDecryptTableResource.Key;
                des3.IV = TspXMLDecryptTableResource.InitVector;
                using (CryptoStream cs = new CryptoStream(ms, des3.CreateDecryptor(), CryptoStreamMode.Write))
                {
                    // 復号化データをファイルに書込み
                    cs.Write(byteBuffer, 0, byteBuffer.Length);
                    cs.FlushFinalBlock();
                }
            }
            return ms.ToArray();
        }
    }

    /// <summary>
    /// XMLライタークラス
    /// </summary>
    /// <remarks>
    /// </remarks>
    internal class TSPSendXMLWriter
    {
         public TSPSendXMLWriter()
        {
        }

        /// <summary>
        /// 暗号化処理
        /// </summary>
        public static byte[] EncryptXML( MemoryStream stream)
        {
            MemoryStream ms = new MemoryStream();
            byte[] byteBuffer = new byte[stream.Length];
            // 3DES暗号化           
            stream.Position = 0;
            stream.Read(byteBuffer, 0, byteBuffer.Length);
            using (TripleDESCryptoServiceProvider des3 = new TripleDESCryptoServiceProvider())
            {
                // キー及び初期化ベクタを設定
                des3.Key = TspXMLDecryptTableResource.Key;
                des3.IV = TspXMLDecryptTableResource.InitVector;
                using (CryptoStream cs = new CryptoStream(ms, des3.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(byteBuffer, 0, byteBuffer.Length);
                    cs.FlushFinalBlock();

                }
            }
            return ms.ToArray();
        }
    }
}
