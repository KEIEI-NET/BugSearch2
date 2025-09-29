using System;
using System.IO;
using System.Security.Cryptography;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// XML���C�^�[�N���X
    /// </summary>
    /// <remarks>
    /// </remarks>
    public class TSPSendXMLWriter
    {
        public TSPSendXMLWriter()
        {
        }

        /// <summary>
        /// �Í�������
        /// </summary>
        public static byte[] EncryptXML(MemoryStream stream)
        {
            MemoryStream ms = new MemoryStream();
            byte[] byteBuffer = new byte[stream.Length];
            // 3DES�Í���           
            stream.Position = 0;
            stream.Read(byteBuffer, 0, byteBuffer.Length);
            using (TripleDESCryptoServiceProvider des3 = new TripleDESCryptoServiceProvider())
            {
                // �L�[�y�я������x�N�^��ݒ�
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
