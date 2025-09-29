//****************************************************************************//
// �V�X�e��         : NS�ҋ@����
// �v���O��������   : NS�ҋ@�������[�e�B���e�B
// �v���O�����T�v   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �H�� �b�D
// �� �� ��  2010/06/22  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

using Broadleaf.Library.Text;
using Broadleaf.Windows.Forms;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// ���O���[�e�B���e�B
    /// </summary>
    public static class LogUtil
    {
        /// <summary>�����̃t�H�[�}�b�g</summary>
        private const string DATE_TIME_FORMAT = "yyyy/MM/dd HH:mm:ss";

        /// <summary>
        /// ���O��1�s���擾���܂��B
        /// </summary>
        /// <param name="msg">���b�Z�[�W</param>
        /// <returns>���� + ���b�Z�[�W</returns>
        public static string GetLine(string msg)
        {
            const string FORMAT = "{0} {1}";
            return string.Format(FORMAT, DateTime.Now.ToString(DATE_TIME_FORMAT), msg);
        }

        /// <summary>
        /// ���O��1�s���擾���܂��B
        /// </summary>
        /// <param name="target">�Ώۖ�</param>
        /// <param name="msg">���b�Z�[�W</param>
        /// <returns>���� + �Ώۖ� + ���b�Z�[�W</returns>
        public static string GetLine(
            string target,
            string msg
        )
        {
            const string FORMAT = "{0} {1} {2}";
            return string.Format(FORMAT, DateTime.Now.ToString(DATE_TIME_FORMAT), target, msg);
        }

        /// <summary>
        /// ���O��1�s���擾���܂��B
        /// </summary>
        /// <param name="target">�Ώۖ�</param>
        /// <param name="seq">�A�ԁi��F���M�R�}���h�̏������̔ԍ��j</param>
        /// <param name="msg">���b�Z�[�W</param>
        /// <returns>���� + �Ώۖ� + [�A��] + ���b�Z�[�W</returns>
        public static string GetLine(
            string target,
            int seq,
            string msg
        )
        {
            const string FORMAT = "{0} {1} [{2}] {3}";
            return string.Format(FORMAT, DateTime.Now.ToString(DATE_TIME_FORMAT), target, seq, msg);
        }

        #region �������^�Í���

        /// <summary>
        /// �t�@�C���𕜍������܂��B
        /// </summary>
        /// <param name="filePathName">�t�@�C���p�X</param>
        public static void DecodeFile(string filePathName)
        {
            byte[] decodes = null;

            using (FileStream inputFile = new FileStream(filePathName, FileMode.Open))
            {
                decodes = TSPSendXMLReader.DecryptXML(inputFile);
            }

            using (FileStream outputFile = new FileStream(filePathName, FileMode.Create))
            {
                outputFile.Write(decodes, 0, decodes.Length);
            }

            #region �{�c

            //string text = string.Empty;
            //if (decodes != null && decodes.Length > 0)
            //{
            //    text = TStrConv.SJisToUnicode(decodes).Trim();
            //}

            //if (string.IsNullOrEmpty(text)) return;

            //using (StreamWriter writer = new StreamWriter(filePathName))
            //{
            //    writer.Write(text);
            //}

            ////using (FileStream decodedFile = new FileStream(filePathName, FileMode.Create))
            ////{
            ////    StreamWriter writer = new StreamWriter(decodedFile, Encoding.GetEncoding("Shift-JIS"));
            ////    {
            ////        writer.Write(text);
            ////    }
            ////}

            #endregion // �{�c
        }

        /// <summary>
        /// �t�@�C�����Í������܂��B
        /// </summary>
        /// <param name="filePathName">�t�@�C���p�X</param>
        public static void EncodeFile(string filePathName)
        {
            MemoryStream context = null;

            using (FileStream inputFile = new FileStream(filePathName, FileMode.Open))
            {
                byte[] decodes = new byte[inputFile.Length];
                inputFile.Read(decodes, 0, (int)inputFile.Length);

                #region �{�c

                //StreamReader reader = new StreamReader(inputFile, Encoding.GetEncoding("Shift-JIS"));
                //string text = reader.ReadToEnd();

                //byte[] decodes = TStrConv.UnicodeToSJis(text);

                #endregion // �{�c

                context = new MemoryStream(decodes);
            }

            using (FileStream outputFile = new FileStream(filePathName, FileMode.Create))
            {
                byte[] encodes = TSPSendXMLWriter.EncryptXML(context);
                outputFile.Write(encodes, 0, encodes.Length);
            }
        }

        #endregion // �������^�Í���
    }
}
