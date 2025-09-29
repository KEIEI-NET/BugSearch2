using System;
using System.IO;
using System.Security.Cryptography;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// XMLリーダークラス
    /// </summary>
    public class TSPSendXMLReader
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
}
