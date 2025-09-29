using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace Broadleaf.Windows.Forms
{

    /// <summary>
    /// ���̃\�[�X�Ɋւ��Ă̓Z�L�����e�B�ׁ̈A�����ď����Ȃ�
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
        /// ���L�L�[�p�ɁA�o�C�g�z��̃T�C�Y��ύX����
        /// </summary>
        /// <param name="bytes">�T�C�Y��ύX����o�C�g�z��</param>
        /// <param name="newSize">�o�C�g�z��̐V�����傫��</param>
        /// <returns>�T�C�Y���ύX���ꂽ�o�C�g�z��</returns>
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
        /// ���L�L�[�p�ɁA�o�C�g�z��̃T�C�Y��ύX����
        /// </summary>
        /// <param name="bytes">�T�C�Y��ύX����o�C�g�z��</param>
        /// <param name="newSize">�o�C�g�z��̐V�����傫��</param>
        /// <returns>�T�C�Y���ύX���ꂽ�o�C�g�z��</returns>
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
            //���L�L�[�Ə������x�N�^������
            //�p�X���[�h���o�C�g�z��ɂ���
            byte[] bytesKey = System.Text.Encoding.UTF8.GetBytes(PassKey);

            //���L�L�[�Ə������x�N�^��ݒ�
            aes.Key = ResizeBytesArray(bytesKey, aes.Key.Length);
            aes.IV = ResizeBytesArray(bytesKey, aes.IV.Length);

        }
        
        /// <summary>
        /// ��������Í���
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
        /// ������𕜍���
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
        /// ���L�L�[�p�ɁA�o�C�g�z��̃T�C�Y��ύX����
        /// </summary>
        /// <param name="bytes">�T�C�Y��ύX����o�C�g�z��</param>
        /// <param name="newSize">�o�C�g�z��̐V�����傫��</param>
        /// <returns>�T�C�Y���ύX���ꂽ�o�C�g�z��</returns>
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
            //��������o�C�g�^�z��ɂ���
            byte[] bytesIn = System.Text.Encoding.UTF8.GetBytes(str);

            //DESCryptoServiceProvider�I�u�W�F�N�g�̍쐬
            System.Security.Cryptography.DESCryptoServiceProvider des = new System.Security.Cryptography.DESCryptoServiceProvider();

            //���L�L�[�Ə������x�N�^������
            //�p�X���[�h���o�C�g�z��ɂ���
            byte[] bytesKey = System.Text.Encoding.UTF8.GetBytes(key);
            //���L�L�[�Ə������x�N�^��ݒ�
            des.Key = ResizeBytesArray(bytesKey, des.Key.Length);
            des.IV = ResizeBytesArray(bytesKey, des.IV.Length);

            //�Í������ꂽ�f�[�^�������o�����߂�MemoryStream
            System.IO.MemoryStream msOut = new System.IO.MemoryStream();
            //DES�Í����I�u�W�F�N�g�̍쐬
            System.Security.Cryptography.ICryptoTransform desdecrypt =
                des.CreateEncryptor();
            //�������ނ��߂�CryptoStream�̍쐬
            System.Security.Cryptography.CryptoStream cryptStreem =
                new System.Security.Cryptography.CryptoStream(msOut,
                desdecrypt,
                System.Security.Cryptography.CryptoStreamMode.Write);
            //��������
            cryptStreem.Write(bytesIn, 0, bytesIn.Length);
            cryptStreem.FlushFinalBlock();
            //�Í������ꂽ�f�[�^���擾
            byte[] bytesOut = msOut.ToArray();

            //����
            cryptStreem.Close();
            msOut.Close();

            if (ReturnType == 0)
            {
                //Base64�ŕ�����ɕύX���Č��ʂ�Ԃ�
                return System.Convert.ToBase64String(bytesOut);
            }
            else
            {
                //16�i�ŕ�����ɕύX���Č��ʂ�Ԃ�
                return BitConverter.ToString(bytesOut).ToLower().Replace("-", "");
            }
        }

        /// <summary>
        /// �Í������ꂽ������𕜍�������
        /// </summary>
        /// <param name="str">�Í������ꂽ������</param>
        /// <param name="key">�p�X���[�h</param>
        /// <returns>���������ꂽ������</returns>
        public static string DecryptString(string str, string key)
        {
            //DESCryptoServiceProvider�I�u�W�F�N�g�̍쐬
            System.Security.Cryptography.DESCryptoServiceProvider des = new System.Security.Cryptography.DESCryptoServiceProvider();

            //���L�L�[�Ə������x�N�^������
            //�p�X���[�h���o�C�g�z��ɂ���
            byte[] bytesKey = System.Text.Encoding.UTF8.GetBytes(key);
            //���L�L�[�Ə������x�N�^��ݒ�
            des.Key = ResizeBytesArray(bytesKey, des.Key.Length);
            des.IV = ResizeBytesArray(bytesKey, des.IV.Length);

            //Base64�ŕ�������o�C�g�z��ɖ߂�
            byte[] bytesIn = System.Convert.FromBase64String(str);
            //�Í������ꂽ�f�[�^��ǂݍ��ނ��߂�MemoryStream
            System.IO.MemoryStream msIn =
                new System.IO.MemoryStream(bytesIn);
            //DES�������I�u�W�F�N�g�̍쐬
            System.Security.Cryptography.ICryptoTransform desdecrypt =
                des.CreateDecryptor();
            //�ǂݍ��ނ��߂�CryptoStream�̍쐬
            System.Security.Cryptography.CryptoStream cryptStreem =
                new System.Security.Cryptography.CryptoStream(msIn,
                desdecrypt,
                System.Security.Cryptography.CryptoStreamMode.Read);

            //���������ꂽ�f�[�^���擾���邽�߂�StreamReader
            System.IO.StreamReader srOut =
                new System.IO.StreamReader(cryptStreem,
                System.Text.Encoding.UTF8);
            //���������ꂽ�f�[�^���擾����
            string result = srOut.ReadToEnd();

            //����
            srOut.Close();
            cryptStreem.Close();
            msIn.Close();

            return result;
        }

        /// <summary>
        /// ���L�L�[�p�ɁA�o�C�g�z��̃T�C�Y��ύX����
        /// </summary>
        /// <param name="bytes">�T�C�Y��ύX����o�C�g�z��</param>
        /// <param name="newSize">�o�C�g�z��̐V�����傫��</param>
        /// <returns>�T�C�Y���ύX���ꂽ�o�C�g�z��</returns>
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
