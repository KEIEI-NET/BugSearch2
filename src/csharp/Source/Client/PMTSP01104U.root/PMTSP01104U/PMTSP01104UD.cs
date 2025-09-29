using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.IO;
using Broadleaf.Application.Controller;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// XML���[�_�[�N���X
    /// </summary>
    internal class TSPSendXMLReader
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

    /// <summary>
    /// XML���C�^�[�N���X
    /// </summary>
    /// <remarks>
    /// </remarks>
    internal class TSPSendXMLWriter
    {
         public TSPSendXMLWriter()
        {
        }

        /// <summary>
        /// �Í�������
        /// </summary>
        public static byte[] EncryptXML( MemoryStream stream)
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
