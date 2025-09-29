using System;
using System.IO;
using System.Security.Cryptography;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// XML���[�_�[�N���X
    /// </summary>
    public class TSPSendXMLReader
    {
        public TSPSendXMLReader()
        {
        }
        /// <summary>
        /// ����������
        /// </summary>
        public static byte[] DecryptXML( FileStream stream)
        {
            MemoryStream ms = new MemoryStream();
            // 3DES������
            byte[] byteBuffer = new byte[stream.Length];
            stream.Read(byteBuffer, 0, byteBuffer.Length);
            using (TripleDESCryptoServiceProvider des3 = new TripleDESCryptoServiceProvider())
            {
                // �L�[�y�я������x�N�^��ݒ�
                des3.Key = TspXMLDecryptTableResource.Key;
                des3.IV = TspXMLDecryptTableResource.InitVector;
                using (CryptoStream cs = new CryptoStream(ms, des3.CreateDecryptor(), CryptoStreamMode.Write))
                {
                    // �������f�[�^���t�@�C���ɏ�����
                    cs.Write(byteBuffer, 0, byteBuffer.Length);
                    cs.FlushFinalBlock();
                }
            }
            return ms.ToArray();
        }
    }
}
